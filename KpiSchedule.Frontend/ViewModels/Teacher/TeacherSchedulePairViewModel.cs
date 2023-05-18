using KpiSchedule.Frontend.ViewModels.Base;

namespace KpiSchedule.Frontend.ViewModels.Teacher
{
    public class TeacherSchedulePairViewModel : BaseSchedulePairViewModel
    {
        /// <summary>
        /// Names of teachers which conduct this pair.
        /// </summary>
        public List<string> Groups { get; set; }
    }
}
