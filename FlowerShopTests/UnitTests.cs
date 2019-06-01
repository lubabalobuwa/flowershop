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

        [Test]
        public void Test2()
        {
            //Arrange 
            IOrderDAO x = Substitute.For<IOrderDAO>(); // mock for IOrderDAO
            IClient y = Substitute.For<IClient>(); // MOCK FOR IClient 

            Order p = new Order(x, y);
            IFlower f = Substitute.For<IFlower>();
            f.Cost.Returns(20);
            IFlower ff = Substitute.For<IFlower>();
            ff.Cost.Returns(30);
            IFlower fff = Substitute.For<IFlower>();
            fff.Cost.Returns(10);
            p.AddFlowers(f, 1);
            p.AddFlowers(ff, 1);
            p.AddFlowers(fff, 1);

            //Act
            double price = p.Price;
            //Assert 
            Assert.AreEqual((0.2 * 20)+(0.2*10)+(0.2*30), price);
        }
    }
}