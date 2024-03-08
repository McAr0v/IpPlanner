using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Interfaces.AlertDialogs
{
    public interface IAlertService
    {
        Task ShowAlert(string title, string message, string buttonText);
    }
}
