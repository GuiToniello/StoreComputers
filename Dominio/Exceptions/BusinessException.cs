using System;


namespace Dominio.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg) : base(msg)
        {

        }
    }
}
