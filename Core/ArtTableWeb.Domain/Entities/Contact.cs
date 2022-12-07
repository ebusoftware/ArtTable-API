using ArtTableWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Domain.Entities
{
    public class Contact:BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set;}
        public string Message { get; set;}
        public bool Status { get; set; }

    }
}
