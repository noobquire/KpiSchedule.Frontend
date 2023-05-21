using KpiSchedule.Common.Entities.Base;

namespace KpiSchedule.Frontend.ViewModels.Student
{
    public class CreateStudentScheduleViewModel
    {
        public string ScheduleName { get; set; }

        public List<SubjectEntity> Subjects { get; set; }
        public List<SubjectEntity> SelectedSubjects { get; set; } = new List<SubjectEntity>();

        public CreateStudentScheduleViewModel(List<SubjectEntity> subjects)
        {
            Subjects = subjects;
        }
    }
}
