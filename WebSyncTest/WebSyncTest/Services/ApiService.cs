using ApexChat.Helpers.Extensions;
using ApexChat.Models;
using ApexChat.Services.Remote;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSyncTest.Services
{
    public class ApiService
    {
        private IApexChatApi ApexChatApi { get; set; }
        private HttpClient HttpClientInstance { get; set; }
        public ApiService()
        {
            HttpClientInstance = new HttpClient(new AuthenticatedHttpClientHandler()) { BaseAddress = new Uri(App.ServiceBaseUrl) };
            ApexChatApi = RestService.For<IApexChatApi>(HttpClientInstance);
        }

        public async Task<ApiResult<List<ChatResponse>>> TextChatHistoryList(string chatId)
        {
            ApiResult<List<ChatResponse>> result;

            try
            {
                var response = await ApexChatApi.TextChatHistory(chatId);
                result = await response.ToServiceResult<List<ChatResponse>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.GetType().ToString()} > TextChatHistoryList()", "Error getting chat history list.", ex);
                result = new ApiResult<List<ChatResponse>>(false, $"Error getting chat history list, {ex.Message}.", null);
            }

            return result;
        }
        internal class AuthenticatedHttpClientHandler : HttpClientHandler
        {
            public AuthenticatedHttpClientHandler() { }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                //if (Workflow.Current.AuthModel != null && Workflow.Current.AuthModel.Credentials != null)
                {
                    //var credentials = Workflow.Current.AuthModel.Credentials;
                    //Add headers for service call
                    request.Headers.Add("apexchat-username", App.User);
                    request.Headers.Add("apexchat-company", App.Company);
                    request.Headers.Add("apexchat-password", App.Password);
                }
                var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                return response;
            }
        }
    }
}
