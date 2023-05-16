using KpiSchedule.Frontend.ViewModels.Base;

namespace KpiSchedule.Frontend.ViewModels.Group
{
    public class GroupScheduleViewModel : BaseScheduleViewModel<GroupScheduleDayViewModel, GroupSchedulePairsGroupViewModel, GroupSchedulePairViewModel>
    {         
        public string GroupName { get; set; }
    }
}
