﻿using System;
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
        private Model model;

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
            StatusRunwayNumber.Text = model.NeedsRunway() ? "__" : model.Runway;
            StatusWindHeadingNumber.Text = model.NeedsWindHeading() ? "__" : model.WindHeading;
            StatusWindSpeedNumber.Text = model.NeedsWindSpeed() ? "__" : model.WindSpeed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            model = UrlService.ExtractModelFromQueryString(NavigationContext.QueryString);
            SetupStatusHeader();

            base.OnNavigatedTo(e);
        }

        private void Digit1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit1.Text.Any())
            {
                Digit2.Focus();
                Underscore1.Fill = new SolidColorBrush(Colors.White);
                Underscore2.Fill = App.Current.Resources["WindSpeedColor"] as SolidColorBrush;
            }
        }

        private void Digit2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Digit2.Text.Any())
            {
                Underscore2.Fill = new SolidColorBrush(Colors.White);

                model.WindSpeed = EnteredWindSpeed();
                var uri = UrlService.CreateNavigationUri(model);
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