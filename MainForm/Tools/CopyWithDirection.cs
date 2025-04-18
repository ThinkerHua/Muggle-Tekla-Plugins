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
 *  CopyWithDirection.cs: copy objects with direction
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System.Collections.Generic;
using Muggle.TeklaPlugins.Common.Geometry3d;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using Tekla.Structures.Model.UI;
using G3d = Tekla.Structures.Geometry3d;
using UI = Tekla.Structures.Model.UI;

namespace Muggle.TeklaPlugins.MainForm.Tools {
    public static class CopyWithDirection {
        public static void Run() {
            var model = new Model();
            if (!model.GetConnectionStatus()) return;

            var selector = new UI.ModelObjectSelector();
            var objectEnumerator = selector.GetSelectedObjects();
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

            var picker = new Picker();
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
            if (G3d.Parallel.VectorToVector(direction, axisZ)) {
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

                if (G3d.Parallel.VectorToVector(targetDirection, axisZ)) {
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
