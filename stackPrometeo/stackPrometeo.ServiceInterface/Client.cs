using System.Collections.Generic;
using System.Linq;
using System.Net;
using ServiceStack;
using stackPrometeo.ServiceModel;
using stackPrometeo.Services.Entities;


namespace stackPrometeo.ServiceInterface
{

    public class ClientService : Service
    {
        public ClientListing Listing { get; set; }

        public string Any(ClientInsertRequest request)
        {
            EntityClient client = new EntityClient { FirstName = request.FirstName, LastName = request.LastName, Address = request.Address, City = request.City, Country = request.Country, Zip = request.Zip, Email = request.eMail, Phone = request.Phone };

            var result = Listing.Insert(client);
            //var result = Listing.Insert(request.Client);

            if (result == 0)
                throw new HttpError(HttpStatusCode.NotFound, "food-not-found", "The requested food was not found in the listing.");

            return result.ToString();
        }

        public void Any(ClientDeleteRequest request)
        {
            Listing.Delete(request.Id);
        }


        public EntityClient Any(ClientGetRequest request)
        {
            var result = Listing.GetClient(request.Id);

            if (result == null)
                throw new HttpError(HttpStatusCode.NotFound, "food-not-found", "The requested food was not found in the listing.");

            return result;
        }

        public List<EntityClient> Any(ClientsGetsRequest request)
        {
            var results = Listing.GetAllClients();

            return results.ToList();
        }
    }
}