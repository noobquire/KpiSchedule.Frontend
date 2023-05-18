using KpiSchedule.Frontend.ViewModels.Base;

namespace KpiSchedule.Frontend.ViewModels.Teacher
{
    public class TeacherScheduleViewModel : BaseScheduleViewModel<TeacherScheduleDayViewModel, TeacherSchedulePairsGroupViewModel, TeacherSchedulePairViewModel>
    {         
        public string TeacherName { get; set; }
    }
}
