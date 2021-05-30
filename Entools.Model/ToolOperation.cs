using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model
{
    public class ToolOperation
    {
        public int ToolOperationId { get; set; }
        public int ToolId { get; set; }
        public Tools Tool { get; set; }
        public int Operationid { get; set; }
        public Operations Operaton { get; set; }
    }
}
