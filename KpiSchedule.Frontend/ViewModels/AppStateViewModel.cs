using Blazored.LocalStorage;
using KpiSchedule.Api.Models.Responses;
using KpiSchedule.Frontend.Client;

namespace KpiSchedule.Frontend.ViewModels
{
    public class AppStateViewModel
    {
        private bool isLoggedIn;
        public event Action AppStateChanged;
        public event Action ScheduleUpdated;

        public string LoggedInUserId { get; set; }

        public bool IsLoggedIn
        {
            get
            {
                return isLoggedIn;
            }
            set
            {
                isLoggedIn = value;
                StateHasChanged();
            }
        }

        public void StateHasChanged()
        {
            AppStateChanged?.Invoke();
        }

        public void ScheduleWasUpdated()
        {
            ScheduleUpdated?.Invoke();
        }
    }
}
