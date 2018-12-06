using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using HotGearAllInOne;
using HotGearAllInOne.Globol;
using System;
using System.Collections.Generic;

public class WallJoin_Miter
{
	public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
	{
		UIApplication application = commandData.get_Application();
		Document document = application.get_ActiveUIDocument().get_Document();
		Selection selection = application.get_ActiveUIDocument().get_Selection();
		ICollection<ElementId> elementIds = selection.GetElementIds();
		List<Element> list = new List<Element>();
		foreach (ElementId item in elementIds)
		{
			Element element = document.GetElement(item);
			list.Add(element);
		}
		if (list.Count > 0)
		{
			GlobolVar.G_JoinWay = "Miter";
			WF_StartEnd wF_StartEnd = new WF_StartEnd();
			wF_StartEnd.ShowDialog();
			if (GlobolVar.G_JoinStatus == -1)
			{
				return 0;
			}
			Transaction val = new Transaction(document);
			val.Start("Miter");
			FailureHandlingOptions failureHandlingOptions = val.GetFailureHandlingOptions();
			MyFailuresPreProcessor myFailuresPreProcessor = new MyFailuresPreProcessor();
			failureHandlingOptions.SetFailuresPreprocessor(myFailuresPreProcessor);
			val.SetFailureHandlingOptions(failureHandlingOptions);
			foreach (Element item2 in list)
			{
				try
				{
					if (GlobolVar.G_JoinStatus == 0)
					{
						(item2.get_Location() as LocationCurve).set_JoinType(1, 1);
						(item2.get_Location() as LocationCurve).set_JoinType(0, 1);
					}
					else if (GlobolVar.G_JoinStatus == 1)
					{
						(item2.get_Location() as LocationCurve).set_JoinType(0, 1);
					}
					else if (GlobolVar.G_JoinStatus == 2)
					{
						(item2.get_Location() as LocationCurve).set_JoinType(1, 1);
					}
				}
				catch (Exception)
				{
				}
			}
			val.Commit();
		}
		else
		{
			TaskDialog.Show("Result", "None Element Selected");
		}
		return 0;
	}
}
