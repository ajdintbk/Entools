using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model
{
    public class PartVersions
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public Parts Part { get; set; }
        public int VersionId { get; set; }
        public Version Version { get; set; }

    }
}
