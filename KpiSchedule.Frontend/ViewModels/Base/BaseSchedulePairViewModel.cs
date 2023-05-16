namespace KpiSchedule.Frontend.ViewModels.Base
{
    public class BaseSchedulePairViewModel
    {
        /// <summary>
        /// Pair type: lec/prac/lab
        /// </summary>
        public string PairType { get; set; }

        /// <summary>
        /// Boolean indicating if pair occurs online.
        /// </summary>
        public bool IsOnline { get; set; }

        /// <summary>
        /// Pair subject name.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Room(s) where pair occurs.
        /// </summary>
        public List<string> Rooms { get; set; }
    }
}