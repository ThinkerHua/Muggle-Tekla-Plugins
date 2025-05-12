using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Muggle.TeklaPlugins.KJ1001.ViewModels;
using Tekla.Structures.Dialog;
using Tekla.Structures.Dialog.UIControls;

namespace Muggle.TeklaPlugins.KJ1001 {
    /// <summary>
    /// Interaction logic for MainPluginWindow.xaml
    /// </summary>
    public partial class MainWindow : PluginWindowBase {
        // define event
        public MainWindowViewModel dataModel;

        public MainWindow(MainWindowViewModel DataModel) {
            InitializeComponent();
            dataModel = DataModel;
        }

        private void WPFOkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e) {
            this.Apply();
        }

        private void WPFOkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e) {
            this.Close();
        }

        private void WPFOkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e) {
            this.Get();
        }

        private void WPFOkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e) {
            this.Modify();
        }

        private void WPFOkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e) {
            this.Apply();
            this.Close();
        }

        private void WPFOkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e) {
            this.ToggleSelection();
        }

        private void STF_MATL_SelectClicked(object sender, EventArgs e) {
            while (!(sender is WpfMaterialCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfMaterialCatalog;
            catalog.SelectedMaterial = dataModel.StiffenerMaterial;
        }

        private void STF_MATL_SelectionDone(object sender, EventArgs e) {
            while (!(sender is WpfMaterialCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfMaterialCatalog;
            dataModel.StiffenerMaterial = catalog.SelectedMaterial;
        }

        private void Cover_MATL_SelectClicked(object sender, EventArgs e) {
            while (!(sender is WpfMaterialCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfMaterialCatalog;
            catalog.SelectedMaterial = dataModel.CoverMaterial;
        }

        private void Cover_MATL_SelectionDone(object sender, EventArgs e) {
            while (!(sender is WpfMaterialCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfMaterialCatalog;
            dataModel.CoverMaterial = catalog.SelectedMaterial;
        }

        private void CNXPL_MATL_SelectClicked(object sender, EventArgs e) {
            while (!(sender is WpfMaterialCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfMaterialCatalog;
            catalog.SelectedMaterial = dataModel.ConnectionPlateMaterial;
        }

        private void CNXPL_MATL_SelectionDone(object sender, EventArgs e) {
            while (!(sender is WpfMaterialCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfMaterialCatalog;
            dataModel.ConnectionPlateMaterial = catalog.SelectedMaterial;
        }

        private void ShortBeam_PRF_SelectClicked(object sender, EventArgs e) {
            while (!(sender is WpfProfileCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfProfileCatalog;
            catalog.SelectedProfile = dataModel.ShortBeamProfile;
        }

        private void ShortBeam_PRF_SelectionDone(object sender, EventArgs e) {
            while (!(sender is WpfProfileCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfProfileCatalog;
            dataModel.ShortBeamProfile = catalog.SelectedProfile;
        }

        private void ShortBeam_MATL_SelectClicked(object sender, EventArgs e) {
            while (!(sender is WpfMaterialCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfMaterialCatalog;
            catalog.SelectedMaterial = dataModel.ShortBeamMaterial;
        }

        private void ShortBeam_MATL_SelectionDone(object sender, EventArgs e) {
            while (!(sender is WpfMaterialCatalog)) {
                sender = LogicalTreeHelper.GetParent(sender as DependencyObject);
            }
            var catalog = sender as WpfMaterialCatalog;
            dataModel.ShortBeamMaterial = catalog.SelectedMaterial;
        }
    }
}
