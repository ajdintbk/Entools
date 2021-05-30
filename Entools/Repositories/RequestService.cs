using AutoMapper;
using Entools.Model;
using Entools.Model.Requests.Request;
using Entools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories
{
    public class RequestService : IRequests
    {
        readonly Database.EntoolsDbContext _context;
        readonly IMapper _mapper;
        public RequestService(Database.EntoolsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Request> Get()
        {
            return _mapper.Map<List<Model.Request>>(_context.Requests.ToList());
        }

        public Request GetById(int requestId)
        {
            return _mapper.Map<Model.Request>(_context.Requests.Include(i=>i.Part).FirstOrDefault(w => w.Id == requestId));

        }

        public Request Insert(RequestInsertUpdateRequest request)
        {
            var req = _mapper.Map<Database.Request>(request);
            _context.Requests.Add(req);
            _context.SaveChanges();

            return _mapper.Map<Model.Request>(req);
        }

        public Request Update(int id, RequestInsertUpdateRequest request)
        {
            var requestMatch = _context.Requests.FirstOrDefault(w => w.Id == id);
            if (requestMatch == null)
                return null;

            _context.Requests.Attach(requestMatch);
            _context.Requests.Update(requestMatch);

            _mapper.Map(request, requestMatch);

            _context.SaveChanges();

            return _mapper.Map<Model.Request>(requestMatch);
        }
    }
}
