using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Design.TextWidgets
{
    public static class TextWidget
    {
        public static Label GetTextWidget(string text, Color color, TextState state, bool cut = false) 
        { 
            return new Label()
            {
                Text = text,
                TextColor = color,
                FontSize = GetFontSize(state),
                LineBreakMode = !cut ? LineBreakMode.WordWrap : LineBreakMode.NoWrap,
                FontFamily = GetFontFamily(state),
                LineHeight = GetLineHeight(state),
            }; 
        }

        private static double GetLineHeight(TextState state)
        {
            switch (state)
            {
                case TextState.HeadlineBig:
                    return 0.7;
                case TextState.HeadlineMedium:
                    return 0.9;
                case TextState.HeadlineSmall:
                    return 0.9;
                case TextState.BodyBig:
                    return 1;
                case TextState.BodyMedium:
                    return 1;
                case TextState.BodySmall:
                    return 1;
                case TextState.DescBig:
                    return 1;
                case TextState.DescMedium:
                    return 1;
                case TextState.DescSmall:
                    return 1;
                default:
                    return 1; // Значение по умолчанию
            }
        }

        private static string GetFontFamily(TextState state)
        {
            //

            switch (state)
            {
                case TextState.HeadlineBig:
                case TextState.HeadlineMedium:
                case TextState.HeadlineSmall:
                    return "sfprodisplay_black";
                default:
                    return "sfprodisplay_regular";
            }

        }

        /*private static FontAttributes GetFontWeight(TextState state)
        {
            switch (state)
            {
                case TextState.HeadlineBig:
                case TextState.HeadlineMedium:
                case TextState.HeadlineSmall:
                    return FontAttributes.Bold;
                default:
                    return FontAttributes.None;
            }
        }*/

        private static double GetFontSize(TextState state)
        {
            switch (state)
            {
                case TextState.HeadlineBig:
                    return 45;
                case TextState.HeadlineMedium:
                    return 20;
                case TextState.HeadlineSmall:
                    return 16;
                case TextState.BodyBig:
                    return 18;
                case TextState.BodyMedium:
                    return 16;
                case TextState.BodySmall:
                    return 14;
                case TextState.DescBig:
                    return 14;
                case TextState.DescMedium:
                    return 12;
                case TextState.DescSmall:
                    return 10;
                default:
                    return 16; // Значение по умолчанию
            }
        }
    }
}
