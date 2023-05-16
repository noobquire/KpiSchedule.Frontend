namespace KpiSchedule.Frontend.ViewModels.Base
{
    public class BaseScheduleDayViewModel<TPair>
        where TPair : BaseSchedulePairViewModel
    {
        public int DayNumber { get; set; }
        public List<TPair> Pairs { get; set; }
    }
}