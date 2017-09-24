using System.Data;
using stackPrometeo.Services.Entities;
using stackPrometeo.Data.Library;

namespace stackPrometeo.Services.Membership.Repositories.Builders
{
    public class ClientBuilder
    {
        public EntityClient Build(IDataReader reader)
        {
            return new EntityClient
            {
                Id = reader.GetData<int>("Id"),

                FirstName = reader.GetData<string>("FirstName"),

                LastName = reader.GetData<string>("LastName"),

                Address = reader.GetData<string>("Address"),

                City = reader.GetData<string>("City"),

                Zip = reader.GetData<int>("Zip"),

                Country = reader.GetData<string>("Country"),

                Email = reader.GetData<string>("email"),

                Phone = reader.GetData<string>("Phone")
            };
        }
    }
}
