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
 *  MainWindowViewModel.xaml.cs: view model for all tools and plugins.
 *  written by Huang YongXing - thinkerhua@hotmail.com
 *==============================================================================*/
using System;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using Muggle.TeklaPlugins.MainWindow.Services;

namespace Muggle.TeklaPlugins.MainWindow.ViewModels {
    public partial class MainWindowViewModel : ViewModelBase {

        private readonly IMessageBoxService messageBoxService;
        private readonly NavigationService navigationService;

        public MainWindowViewModel(IMessageBoxService messageBoxService, NavigationService navigationService) {
            this.messageBoxService = messageBoxService;
            this.navigationService = navigationService;
        }

        [RelayCommand]
        private void Navigate(Page page) {
            try {
                navigationService.Navigate(page);
            } catch (Exception e) {
                messageBoxService.ShowError($"Navigation failed: {e.Message}");
            }
        }
    }

}
