using Entools.Model;
using Entools.Model.Requests.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories.Interfaces
{
    public interface IRequests
    {
        Request Insert(RequestInsertUpdateRequest request);
        Request Update(int id, RequestInsertUpdateRequest request);
        Request GetById(int machineId);
        List<Request> Get(RequestSearchRequest req);
    }
}
