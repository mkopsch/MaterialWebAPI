using Raven.Client.Documents;

namespace MaterialWebAPI.Infrastructure.Context
{
    public interface IRavenDbContext
    {
        public IDocumentStore store { get;}
    }
}