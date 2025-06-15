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
 *  MainWindowViewModel.cs: view model for main window of WK1001
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System.ComponentModel;
using Tekla.Structures.Dialog;
using TD = Tekla.Structures.Datatype;

namespace Muggle.TeklaPlugins.WK1001.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private string pipe_profile = string.Empty;
        [StructuresDialog("prfStr_Pipe", typeof(TD.String))]
        public string PipeProfile {
            get { return pipe_profile; }
            set { pipe_profile = value; OnPropertyChanged("PipeProfile"); }
        }

        private double topEndPlate_thickness = 40.0;
        [StructuresDialog("thick_TEndplate", typeof(TD.Double))]
        public double TopEndPlateThickness {
            get { return topEndPlate_thickness; }
            set { topEndPlate_thickness = value; OnPropertyChanged("TopEndPlateThickness"); }
        }

        private double bottomEndPlate_thickness = 40.0;
        [StructuresDialog("thick_BEndplate", typeof(TD.Double))]
        public double BottomEndPlateThickness {
            get { return bottomEndPlate_thickness; }
            set { bottomEndPlate_thickness = value; OnPropertyChanged("BottomEndPlateThickness"); }
        }

        private double bottomEndPlate_diameter = 0.0;
        [StructuresDialog("diam_BEndplate", typeof(TD.Double))]
        public double BottomEndPlateDiameter {
            get { return bottomEndPlate_diameter; }
            set { bottomEndPlate_diameter = value; OnPropertyChanged("BottomEndPlateDiameter"); }
        }

        private double stiffener_thickness = 25.0;
        [StructuresDialog("thick_Stiffener", typeof(TD.Double))]
        public double StiffenerThickness {
            get { return stiffener_thickness; }
            set { stiffener_thickness = value; OnPropertyChanged("StiffenerThickness"); }
        }

        private double min_distance = 50.0;
        [StructuresDialog("minDis", typeof(TD.Double))]
        public double MinimumDistance {
            get { return min_distance; }
            set { min_distance = value; OnPropertyChanged("MinimumDistance"); }
        }

        private double top_extended_length = 20.0;
        [StructuresDialog("extLength_T", typeof(TD.Double))]
        public double TopExtendedLength {
            get { return top_extended_length; }
            set { top_extended_length = value; OnPropertyChanged("TopExtendedLength"); }
        }

        private double bottom_extended_length = 20.0;
        [StructuresDialog("extLength_B", typeof(TD.Double))]
        public double BottomExtendedLength {
            get { return bottom_extended_length; }
            set { bottom_extended_length = value; OnPropertyChanged("BottomExtendedLength"); }
        }

        private string material = "Q345B";
        [StructuresDialog("materialStr", typeof(TD.String))]
        public string Material {
            get { return material; }
            set { material = value; OnPropertyChanged("Material"); }
        }

        private int group_no = -1;
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
