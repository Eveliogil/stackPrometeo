using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using stackPrometeo.ServiceModel;
using stackPrometeo.ServiceInterface;
using stackPrometeo.Services.Entities;


namespace stackPrometeo.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;


        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(ClientService).Assembly)
            {
                ConfigureContainer = container =>
                {
                    
                    //container.Register(_ => new ClientListing());
                }
            }
            .Init();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        //[Test]
        //public void Test_Method1()
        //{
        //    var service = appHost.Container.Resolve<ClientDetailsService>();

        //    var response = (EntityClient)service.Any(new ClientDetailsRequest { FistName = "Evelio", LastName="Gil" });

        //    Assert.That(response.FirstName, Is.EqualTo("Evelio"));
        //}

     /*   [Test]
        public void Test_InsertClient()
        {
                var service = appHost.Container.Resolve<ClientInsertService>();

                EntityClient client = new EntityClient { FirstName = "Evelio", LastName = "Gonzalez", Address = "Los Frailes",  City = "Pampatar", Country = "Vzla", Zip = 6300, Email= "evelio.gil@gmail.com", Phone="407 8833119" };

                var response = (int)service.Any(new ClientInsertRequest { Client = client });

                Assert.AreNotEqual(0, response);
        }*/
    }
}
