﻿
namespace BancoDadosTest.Application.CustonException
{
    public class RegraNegocioException : Exception
    {
        public RegraNegocioException() { }

        public RegraNegocioException(string message)
            : base(message) { }

        public RegraNegocioException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
