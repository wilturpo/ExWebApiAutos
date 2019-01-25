using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServices.Models.Repositories
{
    public class EFAutoRepository : IAutoRepository
    {
        public IQueryable<TAuto> Items => context.TAuto;
        private AutoDbContext context;

        public EFAutoRepository(AutoDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TAuto auto)
        {
            if (auto.AutoId == Guid.Empty)
            {
                auto.AutoId = Guid.NewGuid();
                context.TAuto.Add(auto);
            }
            else
            {
                TAuto dbEntry = context.TAuto
                .FirstOrDefault(p => p.AutoId == auto.AutoId);
                if (dbEntry != null)
                {
                    dbEntry.AutoColor = auto.AutoColor;
                    dbEntry.AutoAnioFabricacion = auto.AutoAnioFabricacion;
                    dbEntry.AutoNroPlaca = auto.AutoNroPlaca;
                    dbEntry.AutoNroAsientos = auto.AutoNroAsientos;
                    dbEntry.AutoMecanico = auto.AutoMecanico;
                    dbEntry.AutoFull = auto.AutoFull;
                    dbEntry.MarcaId = auto.MarcaId;
                }
            }
            await context.SaveChangesAsync();
        }
        public void Delete(Guid AutoId)
        {
            TAuto dbEntry = context.TAuto
            .FirstOrDefault(p => p.AutoId == AutoId);
            if (dbEntry != null)
            {
                context.TAuto.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
