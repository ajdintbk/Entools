using Entools.Model;
using Entools.Model.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Repositories.Interfaces
{
    public interface IUsers
    {
        public List<Users> Get(UserSearchRequest request);
        public Users GetById(int id);
        public Users AddUser(AddUserRequest req);
        Users Update(int id, AddUserRequest request);
        Users Authenticate(UserLoginRequest request);
    }
}
