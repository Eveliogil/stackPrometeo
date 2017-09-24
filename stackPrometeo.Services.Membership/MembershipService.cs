using System.Collections.Generic;
using System.ServiceModel;

using stackPrometeo.Services.Membership.Repositories.Interfaces;
using stackPrometeo.Services.Membership.Repositories;
using stackPrometeo.Services.Entities;

namespace stackPrometeo.Services.Membership
{
    [ServiceBehavior()]
    public class MembershipService
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipService()
            : this(new MembershipRepository())
        {
        }

        public MembershipService(IMembershipRepository repository)
        {
            _membershipRepository = repository;
        }

        public List<EntityClient> Gets()
        {
            return _membershipRepository.Gets();
        }

        public EntityClient Get(int id)
        {
            return _membershipRepository.Get(id);
        }

        public int Insert(EntityClient client)
        {
            return _membershipRepository.Insert(client);
        }

        public void Delete (int id)
        {
            _membershipRepository.Delete(id);
        }
    }
}
