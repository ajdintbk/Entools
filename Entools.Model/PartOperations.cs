using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model
{
    public class PartOperations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PartId { get; set; }
        public Parts Part{ get; set; }
        public int OperationId { get; set; }
        public Operations Operation { get; set; }
        public int MachineId { get; set; }
        public Machines Machine { get; set; }
        public int ToolId { get; set; }
        public Tools Tool { get; set; }

    }
}
