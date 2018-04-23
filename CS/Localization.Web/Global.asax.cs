using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Web;

namespace Localization.Web {
	public class Global : System.Web.HttpApplication {
		public Global() {
			InitializeComponent();
		}
		protected void Application_Start(Object sender, EventArgs e) {
			WebApplication.OldStyleLayout = false;
		}
		protected void Session_Start(Object sender, EventArgs e) {
			WebApplication.SetInstance(Session, new LocalizationAspNetApplication());
			if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
				WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
			WebApplication.Instance.CustomizeLanguage += new EventHandler<CustomizeLanguageEventArgs>(Instance_CustomizeLanguage);
			WebApplication.Instance.CustomizeFormattingCulture += new EventHandler<CustomizeFormattingCultureEventArgs>(Instance_CustomizeFormattingCulture);

			WebApplication.Instance.Setup();
			WebApplication.Instance.Start();
		}

		void Instance_CustomizeFormattingCulture(object sender, CustomizeFormattingCultureEventArgs e) {
			e.FormattingCulture.DateTimeFormat.ShortDatePattern = "M/d/yy";
		}

		void Instance_CustomizeLanguage(object sender, CustomizeLanguageEventArgs e) {
			e.LanguageName = "de";
			//To use the default (English) language, use the following code line instead:
			//e.LanguageName = "en";
		}
		protected void Application_BeginRequest(Object sender, EventArgs e) {
			string filePath = HttpContext.Current.Request.PhysicalPath;
			if(!string.IsNullOrEmpty(filePath)
				&& (filePath.IndexOf("Images") >= 0) && !System.IO.File.Exists(filePath)) {
				HttpContext.Current.Response.End();
			}
		}
		protected void Application_EndRequest(Object sender, EventArgs e) {
		}
		protected void Application_AuthenticateRequest(Object sender, EventArgs e) {
		}
		protected void Application_Error(Object sender, EventArgs e) {
			ErrorHandling.Instance.ProcessApplicationError();
		}
		protected void Session_End(Object sender, EventArgs e) {
			WebApplication.DisposeInstance(Session);
		}
		protected void Application_End(Object sender, EventArgs e) {
		}
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for the Designer support - do not modify
		/// the content of this method via the code editor.
		/// </summary>
		private void InitializeComponent() {
		}
		#endregion
	}
}
