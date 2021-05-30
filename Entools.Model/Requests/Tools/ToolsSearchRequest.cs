using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model.Requests.Tools
{
    public class ToolsSearchRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int OperationId { get; set; }
        public string OperationName { get; set; }

    }
}
