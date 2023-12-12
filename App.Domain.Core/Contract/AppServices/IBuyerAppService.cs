using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppServices
{
    public interface IBuyerAppService
    {
        Task<List<BuyerSearchDto>> Search(string UserName, CancellationToken cancellation);

        Task<bool> AddToCart(Buyer buyer ,int ProductId, int CartId, CancellationToken cancellation);

        Buyer FindBuyer(int UserId, CancellationToken cancellation);

        Task<List<AuctionDto>> Action(CancellationToken cancellation);

        Task<bool> AddNewPrice(int UserId, int newPrice, int AuctionId, CancellationToken cancellation);

        Task<List<BuyerCartDto>> Cart(Buyer buyer, CancellationToken cancellation);

        Task<bool> AddOrder(List<BuyerCartDto> input, CancellationToken cancellation);

        Task<List<Comment>> ShowComment(Buyer Buyer, CancellationToken cancellation);

        Task<bool> AddComment(Comment input, CancellationToken cancellation);

        Task<List<BuyerCartDto>> OrderetProdut(Buyer input, CancellationToken cancellation);

        Task<bool> DeleteComment(int CommentId, CancellationToken cancellation);

        Task<List<BuyerSearchDto>> ShowAllProduct(CancellationToken cancellation);

        Task<List<ProductHistoryDto>> FuildBuyerDto(int UserId, CancellationToken cancellation);
    }
}
