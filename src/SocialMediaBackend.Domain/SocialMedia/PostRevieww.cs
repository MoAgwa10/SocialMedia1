using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SocialMediaBackend.SocialMedia
{
    public class PostRevieww: CreationAuditedEntity<Guid>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected PostRevieww() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public PostRevieww(Guid id, string reviewdetails, string reviewedby) : base(id)
        {
            ReviewDetails = reviewdetails;
            ReviewedBy = reviewedby;
            ReviewedAt = DateTime.Now;
        }
        public int Status { get; set; }
        public string ReviewDetails { get; set; }

        public string ReviewedBy { get; set; }

        public DateTime ReviewedAt { get; set; }

       
    }
}
