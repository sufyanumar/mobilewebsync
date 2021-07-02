using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace ApexChat.Services.Remote
{
    [Headers("Accept: application/json")]
    public interface IApexChatApi
    {
        [Post("/Services/ApexChatService.svc/textchats/{chatId}/history")]
        Task<HttpResponseMessage> TextChatHistory(string chatId);

    }
}