using System;

namespace SuefaApp.Exceptions
{
    public class RecordDublicateException : Exception
    {
        public RecordDublicateException(string msg) : base(msg)
        {

        }
    }
}
