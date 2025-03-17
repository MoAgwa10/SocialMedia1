using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

public class PostCommentHistory : CreationAuditedEntity<Guid>
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    protected PostCommentHistory() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public PostCommentHistory(Guid id, ulong version, string text, List<string> images):base(id)
    {
        Version = version;
        Text = text;
        Images = images;
    }

    public ulong Version { get; set; }
    public string Text { get; set; }
    public List<string> Images { get; set; }
}
