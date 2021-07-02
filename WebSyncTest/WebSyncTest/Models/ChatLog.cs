using System;
using System.Runtime.Serialization;

namespace WebSyncTest.Models
{
    /// <summary>
    /// A message within a chat
    /// </summary>
    [DataContract(Name = "chatLog")]
    public class ChatLog 
    {
        /// <summary>
        /// The id of the chat log, so we can avoid duplicates under specific scenarios
        /// </summary>
        [DataMember(Name = "id")]
        public int ID { get; set; }

        /// <summary>
        /// The chat to which this log belongs
        /// </summary>
        [DataMember(Name = "chatId")]
        public int ChatID { get; set; }

        /// <summary>
        /// For tracking purposes, the id of the chat participant
        /// </summary>
        [DataMember(Name = "participantId")]
        public int ParticipantID { get; set; }

        /// <summary>
        /// For tracking purposes, the id of the user; this will be zero for the visitors
        /// </summary>
        [DataMember(Name = "userId")]
        public int UserID { get; set; }

        /// <summary>
        /// For display purposes, we need to know who sent a given message
        /// </summary>
        [DataMember(Name = "participantDisplayName")]
        public string ParticipantDisplayName { get; set; }

        /// <summary>
        /// The actual text of the message
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "originalText")]
        public string OriginalText { get; set; }

        [DataMember(Name = "translatedText")]
        public string TranslatedText { get; set; }

        [DataMember(Name = "originalTextLanguage")]
        public string OriginalTextLanguage { get; set; }

        [DataMember(Name = "translatedTextLanguage")]
        public string TranslatedTextLanguage { get; set; }

        /// <summary>
        /// The date this log was created
        /// </summary>
        [DataMember(Name = "createdOn")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Is this a greeting
        /// </summary>
        [DataMember(Name = "isGreeting")]
        public bool IsGreeting { get; set; }

        /// <summary>
        /// This property carries masked message
        /// </summary>
        [DataMember(Name = "maskedText")]
        public string MaskedText { get; set; }

        /// <summary>
        /// This property carries random numbers for masking
        /// </summary>
        [DataMember(Name = "randomNumber")]
        public string RandomNumber { get; set; }

        /// <summary>
        /// The value that references a Virtual Assistant artifact associated with this ChatLog
        /// </summary>
        [DataMember(Name = "virtualAssistantReference")]
        public string VirtualAssistantReference { get; set; }

        /// <summary>
        /// For tracking script question
        /// </summary>
        [DataMember(Name = "scriptAnswerId")]
        public int ScriptAnswerID { get; set; }

        [DataMember(Name = "questionType")]
        public short QuestionType { get; set; }

        [DataMember(Name = "visitorResponseType")]
        public int VisitorResponseType { get; set; }

        [DataMember(Name = "questionTypeDelaySeconds ")]
        public int QuestionTypeDelaySeconds { get; set; }

        [DataMember(Name = "options")]
        public string Options { get; set; }

        [DataMember(Name = "visitorResponseStatus")]
        public short VisitorResponseStatus { get; set; }

        [DataMember(Name = "questionTypeDisplayListForVisitor")]
        public bool QuestionTypeDisplayListForVisitor { get; set; }

        [DataMember(Name = "questionTypeChatLogIdToBeUpdated")]
        public int? QuestionTypeChatLogIdToBeUpdated { get; set; }

        [DataMember(Name = "questionTypeResponseChatLogId")]
        public int? QuestionTypeResponseChatLogId { get; set; }

        /// <summary>
        /// Is this message unread
        /// </summary>
        [DataMember(Name = "isUnread")]
        public bool? IsUnread { get; set; }

        [DataMember(Name = "visitorSelectedOptions")]
        public string VisitorSelectedOptions { get; set; }

        [DataMember(Name = "isChatEnded")]
        public bool isChatEnded { get; set; }

        [DataMember(Name = "isTranslating")]
        public bool IsTranslating { get; set; }

        [DataMember(Name = "messageSequence")]
        public string MessageSequence { get; set; }

        [DataMember(Name = "isNextQuestionMapped")]
        public bool IsNextQuestionMapped { get; set; }

        [DataMember(Name = "isFromPreChat")]
        public bool IsFromPreChat { get; set; }

        [DataMember(Name = "shouldShowChatEndedMessage")]
        public bool ShouldShowChatEndedMessage { get; set; }

        [DataMember(Name = "systemMessageType")]
        public int? SystemMessageType { get; set; }

        [DataMember(Name = "hasCallConnectAction")]
        public bool HasCallConnectAction { get; set; }
        [DataMember(Name = "isCallConnectAvailable")]
        public bool IsCallConnectAvailable { get; set; }
        [DataMember(Name = "hasNextCallConnectAction")]
        public bool HasNextCallConnectAction { get; set; }
        [DataMember(Name = "isNextCallConnectAvailable")]
        public bool IsNextCallConnectAvailable { get; set; }

        [DataMember(Name = "isPredefinedPokeMessage")]
        public bool IsPredefinedPokeMessage { get; set; }

        [DataMember(Name = "isPredefinedResponse")]
        public bool IsPredefinedResponse { get; set; }
    }

}
