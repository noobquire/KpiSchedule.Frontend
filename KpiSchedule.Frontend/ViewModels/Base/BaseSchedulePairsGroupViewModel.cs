namespace KpiSchedule.Frontend.ViewModels.Base
{
    public class BaseSchedulePairsGroupViewModel<TDay, TPair>
        where TDay : BaseScheduleDayViewModel<TPair>
        where TPair : BaseSchedulePairViewModel
    {
        /// <summary>
        /// 1-based pair number.
        /// </summary>
        public int PairNumber { get; set; }

        /// <summary>
        /// Pair start time in HH:mm format
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Pair end time in HH:mm format
        /// </summary>
        public string EndTime { get; set; }

        public List<TDay> Days { get; set; }
    }
}
