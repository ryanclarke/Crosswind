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
        public MainPage()
        {
            InitializeComponent();
        }

        private void Runway_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.Vm.Runway = RunwayNumber.Text;
            var uri = new Uri(UriService.RunwayPage, UriKind.Relative); 
            NavigationService.Navigate(uri);
        }

        private void WindHeading_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.Vm.WindHeading = WindHeadingNumber.Text;
            var uri = new Uri(UriService.WindHeadingPage, UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        private void WindSpeed_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.Vm.WindSpeed = WindSpeedNumber.Text;
            var uri = new Uri(UriService.WindSpeedPage, UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SetupView();

            ClearBackStackToStartOfWizard();
        }

        private void SetupView()
        {
            RunwayNumber.Text = App.Vm.Runway;
            WindHeadingNumber.Text = App.Vm.WindHeading;
            WindSpeedNumber.Text = App.Vm.WindSpeed;
            CrosswindNumber.Text = App.Vm.CrosswindSpeed();
            CrosswindDirection.Text = App.Vm.CrosswindDirection();
            CrosswindDirectionBlock.Visibility = App.Vm.ShouldCrosswindDirection() ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ClearBackStackToStartOfWizard()
        {
            while (NavigationService.BackStack.Count() > 1)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri(UriService.AboutPage, UriKind.Relative));
        }
    }
}