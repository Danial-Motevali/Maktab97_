using App.Domain.Core.Models.Identity.Entites;
using App.Infrastructure.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Maktab97_.Test
{
    public class RepositoryTests
    {
        private readonly BuyerRepository buyerRepository;
        public RepositoryTests(BuyerRepository buyerRepository)
        {
            this.buyerRepository = buyerRepository;
        }

        [Fact]
        public void BuyerRepository_Add_ReturnTrue()
        {
            var inputAddress = new Buyer { UserId = 4};
            var cancatiol = new CancellationToken();

            buyerRepository.Add(inputAddress, cancatiol);
        }
    }
}
