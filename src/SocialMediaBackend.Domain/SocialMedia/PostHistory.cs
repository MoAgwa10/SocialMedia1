using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

public class PostHistory: CreationAuditedEntity<Guid>
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    protected PostHistory()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {

    }
    public PostHistory(Guid id, ulong version, string text, List<Guid> images):base(id)
    {
        Version = version;
        Text = text;
        Images = images;
    }


    public ulong Version { get; set; }
	public string Text { get; set; }
	public List<Guid> Images { get; set; }
}
