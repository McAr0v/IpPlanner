using IpPlanner.Design.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Design.Entries
{
    public static class EntryFrame
    {

        public static Frame GetFrameForEntry(View child) 
        {
            StackLayout entryStack = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Fill,
                Padding = new Thickness(5, 3),
                Margin = new Thickness(3, 3),
                BackgroundColor = CustomColors.BlackLight,
                Children =
                {
                    child
                }

            };

            Frame borderFrame = new Frame()
            {
                Content = entryStack,
                BackgroundColor = CustomColors.BlackLight,
                BorderColor = CustomColors.BlackLight,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 0),
                Margin = new Thickness(3, 3),
                CornerRadius = 7,

            };

            return new Frame
            {
                Content = borderFrame,
                BackgroundColor = CustomColors.Graphite,
                BorderColor = CustomColors.Graphite, // Цвет границы
                CornerRadius = 10, // Закругление углов
                HasShadow = false, // Выключаем тень, если не нужна
                Padding = new Thickness(0, 0),
                HorizontalOptions = LayoutOptions.Fill,
            };
        }
    }
}
