using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IWageService
    {
        Task<bool> Add(Wage input, CancellationToken cancellation);

        Task<bool> Update(int Id, Wage input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Wage> GetById(int Id, CancellationToken cancellation);

        List<Wage> GetAll(CancellationToken cancellation);
    }
}
