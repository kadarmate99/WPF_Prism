using ModuleA;
using ModuleCompositeCommand;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using System.Windows;
using System.Windows.Controls;
using WPF_Prism.Core.Commands;
using WPF_Prism.Core.Regions;
using WPF_Prism.Views;

namespace WPF_Prism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleCompositeCommandModule>();
        }
    }
}
