using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model.Requests.Tools
{
    public class ToolsInsertUpdateRequest
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public List<int> Operations { get; set; }
    }
}
