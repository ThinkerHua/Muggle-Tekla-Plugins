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
 *  MainWindowViewModel.cs: view model for main window of KJ1002
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System.ComponentModel;
using Tekla.Structures.Dialog;
using TD = Tekla.Structures.Datatype;

namespace Muggle.TeklaPlugins.KJ1002.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {

        private double sectionLength = 0.0;
        [StructuresDialog("sectionLEN", typeof(TD.Double))]
        public double SectionLength {
            get { return sectionLength; }
            set {
                sectionLength = value == int.MinValue ? 0.0 : value;
                OnPropertyChanged("SectionLength");
            }
        }

        private string braceProfile = "L70*5.0";
        [StructuresDialog("bracePRF", typeof(TD.String))]
        public string BraceProfile {
            get { return braceProfile; }
            set {
                braceProfile = string.IsNullOrEmpty(value) ? "L70*5.0" : value;
                OnPropertyChanged("BraceProfile");
            }
        }

        private double stiffenerThickness = 8.0;
        [StructuresDialog("STIF_THK", typeof(TD.Double))]
        public double StiffenerThickness {
            get { return stiffenerThickness; }
            set {
                stiffenerThickness = value == int.MinValue ? 8.0 : value;
                OnPropertyChanged("StiffenerThickness");
            }
        }

        private double gussetThickness = 8.0;
        [StructuresDialog("gussetTHK", typeof(TD.Double))]
        public double GussetThickness {
            get { return gussetThickness; }
            set {
                gussetThickness = value == int.MinValue ? 8.0 : value;
                OnPropertyChanged("GussetThickness");
            }
        }

        private double clearance = 50.0;
        [StructuresDialog("clearance", typeof(TD.Double))]
        public double Clearance {
            get { return clearance; }
            set {
                clearance = value == int.MinValue ? 50.0 : value;
                OnPropertyChanged("Clearance");
            }
        }

        private string boltStandard = "TS10.9";
        [StructuresDialog("boltStd", typeof(TD.String))]
        public string BoltStandard {
            get { return boltStandard; }
            set {
                boltStandard = string.IsNullOrEmpty(value) ? "TS10.9" : value;
                OnPropertyChanged("BoltStandard");
            }
        }

        private TD.Distance boltSize = new TD.Distance(14.0);
        [StructuresDialog("boltSize", typeof(TD.Distance))]
        public TD.Distance BoltSize {
            get { return boltSize; }
            set {
                boltSize = value;
                OnPropertyChanged("BoltSize");
            }
        }

        private string boltPositions = "50 70 50";
        [StructuresDialog("bolt_Positions", typeof(TD.String))]
        public string BoltPositions {
            get { return boltPositions; }
            set {
                boltPositions = string.IsNullOrEmpty(value) ? "50 70 50" : value;
                OnPropertyChanged("BoltPositions");
            }
        }

        private double extendedDistance = 30.0;
        [StructuresDialog("EXTD_Distance", typeof(TD.Double))]
        public double ExtendedDistance {
            get { return extendedDistance; }
            set {
                extendedDistance = value == int.MinValue ? 30.0 : value;
                OnPropertyChanged("ExtendedDistance");
            }
        }

        private int creatUpperSplices = 0;
        [StructuresDialog("creatUpperSplices", typeof(TD.Integer))]
        public int CreatUpperSplices {
            get { return creatUpperSplices; }
            set {
                creatUpperSplices = value == 1 ? 1 : 0;
                OnPropertyChanged("CreatUpperSplices");
            }
        }

        private string material = "Q345B";
        [StructuresDialog("material", typeof(TD.String))]
        public string Material {
            get { return material; }
            set {
                material = string.IsNullOrEmpty(value) ? "Q345B" : value;
                OnPropertyChanged("Material");
            }
        }

        private int upDirection = 7;
        [StructuresDialog("zsuunta", typeof(TD.Integer))]
        public int UpDirection {
            get { return upDirection; }
            set {
                upDirection = value <= 0 || value > 7 ? 7 : value;
                OnPropertyChanged("UpDirection");
            }
        }

        private double rotationAngleY = 0.0;
        [StructuresDialog("zang1", typeof(TD.Double))]
        public double RotationAngleY {
            get { return rotationAngleY; }
            set {
                rotationAngleY = value == int.MinValue ? 0.0 : value;
                OnPropertyChanged("RotationAngleY");
            }
        }

        private double rotationAngleX = 0.0;
        [StructuresDialog("zang2", typeof(TD.Double))]
        public double RotationAngleX {
            get { return rotationAngleX; }
            set {
                rotationAngleX = value == int.MinValue ? 0.0 : value;
                OnPropertyChanged("RotationAngleX");
            }
        }

        private int locked = 0;
        [StructuresDialog("OBJECT_LOCKED", typeof(TD.Integer))]
        public int Locked {
            get { return locked; }
            set {
                locked = value == 1 ? 1 : 0;
                OnPropertyChanged("Locked");
            }
        }

        private int @class = -1;
        [StructuresDialog("group_no", typeof(TD.Integer))]
        public int Class {
            get { return @class; }
            set {
                @class = value == int.MinValue ? 0 : value;
                OnPropertyChanged("Class");
            }
        }

        private string connectionCode = string.Empty;
        [StructuresDialog("joint_code", typeof(TD.String))]
        public string ConnectionCode {
            get { return connectionCode; }
            set {
                connectionCode = value ?? string.Empty;
                OnPropertyChanged("ConnectionCode");
            }
        }

        private string autoDefaults = string.Empty;
        [StructuresDialog("ad_root", typeof(TD.String))]
        public string AutoDefaults {
            get { return autoDefaults; }
            set {
                autoDefaults = value ?? string.Empty;
                OnPropertyChanged("AutoDefaults");
            }
        }

        private string autoConnection = string.Empty;
        [StructuresDialog("ac_root", typeof(TD.String))]
        public string AutoConnection {
            get { return autoConnection; }
            set {
                autoConnection = value ?? string.Empty;
                OnPropertyChanged("AutoConnection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
