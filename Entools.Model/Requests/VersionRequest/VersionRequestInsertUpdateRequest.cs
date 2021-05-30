using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model.Requests.VersionRequest
{
    public class VersionRequestInsertUpdateRequest
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int VersionId { get; set; }
        public int OperationId { get; set; }
        public int MachineId { get; set; }
        public int ToolId { get; set; }
    }
}
