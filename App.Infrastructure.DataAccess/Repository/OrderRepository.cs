using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Entities;
using App.Infrastructure.Data.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public OrderRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Order> Add(Order input, CancellationToken cancellation)
        {
            var address = await _db.orders.FirstOrDefaultAsync(x => x.Id == input.Id);

            if (address == null)
            {
                await _db.orders.AddAsync(input, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return input;
            }
            return address;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.orders.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public List<Order> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.orders.ToList();
            var mark = new List<Order>();

            mark = addresses.Where(x => x.IsDeleted == false).ToList();

            return mark;
        }

        public async Task<Order> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.orders.FirstOrDefault(x => x.Id == Id && x.IsDeleted == false);

            return address;
        }

        public async Task<bool> Update(int Id, Order input, CancellationToken cancellation)
        {
            var address = _db.orders.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = input.IsDeleted;
                address.Id = Id;
                address.BuyerId = input.BuyerId;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
