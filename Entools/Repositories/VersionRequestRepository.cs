using AutoMapper;
using Entools.Model;
using Entools.Model.Requests.VersionRequest;
using Entools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories
{
    public class VersionRequestRepository : IVersionRequest
    {
        readonly Database.EntoolsDbContext _context;
        readonly IMapper _mapper;
        public VersionRequestRepository(Database.EntoolsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<VersionRequest> Get(int requestId)
        {
            if(requestId != 0)
            {
                var list = _context.VersionRequests.Include(i=>i.Operation).Include(i=>i.Tool).Include(i=>i.Request).Include(i=>i.Machine).Where(w => w.RequestId == requestId).ToList();
            return _mapper.Map<List<Model.VersionRequest>>(list);
            }
            else
            {
                var list = _context.VersionRequests.Include(i => i.Operation).Include(i => i.Tool).Include(i => i.Request).Include(i => i.Machine).ToList();
            return _mapper.Map<List<Model.VersionRequest>>(list);

            }
        }

        public VersionRequest Insert(VersionRequestInsertUpdateRequest request)
        {
            var newItem = _mapper.Map<Database.VersionRequest>(request);
            _context.VersionRequests.Add(newItem);
            _context.SaveChanges();
            return _mapper.Map<Model.VersionRequest>(newItem);
        }

        public VersionRequest Update(int id, VersionRequestInsertUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
