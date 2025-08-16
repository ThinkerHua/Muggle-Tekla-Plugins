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
 *  MainWindowViewModel.cs: view model for main window of HJ1001
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System.ComponentModel;
using Tekla.Structures.Dialog;
using TD = Tekla.Structures.Datatype;

namespace Muggle.TeklaPlugins.HJ1001.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {
        private double endplate_thickness = 20.0;
        [StructuresDialog("endPlateTHK", typeof(TD.Double))]
        public double EndPlateThickness {
            get { return endplate_thickness; }
            set {
                endplate_thickness = value == int.MinValue ? 20.0 : value;
                OnPropertyChanged("EndPlateThickness");
            }
        }

        private double endplate_diameter = 554.0;
        [StructuresDialog("endPlateDIAM", typeof(TD.Double))]
        public double EndPlateDiameter {
            get { return endplate_diameter; }
            set {
                endplate_diameter = value == int.MinValue ? 554.0 : value;
                OnPropertyChanged("EndPlateDiameter");
            }
        }

        private int creatPrimStif = 1;
        [StructuresDialog("creatPrimStif", typeof(TD.Integer))]
        public int CreatPrimaryStiffeners {
            get { return creatPrimStif; }
            set {
                creatPrimStif = value == 0 ? 0 : 1;
                OnPropertyChanged("CreatPrimaryStiffeners");
            }
        }

        private int creatSecStif = 1;
        [StructuresDialog("creatSecStif", typeof(TD.Integer))]
        public int CreatSecondaryStiffeners {
            get { return creatSecStif; }
            set {
                creatSecStif = value == 0 ? 0 : 1;
                OnPropertyChanged("CreatSecondaryStiffeners");
            }
        }

        private double stifTHK = 10.0;
        [StructuresDialog("stifTHK", typeof(TD.Double))]
        public double StiffenerThickness {
            get { return stifTHK; }
            set {
                stifTHK = value == int.MinValue ? 10.0 : value;
                OnPropertyChanged("StiffenerThickness");
            }
        }

        private double stifWidth = 140.0;
        [StructuresDialog("stifWidth", typeof(TD.Double))]
        public double StiffenerWidth {
            get { return stifWidth; }
            set {
                stifWidth = value == int.MinValue ? 140.0 : value;
                OnPropertyChanged("StiffenerWidth");
            }
        }

        private double chamX = 40.0;
        [StructuresDialog("chamX", typeof(TD.Double))]
        public double ChamferSizeX {
            get { return chamX; }
            set {
                chamX = value == int.MinValue ? 40.0 : value;
                OnPropertyChanged("ChamferSizeX");
            }
        }

        private double chamY = 40.0;
        [StructuresDialog("chamY", typeof(TD.Double))]
        public double ChamferSizeY {
            get { return chamY; }
            set {
                chamY = value == int.MinValue ? 40.0 : value;
                OnPropertyChanged("ChamferSizeY");
            }
        }

        private double margin = 0.0;
        [StructuresDialog("margin", typeof(TD.Double))]
        public double Margin {
            get { return margin; }
            set {
                margin = value == int.MinValue ? 0.0 : value;
                OnPropertyChanged("Margin");
            }
        }

        private int quantity = 16;
        [StructuresDialog("quantity", typeof(TD.Integer))]
        public int Quantity {
            get { return quantity; }
            set {
                quantity = value == int.MinValue ? 16 : value;
                OnPropertyChanged("Quantity");
            }
        }

        private int creatBolt = 1;
        [StructuresDialog("creatBolt", typeof(TD.Integer))]
        public int CreatBolt {
            get { return creatBolt; }
            set {
                creatBolt = value == 0 ? 0 : 1;
                OnPropertyChanged("CreatBolt");
            }
        }

        private string boltStandard = "HS10.0";
        [StructuresDialog("boltStandard", typeof(TD.String))]
        public string BoltStandard {
            get { return boltStandard; }
            set {
                boltStandard = string.IsNullOrEmpty(value) ? "HS10.0" : value;
                OnPropertyChanged("BoltStandard");
            }
        }

        private TD.Distance boltSize = new TD.Distance(20.0);
        [StructuresDialog("boltSize", typeof(TD.Distance))]
        public TD.Distance BoltSize {
            get { return boltSize; }
            set {
                boltSize = value;
                OnPropertyChanged("BoltSize");
            }
        }

        private double boltCircleDiameter = 466.0;
        [StructuresDialog("boltCircleDiameter", typeof(TD.Double))]
        public double BoltCircleDiameter {
            get { return boltCircleDiameter; }
            set {
                boltCircleDiameter = value == int.MinValue ? 466.0 : value;
                OnPropertyChanged("BoltCircleDiameter");
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
