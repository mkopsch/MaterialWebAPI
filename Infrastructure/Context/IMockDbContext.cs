using System.Collections.Generic;
using MaterialWebAPI.Domain.Entities;

namespace MaterialWebAPI.Infrastructure.Context
{
    public interface IMockDbContext
    {
         List<Material> store {get;}
    }
}