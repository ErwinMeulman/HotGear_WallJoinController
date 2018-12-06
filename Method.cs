using Autodesk.Revit.DB;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

public class Method
{
	private const double _inch_to_mm = 25.4;

	private const double _foot_to_mm = 304.79999999999995;

	public static string GetMACAddress()
	{
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		string text = string.Empty;
		NetworkInterface[] array = allNetworkInterfaces;
		foreach (NetworkInterface networkInterface in array)
		{
			if (text == string.Empty)
			{
				IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
				text = networkInterface.GetPhysicalAddress().ToString();
			}
		}
		return text;
	}

	public static string CalculateMD5Hash(string input, int no)
	{
		int i = 0;
		StringBuilder stringBuilder = new StringBuilder();
		for (; i < no; i++)
		{
			MD5 mD = MD5.Create();
			byte[] bytes = Encoding.ASCII.GetBytes(input);
			byte[] array = mD.ComputeHash(bytes);
			for (int j = 0; j < array.Length; j++)
			{
				stringBuilder.Append(array[j].ToString("x2"));
			}
			input = stringBuilder.ToString();
		}
		return input;
	}

	public static string CalculateSHA1Hash(string input)
	{
		using (SHA1Managed sHA1Managed = new SHA1Managed())
		{
			byte[] array = sHA1Managed.ComputeHash(Encoding.UTF8.GetBytes(input));
			StringBuilder stringBuilder = new StringBuilder(array.Length * 2);
			byte[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				byte b = array2[i];
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}

	public static string RealString(double a)
	{
		return a.ToString("0.##");
	}

	public static string PointStringMm(XYZ p)
	{
		return string.Format("{0},{1},{2}", Method.RealString(p.get_X() * 304.79999999999995), Method.RealString(p.get_Y() * 304.79999999999995), Method.RealString(p.get_Z() * 304.79999999999995));
	}
}
