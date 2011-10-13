using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Microsoft.Win32;

namespace Aimirim.iView
{
	public  class SecurityManager
	{
		#region STRUCTS
		/* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Starts Here */
		// Structure contain information about low-level keyboard input event
		[StructLayout(LayoutKind.Sequential)]
		private struct KBDLLHOOKSTRUCT
		{
			public Keys key;
			public int scanCode;
			public int flags;
			public int time;
			public IntPtr extra;
		}
		#endregion

		#region DELEGATES
		//System level functions to be used for hook and unhook keyboard input
		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
		#endregion

		#region P/INVOKE

		//[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[DllImport("user32.dll")]
		private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
		//[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[DllImport("user32.dll")]
		private static extern bool UnhookWindowsHookEx(IntPtr hook);
		//[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[DllImport("user32.dll")]
		private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
		//[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetModuleHandle(string name);
		//[DllImport("user32.dll", CharSet = CharSet.Auto)]
		[DllImport("user32.dll")]
		private static extern short GetAsyncKeyState(Keys key);
		[DllImport( "user32.dll")]
		private static extern int FindWindow( string className, string windowText );
		[DllImport( "user32.dll")]
		private static extern int ShowWindow( int hwnd, int command );

		// When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
		[DllImport("user32.dll")]
		static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();
		#endregion

		#region FIELDS
		//Declaring Global objects
		private static IntPtr ptrHook;
		private static LowLevelKeyboardProc objKeyboardProcess;

		private static object _thisLock = new object();
		private static SecurityManager _instance;
		private static bool _unsetLock = false;

		private DataSet _dsSecurity;
		private string _loggedUsrName;

		private const int SW_HIDE = 0;
		private const int SW_SHOW = 1;

		#endregion

		#region PROPERTIES
		protected static int Handle
		{
			get
			{
				return FindWindow( "Shell_TrayWnd", "" );
			}
		}

		public static SecurityManager Instance
		{
			get
			{
				lock(_thisLock)
				{
					if (_instance == null)
					{
						_instance = new SecurityManager();
					}
					return _instance;
				}
			}
			set
			{
				_instance = value;
			}
		}
		public static string FullFileNameData
		{
			get
			{
				return System.Configuration.ConfigurationSettings.AppSettings["SecurityDatabase"];
			}
		}
		public DataSet DataSource
		{
			get
			{
				return _dsSecurity;
			}
		}
		public string LoggedUser
		{
			get
			{
				return _loggedUsrName;
			}
		}

		#endregion

		#region CONSTRUCTORS
		private SecurityManager()
		{
			Initialize();
		}
		#endregion

		#region METHODS
		private void Initialize()
		{
			if (!ServiceManager.DesignMode)
			{
				try
				{
					// Instancia o database e adiciona as tabelas
					_dsSecurity = new DataSet("Security");

					//
					// Construção da tabela user começa
					// com a criação das colunas.
					//
					DataColumn dcUserName = new DataColumn("Name", typeof(string));
					dcUserName.AllowDBNull = false;
					DataColumn dcUserPass = new DataColumn("Pass", typeof(string));
					//
					// Em seguida cria o objeto que representa
					// a tabela e adiciona as colunas que foram criadas.
					//
					DataTable dtUser = new DataTable("User");
					dtUser.Columns.Add(dcUserName);
					dtUser.Columns.Add(dcUserPass);
					dtUser.PrimaryKey = new DataColumn[] {dcUserName};

					_dsSecurity.Tables.Add(dtUser);

					//
					// Construção da tabela group
					//
					DataColumn dcGroupName = new DataColumn("Name", typeof(string));
					dcGroupName.AllowDBNull = false;
					DataColumn dcGroupDescription = new DataColumn("Description", typeof(string));

					DataTable dtGroup = new DataTable("Group");
					dtGroup.Columns.Add(dcGroupName);
					dtGroup.Columns.Add(dcGroupDescription);
					dtGroup.PrimaryKey = new DataColumn[] {dcGroupName};

					_dsSecurity.Tables.Add(dtGroup);

					//
					// Construção da tabela rule
					//
					DataColumn dcRuleName = new DataColumn("Name", typeof(string));
					dcRuleName.AllowDBNull = false;
					DataColumn dcRuleDescription = new DataColumn("Description", typeof(string));

					DataTable dtRule = new DataTable("Rule");
					dtRule.Columns.Add(dcRuleName);
					dtRule.Columns.Add(dcRuleDescription);

					dtRule.PrimaryKey = new DataColumn[] {dcRuleName};

					_dsSecurity.Tables.Add(dtRule);

					//
					// Construção da tabela que relaciona
					// User com Group
					//
					DataColumn dcUsrGrpUserName = new DataColumn("UserName", typeof(string));
					DataColumn dcUsrGrpGroupName = new DataColumn("GroupName", typeof(string));

					DataTable dtUsrGrp = new DataTable("UsrGrp");
					dtUsrGrp.Columns.Add(dcUsrGrpUserName);
					dtUsrGrp.Columns.Add(dcUsrGrpGroupName);

					dtUsrGrp.PrimaryKey = new DataColumn[] {dcUsrGrpUserName,dcUsrGrpGroupName};

					_dsSecurity.Tables.Add(dtUsrGrp);

					//
					// Construção da tabela que relaciona
					// Group com Regra
					//
					DataColumn dcGrpRlGroupName = new DataColumn("GroupName", typeof(string));
					DataColumn dcGrpRlRuleName = new DataColumn("RuleName", typeof(string));

					DataTable dtGrpRl = new DataTable("GrpRl");
					dtGrpRl.Columns.Add(dcGrpRlGroupName);
					dtGrpRl.Columns.Add(dcGrpRlRuleName);

					dtGrpRl.PrimaryKey = new DataColumn[] {dcGrpRlGroupName,dcGrpRlRuleName};

					_dsSecurity.Tables.Add(dtGrpRl);

					//
					// Construção dos relacionamentos
					//
					DataRelation drlUserUsrGrp = new DataRelation("drlUserUsrGrp", dcUserName, dcUsrGrpUserName, true);
					DataRelation drlGroupUsrGrp = new DataRelation("drlGroupUsrGrp", dcGroupName, dcUsrGrpGroupName, true);

					DataRelation drlGroupGrpRl = new DataRelation("drlGroupGrpRl", dcGroupName, dcGrpRlGroupName, true);
					DataRelation drlRuleGrpRl = new DataRelation("drlRuleGrpRl", dcRuleName, dcGrpRlRuleName, true);

					_dsSecurity.Relations.Add(drlUserUsrGrp);
					_dsSecurity.Relations.Add(drlGroupUsrGrp);
					_dsSecurity.Relations.Add(drlGroupGrpRl);
					_dsSecurity.Relations.Add(drlRuleGrpRl);

					_dsSecurity.ReadXml(FullFileNameData);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Loading SecurityDatabase failure!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public bool Login(string usr, string pass)
		{
			// query data table
			//
			// ALTERNATIVA A ALGO QUE AINDA NÃO SEI:
			// var query = from p in dt.AsEnumerable() where p.Field("code") == this.txtCat.Text select new { name = p.Field("name"), age= p.Field("age")};
			//

			var results = from myRow in _dsSecurity.Tables["User"].AsEnumerable()
				where myRow.Field<string>("Name") == usr && myRow.Field<string>("Pass") == pass
				select myRow;

			// Se o nome e o password conferirem então vai existir um
			// registro como resultado da pesquisa. Então se for diferente
			// de um retorna falso e sai.
			if (results.AsDataView().Count != 1)
			{
				return false;
			}

			// Guarda o usuário logado;
			// Retorna verdadeiro e;
			// Sai.
			foreach (var v in results)
			{
				_loggedUsrName = v.Field<string>("Name");
			}
			return true;
		}
		public void Logout()
		{
			_loggedUsrName = string.Empty;
		}
		public bool SecurityCheck(string rule)
		{
			var results =
				from User in _dsSecurity.Tables["User"].AsEnumerable()
				join UsrGrp in _dsSecurity.Tables["UsrGrp"].AsEnumerable() on User.Field<string>("Name") equals UsrGrp.Field<string>("UserName")
				join Group in _dsSecurity.Tables["Group"].AsEnumerable() on UsrGrp.Field<string>("GroupName") equals Group.Field<string>("Name")
				join GrpRl in _dsSecurity.Tables["GrpRl"].AsEnumerable() on Group.Field<string>("Name") equals GrpRl.Field<string>("GroupName")
				join Rule in _dsSecurity.Tables["Rule"].AsEnumerable() on GrpRl.Field<string>("RuleName") equals Rule.Field<string>("Name")
				where User.Field<string>("Name") == _loggedUsrName && Rule.Field<string>("Name") == rule
				select Rule;

			int count = 0;

			foreach (var v in results)
			{
				count ++;
			}

			if (count == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public static void Unload()
		{
			_instance = null;
		}
		private static IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
		{
			try
			{
				if (nCode >= 0 && _unsetLock)
				{
					KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));
					// Disabling Windows keys
					if (objKeyInfo.key == Keys.RWin ||
					    objKeyInfo.key == Keys.LWin ||
					    objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) ||
					    objKeyInfo.key == Keys.Tab && (Control.ModifierKeys  & Keys.Control) == Keys.Control ||
					    objKeyInfo.key == Keys.Escape && (Control.ModifierKeys  & Keys.Control) == Keys.Control ||
					    objKeyInfo.key == Keys.F4 && HasAltModifier(objKeyInfo.flags) ||
					    objKeyInfo.key == Keys.F4 && (Control.ModifierKeys  & Keys.Control) == Keys.Control)
					{
						return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
					}
				}
				return (IntPtr)0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return (IntPtr)0;
			}
		}
		private static bool HasAltModifier(int flags)
		{
			return (flags & 0x20) == 0x20;
		}

		public static void UnsetLock()
		{
			_unsetLock = false;
		}

		public static void SetLock()
		{
			ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
			objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
			ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
			_unsetLock = true;
		}
		public static void KillCtrlAltDelete()
		{
			RegistryKey regkey;
			string keyValueInt = "1";
			string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
			try
			{
				regkey = Registry.CurrentUser.CreateSubKey(subKey);
				regkey.SetValue("DisableTaskMgr", keyValueInt);
				regkey.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		public static void EnableCTRLALTDEL()
		{
			try
			{
				string subKey = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
				RegistryKey rk = Registry.CurrentUser;
				RegistryKey sk1 = rk.OpenSubKey(subKey);
				if (sk1 != null)
					rk.DeleteSubKeyTree(subKey);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public static void ShowTaskBar()
		{
			ShowWindow( Handle, SW_SHOW );
		}
		public static void HideTaskBar()
		{
			ShowWindow( Handle, SW_HIDE );
		}
		#endregion
	}
}
