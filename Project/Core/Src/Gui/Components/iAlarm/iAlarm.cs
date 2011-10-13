using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace Aimirim.iView
{
	public partial class iAlarm : UserControl
	{
		private BindingSource _bs;
		private System.Windows.Forms.Timer _refreshTmr;
		
		// used to make thread safe calls, in order to update dataGridComm in MainApp
		private Thread dataThread;
		private List<IAlarm> _almList;

		public iAlarm()
		{
			InitializeComponent();
			
			if (!DesignMode)
			{
				_almList = AlarmManager.Instance.Alarms.FindAll(delegate(IAlarm alarm) { return alarm.TimeStampAck == null && Convert.ToDateTime(alarm.TimeStamp) >  DateTime.Now.Subtract(new TimeSpan(24, 0, 0));});

				_bs=new BindingSource();
				_bs.DataSource = _almList;
				
				dgvAlarms.DataSource = _bs;
				dgvAlarms.Columns["DataType"].Visible = false;
				
				_refreshTmr = new System.Windows.Forms.Timer();
				_refreshTmr.Interval = 1000;
				_refreshTmr.Tick += delegate
				{
					dataThread = new Thread(new ThreadStart(this.ThreadProcSafe));
					dataThread.Start();
					
					_bs.ResetBindings(false);
				};
				_refreshTmr.Start();
			}
		}

		
		// This method is executed on the worker thread and makes
		// a thread-safe call on the MainApp control.
		private void ThreadProcSafe()
		{
			if (dgvAlarms.InvokeRequired)
			{
				dgvAlarms.Invoke(new MethodInvoker(Update));
			}
			else
			{
				Update();
			}
		}
		private Random random = new Random();
		private Color GetRandomColor()
		{
			return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
		}

		private void Update()
		{
			_refreshTmr.Stop();
			
			// Remove os alarmes reconhecidos
			foreach (DataGridViewRow dgvr in dgvAlarms.Rows)
			{
				if (dgvr.Cells["ColumnTimeStamp"].Value != null && Convert.ToDateTime(dgvr.Cells["ColumnTimeStamp"].Value) <=  DateTime.Now.Subtract(new TimeSpan(24, 0, 0)))
				{
					_bs.RemoveAt(dgvr.Index);
				}
			}
			
			// Reserva a lista de alarmes recentes
			List<IAlarm> list  = AlarmManager.Instance.Alarms.FindAll(delegate(IAlarm alarm) { return alarm.TimeStampAck == null && Convert.ToDateTime(alarm.TimeStamp) >  DateTime.Now.Subtract(new TimeSpan(24, 0, 0));});
			
			// Decide qual lista vai utilizar
			// A preferência é para a maior lista
			if (list.Count >= _almList.Count)
			{
				foreach (IAlarm alm in list)
				{
					IAlarm currAlm = _almList.Find(delegate(IAlarm alarm){return alarm.Name == alm.Name && alarm.TimeStamp == alm.TimeStamp;});
					if (currAlm != null)
					{
						currAlm.TimeStampAck = alm.TimeStampAck;
					}
					else
					{
						_almList.Insert(0, alm);
					}
				}
			}
			else
			{
				for (int i=0; i< _almList.Count; i++)
				{
					IAlarm currAlm = list.Find(delegate(IAlarm alarm){return alarm.Name == _almList[i].Name && alarm.TimeStamp == _almList[i].TimeStamp;});
					if (currAlm != null)
					{
						_almList[i].TimeStampAck = currAlm.TimeStampAck;
					}
				}
			}
			
			foreach (DataGridViewRow dgvr in dgvAlarms.Rows)
			{
				if (dgvr.Cells["ColumnTimeStampAck"].Value == null)
				{
					dgvr.DefaultCellStyle.BackColor = Color.Red;
				}
				else
				{
					dgvr.DefaultCellStyle.BackColor = Color.LightGray;
				}
			}
			
			_refreshTmr.Start();
		}
		
		public void Reconhecer()
		{
			AbstractAlarm drv = _bs.Current as AbstractAlarm;
			IAlarm alarm = AlarmManager.Instance.Alarms.Find(delegate(IAlarm alm) { return alm.Name == drv.Name && alm.TimeStamp == drv.TimeStamp; });
			alarm.TimeStampAck = DateTime.Now.ToString();
		}
		
		public void ReconhecerTodos()
		{
			_refreshTmr.Stop();
			foreach (IAlarm alarm in AlarmManager.Instance.Alarms)
			{
				if (alarm.TimeStampAck == null)
				{
					alarm.TimeStampAck = DateTime.Now.ToString();
				}
			}
			_refreshTmr.Start();
		}
	}
}
