/*==============================================================================
 *  Muggle Tekla-Plugins - tools and plugins for Tekla Structures
 *
 *  Copyright © 2025 Huang YongXing.                 
 *
 *  This library is free software, licensed under the terms of the GNU 
 *  General Public License as published by the Free Software Foundation, 
 *  either version 3 of the License, or (at your option) any later version. 
 *  You should have received a copy of the GNU General Public License 
 *  along with this program. If not, see <http://www.gnu.org/licenses/>. 
 *==============================================================================
 *  MainWindowViewModel.cs: view model for main window of MG1001
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System.ComponentModel;
using Tekla.Structures.Dialog;
using TD = Tekla.Structures.Datatype;

namespace Muggle.TeklaPlugins.MG1001.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private string prfStr_top = string.Empty;
        [StructuresDialog("prfStr_TOP", typeof(TD.String))]
        public string TopPlateProfileString {
            get { return prfStr_top; }
            set { prfStr_top = value; OnPropertyChanged("TopPlateProfileString"); }
        }

        private bool horizontal_top = true;
        [StructuresDialog("bol_TOPHOR", typeof(TD.Integer))]
        public bool TopPlateHorizontal {
            get { return horizontal_top; }
            set { horizontal_top = value; OnPropertyChanged("TopPlateHorizontal"); }
        }

        private string prfStr_diag = string.Empty;
        [StructuresDialog("prfStr_DIAG", typeof(TD.String))]
        public string DiagonalPlateProfileString {
            get { return prfStr_diag; }
            set { prfStr_diag = value; OnPropertyChanged("DiagonalPlateProfileString"); }
        }

        private double pos_diag_1 = 80.0;
        [StructuresDialog("pos_DIAG1", typeof(TD.Double))]
        public double DiagonalPlatePosition1 {
            get { return pos_diag_1; }
            set { pos_diag_1 = value; OnPropertyChanged("DiagonalPlatePosition1"); }
        }

        private double pos_diag_2 = 80.0;
        [StructuresDialog("pos_DIAG2", typeof(TD.Double))]
        public double DiagonalPlatePosition2 {
            get { return pos_diag_2; }
            set { pos_diag_2 = value; OnPropertyChanged("DiagonalPlatePosition2"); }
        }

        private double chamfer_diag = 0.0;
        [StructuresDialog("chamfer_DIAG", typeof(TD.Double))]
        public double DiagonalPlateChamferSize {
            get { return chamfer_diag; }
            set { chamfer_diag = value; OnPropertyChanged("DiagonalPlateChamferSize"); }
        }

        private string prfStr_hor = string.Empty;
        [StructuresDialog("prfStr_HOR", typeof(TD.String))]
        public string HorizontalPlateProfileString {
            get { return prfStr_hor; }
            set { prfStr_hor = value; OnPropertyChanged("HorizontalPlateProfileString"); }
        }

        private double chamfer_hor = 0.0;
        [StructuresDialog("chamfer_HOR", typeof(TD.Double))]
        public double HorizontalPlateChamferSize {
            get { return chamfer_hor; }
            set { chamfer_hor = value; OnPropertyChanged("HorizontalPlateChamferSize"); }
        }

        private double thk_thked = 0.0;
        [StructuresDialog("thk_THKED", typeof(TD.Double))]
        public double ThickenedPlateThickness {
            get { return thk_thked; }
            set { thk_thked = value; OnPropertyChanged("ThickenedPlateThickness"); }
        }

        private double pos_thked = 0.0;
        [StructuresDialog("pos_THKED", typeof(TD.Double))]
        public double ThickenedPlatePosition {
            get { return pos_thked; }
            set { pos_thked = value; OnPropertyChanged("ThickenedPlatePosition"); }
        }

        private double len_eave = 0.0;
        [StructuresDialog("len_Eave", typeof(TD.Double))]
        public double EavePlateLength {
            get { return len_eave; }
            set { len_eave = value; OnPropertyChanged("EavePlateLength"); }
        }

        private double hgt_eave = 100.0;
        [StructuresDialog("hgt_Eave", typeof(TD.Double))]
        public double EavePlateHeight {
            get { return hgt_eave; }
            set { hgt_eave = value; OnPropertyChanged("EavePlateHeight"); }
        }

        private double thk_eave;
        [StructuresDialog("thk_Eave", typeof(TD.Double))]
        public double EavePlateThickness {
            get { return thk_eave; }
            set { thk_eave = value; OnPropertyChanged("EavePlateThickness"); }
        }

        private double diff_thk = 4.0;
        [StructuresDialog("diff_THK", typeof(TD.Double))]
        public double ThicknessDifference {
            get { return diff_thk; }
            set { diff_thk = value; OnPropertyChanged("ThicknessDifference"); }
        }

        private double slope_thk = 2.5;
        [StructuresDialog("slope_THK", typeof(TD.Double))]
        public double Slope {
            get { return slope_thk; }
            set { slope_thk = value; OnPropertyChanged("Slope"); }
        }

        private string prfStr_endplate1 = "PL28*350*1355";
        [StructuresDialog("prfStr_EndPlate1", typeof(TD.String))]
        public string Endplate1ProfileString {
            get { return prfStr_endplate1; }
            set { prfStr_endplate1 = value; OnPropertyChanged("Endplate1ProfileString"); }
        }

        private string prfStr_endplate2 = "PL28*350*1255";
        [StructuresDialog("prfStr_EndPlate2", typeof(TD.String))]
        public string EndPlate2ProfileString {
            get { return prfStr_endplate2; }
            set { prfStr_endplate2 = value; OnPropertyChanged("EndPlate2ProfileString"); }
        }

        private double pos_endplate = 136.0;
        [StructuresDialog("pos_EndPlate", typeof(TD.Double))]
        public double EndPlatePosition {
            get { return pos_endplate; }
            set { pos_endplate = value; OnPropertyChanged("EndPlatePosition"); }
        }

        private string prfStr_stif_flange = "PL10*205*135";
        [StructuresDialog("prfStr_STIF_FLNG", typeof(TD.String))]
        public string FlangeStiffenerProfileString {
            get { return prfStr_stif_flange; }
            set { prfStr_stif_flange = value; OnPropertyChanged("FlangeStiffenerProfileString"); }
        }

        private string prfStr_stif_web = "PL10*175*170";
        [StructuresDialog("prfStr_STIF_Web", typeof(TD.String))]
        public string WebStiffenerProfileString {
            get { return prfStr_stif_web; }
            set { prfStr_stif_web = value; OnPropertyChanged("WebStiffenerProfileString"); }
        }

        private double chamfer_stif_in = 0.0;
        [StructuresDialog("chamfer_STIF_in", typeof(TD.Double))]
        public double StiffenerChamferInside {
            get { return chamfer_stif_in; }
            set { chamfer_stif_in = value; OnPropertyChanged("StiffenerChamferInside"); }
        }

        private int type_stif_web = 0;
        [StructuresDialog("type_STIF_Web", typeof(TD.Integer))]
        public int WebStiffenerType {
            get { return type_stif_web; }
            set { type_stif_web = value; OnPropertyChanged("WebStiffenerType"); }
        }

        private double chamfer_stif_out = 25.0;
        [StructuresDialog("chamfer_STIF_out", typeof(TD.Double))]
        public double StiffenerChamferOutside {
            get { return chamfer_stif_out; }
            set { chamfer_stif_out = value; OnPropertyChanged("StiffenerChamferOutside"); }
        }

        private string disLst_stif_web = "190 4*150";
        [StructuresDialog("disLstStr_STIF_Web", typeof(TD.String))]
        public string WebStiffenersDistanceList {
            get { return disLst_stif_web; }
            set { disLst_stif_web = value; OnPropertyChanged("WebStiffenersDistanceList"); }
        }

        private string disLst_bolt_X = "80 6*150 120";
        [StructuresDialog("disLstStr_Bolt_X", typeof(TD.String))]
        public string BoltDistanceListX {
            get { return disLst_bolt_X; }
            set { disLst_bolt_X = value; OnPropertyChanged("BoltDistanceListX"); }
        }

        private string disLst_bolt_Y = "70";
        [StructuresDialog("disLstStr_Bolt_Y", typeof(TD.String))]
        public string BoltDistanceListY {
            get { return disLst_bolt_Y; }
            set { disLst_bolt_Y = value; OnPropertyChanged("BoltDistanceListY"); }
        }

        private string bolt_standard = "HS10.9";
        [StructuresDialog("bolt_Standard", typeof(TD.String))]
        public string BoltStandard {
            get { return bolt_standard; }
            set { bolt_standard = value; OnPropertyChanged("BoltStandard"); }
        }

        private TD.Distance bolt_size = new TD.Distance(20.0);
        [StructuresDialog("bolt_Size", typeof(TD.Distance))]
        public TD.Distance BoltSize {
            get { return bolt_size; }
            set { bolt_size = value; OnPropertyChanged("BoltSize"); }
        }

        private string material = "Q345B";
        [StructuresDialog("materialStr", typeof(TD.String))]
        public string Material {
            get { return material; }
            set { material = value; OnPropertyChanged("Material"); }
        }

        private int grou_no = -1;
        [StructuresDialog("grou_no", typeof(TD.Integer))]
        public int GroupNo {
            get { return grou_no; }
            set { grou_no = value; OnPropertyChanged("GroupNo"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
