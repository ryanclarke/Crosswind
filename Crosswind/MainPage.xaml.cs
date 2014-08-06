using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Crosswind.Resources;

namespace Crosswind
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Runway_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var path = string.Format("/RunwayPage.xaml?Runway={0}", RunwayNumber.Text);
            NavigationService.Navigate(new Uri(path, UriKind.Relative));
        }

        private void WindHeading_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var path = string.Format("/WindHeadingPage.xaml?WindHeading={0}", WindHeadingNumber.Text);
            NavigationService.Navigate(new Uri(path, UriKind.Relative));
        }

        private void WindSpeed_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var path = string.Format("/WindSpeedPage.xaml?WindSpeed={0}", WindHeadingNumber.Text);
            NavigationService.Navigate(new Uri(path, UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("Runway"))
            {
                RunwayNumber.Text = NavigationContext.QueryString["Runway"];
            }
            if (NavigationContext.QueryString.ContainsKey("WindHeading"))
            {
                WindHeadingNumber.Text = NavigationContext.QueryString["WindHeading"];
            }
            if (NavigationContext.QueryString.ContainsKey("WindSpeed"))
            {
                WindSpeedNumber.Text = NavigationContext.QueryString["WindSpeed"];
            }
            base.OnNavigatedTo(e);
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}