using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Interfaces.AlertDialogs
{
    public class AlertService : IAlertService
    {
        public async Task ShowAlert(string title, string message, string buttonText)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
        }
    }
}
