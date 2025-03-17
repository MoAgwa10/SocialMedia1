using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

public class PostComment : FullAuditedAggregateRoot<Guid>
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    protected PostComment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public PostComment(Guid id, Guid postId, Guid? parentCommentId,  PostCommentHistory initialHistory):base(id)
    {
        PostId = postId;
        ParentCommentId = parentCommentId;
        Likes = 0;
        CommentCount = 0;
        History = [initialHistory];
    }

    public Guid PostId { get; set; }
    public Guid? ParentCommentId { get; set; }
    public ulong Likes { get; set; }

    public ulong CommentCount { get; set; }

    public List<PostCommentHistory> History { get; set; }
}
