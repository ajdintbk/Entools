using Entools.Model;
using Entools.Model.Requests.Machines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories.Interfaces
{
    public interface IMachines
    {
        Machines Insert(InsertUpdateRequest request);
        Machines Update(int id, InsertUpdateRequest request);
        Machines GetById(int machineId);
        List<Machines> Get(MachineSearchRequest request);
    }
}
