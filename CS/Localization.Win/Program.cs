using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.Threading;

namespace Localization.Win {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
			LocalizationWindowsFormsApplication application = new LocalizationWindowsFormsApplication();

			application.CustomizeLanguage += new EventHandler<CustomizeLanguageEventArgs>(application_CustomizeLanguage);
			application.CustomizeFormattingCulture += new EventHandler<CustomizeFormattingCultureEventArgs>(application_CustomizeFormattingCulture);

			if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
				application.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
			try {
				application.Setup();
				application.Start();
			}
			catch(Exception e) {
				application.HandleException(e);
			}
		}

		static void application_CustomizeFormattingCulture(object sender, CustomizeFormattingCultureEventArgs e) {
			e.FormattingCulture.DateTimeFormat.ShortDatePattern = "M/d/yy";
		}

		static void application_CustomizeLanguage(object sender, CustomizeLanguageEventArgs e) {
			e.LanguageName = "de";
			//To use the default (English) language, use the following code line instead:
			//Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
		}
	}
}
