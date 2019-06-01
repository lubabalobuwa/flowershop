using NUnit.Framework;
using NSubstitute;
using FlowerShop;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Arrange
            IOrderDAO x = Substitute.For<IOrderDAO>(); // mock for IOrderDAO
            IClient y = Substitute.For<IClient>(); // MOCK FOR IClient 
            IOrder p = new Order(x, y);
            //Act
            p.Deliver();
            //Assert
            x.Received().SetDelivered(p);
        }
    }
}