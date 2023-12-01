﻿using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Dto.ControllerDto.Admin;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppServices
{
    public interface IAdminAppServices
    {
        int FindSeller(int UserId ,CancellationToken cancellation);

        int FindBuyer(int UserId ,CancellationToken cancellation);

        List<Comment> FindCommentByUserId(int BuyerId, CancellationToken cancellation);

        List<User> FindAllSeller(CancellationToken cancellation);
        List<User> FindAllBuyer(CancellationToken cancellation);

        Task<List<ShowProductDto>> SellersProduct(int SellerId ,CancellationToken cancellation);

        Task<bool> DeleteProduct(int ProductId ,CancellationToken cancellation);
        Task<bool> DeleteComment(int CommentId ,CancellationToken cancellation);

        int ShowSellerWage(int SellerId ,CancellationToken cancellation);

        string FindUserRole(int UserId, CancellationToken cancellation);
    }
}
