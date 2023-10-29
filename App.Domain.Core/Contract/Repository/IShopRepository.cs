﻿using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IShopRepository
    {
        Task<bool> Add(ShopDtoInput shopInput);

        Task<bool> Update(int Id, ShopDtoInput shopInput);

        Task<bool> Delete(int Id);

        Task<ShopDtoOutput> GetById(int Id);

        Task<List<ShopDtoOutput>> GetAll();
    }
}