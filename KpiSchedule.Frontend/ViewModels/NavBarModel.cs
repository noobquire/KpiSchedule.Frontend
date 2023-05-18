namespace KpiSchedule.Frontend.ViewModels
{
    public class NavBarModel
    {
        private bool displayPersonalSchedule = false;
        public bool DisplayPersonalSchedule
        {
            get
            {
                return displayPersonalSchedule;
            }
            set
            {
                displayPersonalSchedule = value;
                Changed?.Invoke();
            }
        }
        public Action Changed { get; set; }
    }
}
