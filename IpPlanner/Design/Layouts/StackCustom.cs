using IpPlanner.Design.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Design.Layouts
{
    public static class StackCustom
    {
        public static StackLayout CreateLayout()
        {
            return new StackLayout
            {
                BackgroundColor = CustomColors.Black,
                Padding = new Thickness(20),
                Spacing = 20
            };
        }
    }
}
