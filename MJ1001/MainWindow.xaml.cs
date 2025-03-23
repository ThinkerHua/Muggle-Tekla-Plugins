using System;
using Tekla.Structures.Dialog;

namespace Muggle.TeklaPlugins.MJ1001 {
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

        private void WpfSaveLoad_HelpOpenClicked(object sender, EventArgs e) {

        }

        private void AnchorRodMaterial_SelectClicked(object sender, EventArgs e) {
            catalogAnchorRodMaterial.SelectedMaterial = dataModel.AnchorRodMaterial;
            //catalogAnchorRodMaterial.SelectedMaterial = tboxAnchorRodMaterial.Text;
        }

        private void AnchorRodMaterial_SelectionDone(object sender, EventArgs e) {
            dataModel.AnchorRodMaterial = catalogAnchorRodMaterial.SelectedMaterial;
            //tboxAnchorRodMaterial.Text = catalogAnchorRodMaterial.SelectedMaterial;
        }

        private void EmbedmentMaterial_SelectClicked(object sender, EventArgs e) {
            catalogEmbedmentMaterial.SelectedMaterial = dataModel.EmbedmentMaterial;
            //catalogEmbedmentMaterial.SelectedMaterial = tboxEmbedmentMaterial.Text;
        }

        private void EmbedmentMaterial_SelectionDone(object sender, EventArgs e) {
            dataModel.EmbedmentMaterial = catalogEmbedmentMaterial.SelectedMaterial;
            //tboxEmbedmentMaterial.Text = catalogEmbedmentMaterial.SelectedMaterial;
        }

        private void CleatMaterial_SelectClicked(object sender, EventArgs e) {
            catalogCleatMaterial.SelectedMaterial = dataModel.CleatMaterial;
            //catalogCleatMaterial.SelectedMaterial = tboxCleatMaterial.Text;
        }

        private void CleatMaterial_SelectionDone(object sender, EventArgs e) {
            dataModel.CleatMaterial = catalogCleatMaterial.SelectedMaterial;
            //tboxCleatMaterial.Text = catalogCleatMaterial.SelectedMaterial;
        }
    }
}
