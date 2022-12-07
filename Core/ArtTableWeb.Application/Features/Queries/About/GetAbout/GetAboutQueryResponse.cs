using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.About.GetAbout
{
    public class GetAboutQueryResponse
    {
        public string AboutId { get; set; }
        public string Details { get; set; }
        public string MapLocation { get; set; }
        public bool Status { get; set; }
    }
}
