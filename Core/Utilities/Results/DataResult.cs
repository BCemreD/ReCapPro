//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Core.Utilities.Results
//{
//    public class DataResult<T>:Results, IDataResult<T>
//    {
//        public DataResult(T data, bool success, string message): base(success, message)
//        {
//            data = data;
//        }
//        public DataResult(T data, bool success): base(success)
//        {
//            data = data;
//        }
//        public T Data { get; }
//    }
//}
