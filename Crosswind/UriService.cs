using Crosswind.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosswind
{
    class UriService
    {
        public static Uri MainPage = AppUri(AppUris.MainPage);
        public static Uri AboutPage = AppUri(AppUris.AboutPage);
        public static Uri RunwayPage = AppUri(AppUris.RunwayPage);
        public static Uri WindHeadingPage = AppUri(AppUris.WindHeadingPage);
        public static Uri WindSpeedPage = AppUri(AppUris.WindSpeedPage);

        internal static Uri CreateNavigationUri(Model model)
        {
            if (model.NeedsRunway())
            {
                return RunwayPage;
            }
            else if (model.NeedsWindHeading())
            {
                return WindHeadingPage;
            }
            else if (model.NeedsWindSpeed())
            {
                return WindSpeedPage;
            }
            else
            {
                return MainPage;
            }
        }

        private static Uri AppUri(string page)
        {
            return new Uri(AppUris.ViewsDir + page, UriKind.Relative);
        }
    }
}
