using Autodesk.Revit.UI;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HotGear
{
	public class HotGearPackage
	{
		private static string AddInPath = typeof(HotGearPackage).Assembly.Location;

		public Result OnStartup(UIControlledApplication application)
		{
			string text = "Hot Gear";
			try
			{
				application.CreateRibbonTab(text);
			}
			catch
			{
			}
			RibbonPanel val = application.CreateRibbonPanel(text, "Wall Join Controller");
			ContextualHelp contextualHelp = new ContextualHelp(2, "https://hotgearproject.gitbooks.io/hotgear-project/content/");
			SplitButtonData val2 = new SplitButtonData("HotGear", "HotGear");
			SplitButton val3 = val.AddItem(val2) as SplitButton;
			PushButton val4 = val3.AddPushButton(new PushButtonData("SquareOff", "Join SquareOff", HotGearPackage.AddInPath, "WallJoin_SquareOff"));
			val4.set_ToolTip("Wall Join Type : SquareOff");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Square_off.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Square_off_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("Butt", "Join Butt", HotGearPackage.AddInPath, "WallJoin_Butt"));
			val4.set_ToolTip("Wall Join Type : Butt");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Butt.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Butt_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("Miter", "Join Miter", HotGearPackage.AddInPath, "WallJoin_Miter"));
			val4.set_ToolTip("Wall Join Type : Miter");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Miter.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Miter_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("AllowJoin", "Join Allow", HotGearPackage.AddInPath, "WallJoin_Allow"));
			val4.set_ToolTip("Wall Join : Allow");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Allow.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.Allow_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("DisallowJoin", "Join DisAllow", HotGearPackage.AddInPath, "WallJoin_Disallow"));
			val4.set_ToolTip("Wall Join : Disallow");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.DisAllow.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.DisAllow_s.png"));
			val4.SetContextualHelp(contextualHelp);
			val4 = val3.AddPushButton(new PushButtonData("About", "About", HotGearPackage.AddInPath, "About"));
			val4.set_ToolTip("About HotGear Project");
			val4.set_LargeImage(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.gear32.png"));
			val4.set_Image(HotGearPackage.RetriveImage("HotGearAllInOne.Resources.gear16.png"));
			val4.SetContextualHelp(contextualHelp);
			return 0;
		}

		public Result OnShutdown(UIControlledApplication application)
		{
			return 0;
		}

		public static ImageSource RetriveImage(string imagePath)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imagePath);
			switch (imagePath.Substring(imagePath.Length - 3))
			{
			case "jpg":
			{
				JpegBitmapDecoder jpegBitmapDecoder = new JpegBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return jpegBitmapDecoder.Frames[0];
			}
			case "bmp":
			{
				BmpBitmapDecoder bmpBitmapDecoder = new BmpBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return bmpBitmapDecoder.Frames[0];
			}
			case "png":
			{
				PngBitmapDecoder pngBitmapDecoder = new PngBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return pngBitmapDecoder.Frames[0];
			}
			case "ico":
			{
				IconBitmapDecoder iconBitmapDecoder = new IconBitmapDecoder(manifestResourceStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
				return iconBitmapDecoder.Frames[0];
			}
			default:
				return null;
			}
		}
	}
}
