using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApexChat.Models;
using Newtonsoft.Json;

namespace ApexChat.Helpers.Extensions
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<ApiResult<T>> ToServiceResult<T>(this HttpResponseMessage response)
        {
            try
            {
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResult<T>>(responseContent);
                return result;
            }
            catch (Exception e)
            {
                return new ApiResult<T>(false, e.Message, default(T));
            }
        }
    }
}

