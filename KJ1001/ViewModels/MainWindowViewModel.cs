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
 *  MainWindowViewModel.cs: view model for main window of KJ1001
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System.ComponentModel;
using Tekla.Structures.Dialog;
using TD = Tekla.Structures.Datatype;

namespace Muggle.TeklaPlugins.KJ1001.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private int type;
        [StructuresDialog("type", typeof(TD.Integer))]
        public int Type {
            get { return type; }
            set { type = value < 0 || value > 2 ? 0 : value; OnPropertyChanged("Type"); }
        }

        private double innerStiffener_thickness;
        [StructuresDialog("innerSTF_THK", typeof(TD.Double))]
        public double InnerStiffenerThickness {
            get { return innerStiffener_thickness; }
            set { innerStiffener_thickness = value; OnPropertyChanged("InnerStiffenerThickness"); }
        }

        private double innerStiffener_chamferSize;
        [StructuresDialog("innerSTF_chamfer", typeof(TD.Double))]
        public double InnerStiffenerChamferSize {
            get { return innerStiffener_chamferSize; }
            set { innerStiffener_chamferSize = value; OnPropertyChanged("InnerStiffenerChamferSize"); }
        }

        private string moreInnerStiffeners_distanceList;
        [StructuresDialog("moreSTF_DISLST", typeof(TD.String))]
        public string MoreInnerStiffenersDistanceList {
            get { return moreInnerStiffeners_distanceList; }
            set { moreInnerStiffeners_distanceList = value; OnPropertyChanged("MoreInnerStiffenersDistanceList"); }
        }

        private double thickenedStiffener_thickness;
        [StructuresDialog("THKDSTF_THK", typeof(TD.Double))]
        public double ThickenedStiffenerThickness {
            get { return thickenedStiffener_thickness; }
            set { thickenedStiffener_thickness = value; OnPropertyChanged("ThickenedStiffenerThickness"); }
        }

        private double thickenedStiffener_extensionLength;
        [StructuresDialog("THKDSTF_EXTLEN", typeof(TD.Double))]
        public double ThickenedStiffenerExtensionLength {
            get { return thickenedStiffener_extensionLength; }
            set { thickenedStiffener_extensionLength = value; OnPropertyChanged("ThickenedStiffenerExtensionLength"); }
        }

        private string stiffener_material;
        [StructuresDialog("STF_MATL", typeof(TD.String))]
        public string StiffenerMaterial {
            get { return stiffener_material; }
            set { stiffener_material = value; OnPropertyChanged("StiffenerMaterial"); }
        }

        private double ratHole_radius;
        [StructuresDialog("ratHole_radius", typeof(TD.Double))]
        public double RatHoleRadius {
            get { return ratHole_radius; }
            set { ratHole_radius = value; OnPropertyChanged("RatHoleRadius"); }
        }

        private double gap;
        [StructuresDialog("gap", typeof(TD.Double))]
        public double Gap {
            get { return gap; }
            set { gap = value; OnPropertyChanged("Gap"); }
        }

        private double weld_angle;
        [StructuresDialog("weld_angle", typeof(TD.Double))]
        public double WeldAngle {
            get { return weld_angle; }
            set { weld_angle = value; OnPropertyChanged("WeldAngle"); }
        }

        private double weld_root_face;
        [StructuresDialog("root_face", typeof(TD.Double))]
        public double WeldRootFace {
            get { return weld_root_face; }
            set { weld_root_face = value; OnPropertyChanged("WeldRootFace"); }
        }

        private double weld_root_opening;
        [StructuresDialog("root_opening", typeof(TD.Double))]
        public double WeldRootOpening {
            get { return weld_root_opening; }
            set { weld_root_opening = value; OnPropertyChanged("WeldRootOpening"); }
        }

        private double cover_thickness;
        [StructuresDialog("cover_THK", typeof(TD.Double))]
        public double CoverThickness {
            get { return cover_thickness; }
            set { cover_thickness = value; OnPropertyChanged("CoverThickness"); }
        }

        private double cover_length1;
        [StructuresDialog("cover_LEN1", typeof(TD.Double))]
        public double CoverLength1 {
            get { return cover_length1; }
            set { cover_length1 = value; OnPropertyChanged("CoverLength1"); }
        }

        private double cover_length2;
        [StructuresDialog("cover_LEN2", typeof(TD.Double))]
        public double CoverLength2 {
            get { return cover_length2; }
            set { cover_length2 = value; OnPropertyChanged("CoverLength2"); }
        }

        private double topCover_width1;
        [StructuresDialog("topCover_WD1", typeof(TD.Double))]
        public double TopCoverWidth1 {
            get { return topCover_width1; }
            set { topCover_width1 = value; OnPropertyChanged("TopCoverWidth1"); }
        }

        private double topCover_width2;
        [StructuresDialog("topCover_WD2", typeof(TD.Double))]
        public double TopCoverWidth2 {
            get { return topCover_width2; }
            set { topCover_width2 = value; OnPropertyChanged("TopCoverWidth2"); }
        }

        private double bottomCover_width1;
        [StructuresDialog("BTMCover_WD1", typeof(TD.Double))]
        public double BottomCoverWidth1 {
            get { return bottomCover_width1; }
            set { bottomCover_width1 = value; OnPropertyChanged("BottomCoverWidth1"); }
        }

        private double bottomCover_width2;
        [StructuresDialog("BTMCover_WD2", typeof(TD.Double))]
        public double BottomCoverWidth2 {
            get { return bottomCover_width2; }
            set { bottomCover_width2 = value; OnPropertyChanged("BottomCoverWidth2"); }
        }

        private string cover_material;
        [StructuresDialog("cover_MATL", typeof(TD.String))]
        public string CoverMaterial {
            get { return cover_material; }
            set { cover_material = value; OnPropertyChanged("CoverMaterial"); }
        }

        private int webConnectionPlate_creationEnum;
        [StructuresDialog("webCNXPL_enum", typeof(TD.Integer))]
        public int WebConnectionPlateCreationEnum {
            get { return webConnectionPlate_creationEnum; }
            set { webConnectionPlate_creationEnum = value < 0 || value > 2 ? 0 : value; OnPropertyChanged("WebConnectionPlateCreationEnum"); }
        }

        private double webConnectionPlate_thickness;
        [StructuresDialog("webCNXPL_THK", typeof(TD.Double))]
        public double WebConnectionPlateThickness {
            get { return webConnectionPlate_thickness; }
            set { webConnectionPlate_thickness = value; OnPropertyChanged("WebConnectionPlateThickness"); }
        }

        private string connectionPlate_material;
        [StructuresDialog("CNXPL_MATL", typeof(TD.String))]
        public string ConnectionPlateMaterial {
            get { return connectionPlate_material; }
            set { connectionPlate_material = value; OnPropertyChanged("ConnectionPlateMaterial"); }
        }

        private string webBolt_standard;
        [StructuresDialog("webBolt_STD", typeof(TD.String))]
        public string WebBoltStandard {
            get { return webBolt_standard; }
            set { webBolt_standard = value; OnPropertyChanged("WebBoltStandard"); }
        }

        private TD.Distance webBolt_size;
        [StructuresDialog("webBolt_size", typeof(TD.Distance))]
        public TD.Distance WebBoltSize {
            get { return webBolt_size; }
            set { webBolt_size = value; OnPropertyChanged("WebBoltSize"); }
        }

        private string webPosition_distanList_X;
        [StructuresDialog("webPOS_X", typeof(TD.String))]
        public string WebPositionDistanceListX {
            get { return webPosition_distanList_X; }
            set { webPosition_distanList_X = value; OnPropertyChanged("WebPositionDistanceListX"); }
        }

        private string webPosition_distanceList_Y;
        [StructuresDialog("webPOS_Y", typeof(TD.String))]
        public string WebPositionDistanceListY {
            get { return webPosition_distanceList_Y; }
            set { webPosition_distanceList_Y = value; OnPropertyChanged("WebPositionDistanceListY"); }
        }

        private double shortBeam_length;
        [StructuresDialog("shortBeam_LEN", typeof(TD.Double))]
        public double ShortBeamLength {
            get { return shortBeam_length; }
            set { shortBeam_length = value; OnPropertyChanged("ShortBeamLength"); }
        }

        private string shortBeam_profile;
        [StructuresDialog("shortBeam_PRF", typeof(TD.String))]
        public string ShortBeamProfile {
            get { return shortBeam_profile; }
            set { shortBeam_profile = value; OnPropertyChanged("ShortBeamProfile"); }
        }

        private string shortBeam_material;
        [StructuresDialog("shortBeam_MATL", typeof(TD.String))]
        public string ShortBeamMaterial {
            get { return shortBeam_material; }
            set { shortBeam_material = value; OnPropertyChanged("ShortBeamMaterial"); }
        }

        private double outterFlangeConnectionPlate_thickness;
        [StructuresDialog("outFLNGCNXPL_THK", typeof(TD.Double))]
        public double OutterFlangeConnectionPlateThickness {
            get { return outterFlangeConnectionPlate_thickness; }
            set { outterFlangeConnectionPlate_thickness = value; OnPropertyChanged("OutterFlangeConnectionPlateThickness"); }
        }

        private double innerFlangeConnectionPlate_thickness;
        [StructuresDialog("innerFLNGCNXPL_THK", typeof(TD.Double))]
        public double InnerFlangeConnectionPlateThickness {
            get { return innerFlangeConnectionPlate_thickness; }
            set { innerFlangeConnectionPlate_thickness = value; OnPropertyChanged("InnerFlangeConnectionPlateThickness"); }
        }

        private string flangeBolt_standard;
        [StructuresDialog("FLNGBolt_STD", typeof(TD.String))]
        public string FlangeBoltStandard {
            get { return flangeBolt_standard; }
            set { flangeBolt_standard = value; OnPropertyChanged("FlangeBoltStandard"); }
        }

        private TD.Distance flangeBolt_size;
        [StructuresDialog("FLNGBolt_size", typeof(TD.Distance))]
        public TD.Distance FlangeBoltSize {
            get { return flangeBolt_size; }
            set { flangeBolt_size = value; OnPropertyChanged("FlangeBoltSize"); }
        }

        private string flangePosition_distanceList_X;
        [StructuresDialog("FLNGPOS_X", typeof(TD.String))]
        public string FlangePositionDistanceListX {
            get { return flangePosition_distanceList_X; }
            set { flangePosition_distanceList_X = value; OnPropertyChanged("FlangePositionDistanceListX"); }
        }

        private string flangePosition_distanceList_Y;
        [StructuresDialog("FLNGPOS_Y", typeof(TD.String))]
        public string FlangePositionDistanceListY {
            get { return flangePosition_distanceList_Y; }
            set { flangePosition_distanceList_Y = value; OnPropertyChanged("FlangePositionDistanceListY"); }
        }

        private int group_no;
        [StructuresDialog("group_no", typeof(TD.Integer))]
        public int GroupNo {
            get { return group_no; }
            set { group_no = value; OnPropertyChanged("GroupNo"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
