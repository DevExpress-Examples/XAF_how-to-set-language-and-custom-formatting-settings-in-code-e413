using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace Localization.Module.Win {
	[ToolboxItemFilter("Xaf.Platform.Win")]
	public sealed partial class LocalizationWindowsFormsModule : ModuleBase {
		public LocalizationWindowsFormsModule() {
			InitializeComponent();
		}
	}
}
