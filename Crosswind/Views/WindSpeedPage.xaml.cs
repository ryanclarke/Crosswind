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
using System.Windows.Media.Animation;
using Crosswind.Resources;

namespace Crosswind
{
    public partial class WindSpeedPage : PhoneApplicationPage
    {
        public WindSpeedPage()
        {
            InitializeComponent();

            this.Loaded += (s, e) =>
            {
                Digit1.Focus();
                Underscore1.Fill = App.Current.Resources["WindSpeedColor"] as SolidColorBrush;
            };
        }

        private void SetupStatusHeader()
        {
            StatusRunwayNumber.Text = CreateStatusHeaderText(App.Vm.Runway);
            StatusWindHeadingNumber.Text = CreateStatusHeaderText(App.Vm.WindHeading);
            StatusWindSpeedNumber.Text = CreateStatusHeaderText(App.Vm.WindSpeed);
        }

        private string CreateStatusHeaderText(string number)
        {
            return number ?? AppResources.EmptyStatusHeader;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetupStatusHeader();

            base.OnNavigatedTo(e);
        }

        private void Digit1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit1.Text.Any())
            {
                Digit2.Focus();
                Underscore1.Fill = App.Current.Resources["PhoneForegroundBrush"] as SolidColorBrush;
                Underscore2.Fill = App.Current.Resources["WindSpeedColor"] as SolidColorBrush;
            }
        }

        private void Digit2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit2.Text.Any())
            {
                this.Focus();

                Underscore2.Fill = new SolidColorBrush(Colors.White);

                App.Vm.WindSpeed = EnteredWindSpeed();
                var uri = UriService.CreateNavigationUri(App.Vm);
                NavigationService.Navigate(uri);
            }
        }

        private string EnteredWindSpeed()
        {
            return string.Format("{0}{1}", Digit1.Text, Digit2.Text);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var bg = App.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;
            Digit1.Background = bg;
            Digit2.Background = bg;
        }
    }
}