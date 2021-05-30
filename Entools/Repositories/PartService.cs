using AutoMapper;
using Entools.Database;
using Entools.Model;
using Entools.Model.Requests.Parts;
using Entools.Model.ViewModels;
using Entools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories
{
    public class PartService : IParts
    {
        readonly EntoolsDbContext _context;
        readonly IMapper _mapper;
        public PartService(EntoolsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Delete(int id)
        {
            var part = _context.Parts.FirstOrDefault(w => w.Id == id);
            int partId = part.Id;
            if (part != null)
            {
                _context.Parts.Remove(part);
                _context.SaveChanges();
            }
            else 
                return 0;
            return partId;
        }
        public List<PartVersionsVM> GetPreview(int id)
        {
            var versions = _context.Versions.Where(w => w.PartId == id).ToList();
            var list = new List<PartVersionsVM>();

            foreach (var item in versions)
            {
                var listItem = new PartVersionsVM()
                {
                    GCode = item.GCodePath != null && item.GCodePath.Length > 0 ? true : false,
                    Name = item.Name,
                    VersionId = item.Id,
                    CreatedBy = item.CreatedBy,
                    DateCreated = item.DateCreated.ToString("dd/MM/yyyy"),
                    GCodePath = item.GCodePath == null? "" : item.GCodePath,
                    GCodeUrl = item.GCodeUrl== null ? "" : item.GCodeUrl
                };
                list.Add(listItem);
            }
            return list;

        }
        public List<Model.Parts> Get(PartSearchRequest request)
        {
            var query = _context.Parts.AsQueryable();
            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(w => w.Name.Contains(request.Name));
            if (!string.IsNullOrEmpty(request.Label))
                query = query.Where(w => w.Label.Contains(request.Label));

            return _mapper.Map<List<Model.Parts>>(query.ToList());
        }

        public Model.Parts GetById(int machineId)
        {
            return _mapper.Map<Model.Parts>(_context.Parts.FirstOrDefault(w => w.Id == machineId));
        }

        public Model.Parts Insert(PartInsertUpdateRequest request)
        {
            var partMatch = _context.Parts.FirstOrDefault(w => w.Label.ToLower() == request.Label.ToLower());
            if (partMatch != null)
                return null;

            var newPart = _mapper.Map<Database.Parts>(request);
            _context.Parts.Add(newPart);
            _context.SaveChanges();

            return _mapper.Map<Model.Parts>(newPart);
        }

        public Model.Parts Update(int id, PartInsertUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
