using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace Crosswind
{
    public partial class WindHeadingPage : PhoneApplicationPage
    {
        private Model model;

        public WindHeadingPage()
        {
            InitializeComponent();

            FillContentPanel();
        }

        private void SetupStatusHeader()
        {
            StatusRunwayNumber.Text = model.NeedsRunway() ? "__" : model.Runway;
            StatusWindHeadingNumber.Text = model.NeedsWindHeading() ? "__" : model.WindHeading;
            StatusWindSpeedNumber.Text = model.NeedsWindSpeed() ? "__" : model.WindSpeed;
        }

        private void FillContentPanel()
        {
            for (int i = 0; i < 36; i++)
            {
                var tb = new TextBlock();
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.FontSize = 46;
                tb.Text = string.Format("{0:00}", i);

                var sp = new StackPanel();
                sp.Margin = new Thickness(6);
                sp.Background = App.Current.Resources["WindHeadingColor"] as SolidColorBrush;
                sp.Tap += sp_Tap;
                sp.Tag = string.Format("{0:00}", i);
                sp.Children.Add(tb);
                Grid.SetRow(sp, (int)Math.Floor(i / 4.0));
                Grid.SetColumn(sp, i % 4);

                ContentPanel.Children.Add(sp);
            }
        }

        private void sp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            model.WindHeading = (string)(sender as StackPanel).Tag;
            var uri = UrlService.CreateNavigationUri(model);
            NavigationService.Navigate(uri);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            model = UrlService.ExtractModelFromQueryString(NavigationContext.QueryString);
            SetupStatusHeader();

            base.OnNavigatedTo(e);
        }
    }
}