using System;
using System.Collections.Generic;
using System.Linq;
using MaterialWebAPI.Domain.Entities;

namespace MaterialWebAPI.Infrastructure.Context
{
    public class MockDbContext : IMockDbContext
    {
        
        private List<Material> _localStore;
        public List<Material> store => _localStore;
        public MockDbContext()
        {

          EnsureDatabaseIsCreated();  
        }

        public void EnsureDatabaseIsCreated() {
            
            
            try
            {
                  
                _localStore.Add(new Material ()
                {
                    Id = "First",
                    Name = "First Material",
                    IsVisible = true,
                    TypeOfPhase = "solid",
                    MaterialFunction = new MaterialFunction {MinTemperature = 23.4, MaxTemperature = 56.8}

                });

            
            }
            catch(Exception ex)
            {

                _localStore = new List<Material>();

                _localStore.Add(new Material ()
                    {
                        Id = "First",
                        Name = "First Material",
                        IsVisible = true,
                        TypeOfPhase = "solid",
                        MaterialFunction = new MaterialFunction {MinTemperature = 23.4, MaxTemperature = 56.8}

                    });
            }
        }
    }
}