using KpiSchedule.Frontend.ViewModels.Base;

namespace KpiSchedule.Frontend.ViewModels.Student
{
    public class StudentScheduleViewModel : BaseScheduleViewModel<StudentScheduleDayViewModel, StudentSchedulePairsGroupViewModel, StudentSchedulePairViewModel>
    {         
        public string OwnerId { get; set; }
        public bool IsPublic { get; set; }
    }
}
