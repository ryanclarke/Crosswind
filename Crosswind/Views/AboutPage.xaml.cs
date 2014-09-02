using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Crosswind.Views
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Twitter_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Windows.System.Launcher.LaunchUriAsync(new Uri("https://twitter.com/RyanSClarke", UriKind.Absolute));
        }

        private void Email_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Windows.System.Launcher.LaunchUriAsync(new Uri("mailto://ryan+crosswind@ryanclarke.net?Crosswind", UriKind.Absolute));
        }
    }
}