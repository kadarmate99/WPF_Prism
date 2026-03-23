using ModuleA.ViewModels;
using ModuleA.Views;
using System.Net.Security;
using System.Windows;
using System.Windows.Controls;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            // adding a view using region manager
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));

            // adding views manually with view injection
            IRegion region = _regionManager.Regions["ContentRegion"];

            var view1 = containerProvider.Resolve<ViewA>();
            region.Add(view1);
            view1.Content = new TextBlock()
            {
                Text = "Hello From View 1",
                FontSize = 48,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            var view2 = containerProvider.Resolve<ViewA>();
            view2.Content = new TextBlock()
            {
                Text = "Hello From View 2",
                FontSize = 48,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            region.Add(view2);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // bypasses naming convention auto locator witch relays on reflection.
            // this way we don't have to keep conventions and get a faster app
            ViewModelLocationProvider.Register<ViewA, ViewAViewModel>();
        }
    }
}
