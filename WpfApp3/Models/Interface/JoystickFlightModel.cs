using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models.Interface
{
    interface JoystickFlightModel
    {
        double Throttle { get; set; }
        double Rudder { get; set; }
    }
}
