using System;

namespace SuefaApp.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg)
        {

        }
    }
}
