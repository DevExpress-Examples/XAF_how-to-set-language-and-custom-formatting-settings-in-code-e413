using System;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace Localization.Module.Web {
	[ToolboxItemFilter("Xaf.Platform.Web")]
	public sealed partial class LocalizationAspNetModule : ModuleBase {
		public LocalizationAspNetModule() {
			InitializeComponent();
		}
	}
}
