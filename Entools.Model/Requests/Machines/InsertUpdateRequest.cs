using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model.Requests.Machines
{
    public class InsertUpdateRequest
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
        public bool ToggleAvailability { get; set; }
    }
}
