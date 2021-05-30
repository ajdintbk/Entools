using Entools.Model;
using Entools.Model.Requests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories.Interfaces
{
    public interface ITools
    {
        Tools Insert(ToolsInsertUpdateRequest request);
        Tools Update(int id, ToolsInsertUpdateRequest request);
        Tools GetById(int machineId);
        List<Tools> Get(ToolsSearchRequest request);

    }
}
