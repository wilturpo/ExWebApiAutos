using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServices.Models.Repositories
{
    public class EFMarcaRepository : IMarcaRepository
    {
        public IQueryable<TMarca> Items => context.TMarca;
        private AutoDbContext context;

        public EFMarcaRepository(AutoDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TMarca marca)
        {
            if (marca.MarcaId == Guid.Empty)
            {
                marca.MarcaId = Guid.NewGuid();
                context.TMarca.Add(marca);
            }
            else
            {
                TMarca dbEntry = context.TMarca
                .FirstOrDefault(p => p.MarcaId == marca.MarcaId);
                if (dbEntry != null)
                {
                    dbEntry.MarcaNombre = marca.MarcaNombre;
                }
            }
            await context.SaveChangesAsync();
        }
        public void Delete(Guid MarcaId)
        {
            TMarca dbEntry = context.TMarca
            .FirstOrDefault(p => p.MarcaId == MarcaId);
            if (dbEntry != null)
            {
                context.TMarca.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
