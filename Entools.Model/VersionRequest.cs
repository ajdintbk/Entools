using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model
{
    public class VersionRequest
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public int OperationId { get; set; }
        public Operations Operation { get; set; }
        public int MachineId { get; set; }
        public Machines Machine { get; set; }
        public int ToolId { get; set; }
        public Tools Tool { get; set; }
    }
}
