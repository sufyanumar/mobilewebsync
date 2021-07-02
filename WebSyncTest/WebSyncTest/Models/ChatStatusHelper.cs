using ApexChat.Enums;
using ApexChat.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
namespace ApexChat.Core.Helpers
{
    public static class ChatStatusHelper
    {
        /// <summary>
        /// Get the chat message status by comparing message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static TextChatStatus GetChatMessageStatus(string message)
        {
            TextChatStatus status = TextChatStatus.None;
            if (message.Equals(StringConstants.VISITORS_ARE_ALL_GONE) ||
               message.Equals(StringConstants.SYSTEM_CHAT_ALL_USERS_HAVE_LEFT) ||
               message.Equals(StringConstants.LIVE_SESSION_ENDED) ||
               message.StartsWith(StringConstants.LIVE_SESSION_STARTED))
            {
                status = TextChatStatus.VisitorLeft;
            }
            else if (message.Equals(StringConstants.SYSTEM_CHAT_CLOSED) || message.Equals(StringConstants.SYSTEM_CHAT_HAS_IDLED))
            {
                status = TextChatStatus.End;
            }
            return status;
        }
        /// <summary>
        /// Get visitor default name for unknown visitor
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        //public static string GetVisitorDefaultName(int chatId,bool isSms = false, string phoneNumber = "")
        //{
        //    //If the Chat is based on SMS, the default visitor title would be the phone number.
        //    if (isSms & !string.IsNullOrEmpty(phoneNumber))
        //    {
        //        return phoneNumber.FormatPhoneNumber();
        //    }
        //    //else use the Chat ID convention like this Chat # 349
        //    else
        //    {
        //        return string.Format("{0} #{1}", StringConstants.VisitorDefaultName, (chatId % 1000).ToString("D3"));
        //    }           
        //}
    }
}
