using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IMarcaService
    {
        Task Insert(MarcaDTO entityDTO);
        IList<MarcaDTO> GetAll();
        Task Update(MarcaDTO entityDTO);
        void Delete(Guid entityId);
    }
}
