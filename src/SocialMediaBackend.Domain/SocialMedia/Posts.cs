using System;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;
using SocialMediaBackend.SocialMedia;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Guids;

public class Posts:FullAuditedAggregateRoot<Guid>
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
   
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Posts() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


        public Posts(Guid id, string content, List<Images>? images) : base(id)
        {

            Date = DateTime.Now;
            Content = content;
            if (images != null) { Images = images; } 
            Review = null;
            Status = new PostStatus(Guid.NewGuid(), 0, 0, 0);
        }

        public DateTime Date { get; set; }

        public string Content { get; set; }
        public PostStatus? Status { get; set; }

        public PostRevieww? Review { get; set; }

        public List<Images>? Images { get; set; }

  }





