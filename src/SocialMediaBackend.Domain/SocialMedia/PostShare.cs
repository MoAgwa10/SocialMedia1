using System;
using Volo.Abp.Domain.Entities.Auditing;

public class PostShare : CreationAuditedEntity<Guid>
{
    protected PostShare() { }

    public PostShare(Guid id):base(id) 
    {
        
    }
}