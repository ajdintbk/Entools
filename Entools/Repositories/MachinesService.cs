using AutoMapper;
using Entools.Database;
using Entools.Model;
using Entools.Model.Requests.Machines;
using Entools.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories
{
    public class MachinesService : IMachines
    {
        readonly EntoolsDbContext _context;
        readonly IMapper _mapper;
        public MachinesService(EntoolsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        List<Model.Machines> IMachines.Get(MachineSearchRequest request)
        {
            var query = _context.Machines.AsQueryable();
            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(w => w.Name.Contains(request.Name));
            if (!string.IsNullOrEmpty(request.Label))
                query = query.Where(w => w.Label.Contains(request.Label));
            if ((request.FromSpeed >=0 && request.ToSpeed >0) && (request.FromSpeed <= request.ToSpeed))
                query = query.Where(w => w.Speed >= request.FromSpeed && w.Speed <= request.ToSpeed);
            if (request.Power > 0)
                query = query.Where(w => w.Power == request.Power);
            if (request.Availability > 0)
                query = query.Where(w => request.Availability == 1? w.IsAvailable == true : w.IsAvailable == false);

            return _mapper.Map<List<Model.Machines>>(query.ToList());
        }

        Model.Machines IMachines.GetById(int machineId)
        {
            return _mapper.Map<Model.Machines>(_context.Machines.FirstOrDefault(w => w.Id == machineId));
        }

        Model.Machines IMachines.Insert(InsertUpdateRequest request)
        {
            var machineMatch = _context.Machines.FirstOrDefault(w => w.Label.ToLower() == request.Label.ToLower());
            if (machineMatch != null)
                return null;

            var newMachine = _mapper.Map<Database.Machines>(request);
            _context.Machines.Add(newMachine);
            _context.SaveChanges();

            return _mapper.Map<Model.Machines>(newMachine);
        }

        Model.Machines IMachines.Update(int id, InsertUpdateRequest request)
        {
            var machine = _context.Machines.FirstOrDefault(w => w.Id == id);
            if (machine == null)
                return null;

            _context.Machines.Attach(machine);
            _context.Machines.Update(machine);

            if (request.ToggleAvailability)
                machine.IsAvailable = request.IsAvailable;
            else
                _mapper.Map(request, machine);
            
            _context.SaveChanges();

            return _mapper.Map<Model.Machines>(machine);
        }
    }
}
