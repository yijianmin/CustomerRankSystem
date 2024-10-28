using System.ComponentModel;

namespace CustomerRankSystem.Core
{
    public class CustomException : Exception
    {
        public CustomException(EnumResultCode errorCode)
        {
            ErrCode = errorCode;
            ErrMsg = errorCode.Description();
        }

        public CustomException(EnumResultCode errorCode, string message) : base(string.IsNullOrWhiteSpace(message) ? $"errorCode:{errorCode}" : message)
        {
            ErrCode = errorCode;
            ErrMsg = message;
        }

        /// <summary>
        /// error code
        /// </summary>
        public EnumResultCode ErrCode { get; }

        /// <summary>
        /// error message
        /// </summary>
        public string ErrMsg { get; set; }
    }




    public enum EnumResultCode
    {
        [Description("Ok")]
        Ok = 0,

        [Description("Fail")]
        Fail = 1,

        [Description("Record does not exist")]
        Record_NotExists = 11,

        [Description("Parameter Invalid")]
        Parameter_Invalid = 100,

        [Description("Service Exception")]
        Service_Exception = 500
    }
}
