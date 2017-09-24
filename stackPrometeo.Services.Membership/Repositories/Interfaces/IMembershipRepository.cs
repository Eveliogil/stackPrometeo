using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stackPrometeo.Services.Entities;

namespace stackPrometeo.Services.Membership.Repositories.Interfaces
{
    public interface IMembershipRepository
    {
        List<EntityClient> Gets();

        EntityClient Get(int id);

        void Delete(int id);

        int Insert(EntityClient client);
    }
}
