using System.ComponentModel;

namespace ApexChat.Enums
{
    public enum TextChatStatus
    {
        [Description("")]
        None = 0,
        [Description("start")]
        Start = 1,
        [Description("end")]
        End = 2,
        [Description("disassociate")]
        Disassociate = 3,
        [Description("usertyping")]
        UserTyping = 4,
        [Description("visitorleft")]
        VisitorLeft = 5,
        [Description("transferRequest")]
        TransferRequest = 6,
        [Description("useronlineoffline")]
        UserOnlineOffline
    }
}
