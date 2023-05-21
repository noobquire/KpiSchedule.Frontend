using KpiSchedule.Common.Entities.Base;

namespace KpiSchedule.Frontend.ViewModels.Student
{
    public class CreateStudentScheduleViewModel
    {
        public List<SubjectEntity> Subjects { get; set; }
        public List<SubjectEntity> SelectedSubjects { get; set; } = new List<SubjectEntity>();

        public bool PubliclyVisible { get; set; } = false;

        public CreateStudentScheduleViewModel(List<SubjectEntity> subjects)
        {
            Subjects = subjects;
        }
    }
}
