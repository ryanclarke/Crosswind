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
            base.OnNavigatedTo(e);

            model = UrlService.ExtractModelFromQueryString(NavigationContext.QueryString);

            SetupView();

            ClearBackStackToStartOfWizard();
        }

        private void SetupView()
        {
            RunwayNumber.Text = model.Runway;
            WindHeadingNumber.Text = model.WindHeading;
            WindSpeedNumber.Text = model.WindSpeed;
            CrosswindNumber.Text = model.CrosswindSpeed();
            CrosswindDirection.Text = model.CrosswindDirection();
            CrosswindDirectionBlock.Visibility = model.ShouldCrosswindDirection() ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ClearBackStackToStartOfWizard()
        {
            while (NavigationService.BackStack.Count() > 1)
            {
                NavigationService.RemoveBackEntry();
            }
        }
    }
}