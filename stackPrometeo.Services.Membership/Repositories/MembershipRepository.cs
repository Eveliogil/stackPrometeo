using System;
using System.Collections.Generic;
using stackPrometeo.Services.Membership.Repositories.Interfaces;
using stackPrometeo.Services.Entities;
using stackPrometeo.Services.Membership.Repositories.Builders;

using stackPrometeo.Data.Repository;


namespace stackPrometeo.Services.Membership.Repositories
{
    public class MembershipRepository : RepositoryBase, IMembershipRepository
    {
        public MembershipRepository(): base("stackPrometeo.User.DataBase") {}

        public void Delete(int id)
        {
            Connection.Execute("User_Delete", id);
        }

        public EntityClient Get(int id)
        {
            ClientBuilder builder = new ClientBuilder();

            return Connection.GetSingle<EntityClient>("User_Get", builder.Build, id);
        }

        public List<EntityClient> Gets()
        {
            ClientBuilder builder = new ClientBuilder();

            return Connection.GetList("User_Gets", builder.Build);
        }

        public int Insert(EntityClient client)
        {
            object id = Connection.GetScalar<object>("User_Insert", client.FirstName, client.LastName, client.Address, client.City, client.Zip, client.Country, client.Email, client.Phone);

            return int.Parse(id.ToString());
        }
    }


}
