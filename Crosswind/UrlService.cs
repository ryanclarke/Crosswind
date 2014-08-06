using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosswind
{
    class UrlService
    {
        private static string Runway = "Runway";
        private static string WindHeading = "WindHeading";
        private static string WindSpeed = "WindSpeed";

        public static string MainPage = "/MainPage.xaml";
        public static string RunwayPage = "/RunwayPage.xaml";
        public static string WindHeadingPage = "/WindHeadingPage.xaml";
        public static string WindSpeedPage = "/WindSpeedPage.xaml";

        public static Model ExtractModelFromQueryString(IDictionary<string, string> queryString)
        {
            var model = new Model();

            if (queryString.ContainsKey(Runway))
            {
                model.Runway = queryString[Runway];
            }
            if (queryString.ContainsKey(WindHeading))
            {
                model.WindHeading = queryString[WindHeading];
            }
            if (queryString.ContainsKey(WindSpeed))
            {
                model.WindSpeed = queryString[WindSpeed];
            }

            return model;
        }

        internal static Uri CreateNavigationUri(Model model)
        {
            if (model.NeedsRunway())
            {
                return CreateNavigationUri(RunwayPage, model);
            }
            else if (model.NeedsWindHeading())
            {
                return CreateNavigationUri(WindHeadingPage, model);
            }
            else if (model.NeedsWindSpeed())
            {
                return CreateNavigationUri(WindSpeedPage, model);
            }
            else
            {
                return CreateNavigationUri(MainPage, model);
            }
        }

        internal static Uri CreateNavigationUri(string page, Model model)
        {
            var pathBuilder = new StringBuilder(page);
            pathBuilder.Append("?");
            pathBuilder.Append(string.Format("{0}={1}", Runway, model.Runway));
            pathBuilder.Append("&");
            pathBuilder.Append(string.Format("{0}={1}", WindHeading, model.WindHeading));
            pathBuilder.Append("&");
            pathBuilder.Append(string.Format("{0}={1}", WindSpeed, model.WindSpeed));

            return new Uri(pathBuilder.ToString(), UriKind.Relative);
        }
    }
}
