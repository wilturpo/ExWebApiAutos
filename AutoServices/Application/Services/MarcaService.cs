using Application.DTOs;
using Application.IServices;
//using AutoServices.Models.Repositories;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MarcaService : IMarcaService
    {
        IMarcaRepository repository;
        public MarcaService(IMarcaRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<MarcaDTO> GetAll()
        {
            return
           Builders.GenericBuilder.builderListEntityDTO<MarcaDTO, TMarca>(repository.Items);
        }
        public async Task Insert(MarcaDTO entityDTO)
        {
            var entity =
           Builders.GenericBuilder.builderDTOEntity<TMarca, MarcaDTO>(entityDTO);
            await repository.Save(entity);
        }
        public async Task Update(MarcaDTO entityDTO)
        {
            var entity =
           Builders.GenericBuilder.builderDTOEntity<TMarca, MarcaDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
