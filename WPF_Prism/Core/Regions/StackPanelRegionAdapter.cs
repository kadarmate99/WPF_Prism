using Prism.Navigation.Regions;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Prism.Core.Regions
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(RegionBehaviorFactory behaviorFactory)
            :base(behaviorFactory)
        {
            
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement item in e.NewItems)
                    {
                        regionTarget.Children.Add(item);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement item in e.OldItems)
                    {
                        regionTarget.Children.Remove(item);
                    }
                }
            };
        }

        protected override IRegion CreateRegion() => new Region();
    }
}
