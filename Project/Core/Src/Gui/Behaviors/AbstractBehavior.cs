using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace Aimirim.iView
{
	// This is a special type converter which will be associated with the Employee class.
	// It converts an Employee object to string representation for use in a property grid.
	public abstract class AbstractBehavior : IBehavior
	{
		#region FIELDS
		protected List<ITag> _tagList = new List<ITag>();
		protected Control _parent;
		#endregion
		
		#region PROPERTIES
		[Browsable(false)]
		public XmlDocument TagGroup
		{
			get
			{
				if (_parent != null)
				{
					IFrmTagGroup frmTgg = _parent.FindForm() as IFrmTagGroup;
					if (frmTgg != null && frmTgg.TagGroup != null)
					{
						return frmTgg.TagGroup;
					}
				}
				
				return null;
			}
		}
		#endregion // properties
		
		#region METHODS
		public abstract void Execute();
		private string[] split (char[] characters)
		{
			ArrayList itens = new ArrayList();
			string _expression = "";
			for (int i = characters.Length - 1; i >= 0 ; i--)
			{
				switch (characters[i])
				{
					case '>':
					case '<':
					case '!':
					case '=':
					case '|':
					case '&':
					case ')':
					case '(':
					case '+':
					case '-':
					case '*':
					case '/':
						if (_expression.ToLower() == "false")
						{
							itens.Insert(0,"0");
							itens.Insert(0,"=");
							itens.Insert(0,"1");
						}
						else if (_expression.ToLower() == "true")
						{
							itens.Insert(0,"1");
							itens.Insert(0,"=");
							itens.Insert(0,"1");
						}
						else if (_expression.Length > 0)
						{
							itens.Insert(0,_expression);
						}
						_expression = "";
						if ( i > 0 && (characters[i-1] == '>' || characters[i-1] == '<' || characters[i-1] == '!'))
						{
							itens.Insert(0,characters[i-1].ToString() + characters[i].ToString());
							i--;
						}
						else
						{
							itens.Insert(0,characters[i].ToString());
						}
						break;
					default:
						_expression = characters[i].ToString() + _expression;
						break;
				}
			}
			if (_expression.Length > 0)
			{
				if (_expression.ToLower() == "false")
				{
					itens.Insert(0,"0");
					itens.Insert(0,"=");
					itens.Insert(0,"1");
				}
				else if (_expression.ToLower() == "true")
				{
					itens.Insert(0,"1");
					itens.Insert(0,"=");
					itens.Insert(0,"1");
				}
				else
				{
					itens.Insert(0,_expression);
				}
			}
			
			string[] s = new string[itens.Count];
			itens.CopyTo(s);
			return s;
		}
		private object solveResult(string Expression)
		{
			if (Expression.StartsWith("@"))
			{
				return TagManager.Instance.ResolveSymbol(Expression, TagGroup);
			}
			
			object ret = false;
			
			string _expression = Expression;
			//Verifica se é matemática
			Parser p = new Parser();
			if (p.Evaluate(_expression))
			{
				ret = p.Result;
			}
			else
			{
				#region Tratamento de Parenteses
				while (_expression.Contains("("))
				{
					_expression = _expression.Replace(_expression.Substring(_expression.LastIndexOf('('), (_expression.IndexOf(')', _expression.LastIndexOf('(') + 1) + 1) - _expression.LastIndexOf('(')), solveResult(_expression.Substring(_expression.LastIndexOf('(') + 1, (_expression.IndexOf(')', _expression.LastIndexOf('(') + 1) - 1) - _expression.LastIndexOf('('))).ToString());
				}
				#endregion
				
				// Atualizando o array de string
				string[] expressionSplited = split(_expression.ToCharArray());
				// Procura pela tag do primeiro termo da expressão
				bool parcialRet = false;
				for (int i = 0; i <= System.Math.Floor((Convert.ToDouble(expressionSplited.Length) / Convert.ToDouble(4))); i++)
				{
					switch (expressionSplited[((i * 4) + 1)])
					{
						case "!=":
							parcialRet = Convert.ToDouble(expressionSplited[i*4]) != Convert.ToDouble(expressionSplited[((i * 4) + 2)]);
							break;
						case "=":
							parcialRet = Convert.ToDouble(expressionSplited[i*4]) == Convert.ToDouble(expressionSplited[((i * 4) + 2)]);
							break;
						case "<=":
							parcialRet = Convert.ToDouble(expressionSplited[i*4]) <= Convert.ToDouble(expressionSplited[((i * 4) + 2)]);
							break;
						case ">=":
							parcialRet = Convert.ToDouble(expressionSplited[i*4]) >= Convert.ToDouble(expressionSplited[((i * 4) + 2)]);
							break;
						case "<":
							parcialRet = Convert.ToDouble(expressionSplited[i*4]) < Convert.ToDouble(expressionSplited[((i * 4) + 2)]);
							break;
						case ">":
							parcialRet = Convert.ToDouble(expressionSplited[i*4]) > Convert.ToDouble(expressionSplited[((i * 4) + 2)]);
							break;
					}
					if (i == 0)
					{
						ret = parcialRet;
					}
					else
					{
						ret = expressionSplited[((i * 4) - 1)] == "|" ? Convert.ToBoolean(ret) || parcialRet : Convert.ToBoolean(ret) && parcialRet;
					}
				}
			}
			return ret;
		}
		public object getResult(string Expression, IFrmTagGroup tagGroup)
		{
			try
			{
				//Identificando se a expressão possui expressões lógicas
				string _expression = "";
				
				string[] expressionSplited = split(Expression.Trim()
				                                   .Replace(" and ","&")
				                                   .Replace(" And ","&")
				                                   .Replace(" aNd ","&")
				                                   .Replace(" anD ","&")
				                                   .Replace(" ANd ","&")
				                                   .Replace(" AnD ","&")
				                                   .Replace(" aND ","&")
				                                   .Replace(" AND ","&")
				                                   .Replace("&&","&")
				                                   .Replace(" or ","|")
				                                   .Replace(" Or ","|")
				                                   .Replace(" oR ","|")
				                                   .Replace(" OR ","|")
				                                   .Replace("||","|")
				                                   .Replace("==","=")
				                                   .Replace("<>","!=")
				                                   .Replace("!=","!")
				                                   .Replace(" ","")
				                                   .ToCharArray());
				
				foreach (string s in expressionSplited)
				{
					ITag tag;
					if (tagGroup != null && s.StartsWith("@"))
					{
						tag = TagManager.Instance.GetTag(s, tagGroup.TagGroup);
					}
					else
					{
						tag = TagManager.Instance.GetTag(s);
					}
					
					//Caso a tag não seja encontrada
					if (tag != null)
					{
						if (!_tagList.Contains(tag))
						{
							_tagList.Add(tag);
							tag.ValueChanged += new EventHandler(tag_ValueChanged);
						}
						_expression = _expression + tag.Value;
					}
					else
					{
						_expression = _expression + s;
					}
				}
				
				return solveResult (_expression);
			}
			catch
			{
				try
				{
					ITag tag;
					if (tagGroup != null && Expression.StartsWith("@"))
					{
						tag = TagManager.Instance.GetTag(Expression, tagGroup.TagGroup);
					}
					else
					{
						tag = TagManager.Instance.GetTag(Expression);
					}
					
					//Caso a tag não seja encontrada
					if (tag != null)
					{
						if (!_tagList.Contains(tag))
						{
							_tagList.Add(tag);
							tag.ValueChanged += new EventHandler(tag_ValueChanged);
						}
						return tag;
					}
					else
					{
						return Expression;
					}
				}
				catch
				{
					return Expression;
				}
			}
		}
		
		protected void tag_ValueChanged(object sender, EventArgs e)
		{
			Execute();
		}
		#endregion
	}
}
