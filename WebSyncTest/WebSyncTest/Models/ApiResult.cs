using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ApexChat.Models
{
    public class ApiResult<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        public ApiResult(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
    public class FilterParam 
    {
        [JsonProperty("propertyName")]
        public string PropertyName { get; set; }

        [JsonProperty("propertyValue1")]
        public string PropertyValue1 { get; set; }

        [JsonProperty("propertyValue2")]
        public string PropertyValue2 { get; set; }

        [JsonProperty("propertyValue3")]
        public List<string> PropertyValue3 { get; set; }

        [JsonProperty("comparison")]
        public int Comparison { get; set; }

        [JsonProperty("filterDataType")]
        public int FilterDataType { get; set; }

        [JsonProperty("filterColumnName")]
        public string FilterColumnName { get; set; }
    }
    public enum FilterDataType
    {
        Int = 1,
        String = 2,
        Float = 3,
        Date = 4

    }
    public enum Comparison
    {
        Equals,
        NotEquals,
        Like,
        NotLike,
        GreaterThan,
        GreaterOrEquals,
        LessThan,
        LessOrEquals,
        Blank,
        Is,
        IsNot,
        In,
        NotIn,
        OpenParentheses,
        CloseParentheses,
        BetweenAnd,
        Contains
    }

}
