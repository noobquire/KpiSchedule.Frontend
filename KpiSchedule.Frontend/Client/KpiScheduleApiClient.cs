using Blazored.LocalStorage;
using KpiSchedule.Api.Models.Requests;
using KpiSchedule.Api.Models.Responses;
using KpiSchedule.Common.Clients;
using KpiSchedule.Common.Entities.Base;
using KpiSchedule.Common.Entities.Group;
using KpiSchedule.Common.Entities.Student;
using KpiSchedule.Common.Entities.Teacher;
using Serilog.Core;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace KpiSchedule.Frontend.Client
{
    public class KpiScheduleApiClient : BaseClient
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;

        public KpiScheduleApiClient(IHttpClientFactory clientFactory, ILocalStorageService localStorage) : base(Logger.None)
        {
            httpClient = clientFactory.CreateClient(nameof(KpiScheduleApiClient));
            this.localStorage = localStorage;
        }

        public void ClearHeaders()
        {
            httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task SetAuthenticationHeader()
        {
            var authToken = await localStorage.GetItemAsync<JwtTokenResponse>("token");
            if (authToken == null) return;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken.Token);
        }

        public async Task<JwtTokenResponse> AuthenticateTelegramUser(TelegramAuthenticationRequest request)
        {
            var requestApi = "login/telegram";
            var telegramAuthJson = JsonSerializer.Serialize(request);
            var requestContent = new StringContent(telegramAuthJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(requestApi, requestContent);
            var token = await VerifyAndParseResponseBody<JwtTokenResponse>(response);

            return token;
        }

        public async Task<GroupScheduleEntity> GetGroupSchedule(Guid scheduleId)
        {
            var requestApi = $"schedules/group/{scheduleId}";

            var response = await httpClient.GetAsync(requestApi);
            var schedule = await VerifyAndParseResponseBody<GroupScheduleEntity>(response);

            return schedule;
        }

        public async Task<List<SubjectEntity>> GetSubjectsInGroupSchedule(Guid scheduleId)
        {
            var requestApi = $"schedules/group/{scheduleId}/subjects";

            var response = await httpClient.GetAsync(requestApi);
            var subjects = await VerifyAndParseResponseBody<List<SubjectEntity>>(response);

            return subjects;
        }

        public async Task<List<TeacherEntity>> GetTeachersInGroupSchedule(Guid scheduleId)
        {
            var requestApi = $"schedules/group/{scheduleId}/teachers";

            var response = await httpClient.GetAsync(requestApi);
            var teachers = await VerifyAndParseResponseBody<List<TeacherEntity>>(response);

            return teachers;
        }

        public async Task<List<GroupScheduleSearchResult>> SearchGroupSchedules(string groupNamePrefix)
        {
            var requestApi = $"schedules/group/search?groupNamePrefix={groupNamePrefix}";

            var response = await httpClient.GetAsync(requestApi);
            var searchResults = await VerifyAndParseResponseBody<List<GroupScheduleSearchResult>>(response);

            return searchResults;
        }

        public async Task<TeacherScheduleEntity> GetTeacherSchedule(Guid scheduleId)
        {
            var requestApi = $"schedules/teacher/{scheduleId}";

            var response = await httpClient.GetAsync(requestApi);
            var schedule = await VerifyAndParseResponseBody<TeacherScheduleEntity>(response);

            return schedule;
        }

        public async Task<List<SubjectEntity>> GetSubjectsInTeacherSchedule(Guid scheduleId)
        {
            var requestApi = $"schedules/teacher/{scheduleId}/subjects";

            var response = await httpClient.GetAsync(requestApi);
            var subjects = await VerifyAndParseResponseBody<List<SubjectEntity>>(response);

            return subjects;
        }

        public async Task<List<TeacherScheduleSearchResult>> SearchTeacherSchedules(string teacherNamePrefix)
        {
            var requestApi = $"schedules/teacher/search?teacherNamePrefix={teacherNamePrefix}";

            var response = await httpClient.GetAsync(requestApi);
            var searchResults = await VerifyAndParseResponseBody<List<TeacherScheduleSearchResult>>(response);

            return searchResults;
        }

        public async Task<StudentScheduleEntity> GetStudentSchedule(Guid scheduleId)
        {
            var requestApi = $"schedules/student/{scheduleId}";

            var response = await httpClient.GetAsync(requestApi);
            var schedule = await VerifyAndParseResponseBody<StudentScheduleEntity>(response);

            return schedule;
        }

        public async Task<List<SubjectEntity>> GetSubjectsInStudentSchedule(Guid scheduleId)
        {
            var requestApi = $"schedules/student/{scheduleId}";

            var response = await httpClient.GetAsync(requestApi);
            var subjects = await VerifyAndParseResponseBody<List<SubjectEntity>>(response);

            return subjects;
        }

        public async Task<StudentScheduleEntity> CreateStudentScheduleFromGroupSchedule(CreateStudentScheduleRequest requestModel)
        {
            var requestApi = "schedules/student";

            var requestModelJson = JsonSerializer.Serialize(requestModel);
            var requestContent = new StringContent(requestModelJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(requestApi, requestContent);
            var schedule = await VerifyAndParseResponseBody<StudentScheduleEntity>(response);

            return schedule;
        }

        public async Task<StudentScheduleEntity> DeleteSchedulePair(Guid scheduleId, DeleteSchedulePairRequest requestModel)
        {
            var requestApi = $"schedules/student/{scheduleId}/pair?week={requestModel.Week}&day={requestModel.Day}&pair={requestModel.Pair}&dupPair={requestModel.DupPair}";

            var response = await httpClient.DeleteAsync(requestApi);
            var updatedSchedule = await VerifyAndParseResponseBody<StudentScheduleEntity>(response);

            return updatedSchedule;
        }

        public async Task<StudentScheduleEntity> UpdateSchedulePair(Guid scheduleId, UpdateSchedulePairRequest requestModel)
        {
            var requestApi = $"schedules/student/{scheduleId}/pair";

            var requestModelJson = JsonSerializer.Serialize(requestModel);
            var requestContent = new StringContent(requestModelJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(requestApi, requestContent);
            var updatedSchedule = await VerifyAndParseResponseBody<StudentScheduleEntity>(response);

            return updatedSchedule;
        }

        public async Task<List<StudentScheduleSearchResult>> GetSchedulesForStudent(string userId)
        {
            var requestApi = $"student/{userId}/schedules";

            var response = await httpClient.GetAsync(requestApi);
            var schedules = await VerifyAndParseResponseBody<List<StudentScheduleSearchResult>>(response);

            return schedules;
        }

        public async Task DeleteStudentSchedule(Guid scheduleId)
        {
            var requestApi = $"schedules/student/{scheduleId}";

            var response = await httpClient.DeleteAsync(requestApi);
            await CheckIfSuccessfulResponse(response, requestApi);
        }
    }
}
