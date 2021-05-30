using AutoMapper;
using Entools.Database;
using Entools.Model;
using Entools.Model.Requests.Tools;
using Entools.Model.ViewModels;
using Entools.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories
{
    public class ToolsService : ITools
    {
        readonly EntoolsDbContext _context;
        readonly IMapper _mapper;
        public ToolsService(EntoolsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Tools> Get(ToolsSearchRequest request)
        {
            return _mapper.Map<List<Model.Tools>>(_context.Tools.ToList());
        }

        public Model.Tools GetById(int machineId)
        {
            throw new NotImplementedException();
        }
        
        public Model.Tools Insert(ToolsInsertUpdateRequest request)
        {
            if (_context.Tools.FirstOrDefault(w => w.Name.ToLower() == request.Name.ToLower()) != null)
                return null;

            var newTool = _mapper.Map<Database.Tools>(request);
            _context.Tools.Add(newTool);
            _context.SaveChanges();
            foreach (var item in request.Operations)
            {
                var newToolsOperations = new Database.ToolOperations()
                {
                    Operationid = item,
                    ToolId = newTool.Id
                };
                _context.ToolOperations.Add(newToolsOperations);
            }
            _context.SaveChanges();
            return _mapper.Map<Model.Tools>(newTool);
        }

        public Model.Tools Update(int id, ToolsInsertUpdateRequest request)
        {
            var tool = _context.Tools.FirstOrDefault(w => w.Id == id);
            if (tool == null)
                return null;

            tool.Label = request.Label;
            tool.Name = request.Name;
            _context.Tools.Attach(tool);
            _context.Tools.Update(tool);
            _context.SaveChanges();

            return _mapper.Map<Model.Tools>(tool);
        }
    }
}
