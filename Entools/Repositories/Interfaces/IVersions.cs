using Entools.Model;
using Entools.Model.Requests.Versions;
using Entools.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories.Interfaces
{
    public interface IVersions
    {
        Versions Insert(VersionInsertUpdateRequest request);
        Versions Update(int id, VersionInsertUpdateRequest request);
        Versions GetById(int id);
        List<Versions> Get();
        int Delete(int id);
    }
}
