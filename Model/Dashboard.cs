using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace LaundryApps.Model
{
    class Dashboard
    {

        public string ToIDR(string data)
        {
            return String.Format(CultureInfo.CreateSpecificCulture("id-ID"), "Rp. {0:N}", data);
        }
    }
}
