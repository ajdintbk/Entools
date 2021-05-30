using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Database
{
    public class ToolOperations
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public Tools Tool { get; set; }
        public int Operationid { get; set; }
        public Operations Operation { get; set; }

    }
}
