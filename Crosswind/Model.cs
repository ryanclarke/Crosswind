using Crosswind.Resources;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosswind
{
    public class Model
    {
        public string Runway { get; set; }
        public string WindHeading { get; set; }
        public string WindSpeed { get; set; }

        public bool NeedsRunway()
        {
            return string.IsNullOrWhiteSpace(Runway);
        }

        public bool NeedsWindHeading()
        {
            return string.IsNullOrWhiteSpace(WindHeading);
        }

        public bool NeedsWindSpeed()
        {
            return string.IsNullOrWhiteSpace(WindSpeed);
        }

        public string CrosswindSpeed()
        {
            int runway;
            int windHeading;
            int windSpeed;

            bool possible = true;
            possible &= int.TryParse(Runway, out runway);
            possible &= int.TryParse(WindHeading, out windHeading);
            possible &= int.TryParse(WindSpeed, out windSpeed);

            if (possible)
            {
                return string.Format("{0:0}", Math.Abs(Math.Sin(ToRad(runway) - ToRad(windHeading)) * windSpeed));
            }
            else
            {
                return ".";
            }
        }

        public string CrosswindDirection()
        {
            int runway;
            int windHeading;
            int windSpeed;

            bool possible = true;
            possible &= int.TryParse(Runway, out runway);
            possible &= int.TryParse(WindHeading, out windHeading);
            possible &= int.TryParse(WindSpeed, out windSpeed);

            if (possible)
            {
                if (Math.Abs(windHeading - runway) % 18 == 0)
                {
                    return ".";
                }
                else if ((windHeading - runway + 36) % 36 < 18)
                {
                    return AppResources.Right;
                }
                else
                {
                    return AppResources.Left;
                }
            }
            else
            {
                return ".";
            }
        }

        private double ToRad(double degrees)
        {
            return (double)MathHelper.ToRadians((float)(degrees * 10.0));
        }

        internal bool ShouldCrosswindDirection()
        {
            var speed = CrosswindSpeed();
            return speed != "0" && speed != ".";
        }
    }
}
