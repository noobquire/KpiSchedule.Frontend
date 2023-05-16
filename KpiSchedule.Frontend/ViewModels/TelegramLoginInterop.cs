using Microsoft.JSInterop;
using System.Text.Json;

namespace KpiSchedule.Frontend.ViewModels
{
    public class TelegramLoginInterop
    {
        private readonly Func<JsonElement, Task> _action;

        public TelegramLoginInterop(Func<JsonElement, Task> action)
        {
            _action = action;
        }

        [JSInvokable("LoginWithTelegram")]
        public async Task LoginWithTelegram(JsonDocument receivedTelegramInfo)
        {
            await _action.Invoke(receivedTelegramInfo.RootElement);
        }
    }
}
