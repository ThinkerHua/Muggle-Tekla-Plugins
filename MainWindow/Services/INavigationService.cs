using System.Windows.Controls;

namespace Muggle.TeklaPlugins.MainWindow.Services {
    public interface INavigationService {
        public void SetFrame(Frame frame);
        public void Navigate(Page page);
    }
}
