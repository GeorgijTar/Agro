
using System.Windows.Controls;

namespace Agro.WPF.Helpers
{
    public interface IHelperNavigation
    {

        public abstract TabItem OpenPage(Page page, string title);

        public abstract bool ClosePage(TabItem tabItem);
    }
}
