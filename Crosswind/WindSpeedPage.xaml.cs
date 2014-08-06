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

namespace Crosswind
{
    public partial class WindSpeedPage : PhoneApplicationPage
    {
        public WindSpeedPage()
        {
            InitializeComponent();

            this.Loaded += (s, e) => Digit1.Focus();
        }

        private void Digit1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit1.Text.Any())
            {
                Digit2.Focus();
            }
        }

        private void Digit2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit2.Text.Any())
            {
                var path = string.Format("/MainPage.xaml?WindSpeed={0}{1}", Digit1.Text, Digit2.Text);
                NavigationService.Navigate(new Uri(path, UriKind.Relative));
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var bg = new SolidColorBrush(Colors.Black);
            Digit1.Background = bg;
            Digit2.Background = bg;
        }
    }
}