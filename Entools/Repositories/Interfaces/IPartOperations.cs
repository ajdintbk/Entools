using Entools.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories.Interfaces
{
    public interface IPartOperations
    {
        public List<Model.ViewModels.PartOperationsVM> Get(int partid);
    }
}
