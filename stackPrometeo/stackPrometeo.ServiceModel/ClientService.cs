using System.Collections.Generic;
using stackPrometeo.Services.Entities;
using ServiceStack;

namespace stackPrometeo.ServiceModel
{
    [Route("/allclient")] // maps the URI to the request model
    public class ClientsGetsRequest : IReturn<List<EntityClient>>
    {
        
    }
    

    [Route("/GetClient/{Id}")]
    //[Route("/client/details")]
    public class ClientGetRequest : IReturn<EntityClient>
    {
        public int Id { get; set; }
    }

    [Route("/DeleteClient/{Id}")]
    public class ClientDeleteRequest
    {
        public int Id { get; set; }
    }

    [Route("/InsertClient/{FirstName}/{LastName}/{Address}/{City}/{Zip}/{Country}/{eMail}/{Phone}")]
    public class ClientInsertRequest : IReturn<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string Country { get; set; }
        public string eMail { get; set; }
        public string Phone { get; set; }


        //public EntityClient Client { get; set; }
        
        

        //public EntityClient Get([FromUri] Client client { get; set; }

        //LOOOKKKK
    }


}
