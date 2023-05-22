using KpiSchedule.Common.Entities.Student;
using KpiSchedule.Common.Models;
using KpiSchedule.Common.Parsers;
using KpiSchedule.Frontend.ViewModels.Group;

namespace KpiSchedule.Frontend.ViewModels.Student
{
    public static class StudentScheduleMapper
    {
        public static StudentScheduleViewModel MapToViewModel(this StudentScheduleEntity entity)
        {
            var viewModel = new StudentScheduleViewModel
            {
                IsPublic = entity.IsPublic,
                OwnerId = entity.OwnerId,
                ScheduleId = entity.ScheduleId,
                GrouppedFirstWeekPairs = entity.FirstWeek.GroupPairs(1),
                GrouppedSecondWeekPairs = entity.SecondWeek.GroupPairs(2)
            };
            return viewModel;
        }

        public static StudentSchedulePairViewModel MapToViewModel(this StudentSchedulePairEntity entity, PairIdentifier pairId)
        {
            var viewModel = new StudentSchedulePairViewModel
            {
                IsOnline = entity.IsOnline,
                PairType = entity.PairType.MapPairTypeToString(),
                Subject = entity.Subject.SubjectName,
                Rooms = entity.Rooms,
                Teachers = entity.Teachers.Select(t => t.TeacherName).ToList(),
                OnlineConferenceUrl = entity.OnlineConferenceUrl,
                PairId = pairId
            };
            return viewModel;
        }

        private static List<StudentSchedulePairsGroupViewModel> GroupPairs(this List<StudentScheduleDayEntity> dayEntities, int weekNumber)
        {
            var StudentpedPairs = new List<StudentSchedulePairsGroupViewModel>();
            for (int i = 0; i < 6; i++)
            {
                var pairNumber = i + 1;
                var startAndEnd = PairSchedule.GetPairStartAndEnd(pairNumber);

                var group = new StudentSchedulePairsGroupViewModel
                {
                    PairNumber = pairNumber,
                    StartTime = startAndEnd.pairStart.ToString("HH:mm"),
                    EndTime = startAndEnd.pairEnd.ToString("HH:mm"),
                };

                group.Days = dayEntities.Select(day => new StudentScheduleDayViewModel
                {
                    DayNumber = day.DayNumber,
                    Pairs = day.Pairs.Where(pair => pair.PairNumber == pairNumber).Select((pair, dupPairNumber) =>
                    {
                        var pairId = new PairIdentifier
                        {
                            WeekNumber = weekNumber,
                            DayNumber = day.DayNumber,
                            PairNumber = pairNumber,
                            DuplicatePairNumber = dupPairNumber + 1
                        };
                        return pair.MapToViewModel(pairId);
                    }).ToList()
                }).ToList();
                StudentpedPairs.Add(group);
            }
            return StudentpedPairs;
        }
    }
}
