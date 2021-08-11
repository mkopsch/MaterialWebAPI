using System;

namespace MaterialWebAPI.Infrastructure.Repositories
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}