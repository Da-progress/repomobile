using System.Globalization;
using System.Reflection;
using System.Resources;
using Microsoft.Maui.Devices;

namespace LoDo.MAUI.Helpers
{
	public class I18N
	{
		public const string GERMAN_LANG_CODE = "de-CH";
		public const string ENGLISH_LANG_CODE = "en-GB";

		public static string Locale()
		{
			return GERMAN_LANG_CODE;
		}

		public static string Localize(string key)
		{
			var netLanguage = Locale();

			// Platform-specific
			var resource = "";
			if (DeviceInfo.Platform == DevicePlatform.iOS || DeviceInfo.Platform == DevicePlatform.Android)
			{
				resource = "LoDo.MAUI.Resources.Raw.AppResources";
			}
			else
			{
				System.Diagnostics.Debug.Fail("Unknown Plaform " + DeviceInfo.Platform);
			}

			var resourceManager = new ResourceManager(resource, typeof(I18N).GetTypeInfo().Assembly);
			var translation = resourceManager.GetString(key, new CultureInfo(netLanguage));
			return translation;
		}
	}
}