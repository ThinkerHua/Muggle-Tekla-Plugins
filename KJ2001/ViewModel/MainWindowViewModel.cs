﻿/*==============================================================================
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
 *  MainWindowViewModel.cs: view model for main window of KJ2001
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System.Collections.Generic;
using System.ComponentModel;
using Tekla.Structures.Catalogs;
using Tekla.Structures.Dialog;
using TD = Tekla.Structures.Datatype;

namespace Muggle.TeklaPlugins.KJ2001.ViewModel {
    /// <summary>
    /// Data logic for MainWindow
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged {
        private string basePlate_material;
        [StructuresDialog("base_MATL", typeof(TD.String))]
        public string BasePlateMaterial {
            get { return basePlate_material; }
            set { basePlate_material = value; OnPropertyChanged("BasePlateMaterial"); }
        }

        private double basePlate_thickness;
        [StructuresDialog("base_THK", typeof(TD.Double))]
        public double BasePlateThickness {
            get { return basePlate_thickness; }
            set { basePlate_thickness = value; OnPropertyChanged("BasePlateThickness"); }
        }

        private double basePlate_width;
        [StructuresDialog("base_WID", typeof(TD.Double))]
        public double BasePlateWidth {
            get { return basePlate_width; }
            set { basePlate_width = value; OnPropertyChanged("BasePlateWidth"); }
        }

        private double basePlate_length;
        [StructuresDialog("base_LEN", typeof(TD.Double))]
        public double BasePlateLength {
            get { return basePlate_length; }
            set { basePlate_length = value; OnPropertyChanged("BasePlateLength"); }
        }

        private string anchorRod_material;
        [StructuresDialog("anchor_MATL", typeof(TD.String))]
        public string AnchorRodMaterial {
            get { return anchorRod_material; }
            set { anchorRod_material = value; OnPropertyChanged("AnchorRodMaterial"); }
        }

        private double anchorRod_size;
        [StructuresDialog("anchor_size", typeof(TD.Double))]
        public double AnchorRodSize {
            get { return anchorRod_size; }
            set { anchorRod_size = value; OnPropertyChanged("AnchorRodSize"); }
        }

        private double anchorRod_tolerance;
        [StructuresDialog("anchor_TOL", typeof(TD.Double))]
        public double AnchorRodTolerance {
            get { return anchorRod_tolerance; }
            set { anchorRod_tolerance = value; OnPropertyChanged("AnchorRodTolerance"); }
        }

        private double anchorRod_length1;
        [StructuresDialog("anchor_LEN1", typeof(TD.Double))]
        public double AnchorRodLength1 {
            get { return anchorRod_length1; }
            set { anchorRod_length1 = value; OnPropertyChanged("AnchorRodLength1"); }
        }

        private double anchorRod_length2;
        [StructuresDialog("anchor_LEN2", typeof(TD.Double))]
        public double AnchorRodLength2 {
            get { return anchorRod_length2; }
            set { anchorRod_length2 = value; OnPropertyChanged("AnchorRodLength2"); }
        }

        private double anchorRod_length3;
        [StructuresDialog("anchor_LEN3", typeof(TD.Double))]
        public double AnchorRodLength3 {
            get { return anchorRod_length3; }
            set { anchorRod_length3 = value; OnPropertyChanged("AnchorRodLength3"); }
        }

        private double anchorRod_length4;
        [StructuresDialog("anchor_LEN4", typeof(TD.Double))]
        public double AnchorRodLength4 {
            get { return anchorRod_length4; }
            set { anchorRod_length4 = value; OnPropertyChanged("AnchorRodLength4"); }
        }

        private double anchorRod_length5;
        [StructuresDialog("anchor_LEN5", typeof(TD.Double))]
        public double AnchorRodLength5 {
            get { return anchorRod_length5; }
            set { anchorRod_length5 = value; OnPropertyChanged("AnchorRodLength5"); }
        }

        private double anchorRod_distance_to_edge;
        [StructuresDialog("anchor_D2E", typeof(TD.Double))]
        public double AnchorRodDistanceToEdge {
            get { return anchorRod_distance_to_edge; }
            set { anchorRod_distance_to_edge = value; OnPropertyChanged("AnchorRodDistanceToEdge"); }
        }

        private string washerPlate_material;
        [StructuresDialog("WSHRPLT_MATL", typeof(TD.String))]
        public string WasherPlateMaterial {
            get { return washerPlate_material; }
            set { washerPlate_material = value; OnPropertyChanged("WasherPlateMaterial"); }
        }

        private double washerPlate_thickness;
        [StructuresDialog("WSHRPLT_THK", typeof(TD.Double))]
        public double WasherPlateThickness {
            get { return washerPlate_thickness; }
            set { washerPlate_thickness = value; OnPropertyChanged("WasherPlateThickness"); }
        }

        private double washerPlate_width;
        [StructuresDialog("WSHRPLT_WID", typeof(TD.Double))]
        public double WasherPlateWidth {
            get { return washerPlate_width; }
            set { washerPlate_width = value; OnPropertyChanged("WasherPlateWidth"); }
        }

        private double washerPlate_holeDiameter;
        [StructuresDialog("WSHRPLT_Hole_DIA", typeof(TD.Double))]
        public double WasherPlateHoleDiameter {
            get { return washerPlate_holeDiameter; }
            set { washerPlate_holeDiameter = value; OnPropertyChanged("WasherPlateHoleDiameter"); }
        }

        private string stud_standard;
        [StructuresDialog("stud_STD", typeof(TD.String))]
        public string StudStandard {
            get { return stud_standard; }
            set { stud_standard = value == string.Empty ? "STUD" : value; OnPropertyChanged("StudStandard"); OnPropertyChanged("StudLengths"); }
        }

        private TD.Distance stud_size;
        [StructuresDialog("stud_size", typeof(TD.Distance))]
        public TD.Distance StudSize {
            get { return stud_size; }
            set { stud_size = value; OnPropertyChanged("StudSize"); OnPropertyChanged("StudLengths"); }
        }

        public List<double> StudLengths {
            get {
                var catalogHandler = new CatalogHandler();
                var boltItemEnumerator = catalogHandler.GetBoltItems();
                BoltItem boltItem;
                while (boltItemEnumerator.MoveNext()) {
                    boltItem = boltItemEnumerator.Current;
                    if (boltItem.Standard == StudStandard && boltItem.Size == StudSize.Value) {
                        return boltItem.Lengths;
                    }
                }

                return new List<double>();
            }
        }

        private double stud_length;
        [StructuresDialog("stud_LEN", typeof(TD.Double))]
        public double StudLength {
            get { return stud_length; }
            set { stud_length = value; OnPropertyChanged("StudLength"); }
        }

        private string stud_distanceList_X;
        [StructuresDialog("stud_DISLST_X", typeof(TD.String))]
        public string StudDistanceListX {
            get { return stud_distanceList_X; }
            set { stud_distanceList_X = value; OnPropertyChanged("StudDistanceListX"); }
        }

        private string stud_distanceList_Y;
        [StructuresDialog("stud_DISLST_Y", typeof(TD.String))]
        public string StudDistanceListY {
            get { return stud_distanceList_Y; }
            set { stud_distanceList_Y = value; OnPropertyChanged("StudDistanceListY"); }
        }

        private double stud_offset_XZ;
        [StructuresDialog("stud_offset_XZ", typeof(TD.Double))]
        public double StudOffsetXZ {
            get { return stud_offset_XZ; }
            set { stud_offset_XZ = value; OnPropertyChanged("StudOffsetXZ"); }
        }

        private double stud_offset_YZ;
        [StructuresDialog("stud_offset_YZ", typeof(TD.Double))]
        public double StudOffsetYZ {
            get { return stud_offset_YZ; }
            set { stud_offset_YZ = value; OnPropertyChanged("StudOffsetYZ"); }
        }

        private string stud_distanceList_XZ;
        [StructuresDialog("stud_DISLST_XZ", typeof(TD.String))]
        public string StudDistanceListXZ {
            get { return stud_distanceList_XZ; }
            set { stud_distanceList_XZ = value; OnPropertyChanged("StudDistanceListXZ"); }
        }

        private string stud_distanceList_YZ;
        [StructuresDialog("stud_DISLST_YZ", typeof(TD.String))]
        public string StudDistanceListYZ {
            get { return stud_distanceList_YZ; }
            set { stud_distanceList_YZ = value; OnPropertyChanged("StudDistanceListYZ"); }
        }

        private string innerStiffener_material;
        [StructuresDialog("stif_MATL", typeof(TD.String))]
        public string InnerStiffenerMaterial {
            get { return innerStiffener_material; }
            set { innerStiffener_material = value; OnPropertyChanged("InnerStiffenerMaterial"); }
        }

        private double innerStiffener_thickness;
        [StructuresDialog("stif_THK", typeof(TD.Double))]
        public double InnerStiffenerThickness {
            get { return innerStiffener_thickness; }
            set { innerStiffener_thickness = value; OnPropertyChanged("InnerStiffenerThickness"); }
        }

        private double innerStiffener_distance_to_base;
        [StructuresDialog("stif_D2B", typeof(TD.Double))]
        public double InnerStiffenerDistanceToBase {
            get { return innerStiffener_distance_to_base; }
            set { innerStiffener_distance_to_base = value; OnPropertyChanged("InnerStiffenerDistanceToBase"); }
        }

        private double pouringtHole_diameter;
        [StructuresDialog("pouringHole_DIA", typeof(TD.Double))]
        public double PouringHoleDiameter {
            get { return pouringtHole_diameter; }
            set { pouringtHole_diameter = value; OnPropertyChanged("PouringHoleDiameter"); }
        }

        private double exhaustHole_diameter;
        [StructuresDialog("exhaustHole_DIA", typeof(TD.Double))]
        public double ExhaustHoleDiameter {
            get { return exhaustHole_diameter; }
            set { exhaustHole_diameter = value; OnPropertyChanged("ExhaustHoleDiameter"); }
        }

        private double exhaustHole_position_X;
        [StructuresDialog("exhaustHole_POS_X", typeof(TD.Double))]
        public double ExhaustHolePositionX {
            get { return exhaustHole_position_X; }
            set { exhaustHole_position_X = value; OnPropertyChanged("ExhaustHolePositionX"); }
        }

        private double exhaustHole_position_Y;
        [StructuresDialog("exhaustHole_POS_Y", typeof(TD.Double))]
        public double ExhaustHolePositionY {
            get { return exhaustHole_position_Y; }
            set { exhaustHole_position_Y = value; OnPropertyChanged("ExhaustHolePositionY"); }
        }

        private int group_no;
        [StructuresDialog("group_no", typeof(TD.Integer))]
        public int GroupNumber {
            get { return group_no; }
            set { group_no = value; OnPropertyChanged("GroupNumber"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
