using Entools.Model;
using Entools.Model.Requests.Parts;
using Entools.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories.Interfaces
{
    public interface IParts
    {
        Parts Insert(PartInsertUpdateRequest request);
        Parts Update(int id, PartInsertUpdateRequest request);
        Parts GetById(int id);
        List<Parts> Get(PartSearchRequest request);
        List<PartVersionsVM> GetPreview(int id);
        int Delete(int id);


    }
}
