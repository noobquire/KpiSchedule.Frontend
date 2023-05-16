using KpiSchedule.Common.Entities.Group;
using KpiSchedule.Common.Parsers;

namespace KpiSchedule.Frontend.ViewModels.Group
{
    public static class GroupScheduleMapper
    {
        public static GroupScheduleViewModel MapToViewModel(this GroupScheduleEntity entity)
        {
            var viewModel = new GroupScheduleViewModel
            {
                GroupName = entity.GroupName,
                ScheduleId = entity.ScheduleId,
                GrouppedFirstWeekPairs = entity.FirstWeek.GroupPairs(),
                GrouppedSecondWeekPairs = entity.SecondWeek.GroupPairs()
            };
            return viewModel;
        }

        public static GroupSchedulePairViewModel MapToViewModel(this GroupSchedulePairEntity entity)
        {
            var viewModel = new GroupSchedulePairViewModel
            {
                IsOnline = entity.IsOnline,
                PairType = entity.PairType.MapPairType(),
                Subject = entity.Subject.SubjectName,
                Rooms = entity.Rooms,
                Teachers = entity.Teachers.Select(t => t.TeacherName).ToList()
            };
            return viewModel;
        }

        public static string MapPairType(this string pairType)
        {
            return pairType switch
            {
                "prac" => "Практика",
                "lecture" => "Лекція",
                "lab" => "Лабораторна"
            };
        }

        private static List<GroupSchedulePairsGroupViewModel> GroupPairs(this List<GroupScheduleDayEntity> dayEntities)
        {
            var grouppedPairs = new List<GroupSchedulePairsGroupViewModel>();
            for (int i = 0; i < 6; i++)
            {
                var pairNumber = i + 1;
                var startAndEnd = PairSchedule.GetPairStartAndEnd(pairNumber);

                var group = new GroupSchedulePairsGroupViewModel
                {
                    PairNumber = pairNumber,
                    StartTime = startAndEnd.pairStart.ToString("HH:mm"),
                    EndTime = startAndEnd.pairEnd.ToString("HH:mm"),
                };

                group.Days = dayEntities.Select(day => new GroupScheduleDayViewModel
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
