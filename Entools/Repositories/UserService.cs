using AutoMapper;
using Entools.Database;
using Entools.Model;
using Entools.Model.Requests.Users;
using Entools.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories
{
    public class UserService : IUsers
    {
        readonly EntoolsDbContext _context;
        readonly IMapper _mapper;
        public UserService(EntoolsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Users AddUser(AddUserRequest req)
        {
            var validate = _context.Users.FirstOrDefault(w => w.Username == req.Username);
            if (validate != null)
            {
                return null;
            }
            var user = _mapper.Map<Database.Users>(req);
            user.PasswordSalt = HashGenerator.GenerateSalt();
            user.PasswordHash = HashGenerator.GenerateHash(user.PasswordSalt, req.Password);
            user.RoleId = req.RoleId;
            _context.Users.Add(user);
            _context.SaveChanges();
            return _mapper.Map<Model.Users>(user);
        }

        public Model.Users Authenticate(UserLoginRequest request)
        {
            var user = _context.Users.Include(i => i.Role).FirstOrDefault(x => x.Username == request.Username);

            if (user != null)
            {
                var newHash = HashGenerator.GenerateHash(user.PasswordSalt, request.Password);

                if (user.PasswordHash == newHash)
                {
                    var returnUser = _mapper.Map<Model.Users>(user);
                    return returnUser;
                }
            }
            return null;
        }

        public List<Model.Users> Get(UserSearchRequest request)
        {
            return _mapper.Map<List<Model.Users>>(_context.Users.Include(i=>i.Role).ToList());
        }

        public Model.Users GetById(int id)
        {
            var user = _context.Users.Find(id);
            return _mapper.Map<Model.Users>(user);
        }

        public Model.Users Update(int id, AddUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
