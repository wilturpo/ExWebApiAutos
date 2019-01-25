using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AutoService : IAutoService
    {
        IAutoRepository repository;
        public AutoService(IAutoRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<AutoDTO> GetAll()
        {
            return
           Builders.GenericBuilder.builderListEntityDTO<AutoDTO, TAuto>(repository.Items);
        }
        public async Task Insert(AutoDTO entityDTO)
        {
            var entity =
           Builders.GenericBuilder.builderDTOEntity<TAuto, AutoDTO>(entityDTO);
            await repository.Save(entity);
        }
        public async Task Update(AutoDTO entityDTO)
        {
            var entity =
           Builders.GenericBuilder.builderDTOEntity<TAuto, AutoDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
