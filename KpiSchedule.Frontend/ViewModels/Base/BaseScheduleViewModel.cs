namespace KpiSchedule.Frontend.ViewModels.Base
{
    public class BaseScheduleViewModel<TDay, TPairGroup, TPair>
        where TDay : BaseScheduleDayViewModel<TPair>
        where TPairGroup : BaseSchedulePairsGroupViewModel<TDay, TPair>
        where TPair : BaseSchedulePairViewModel
    {
        public List<TPairGroup> GrouppedFirstWeekPairs { get; set; }
        public List<TPairGroup> GrouppedSecondWeekPairs { get; set; }

        public Guid ScheduleId { get; set; }
    }
}
