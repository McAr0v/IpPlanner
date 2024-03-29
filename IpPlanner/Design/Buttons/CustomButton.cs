﻿using IpPlanner.Design.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Design.Buttons
{
    public class CustomButton: Button
    {
        public CustomButton(String text, ButtonState state) 
        {
            switch (state) 
            {
                case ButtonState.Primary:
                    {

                        BackgroundColor = CustomColors.YellowDark;
                        TextColor = CustomColors.Black;
                        break;

                    }
                case ButtonState.Secondary:
                    {

                        BackgroundColor = CustomColors.White;
                        TextColor = CustomColors.Black;
                        break;

                    }
                case ButtonState.NotActive:
                    {

                        BackgroundColor = CustomColors.Graphite;
                        TextColor = CustomColors.White;
                        break;

                    }
            }

            Text = text;
            CornerRadius = 10;
            Padding = new Thickness(20, 15);
           
        }
    }
}
