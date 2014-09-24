using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosswind
{
    class UriService
    {
        private static string ViewsDir = "/Views";

        public static string MainPage = ViewsDir + "/MainPage.xaml";
        public static string AboutPage = ViewsDir + "/AboutPage.xaml";
        public static string RunwayPage = ViewsDir + "/RunwayPage.xaml";
        public static string WindHeadingPage = ViewsDir + "/WindHeadingPage.xaml";
        public static string WindSpeedPage = ViewsDir + "/WindSpeedPage.xaml";

        internal static Uri CreateNavigationUri(Model model)
        {
            if (model.NeedsRunway())
            {
                return new Uri(RunwayPage, UriKind.Relative);
            }
            else if (model.NeedsWindHeading())
            {
                return new Uri(WindHeadingPage, UriKind.Relative);
            }
            else if (model.NeedsWindSpeed())
            {
                return new Uri(WindSpeedPage, UriKind.Relative);
            }
            else
            {
                return new Uri(MainPage, UriKind.Relative);
            }
        }
    }
}
