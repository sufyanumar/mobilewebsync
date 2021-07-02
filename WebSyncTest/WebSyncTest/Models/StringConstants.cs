namespace ApexChat
{
    public static class StringConstants
    {
        //Preferences keys
        public static string UserLoggedInKey = "userloggedin";
        public static string HostNameKey = "HostName";
        public static string PartnerHostNameKey = "PartnerHostName";
        public static string TokenTimeStamp = "TokenTimeStamp";
        //


        public static string OnlineString => "ONLINE";
        public static string OfflineString => "OFFLINE";
        public static string ImageStarFillWhite => "starFillWhite.png";
        public static string ImageStarEmptyWhite => "starEmptyWhite.png";
        public static string ImageIncomingChatIcon => "incomingChatIcon.png";
        public static string ImageEndChatSmall => "endChatSmall.png";
        public static string sendChatTranscriptIcon => "sendChatTranscript.png";
        public static string ImageSendToCrm => "sendToCrm.png";
        public static string ImageUserOfflineStatus => "usersOfflineStatus.png";
        public static string DefaultUserProfileImage => "admin.png";
        public static string ApplicationTag => "ApexchatApp";
        public static string VisitorDefaultName => "Chat";
        // system messages sent to the chat room
        public static string VISITORS_ARE_ALL_GONE = "All visitors have left the chat.";
        public static string SYSTEM_CHAT_ALL_USERS_HAVE_LEFT = "All users have left the chat.";
        public static string SYSTEM_CHAT_HAS_IDLED = "This chatroom has been closed due to inactivity.";
        public static string SYSTEM_CHAT_CLOSED = "The chat session has ended.";
        public static string LIVE_SESSION_ENDED = "Live Session ended";
        public static string LIVE_SESSION_STARTED = "Starting Live Session with";
        //Host Url constants
        //public static string TestHost = HostState.Test.GetHostStateDescription();
        //public static string ProductionHost = HostState.Production.GetHostStateDescription();
        //public static string BetaHost = HostState.Beta.GetHostStateDescription();
        //public static string StagingHost = HostState.Staging.GetHostStateDescription();
        //Shared Preferences
        public static string DismissKeyguard = "dismisskeyguard";
        public static string IsNewChat = "IsNewChat";
        public static string IsFullScreenChatShowing = "IsFullScreenChatShowing";
        public static string IsAppInForeground ="IsAppInForeground";
        public static string ChatRejectFromNotification = "ChatRejectFromNotification";
        public static string AskDrawOverlay = "askdrawoverlay";
        public static string TimeToPromptTheUserForUpgrade = "TimeToPromptTheUserForUpgrade";
        public static string IsSoundEnabled = "IsSoundEnabled";
        //MessagingCenter subscribing/unsubscribing and sending calls
        public static string IncomingChat = "IncomingChat";
        public const string Accept = "accept";
        public const string Reject = "reject";
        public const string ResumeChat = "resumechat";
        public const string AcceptTransfer = "accepttransfer";
        public const string RejectTransferChat = "rejecttransferchat";
        public const string UpdateApp = "updateapp";
        public const string MissedChatNotification = "MissedChatNotification";
        public static string UpdateUserDetails = "UpdateUserDetails";
        public static string SameUserLoginFromOtherDevice = "SameUserLoginFromOtherDevice";
        public static string UpdateChatValueOnSaveWhenChatEnds = "UpdateChatValueOnSaveWhenChatEnds";
        public static string UpdateRecentChatsOnChatEnded = "UpdateRecentChatsOnChatEnded";
        public static string IncomingTextMessage_ = "IncomingTextMessage_";
        public static string ChatEnded = "ChatEnded";
        public static string UpdateActiveChatLists = "UpdateActiveChatLists"; 
        public static string UpdateMessage = "UpdateMessage";
        public static string UpdateChat = "UpdateChat";
        public static string TriggerGetNotification = "TriggerGetNotification";
        public static string TransferJustOccured = "transferJustOccured";
        public static string TransferParticipantId = "transferParticipantId";
        public const string UserOnlineOfflineFlag = "useronlineofflineflag";
        //Notification Payload key names
        public static string Status = "status";
        public static string ChatId = "chatid";
        public static string Action = "action";
        public static string Phone = "phone";
        public static string VisitorName = "visitorname";
        public static string IsSmsTransferChat = "issmstransferchat";
        public static string IsDirectSmsChat = "isdirectsmschat";
        public static string VisitorLocationInfo = "visitorLocationInfo";
        public static string ChatTransferType = "chatTransferType";
        public static string IsTransferChat = "istransferChat";
        //Transfer message chat already accepted by another operator
        public static string ChatTransferRequesteAlreadyAcceptedMessage = "The chat has already been accepted by another operator.";
        public static string CannotRejectTransfer = "You are the only person available to handle the transfer. If you reject it, the visitor will not have anyone to chat with.";
        //Chat messages
        public static string SMSTransferChat = "Incoming SMS transferred chat";
        public static string SMSChat = "Incoming SMS chat";
        //User Credentials
        public static string CompanyName = "CompanyName";
        public static string UserName = "UserName";
        public static string Password = "Password";
        //Internet Connectivity
        public static string IsConnectedToTheInternet = "IsConnectedToTheInternet";
    }
}
