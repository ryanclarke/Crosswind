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
    public partial class RunwayPage : PhoneApplicationPage
    {
        public RunwayPage()
        {
            InitializeComponent();

            FillContentPanel();
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
                sp.Background = App.Current.Resources["PhoneAccentBrush"] as SolidColorBrush;
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
            var path = string.Format("/MainPage.xaml?Runway={0}", Uri.EscapeUriString((sender as StackPanel).Tag as string));
            NavigationService.Navigate(new Uri(path, UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("Runway"))
            {
                var r = NavigationContext.QueryString["Runway"];
                var items = ContentPanel.Children.First(x =>
                {
                    var sp = x as StackPanel;
                    return sp.Tag.ToString() == r;
                });
                var item = items as StackPanel;
                item.Background = new SolidColorBrush(Colors.Blue);
                //var children = (item).Children;
                //(children.First() as TextBlock).Text = r;
            }
            base.OnNavigatedTo(e);
        }
    }
}