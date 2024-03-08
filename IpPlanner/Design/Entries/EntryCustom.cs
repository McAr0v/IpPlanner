using IpPlanner.Design.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Design.Entries
{
    public static class EntryCustom
    {
        public static Entry CreateNewEntry(string textInPlaceholder, bool isEmail = false, bool isPassword = false) 
        {
            Entry entry = new Entry() 
            {
                Placeholder = textInPlaceholder,
                TextColor = CustomColors.White,
                PlaceholderColor = CustomColors.GreyLight,
                IsTextPredictionEnabled = false,
            };

            entry.IsPassword = isPassword;

            if (isEmail) 
            {
                entry.Keyboard = Keyboard.Email;
            }

            return entry;

        }
    }
}
