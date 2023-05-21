using KpiSchedule.Frontend.ViewModels.Base;

namespace KpiSchedule.Frontend.ViewModels.Student
{
    public class StudentSchedulePairViewModel : BaseSchedulePairViewModel
    {
        /// <summary>
        /// Names of teachers which conduct this pair.
        /// </summary>
        public List<string> Teachers { get; set; }

        public string OnlineConferenceUrl { get; set; }
    }

}
