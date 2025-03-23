using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace SocialMediaBackend.SocialMedia
{
    public class PostStatus : CreationAuditedEntity<Guid>
    {
        protected PostStatus() { }

        public PostStatus(Guid id, ulong likes, ulong comments, ulong shares) : base(id)
        {
            Likes = 0;
            Comments = 0;
            Shares = 0;
        }
        public ulong Likes { get; set; }

        public ulong Comments { get; set; }

        public ulong Shares { get; set; }
    }

}
