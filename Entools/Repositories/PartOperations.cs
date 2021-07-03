using AutoMapper;
using Entools.Model.ViewModels;
using Entools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories
{
    public class PartOperations : IPartOperations
    {
        readonly Database.EntoolsDbContext _context;
        readonly IMapper _mapper;
        public PartOperations(Database.EntoolsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<PartOperationsVM> Get(int partid)
        {
            var list = _context.VersionOperations.Include(i=>i.Machine).Include(i=>i.Operation).Include(i=>i.Tool).Where(w => w.PartId == partid).ToList();
            if (list.Count == 0)
                return null;
            List<PartOperationsVM> returnList = new List<PartOperationsVM>();
            foreach (var item in list)
            {
                PartOperationsVM vmItem = new PartOperationsVM()
                {
                    Id = item.Id,
                    OperationId = item.OperationId,
                    MachineName = item.Machine.Name,
                    OperationName = item.Operation.Name,
                    ToolImageUrl = item.Tool.ImagePath,
                    ToolName = item.Tool.Name
                };
                returnList.Add(vmItem);
            }
            return returnList;
        }
    }
}
