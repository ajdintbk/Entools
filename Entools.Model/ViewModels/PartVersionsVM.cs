using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model.ViewModels
{
    public class PartVersionsVM
    {
        public int VersionId { get; set; }
        public string Name { get; set; }
        public bool GCode { get; set; }
        public string DateCreated { get; set; }
        public string CreatedBy{ get; set; }
        public string GCodePath { get; set; }
        public string GCodeUrl { get; set; }
    }
}
