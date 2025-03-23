using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SocialMediaBackend.SocialMedia
{
    public class Images : CreationAuditedEntity<Guid>
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Images()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        public Images(Guid id, string name, float height,float width, string url) : base(id)
        {
            Width = width;
            Height = height;
            Name = name;
            Url = url;
        }
        public string Name { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Url { get; set; }
    }
 }
