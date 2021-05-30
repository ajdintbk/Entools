using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model.Requests.Operations
{
    public class OperationsInsertUpdateRequest
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string GCodeLocation { get; set; }
    }
}
