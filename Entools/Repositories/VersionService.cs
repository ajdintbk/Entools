using AutoMapper;
using Entools.Model;
using Entools.Model.Requests.Versions;
using Entools.Model.ViewModels;
using Entools.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories
{
    public class VersionService : IVersions
    {
        readonly Database.EntoolsDbContext _context;
        readonly IMapper _mapper;
        public VersionService(Database.EntoolsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Versions> Get()
        {
            throw new NotImplementedException();
        }

        public Versions GetById(int id)
        {
            var version = _context.Versions.FirstOrDefault(w => w.Id == id);
            return _mapper.Map<Model.Versions>(version);
        }

        public Versions Insert(VersionInsertUpdateRequest request)
        {
            var versionMatch = _context.Versions.FirstOrDefault(w => w.Name.ToLower() == request.Name.ToLower());
            if (versionMatch != null)
                return null;

            var newVersion = _mapper.Map<Database.Versions>(request);
            newVersion.DateCreated = DateTime.Now;
            newVersion.CreatedBy = "ajdin";
            _context.Versions.Add(newVersion);

            _context.SaveChanges();

            return _mapper.Map<Model.Versions>(newVersion);
        }

        public Versions Update(int id, VersionInsertUpdateRequest request)
        {
            var version = _context.Versions.FirstOrDefault(w => w.Id == id);
            if (version == null)
                return null;

            _context.Versions.Attach(version);
            _context.Versions.Update(version);

            if (!string.IsNullOrEmpty(request.GCodePath))
                version.GCodePath = request.GCodePath;
            else
                return null;

            _context.SaveChanges();

            return _mapper.Map<Model.Versions>(version);
        }
    }
}
