using KpiSchedule.Common.Entities.Teacher;
using KpiSchedule.Common.Parsers;
using KpiSchedule.Frontend.ViewModels.Group;

namespace KpiSchedule.Frontend.ViewModels.Teacher
{
    public static class TeacherScheduleMapper
    {
        public static TeacherScheduleViewModel MapToViewModel(this TeacherScheduleEntity entity)
        {
            var viewModel = new TeacherScheduleViewModel
            {
                TeacherName = entity.TeacherName,
                ScheduleId = entity.ScheduleId,
                GrouppedFirstWeekPairs = entity.FirstWeek.GroupPairs(),
                GrouppedSecondWeekPairs = entity.SecondWeek.GroupPairs()
            };
            return viewModel;
        }

        public static TeacherSchedulePairViewModel MapToViewModel(this TeacherSchedulePairEntity entity)
        {
            var viewModel = new TeacherSchedulePairViewModel
            {
                IsOnline = entity.IsOnline,
                PairType = entity.PairType.MapPairTypeToString(),
                Subject = entity.Subject.SubjectName,
                Rooms = entity.Rooms,
                Groups = entity.Groups.Select(t => t.GroupName).ToList()
            };
            return viewModel;
        }

        private static List<TeacherSchedulePairsGroupViewModel> GroupPairs(this List<TeacherScheduleDayEntity> dayEntities)
        {
            var grouppedPairs = new List<TeacherSchedulePairsGroupViewModel>();
            for (int i = 0; i < 6; i++)
            {
                var pairNumber = i + 1;
                var startAndEnd = PairSchedule.GetPairStartAndEnd(pairNumber);

                var group = new TeacherSchedulePairsGroupViewModel
                {
                    PairNumber = pairNumber,
                    StartTime = startAndEnd.pairStart.ToString("HH:mm"),
                    EndTime = startAndEnd.pairEnd.ToString("HH:mm"),
                };

                group.Days = dayEntities.Select(day => new TeacherScheduleDayViewModel
                {
                    DayNumber = day.DayNumber,
                    Pairs = day.Pairs.Where(pair => pair.PairNumber == pairNumber).Select(pair => pair.MapToViewModel()).ToList()
                }).ToList();
                grouppedPairs.Add(group);
            }
            return grouppedPairs;
        }
    }
}
