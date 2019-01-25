using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAutoService
    {
        Task Insert(AutoDTO entityDTO);
        IList<AutoDTO> GetAll();
        Task Update(AutoDTO entityDTO);
        void Delete(Guid entityId);
    }
}
