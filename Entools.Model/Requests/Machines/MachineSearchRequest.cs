using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model.Requests.Machines
{
    public class MachineSearchRequest
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public int FromSpeed { get; set; }
        public int ToSpeed { get; set; }
        public int Power { get; set; }
        public int Availability { get; set; }
        public bool IsAvailable { get; set; }
    }
}
