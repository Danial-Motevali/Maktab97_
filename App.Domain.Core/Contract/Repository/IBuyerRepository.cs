using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IBuyerRepository
    {
        Task<bool> Add(Buyer input, CancellationToken cancellation);

        //Task<bool> Update(int Id, Buyer input, CancellationToken cancellation);

        //Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Buyer> GetById(int Id, CancellationToken cancellation);

        List<Buyer> GetAll(CancellationToken cancellation);
    }
}
