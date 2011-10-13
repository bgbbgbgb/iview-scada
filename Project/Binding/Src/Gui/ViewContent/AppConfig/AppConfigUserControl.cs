using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Editor;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Project;

namespace Aimirim.iView
{
	public partial class AppConfigUserControl : UserControl
	{
		#region FIELDS
		#endregion

		#region CONSTRUCTORS
		public AppConfigUserControl()
		{
			InitializeComponent();
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
		public void Load(TextReader textReader)
		{
			XmlDocument xmlDocument = xmlDocument = new XmlDocument();
			xmlDocument.Load(textReader);
			XmlElement docRoot = xmlDocument.DocumentElement;

			//System.Configuration.ConfigurationSettings.AppSettings["DataSourceCfg"];
			
			foreach (XmlNode node in docRoot.ChildNodes)
			{
				if (node.Name == "appSettings")
				{
					foreach (XmlNode subNode in node.ChildNodes)
					{
						if (subNode.Attributes["key"].Value == "TagDatabase")
						{
							textBoxTagDatabase.Text = subNode.Attributes["value"].Value;
							textBoxTagDatabase.TextChanged += delegate { OnDataChanged(EventArgs.Empty); };
						}
						else if (subNode.Attributes["key"].Value == "DriverDatabase")
						{
							textBoxDriverDatabase.Text = subNode.Attributes["value"].Value;
							textBoxDriverDatabase.TextChanged += delegate { OnDataChanged(EventArgs.Empty); };
						}
						else if (subNode.Attributes["key"].Value == "SecurityDatabase")
						{
							textBoxSecurityDatabase.Text = subNode.Attributes["value"].Value;
							textBoxSecurityDatabase.TextChanged += delegate { OnDataChanged(EventArgs.Empty); };
						}
						else if (subNode.Attributes["key"].Value == "DataSourceCfg")
						{
							textBoxDataSourceCfg.Text = subNode.Attributes["value"].Value;
							textBoxDataSourceCfg.TextChanged += delegate { OnDataChanged(EventArgs.Empty); };
						}
						else if (subNode.Attributes["key"].Value == "Client")
						{
							chkBoxClient.Checked = Convert.ToBoolean(subNode.Attributes["value"].Value);
							chkBoxClient.CheckedChanged += delegate { OnDataChanged(EventArgs.Empty); };
						}
					}
				}
			}
		}
		public void Save(TextReader textReader, ITextEditor editor)
		{
			XmlDocument xmlDocument = xmlDocument = new XmlDocument();
			xmlDocument.Load(textReader);
			XmlElement docRoot = xmlDocument.DocumentElement;

			foreach (XmlNode node in docRoot.ChildNodes)
			{
				if (node.Name == "appSettings")
				{
					foreach (XmlNode subNode in node.ChildNodes)
					{
						if (subNode.Attributes["key"].Value == "TagDatabase")
						{
							subNode.Attributes["value"].Value = textBoxTagDatabase.Text;
							textBoxTagDatabase.TextChanged -= delegate { OnDataChanged(EventArgs.Empty); };
						}
						else if (subNode.Attributes["key"].Value == "DriverDatabase")
						{
							subNode.Attributes["value"].Value = textBoxDriverDatabase.Text;
							textBoxDriverDatabase.TextChanged -= delegate { OnDataChanged(EventArgs.Empty); };
						}
						else if (subNode.Attributes["key"].Value == "SecurityDatabase")
						{
							subNode.Attributes["value"].Value = textBoxSecurityDatabase.Text;
							textBoxSecurityDatabase.TextChanged -= delegate { OnDataChanged(EventArgs.Empty); };
						}
						else if (subNode.Attributes["key"].Value == "DataSourceCfg")
						{
							subNode.Attributes["value"].Value = textBoxDataSourceCfg.Text;
							textBoxDataSourceCfg.TextChanged -= delegate { OnDataChanged(EventArgs.Empty); };
						}
						else if (subNode.Attributes["key"].Value == "Client")
						{
							subNode.Attributes["value"].Value = chkBoxClient.Checked.ToString().ToLower();
							chkBoxClient.CheckedChanged -= delegate { OnDataChanged(EventArgs.Empty); };
						}
					}
				}
			}
			
			string formattedXml = SimpleFormat(IndentedFormat(xmlDocument.OuterXml, editor));
			editor.Document.Text = formattedXml;
		}
		/// <summary>
		/// Returns a formatted xml string using a simple formatting algorithm.
		/// </summary>
		static string SimpleFormat(string xml)
		{
			return xml.Replace("><", ">\r\n<");
		}
		
		/// <summary>
		/// Returns a pretty print version of the given xml.
		/// </summary>
		/// <param name="xml">Xml string to pretty print.</param>
		/// <returns>A pretty print version of the specified xml.  If the
		/// string is not well formed xml the original string is returned.
		/// </returns>
		static string IndentedFormat(string xml, ITextEditor editor)
		{
			string indentedText = string.Empty;
			if (editor == null) return indentedText;

			try	{
				XmlTextReader reader = new XmlTextReader(new StringReader(xml));
				reader.WhitespaceHandling = WhitespaceHandling.None;
				reader.XmlResolver = null;

				StringWriter indentedXmlWriter = new StringWriter();
				XmlTextWriter writer = CreateXmlTextWriter(indentedXmlWriter, editor);
				writer.WriteNode(reader, false);
				writer.Flush();

				indentedText = indentedXmlWriter.ToString();
			} catch(Exception) {
				indentedText = xml;
			}
			return indentedText;
		}
		
		static XmlTextWriter CreateXmlTextWriter(TextWriter textWriter, ITextEditor editor)
		{
			XmlTextWriter writer = new XmlTextWriter(textWriter);
			if (editor.Options.ConvertTabsToSpaces) {
				writer.Indentation = editor.Options.IndentationSize;
				writer.IndentChar = ' ';
			} else {
				writer.Indentation = 1;
				writer.IndentChar = '\t';
			}
			writer.Formatting = Formatting.Indented;
			return writer;
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
