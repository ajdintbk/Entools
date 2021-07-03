using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model.ViewModels
{
    public class PartOperationsVM
    {
        public int Id { get; set; }
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public string MachineName { get; set; }
        public string ToolName { get; set; }
        public string ToolImageUrl { get; set; }
    }
}
