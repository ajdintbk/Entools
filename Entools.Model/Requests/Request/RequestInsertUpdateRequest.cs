using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model.Requests.Request
{
    public class RequestInsertUpdateRequest
    {
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public int VersionId { get; set; }
        public int PartId { get; set; }
        public string GCodeUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsOpened { get; set; }
    }
}
