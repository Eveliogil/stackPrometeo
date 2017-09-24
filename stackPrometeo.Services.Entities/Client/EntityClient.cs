
namespace stackPrometeo.Services.Entities
{
    public class EntityClient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int Zip { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }



        public EntityClient() { }

        public EntityClient(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }


    }
}

