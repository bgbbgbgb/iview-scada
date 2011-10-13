using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Aimirim.iView
{

	public partial class SecurityUserControl : UserControl
	{
		#region FIELDS
		private DataSet _dsSecurity;
		private BindingSource _bsUser;
		private BindingSource _bsGroup;
		private BindingSource _bsRule;
		#endregion

		#region CONSTRUCTORS
		public SecurityUserControl()
		{
			InitializeComponent();
			Initialize();
			CreateDataStructure();
		}
		#endregion

		#region METHODS
		protected void OnDataChanged(EventArgs e)
		{
			if (_dataChanged != null)
			{
				_dataChanged(this, e);
			}
		}

		private void Initialize()
		{
			// Instancia o database e adiciona as tabelas
			_dsSecurity = new DataSet("Security");

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
		}
		private void CreateDataStructure()
		{
			// Cria os objetos BindingSource
			_bsUser = new BindingSource();
			_bsUser.PositionChanged += new EventHandler(_bsUser_PositionChanged);
			// --------
			_bsGroup = new BindingSource();
			_bsGroup.PositionChanged += new EventHandler(_bsGroup_PositionChanged);
			// --------
			_bsRule = new BindingSource();

			// Liga os objetos BS ao DataGrid
			dgvUser.DataSource = _bsUser;
			dgvGroup.DataSource = _bsGroup;
			dgvRule.DataSource = _bsRule;

			// Atribui a fonte de dados ao BS
			_bsUser.DataSource = _dsSecurity;
			_bsUser.DataMember = "User";
			_bsUser_PositionChanged(null, null);
		}

		private void _bsUser_PositionChanged(object sender, EventArgs e)
		{
			//
			// Reserva o usuário atual e testa se ele é diferente de nulo
			//
			DataRowView currentUser = _bsUser.Current as DataRowView;
			if (currentUser == null)
			{
				return;
			}

			//
			// Construção da DataTable que receberá o Join entre UsrGrp e Group
			//
			DataColumn dcUserName = new DataColumn("UserName", typeof(string));
			DataColumn dcGroupName = new DataColumn("Name", typeof(string));
			DataColumn dcGroupDescription = new DataColumn("Description", typeof(string));

			//
			// Em seguida cria o objeto que representa
			// a tabela e adiciona as colunas que foram criadas.
			//
			DataTable dtGroup = new DataTable("Group");
			dtGroup.Columns.Add(dcUserName);
			dtGroup.Columns.Add(dcGroupName);
			dtGroup.Columns.Add(dcGroupDescription);

			//
			// Preenche a tabela com o resultado do Join
			//
			var usrgrps = _dsSecurity.Tables["UsrGrp"].AsEnumerable();
			var grps = _dsSecurity.Tables["Group"].AsEnumerable();

			var query =
				from grp in grps
				join usrgrp in usrgrps
				on grp["Name"]
				equals usrgrp["GroupName"] into joinedGroup
				from jndGrp in joinedGroup
				where (string)jndGrp["UserName"] == (string)currentUser["Name"]
				select new
			{
				UserName = jndGrp["UserName"],
				GroupName = grp["Name"],
				Description = grp["Description"]
			};

			foreach (var v in query)
			{
				DataRow drNew = dtGroup.NewRow();
				drNew["UserName"] = v.UserName.ToString();
				drNew["Name"] = v.GroupName.ToString();
				drNew["Description"] = v.Description.ToString();

				dtGroup.Rows.Add(drNew);
				dtGroup.AcceptChanges();
			}

			_bsGroup.DataSource = dtGroup;
			_bsGroup.ResetBindings(false);

			_bsGroup_PositionChanged(null,null);
		}
		private void _bsGroup_PositionChanged(object sender, EventArgs e)
		{
			//
			// Construção da DataTable que receberá o Join entre GrpRl e Rule
			//
			DataColumn dcGroupName = new DataColumn("GroupName", typeof(string));
			DataColumn dcRuleName = new DataColumn("Name", typeof(string));
			DataColumn dcRuleDescription = new DataColumn("Description", typeof(string));

			//
			// Em seguida cria o objeto que representa
			// a tabela e adiciona as colunas que foram criadas.
			//
			DataTable dtRule = new DataTable("Rule");
			dtRule.Columns.Add(dcGroupName);
			dtRule.Columns.Add(dcRuleName);
			dtRule.Columns.Add(dcRuleDescription);

			_bsRule.DataSource = dtRule;

			//
			// Reserva o grupo atual e testa se ele é diferente de nulo
			//
			DataRowView currentGroup = _bsGroup.Current as DataRowView;
			if (currentGroup == null)
			{
				return;
			}

			//
			// Preenche a tabela com o resultado do Join
			//
			var rls = _dsSecurity.Tables["Rule"].AsEnumerable();
			var grprls = _dsSecurity.Tables["GrpRl"].AsEnumerable();

			//      var query =
			//        from rl in rls
			//        join grprl in grprls
			//        on rl["Name"] equals grprl["RuleName"] into joinedRule
			//        from jndRl in joinedRule
			//        where (string)jndRl["GroupName"] == (string)currentGroup["Name"]
			//        select new
			//        {
			//          GroupName = jndRl["GroupName"],
			//          RuleName = rl["Name"],
			//          Description = rl["Description"]
			//        };

			var query =
				from rl in rls
				join grprl in grprls
				on rl["Name"] equals grprl["RuleName"]
				where (string)grprl["GroupName"] == (string)currentGroup["Name"]
				select new
			{
				GroupName = grprl["GroupName"],
				RuleName = rl["Name"],
				Description = rl["Description"]
			};

			foreach (var v in query)
			{
				DataRow drNew = dtRule.NewRow();
				drNew["GroupName"] = v.GroupName.ToString();
				drNew["Name"] = v.RuleName.ToString();
				drNew["Description"] = v.Description.ToString();

				dtRule.Rows.Add(drNew);
				dtRule.AcceptChanges();
			}

			_bsRule.ResetBindings(false);
		}
		private void ListChanged(object sender, ListChangedEventArgs e)
		{
			OnDataChanged(EventArgs.Empty);
		}

		private void TsbUserNewClick(object sender, EventArgs e)
		{
			using (UserForm userForm = new UserForm())
			{
				if (userForm.ShowDialog() == DialogResult.OK)
				{
					DataRowView newUser = _bsUser.AddNew() as DataRowView;

					if (userForm.tbPass.Text != string.Empty && userForm.tbPass.Text == userForm.tbConfirmPass.Text)
					{
						newUser["Name"] = userForm.tbName.Text;
						newUser["Pass"] = userForm.tbPass.Text;

						_bsUser.EndEdit();
						_bsUser.ResetCurrentItem();

						_bsUser.Position = 0;
						int indx = _bsUser.IndexOf(newUser);
						_bsUser.Position = indx;
					}
					else
					{
						MessageBox.Show("Senha inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						_bsUser.CancelEdit();
					}
				}
			}
		}
		private void TsbUserEditClick(object sender, EventArgs e)
		{
			using (UserForm userForm = new UserForm())
			{
				DataRowView currentUser = _bsUser.Current as DataRowView;
				userForm.tbName.Text = currentUser["Name"].ToString();
				userForm.tbPass.Text = currentUser["Pass"].ToString();

				if (userForm.ShowDialog() == DialogResult.OK)
				{
					if (userForm.tbPass.Text == userForm.tbConfirmPass.Text)
					{
						currentUser["Pass"] = userForm.tbPass.Text;
					}
					currentUser["Name"] = userForm.tbName.Text;

					_bsUser.EndEdit();
					_bsUser.ResetCurrentItem();
				}
			}
		}
		private void TsbUserDeleteClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				_bsUser.RemoveCurrent();
				_bsUser.EndEdit();
			}
		}

		private void TsbGroupNewClick(object sender, EventArgs e)
		{
			using (GroupForm groupForm = new GroupForm())
			{
				if (groupForm.ShowDialog() == DialogResult.OK)
				{
					DataRowView currentUser = _bsUser.Current as DataRowView;
					DataRowView newGroup = _bsGroup.AddNew() as DataRowView;

					newGroup["UserName"] = currentUser["Name"];
					newGroup["Name"] = groupForm.tbName.Text;
					newGroup["Description"] = groupForm.tbDescription.Text;

					_bsGroup.EndEdit();
					_bsGroup.ResetCurrentItem();

					DataTable dtGrp = _dsSecurity.Tables["Group"];
					DataRow newGrp = dtGrp.NewRow();

					newGrp["Name"] = newGroup["Name"];
					newGrp["Description"] = newGroup["Description"];

					dtGrp.Rows.Add(newGrp);

					DataTable dtUsrGrp = _dsSecurity.Tables["UsrGrp"];
					DataRow newUsrGrp = dtUsrGrp.NewRow();

					newUsrGrp["GroupName"] = newGroup["Name"];
					newUsrGrp["UserName"] = newGroup["UserName"];

					dtUsrGrp.Rows.Add(newUsrGrp);
				}
			}
		}
		private void TsbGroupEditClick(object sender, EventArgs e)
		{
			using (GroupForm groupForm = new GroupForm())
			{
				DataRowView currentGroup = _bsGroup.Current as DataRowView;

				groupForm.tbName.Text = currentGroup["Name"].ToString();
				groupForm.tbDescription.Text = currentGroup["Description"].ToString();

				if (groupForm.ShowDialog() == DialogResult.OK)
				{
					DataTable dtGrp = _dsSecurity.Tables["Group"];
					DataRow currentGrp = dtGrp.Rows.Find(currentGroup["Name"]);

					currentGroup["Name"] = groupForm.tbName.Text;
					currentGroup["Description"] = groupForm.tbDescription.Text;

					_bsGroup.EndEdit();
					_bsGroup.ResetCurrentItem();

					currentGrp["Name"] = currentGroup["Name"];
					currentGrp["Description"] = currentGroup["Description"];
				}
			}
		}
		private void TsbGroupDeleteClick(object sender, EventArgs e)
		{
			using (DeleteControlForm deleteControlForm = new DeleteControlForm())
			{
				deleteControlForm.Message = "Deseja apagar o grupo selecionado?";
				if (deleteControlForm.ShowDialog() == DialogResult.OK)
				{
					DataRowView currentGroup = _bsGroup.Current as DataRowView;

					_bsGroup.RemoveCurrent();
					_bsGroup.EndEdit();

					if (deleteControlForm.checkBox1.Checked)
					{
						DataRow currentGrp = _dsSecurity.Tables["Group"].Rows.Find(currentGroup["Name"]);
						currentGrp.Delete();
						_dsSecurity.Tables["Group"].AcceptChanges();
					}
					else
					{
						DataRow currentUsrGrp = _dsSecurity.Tables["UsrGrp"].Rows.Find(new object[] {currentGroup["UserName"], currentGroup["Name"]});
						currentUsrGrp.Delete();
						_dsSecurity.Tables["UsrGrp"].AcceptChanges();
					}
				}
			}
		}

		private void TsbRuleNewClick(object sender, EventArgs e)
		{
			using (RuleForm ruleForm = new RuleForm())
			{
				if (ruleForm.ShowDialog() == DialogResult.OK)
				{
					DataRowView currentGroup = _bsGroup.Current as DataRowView;
					DataRowView newRule = _bsRule.AddNew() as DataRowView;

					newRule["GroupName"] = currentGroup["Name"];
					newRule["Name"] = ruleForm.tbName.Text;
					newRule["Description"] = ruleForm.tbDescription.Text;

					_bsRule.EndEdit();
					_bsRule.ResetCurrentItem();

					DataTable dtRl = _dsSecurity.Tables["Rule"];
					DataRow newRl = dtRl.NewRow();

					newRl["Name"] = newRule["Name"];
					newRl["Description"] = newRule["Description"];

					dtRl.Rows.Add(newRl);

					DataTable dtGrpRl = _dsSecurity.Tables["GrpRl"];
					DataRow newGrpRl = dtGrpRl.NewRow();

					newGrpRl["RuleName"] = newRule["Name"];
					newGrpRl["GroupName"] = newRule["GroupName"];

					dtGrpRl.Rows.Add(newGrpRl);
				}
			}
		}
		private void TsbRuleEditClick(object sender, EventArgs e)
		{
			using (RuleForm ruleForm = new RuleForm())
			{
				DataRowView currentRule = _bsRule.Current as DataRowView;
				ruleForm.tbName.Text = currentRule["Name"].ToString();
				ruleForm.tbDescription.Text = currentRule["Description"].ToString();

				if (ruleForm.ShowDialog() == DialogResult.OK)
				{
					currentRule["Name"] = ruleForm.tbName.Text;
					currentRule["Description"] = ruleForm.tbDescription.Text;

					_bsRule.EndEdit();
					_bsRule.ResetCurrentItem();

					//
					//
					DataTable dtRl = _dsSecurity.Tables["Rule"];
					DataRow currentRl = dtRl.Rows.Find(currentRule["Name"]);

					currentRl["Name"] = currentRule["Name"];
					currentRl["Description"] = currentRule["Description"];
				}
			}
		}
		private void TsbRuleDeleteClick(object sender, EventArgs e)
		{
			using (DeleteControlForm deleteControlForm = new DeleteControlForm())
			{
				deleteControlForm.Message = "Deseja apagar a regra selecionada?";
				if (deleteControlForm.ShowDialog() == DialogResult.OK)
				{
					DataRowView currentRule = _bsRule.Current as DataRowView;

					_bsRule.RemoveCurrent();
					_bsRule.EndEdit();

					if (deleteControlForm.checkBox1.Checked)
					{
						DataRow currentRl = _dsSecurity.Tables["Rule"].Rows.Find(currentRule["Name"]);
						currentRl.Delete();
						_dsSecurity.Tables["Rule"].AcceptChanges();
					}
					else
					{
						DataRow currentGrpRl = _dsSecurity.Tables["GrpRl"].Rows.Find(new object[] {currentRule["GroupName"], currentRule["Name"]});
						currentGrpRl.Delete();
						_dsSecurity.Tables["GrpRl"].AcceptChanges();
					}
				}
			}
		}
		
		private void TsbGroupAddClick(object sender, EventArgs e)
		{
			var grps = _dsSecurity.Tables["Group"].AsEnumerable();
			var usrgrps = _dsSecurity.Tables["UsrGrp"].AsEnumerable();
			
			//
			// Reserva o usuário atual
			//
			DataRowView currentUser = _bsUser.Current as DataRowView;
			
			var userGroups =
				from grp in grps
				join usrgrp in usrgrps
				on grp["Name"]
				equals usrgrp["GroupName"] into joinedGroup
				from jndGrp in joinedGroup
				where (string)jndGrp["UserName"] == (string)currentUser["Name"]
				select new
			{
				GroupName = grp["Name"],
				Description = grp["Description"]
			};
			
			var allGroups =
				from grp in grps
				select new
			{
				GroupName = grp["Name"],
				Description = grp["Description"]
			};
			
			var working = allGroups.Except(userGroups);
			
			DataTable avlGrps = _dsSecurity.Tables["Group"].Clone();
			avlGrps.Clear();
			foreach(var record in working)
			{
				DataRow nRow = avlGrps.NewRow();
				
				nRow["Name"] = record.GroupName.ToString();
				nRow["Description"] = record.Description.ToString();
				
				avlGrps.Rows.Add(nRow);
				
				
				avlGrps.AcceptChanges();
			}


			using (GroupListForm groupListForm = new GroupListForm(avlGrps))
			{
				if (groupListForm.ShowDialog() == DialogResult.OK)
				{
					//DataRowView currentUser = _bsUser.Current as DataRowView;
					DataRowView newGroup = _bsGroup.AddNew() as DataRowView;
					
					DataRowView selectedGroup = groupListForm.listBox1.SelectedItem as DataRowView;
					
					newGroup["UserName"] = currentUser["Name"];
					newGroup["Name"] = selectedGroup["Name"];
					
					newGroup["Description"] = selectedGroup["Description"];
					
					_bsGroup.EndEdit();
					_bsGroup.ResetCurrentItem();
					
					DataTable dtUsrGrp = _dsSecurity.Tables["UsrGrp"];
					DataRow newUsrGrp = dtUsrGrp.NewRow();
					
					newUsrGrp["GroupName"] = newGroup["Name"];
					newUsrGrp["UserName"] = newGroup["UserName"];
					
					dtUsrGrp.Rows.Add(newUsrGrp);
				}
				
			}
		}
		private void TsbRuleAddClick(object sender, EventArgs e)
		{
			var rls = _dsSecurity.Tables["Rule"].AsEnumerable();
			var rlgrps = _dsSecurity.Tables["GrpRl"].AsEnumerable();
			
			//
			// Reserva o grupo atual
			//
			DataRowView currentGroup = _bsGroup.Current as DataRowView;
			
			var groupRules =
				from rl in rls
				join rlgrp in rlgrps
				on rl["Name"]
				equals rlgrp["RuleName"] into joinedGroup
				from jndGrp in joinedGroup
				where (string)jndGrp["GroupName"] == (string)currentGroup["Name"]
				select new
			{
				RuleName = rl["Name"],
				Description = rl["Description"]
			};
			
			var allRules =
				from rl in rls
				select new
			{
				RuleName = rl["Name"],
				Description = rl["Description"]
			};
			
			var working = allRules.Except(groupRules);
			
			DataTable avlRls = _dsSecurity.Tables["Rule"].Clone();
			avlRls.Clear();
			foreach(var record in working)
			{
				DataRow nRow = avlRls.NewRow();
				
				nRow["Name"] = record.RuleName.ToString();
				nRow["Description"] = record.Description.ToString();
				
				avlRls.Rows.Add(nRow);
				
				avlRls.AcceptChanges();
			}
			
			using (RuleListForm ruleListForm = new RuleListForm(avlRls))
			{
				if (ruleListForm.ShowDialog() == DialogResult.OK)
				{
					DataRowView newRule = _bsRule.AddNew() as DataRowView;
					
					DataRowView selectedRule = ruleListForm.listBox1.SelectedItem as DataRowView;
					
					newRule["GroupName"] = currentGroup["Name"];
					newRule["Name"] = selectedRule["Name"];
					
					newRule["Description"] = selectedRule["Description"];
					
					_bsRule.EndEdit();
					_bsRule.ResetCurrentItem();
					
					DataTable dtGrpRl = _dsSecurity.Tables["GrpRl"];
					DataRow newGrpRl = dtGrpRl.NewRow();
					
					newGrpRl["RuleName"] = newRule["Name"];
					newGrpRl["GroupName"] = newRule["GroupName"];
					
					dtGrpRl.Rows.Add(newGrpRl);
				}
			}
		}

		public void Load(Stream fileStream)
		{
			_dsSecurity.ReadXml(fileStream);
			_bsUser_PositionChanged(null, null);

			_bsUser.ListChanged += new ListChangedEventHandler(ListChanged);
			_bsGroup.ListChanged += new ListChangedEventHandler(ListChanged);
			_bsRule.ListChanged += new ListChangedEventHandler(ListChanged);
		}
		public void Save(Stream fileStream)
		{
			_dsSecurity.WriteXml(fileStream);
		}
		#endregion

		#region EVENTS
		protected event EventHandler _dataChanged;
		public event EventHandler DataChanged
		{
			add
			{
				_dataChanged += value;
			}
			remove
			{
				_dataChanged -= value;
			}
		}
		#endregion
	}
}
