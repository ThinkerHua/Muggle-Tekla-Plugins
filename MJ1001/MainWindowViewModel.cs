using System.ComponentModel;
using Tekla.Structures.Dialog;
using TD = Tekla.Structures.Datatype;

namespace Muggle.TeklaPlugins.MJ1001 {
    /// <summary>
    /// Data logic for MainWindow
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged {
        #region Fields
        private double gap = 15.0;
        private double ratHole_radius = 30.0;
        private double embedment_thickness = 20.0;
        private double embedment_width = 300.0;
        private double embedment_exten = 90.0;
        private string embedment_material = "Q345B";
        private double anchorRod_length = 150.0;
        private TD.Distance anchorRod_size = new TD.Distance(20.0);
        private string anchorRod_material = "Q345B";
        private string anchorRod_disListStr_X = "250 4*125";
        private string anchorRod_disListStr_Y = "160";
        private double cleat_thickness = 12.0;
        private double cleat_width = 95.0;
        private double cleat_dis_with_innerEdge = 40.0;
        private string cleat_material = "Q345B";
        private string bolt_standard = "HS10.9";
        private TD.Distance bolt_size = new TD.Distance(20.0);
        private string bolt_disListStr_X = "40 7*70";
        private string bolt_disListStr_Y = "0";
        private int group_no = -1;
        #endregion

        #region Properties
        [StructuresDialog("gap", typeof(TD.Double))]
        public double Gap {
            get => gap;
            set { gap = value; RaisePropertyChanged("Gap"); }
        }

        [StructuresDialog("ratHole_radius", typeof(TD.Double))]
        public double RatHoleRadius {
            get => ratHole_radius;
            set { ratHole_radius = value; RaisePropertyChanged("RatHoleRadius"); }
        }

        [StructuresDialog("embedment_THK", typeof(TD.Double))]
        public double EmbedmentThickness {
            get => embedment_thickness;
            set { embedment_thickness = value; RaisePropertyChanged("EmbedmentThickness"); }
        }

        [StructuresDialog("embedment_WDTH", typeof(TD.Double))]
        public double EmbedmentWidth {
            get => embedment_width;
            set { embedment_width = value; RaisePropertyChanged("EmbedmentWidth"); }
        }

        [StructuresDialog("embedment_EXTN", typeof(TD.Double))]
        public double EmbedmentExten {
            get => embedment_exten;
            set { embedment_exten = value; RaisePropertyChanged("EmbedmentExten"); }
        }

        [StructuresDialog("embedment_MATL", typeof(TD.String))]
        public string EmbedmentMaterial {
            get => embedment_material;
            set { embedment_material = value; RaisePropertyChanged("EmbedmentMaterial"); }
        }

        [StructuresDialog("anchorRod_LEN", typeof(TD.Double))]
        public double AnchorRodLength {
            get => anchorRod_length;
            set { anchorRod_length = value; RaisePropertyChanged("AnchorRodLength"); }
        }

        [StructuresDialog("anchorRod_size", typeof(TD.Double))]
        public TD.Distance AnchorRodSize {
            get => anchorRod_size;
            set { anchorRod_size = value; RaisePropertyChanged("AnchorRodSize"); }
        }

        [StructuresDialog("anchorRod_MATL", typeof(TD.String))]
        public string AnchorRodMaterial {
            get => anchorRod_material;
            set { anchorRod_material = value; RaisePropertyChanged("AnchorRodMaterial"); }
        }

        [StructuresDialog("anchorRod_disList_X", typeof(TD.String))]
        public string AnchorRodDistanceListX {
            get => anchorRod_disListStr_X;
            set { anchorRod_disListStr_X = value; RaisePropertyChanged("AnchorRodDistanceListX"); }
        }

        [StructuresDialog("anchorRod_disList_Y", typeof(TD.String))]
        public string AnchorRodDistanceListY {
            get => anchorRod_disListStr_Y;
            set { anchorRod_disListStr_Y = value; RaisePropertyChanged("AnchorRodDistanceListY"); }
        }

        [StructuresDialog("cleat_THK", typeof(TD.Double))]
        public double CleatThickness {
            get => cleat_thickness;
            set { cleat_thickness = value; RaisePropertyChanged("CleatThickness"); }
        }

        [StructuresDialog("cleat_WDTH", typeof(TD.Double))]
        public double CleatWidth {
            get => cleat_width;
            set { cleat_width = value; RaisePropertyChanged("CleatWidth"); }
        }

        [StructuresDialog("cleat_dis_innerEdge", typeof(TD.Double))]
        public double CleatDistanceWithInnerEdge {
            get => cleat_dis_with_innerEdge;
            set { cleat_dis_with_innerEdge = value; RaisePropertyChanged("CleatDistanceWithInnerEdge"); }
        }

        [StructuresDialog("cleat_MATL", typeof(TD.String))]
        public string CleatMaterial {
            get => cleat_material;
            set { cleat_material = value; RaisePropertyChanged("CleatMaterial"); }
        }

        [StructuresDialog("bolt_STD", typeof(TD.String))]
        public string BoltStandard {
            get => bolt_standard;
            set { bolt_standard = value; RaisePropertyChanged("BoltStandard"); }
        }

        [StructuresDialog("bolt_size", typeof(TD.Double))]
        public TD.Distance BoltSize {
            get => bolt_size;
            set { bolt_size = value; RaisePropertyChanged("BoltSize"); }
        }

        [StructuresDialog("bolt_disList_X", typeof(TD.String))]
        public string BoltDistanceListX {
            get => bolt_disListStr_X;
            set { bolt_disListStr_X = value; RaisePropertyChanged("BoltDistanceListX"); }
        }

        [StructuresDialog("bolt_disList_Y", typeof(TD.String))]
        public string BoltDistanceListY {
            get => bolt_disListStr_Y;
            set { bolt_disListStr_Y = value; RaisePropertyChanged("BoltDistanceListY"); }
        }

        [StructuresDialog("group_no", typeof(TD.Integer))]
        public int GroupNo {
            get => group_no;
            set { group_no = value; RaisePropertyChanged("GroupNo"); }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
