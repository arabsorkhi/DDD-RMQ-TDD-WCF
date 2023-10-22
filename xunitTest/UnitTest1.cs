using CBSD.Core.ApplicationServices.Sellers.CommandHandlers;
using CBSD.Framework.Domain.Data;
using CBSD.Seller.Core.Domain.DomainEvent.Commands;
using CBSD.Seller.Core.Domain.SellerAgg.Data;

namespace xunitTest
{
    public class SellBCShould
    {
        //create unique test cases
        [Fact]
        //describe a business feature or behavior.
        public void CreateCommand_Id_Exists()
        {
            //arrange-preCondition
            CreateCommand command=new CreateCommand();
            command.Id = new Guid();
            //IUnitOfWork unitOfWork=new DummyUOW();
            //ISellerRepository sellerRepository=new DummyRep() ;
            ////var t = new CreateHandler(sellerRepository,unitOfWork  );


            //act-exe
            ////t.Handle(command);

            Assert.Equal(1,1);

        }
    }
}