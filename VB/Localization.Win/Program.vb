Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports System.Threading

Namespace Localization.Win
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
			Dim myApplication As New LocalizationWindowsFormsApplication()

			AddHandler myApplication.CustomizeLanguage, AddressOf application_CustomizeLanguage
			AddHandler myApplication.CustomizeFormattingCulture, AddressOf application_CustomizeFormattingCulture

			If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
				myApplication.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
			End If
			Try
				myApplication.Setup()
				myApplication.Start()
			Catch e As Exception
				myApplication.HandleException(e)
			End Try
		End Sub

		Private Shared Sub application_CustomizeFormattingCulture(ByVal sender As Object, ByVal e As CustomizeFormattingCultureEventArgs)
			e.FormattingCulture.DateTimeFormat.ShortDatePattern = "M/d/yy"
		End Sub

		Private Shared Sub application_CustomizeLanguage(ByVal sender As Object, ByVal e As CustomizeLanguageEventArgs)
			e.LanguageName = "de"
			'To use the default (English) language, use the following code line instead:
			'Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
		End Sub
	End Class
End Namespace
