using System;
using System.Collections.Generic;
using System.Linq;
using stackPrometeo.Services.Entities;
using stackPrometeo.Services.Membership;


public class ClientListing //: List<EntityClient>
{
    MembershipService memberService = new MembershipService();

    public IEnumerable<EntityClient> GetAllClients()
    {
        return memberService.Gets().AsEnumerable<EntityClient>();
        //return this.AsEnumerable();
    }

    public EntityClient GetClient(int id)
    {
        return memberService.Get(id);
        //return this.FirstOrDefault(x => (String.Equals(firstName, x.FirstName, StringComparison.OrdinalIgnoreCase) && String.Equals(lastName, x.LastName, StringComparison.OrdinalIgnoreCase)));
    }

    public int Insert(EntityClient client)
    {
        return memberService.Insert(client);
    }


    public void Delete(int id)
    {
        memberService.Delete(id);
    }
}