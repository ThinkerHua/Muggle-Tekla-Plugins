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
 *  NormalToolsViewModel.xaml.cs: view model for the normal tools.
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Muggle.TeklaPlugins.Common.Geometry3d;
using Muggle.TeklaPlugins.Common.Internal;
using Muggle.TeklaPlugins.MainWindow.Services;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;
using TSMUI = Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.MainWindow.ViewModels {
    public partial class NormalToolsViewModel : ViewModelBase {
        private const string USER_INTERRUPT = "User interrupt";
        private const string NOT_CONNECTED = "Not connected to a model.";
        private readonly Model model = new Model();
        private readonly Picker picker = new Picker();
        private readonly TSMUI.ModelObjectSelector uiSelector = new TSMUI.ModelObjectSelector();

        private readonly IMessageBoxService messageBoxService;

        public NormalToolsViewModel(IMessageBoxService messageBoxService) {
            this.messageBoxService = messageBoxService;
        }

        [RelayCommand]
        private void ShowModelObjectCoordinateSystem() {
            ModelObject obj;
            try {
                if (!model.GetConnectionStatus()) throw new InvalidOperationException(NOT_CONNECTED);

                while (true) {
                    obj = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT);
                    if (obj is PolyBeam polyBeam) {
                        var css = polyBeam.GetPolybeamCoordinateSystems();
                        foreach (CoordinateSystem cs in css) {
                            Internal.ShowCoordinateSystem(cs);
                        }
                    } else {
                        Internal.ShowCoordinateSystem(obj.GetCoordinateSystem());
                    }
                }
            } catch (Exception e) when (e.Message == USER_INTERRUPT) {

            } catch (Exception e) {
                messageBoxService.ShowError(e.ToString());
            }
        }

        [RelayCommand]
        private void SelectWeldedObjects() {
            try {
                if (!model.GetConnectionStatus()) throw new InvalidOperationException(NOT_CONNECTED);

                var weld = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_WELD) as BaseWeld;
                var parts = new ArrayList {
                    weld.MainObject,
                    weld.SecondaryObject,
                };

                uiSelector.Select(parts, false);
                model.CommitChanges();
            } catch (Exception e) when (e.Message == USER_INTERRUPT) {

            } catch (Exception e) {
                messageBoxService.ShowError(e.ToString());
            }
        }

        [RelayCommand]
        private void ReorderContourPoints() {
            ContourPlate plate;
            try {
                if (!model.GetConnectionStatus()) throw new InvalidOperationException(NOT_CONNECTED);

                plate = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_PART, "Select a contour plate:") as ContourPlate;
            } catch (Exception e) when (e.Message == USER_INTERRUPT) {
                return;
            } catch (Exception e) {
                messageBoxService.ShowError(e.ToString());
                return;
            }

            if (plate == null) {
                Operation.DisplayPrompt("No contour plate selected.");
                return;
            }
            var point = picker.PickPoint("Select a point as the first point:");

            var contour = plate.Contour.ContourPoints.Cast<ContourPoint>();
            var index = contour
                .Select((p, i) => (i, Distance.PointToPoint(p, point)))
                .OrderBy(item => item.Item2).First().i;

            var newContour = contour.Skip(index).Concat(contour.Take(index)).ToList();
            plate.Contour.ContourPoints = new ArrayList(newContour);
            plate.Modify();
            model.CommitChanges();
        }

        [RelayCommand]
        private void CopyWithDirection() {
            try {
                if (!model.GetConnectionStatus()) throw new InvalidOperationException(NOT_CONNECTED);
            } catch (Exception e) {
                messageBoxService.ShowError(e.ToString());
                return;
            }

            var objectEnumerator = uiSelector.GetSelectedObjects();
            if (objectEnumerator == null || objectEnumerator.GetSize() == 0) {
                Operation.DisplayPrompt("No objects selected.");
                return;
            }

            var selectedObjects = new List<ModelObject>();
            BaseComponent component;
            foreach (ModelObject modelObject in objectEnumerator) {
                component = modelObject.GetFatherComponent();
                if (component == null) {
                    selectedObjects.Add(modelObject);
                }
            }

            Point origin, directionPoint;
            try {
                origin = picker.PickPoint("Select the source origin point:");
                directionPoint = picker.PickPoint("Select the source direction point:", origin);
            } catch {
                return;
            }
            var direction = new Vector(directionPoint - origin);
            if (direction.IsZero()) {
                Operation.DisplayPrompt("The direction vector cannot be zero.");
                return;
            }

            var axisX = new Vector(1000.0, 0.0, 0.0);
            var axisZ = new Vector(0.0, 0.0, 1000.0);
            CoordinateSystem sourceCS;
            if (Parallel.VectorToVector(direction, axisZ)) {
                sourceCS = new CoordinateSystem(origin, axisX, direction.Cross(axisX));
            } else {
                sourceCS = new CoordinateSystem(origin, direction, axisZ.Cross(direction));
            }

            Point targetOrigin;
            Point targetDirectionPoint;
            Vector targetDirection;
            CoordinateSystem targetCS;
            while (true) {
                try {
                    targetOrigin = picker.PickPoint("Select the target origin point:", directionPoint);
                    targetDirectionPoint = picker.PickPoint("Select the target direction point:", targetOrigin);
                } catch {
                    return;
                }

                targetDirection = new Vector(targetDirectionPoint - targetOrigin);
                if (targetDirection.IsZero()) {
                    Operation.DisplayPrompt("The target direction vector cannot be zero.");
                    continue;
                }

                if (Parallel.VectorToVector(targetDirection, axisZ)) {
                    targetCS = new CoordinateSystem(targetOrigin, axisX, targetDirection.Cross(axisX));
                } else {
                    targetCS = new CoordinateSystem(targetOrigin, targetDirection, axisZ.Cross(targetDirection));
                }

                foreach (ModelObject obj in selectedObjects) {
                    Operation.CopyObject(obj, sourceCS, targetCS);
                }

                model.CommitChanges();
            }
        }
    }
}
