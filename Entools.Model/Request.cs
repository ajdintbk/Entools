using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int VersionId { get; set; }
        public Versions Version { get; set; }
        public int PartId { get; set; }
        public Parts Part { get; set; }
        public string CreatedBy { get; set; }
        public string GCodeUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsOpened { get; set; }
    }
}
