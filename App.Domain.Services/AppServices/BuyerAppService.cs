using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppServices
{
    public class BuyerAppService : IBuyerAppService
    {
        private readonly IUserServices _userServices;
        private readonly ISellerService _sellerService;
        private readonly IInventoryService _inventoryService;
        private readonly IShopService _shopService;
        private readonly IProductPictureService _productPictureService;
        private readonly IPictureService _pictureService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IPriceService _priceService;
        public BuyerAppService(
             IPriceService priceService 
            ,ICategoryService categoryService
            , IPictureService pictureService
            , IProductPictureService productPictureService
            , IProductService productService
            ,  IShopService shopService
            , IInventoryService inventoryService
            , ISellerService sellerService
            , IUserServices userServices)
        {
            _userServices = userServices;
            _sellerService = sellerService;
            _inventoryService = inventoryService;
            _shopService = shopService;
            _productPictureService = productPictureService;
            _pictureService = pictureService;
            _categoryService = categoryService;
            _productService = productService;
            _priceService = priceService;
        }


        public async Task<List<BuyerSearchDto>> Search(string UserName, CancellationToken cancellation)
        {
            var searchDto = new List<BuyerSearchDto>();
            

            return searchDto;
        }
    }
}
