
namespace Aimirim.iView
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Windows.Forms;
	using System.Xml;
	using System.Diagnostics;
	using System.Reflection;
	using System.Collections;
	using System.ComponentModel;
	using System.Xml.XPath;

	public sealed class TagManager
	{
		#region FIELDS
		private static object thisLock = new object();
		private static TagManager _instance;
		
		private List<ITag> _tags = new List<ITag>();
		private WcfHost _wcfHost;
		#endregion

		#region PROPERTIES
		public static TagManager Instance
		{
			get
			{
				lock (thisLock)
				{
					if (_instance == null)
					{
						_instance = new TagManager();
					}
					return _instance;
				}
			}
			set
			{
				_instance = value;
			}
		}
		public static string FullFileName
		{
			get
			{
				return System.Configuration.ConfigurationSettings.AppSettings["TagDatabase"];
			}
		}
		public List<ITag> Tags
		{
			get
			{
				return _tags;
			}
		}
		#endregion

		#region CONSTRUCTORS
		private TagManager()
		{
			Initialize();
		}
		#endregion

		#region METHODS
		private void Initialize()
		{
			if (!ServiceManager.DesignMode)
			{
				// Carrega o arquivo do tag database e
				// inicializa o serviço
				Load(FullFileName);

				// Após o serviço ser iniciado
				// checa se a instancia da aplicação
				// foi designada como servidor. Se for
				// um servidor então instacia o host WCF.
				if (!ServiceManager.IsClient)
				{
					_wcfHost = new WcfHost();
				}
			}
		}

		public static void Unload()
		{
			_instance = null;
		}
		public void Load(string fileName)
		{
			// Limpa o conteúdo da coleção
			Tags.Clear();

			//
			// XmlDocument
			//
			XmlDocument xmlDocument = null;
			StreamReader fileStream = null;
			
			try
			{
				
				//
				// Load TagDatabase file
				//
				xmlDocument = new XmlDocument();
				fileStream = new StreamReader(fileName);
				
				xmlDocument.Load(fileStream);
				XmlElement docRoot = xmlDocument.DocumentElement;
				
				foreach (XmlNode tagNode in docRoot.ChildNodes)
				{
					ITag nTag = NewTag(tagNode.Attributes["DataType"].Value);
					nTag.ReadXml(tagNode);
					
					Tags.Add(nTag);
				}
				
				fileStream.Close();
				fileStream = null;
			}
			catch (FileNotFoundException)
			{
				Save();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				
				xmlDocument = null;
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
		}
		
		public void Save()
		{
			//
			// XmlDocument
			//
			XmlDocument xmlDocument = new XmlDocument();

			//
			// Database Node
			//
			XmlElement docElement = xmlDocument.CreateElement("TagDatabase");
			xmlDocument.AppendChild(docElement);
			
			foreach (ITag tag in TagManager.Instance.Tags)
			{
				tag.WriteXml(ref docElement);
			}

			//
			// Save project file
			//
			xmlDocument.Save(FullFileName);
			
		}
		public void Import(string fileName)
		{
			try
			{
				// Limpa o conteúdo da coleção
				Tags.Clear();

				//
				// XmlDocument
				//
				XmlDocument xmlDocument = new XmlDocument();
				
				//
				// Load TagDatabase file
				//
				xmlDocument.Load(fileName);
				XmlElement docRoot = xmlDocument.DocumentElement;
				
				foreach (XmlNode tagNode in docRoot.ChildNodes)
				{
					ITag nTag = NewTag(tagNode.Attributes["DataType"].Value);
					nTag.Name = tagNode.Attributes["Name"].Value;
					nTag.Description = tagNode.Attributes["Description"].Value;
					nTag.Address = tagNode.Attributes["Address"].Value;
					nTag.Driver = DriverManager.Instance.GetDriver("6A1B8105-BD9A-4658-870F-D35D4029C928");
					
					Tags.Add(nTag);
				}
				
				DriverManager.Instance.Refresh();

				Save();
			}
			catch (Exception)
			{
				
			}
		}
		
		public static ITag NewTag(string type)
		{
			switch (type)
			{
				case "Digital":
					TagDigital tagDigital = new TagDigital();
					return tagDigital;
				case "Analog":
					TagAnalog tagAnalog = new TagAnalog();
					return tagAnalog;
				case "Sql":
					TagSql tagSql = new TagSql();
					return tagSql;
				default:
					return null;
			}
		}

		public ITag[] NewListTag(string type)
		{
			switch (type)
			{
				case "Digital":
					using (DigitalTagListConfigurator digitalTagListConfigurator = new DigitalTagListConfigurator())
					{
						if (digitalTagListConfigurator.ShowDialog() == DialogResult.OK)
						{
							return digitalTagListConfigurator.Items;
						}
						else
						{
							return null;
						}
					}
				case "Analog":
					using (AnalogTagListConfigurator analogTagListConfigurator = new AnalogTagListConfigurator())
					{
						if (analogTagListConfigurator.ShowDialog() == DialogResult.OK)
						{
							return analogTagListConfigurator.Items;
						}
						else
						{
							return null;
						}
					}
				default:
					return null;
			}
		}
		public ITag GetTag(string name)
		{
			return Tags.Find(delegate(ITag tag) { return tag.Name == name; });
		}
		public ITag GetTag(string symbol, XmlDocument tagGroup)
		{
			ITag returnedTag = null;
			XmlElement table = tagGroup.DocumentElement;
			XmlNode row = table.SelectSingleNode(string.Format("/DocumentElement/TagGroup[Symbol = '{0}']", symbol));
			if (row != null)
			{
				foreach(XmlNode column in row.ChildNodes)
				{
					if (column.Name == "Substitution")
					{
						returnedTag = GetTag(column.InnerText);
					}
				}
			}
			return returnedTag;
		}
		public ITag GetTag(string symbol, IFrmTagGroup tagGroup)
		{
			if (tagGroup == null || !symbol.StartsWith("@"))
			{
				return GetTag(symbol);
			}
			
			ITag returnedTag = null;
			XmlElement table = tagGroup.TagGroup.DocumentElement;
			XmlNode row = table.SelectSingleNode(string.Format("/DocumentElement/TagGroup[Symbol = '{0}']", symbol));
			if (row != null)
			{
				foreach(XmlNode column in row.ChildNodes)
				{
					if (column.Name == "Substitution")
					{
						returnedTag = GetTag(column.InnerText);
					}
				}
			}
			return returnedTag;
		}

		public string ResolveSymbol(string symbol, XmlDocument tagGroup)
		{
			XmlElement table = tagGroup.DocumentElement;
			XmlNode row = table.SelectSingleNode(string.Format("/DocumentElement/TagGroup[Symbol = '{0}']", symbol));
			if (row != null)
			{
				foreach(XmlNode column in row.ChildNodes)
				{
					if (column.Name == "Substitution")
					{
						return column.InnerText;
					}
				}
			}
			
			return symbol;
		}
		#endregion
	}
}
