using System.ComponentModel;

namespace CustomerRankSystem.Core
{
    public class OutputResult
    {
        public EnumResultCode Code { get; set; }

        public string Message { get; set; }

        public OutputResult()
        {
            Code = EnumResultCode.Ok;
            Message = string.Empty;
        }

        public OutputResult(EnumResultCode resultCode, string msg)
        {
            Code = resultCode;
            Message = msg;
        }
    }

    public class OutputResult<T> : OutputResult
    {
        public OutputResult(T data = default)
        {
            Data = data;
        }

        public T Data { get; set; }

    }
}
