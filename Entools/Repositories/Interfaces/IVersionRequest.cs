using Entools.Model;
using Entools.Model.Requests.VersionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories.Interfaces
{
    public interface IVersionRequest
    {
        VersionRequest Insert(VersionRequestInsertUpdateRequest request);
        VersionRequest Update(int id, VersionRequestInsertUpdateRequest request);
        List<VersionRequest> Get(int requestId);
    }
}
