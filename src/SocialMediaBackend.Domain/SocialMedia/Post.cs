using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Guids;

public class Post:FullAuditedAggregateRoot<Guid>
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    protected Post()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {

	}

	public Post(Guid id ,PostHistory initialHistory):base(id)
	{
		Likes = 0;
		CommentCount = 0;
		History = [initialHistory];
		Share = [];

	}

	

//	public  Guid Id { get; set; }
	//Likes
	public ulong Likes { get; set; }

	public ulong CommentCount { get; set; }
	//Shares&shareLinkes
	public ulong Shares { get; set; }

    public List<PostHistory> History { get; set; }

    public List<PostShare> Share { get; set; }
}
