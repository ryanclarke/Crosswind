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
        private Model model;

        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Runway_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            model.Runway = RunwayNumber.Text;
            var uri = UrlService.CreateNavigationUri(UrlService.RunwayPage, model); 
            NavigationService.Navigate(uri);
        }

        private void WindHeading_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            model.WindHeading = WindHeadingNumber.Text;
            var uri = UrlService.CreateNavigationUri(UrlService.WindHeadingPage, model);
            NavigationService.Navigate(uri);
        }

        private void WindSpeed_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            model.WindSpeed = WindSpeedNumber.Text;
            var uri = UrlService.CreateNavigationUri(UrlService.WindSpeedPage, model);
            NavigationService.Navigate(uri);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            model = UrlService.ExtractModelFromQueryString(NavigationContext.QueryString);

            RunwayNumber.Text = model.Runway;
            WindHeadingNumber.Text = model.WindHeading;
            WindSpeedNumber.Text = model.WindSpeed;
            CrosswindNumber.Text = model.CrosswindSpeed();
            CrosswindDirection.Text = model.CrosswindDirection();
            CrosswindDirectionBlock.Visibility = model.ShouldCrosswindDirection() ? Visibility.Visible : Visibility.Collapsed;

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