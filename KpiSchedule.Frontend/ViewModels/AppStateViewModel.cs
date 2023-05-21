using Blazored.LocalStorage;
using KpiSchedule.Api.Models.Responses;
using KpiSchedule.Frontend.Client;

namespace KpiSchedule.Frontend.ViewModels
{
    public class AppStateViewModel
    {
        private bool isLoggedIn;
        public event Action AppStateChanged;

        public bool IsLoggedIn
        {
            get
            {
                return isLoggedIn;
            }
            set
            {
                isLoggedIn = value;
                AppStateChanged?.Invoke();
            }
        }
    }
}
