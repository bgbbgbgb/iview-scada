using System;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Gui;

namespace Aimirim.iView
{
  public class TagListDisplayBinding : IDisplayBinding
  {
    #region FIELDS
    #endregion

    #region PROPERTIES
    #endregion

    #region METHODS
    public bool CanCreateContentForFile(string fileName)
    {
      return true;
    }
    public IViewContent CreateContentForFile(OpenedFile file)
    {
      return new TagListViewContent(file);
    }
    #endregion
  	
	public bool IsPreferredBindingForFile(string fileName)
	{
		return true;
	}
  	
	public double AutoDetectFileContent(string fileName, System.IO.Stream fileContent, string detectedMimeType)
	{
		throw new NotImplementedException();
	}
  }
}
