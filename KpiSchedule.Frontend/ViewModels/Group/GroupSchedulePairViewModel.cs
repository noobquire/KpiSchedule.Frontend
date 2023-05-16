using KpiSchedule.Frontend.ViewModels.Base;

namespace KpiSchedule.Frontend.ViewModels.Group
{
    public class GroupSchedulePairViewModel : BaseSchedulePairViewModel
    {
        /// <summary>
        /// Names of teachers which conduct this pair.
        /// </summary>
        public List<string> Teachers { get; set; }
    }
}
