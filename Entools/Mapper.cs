using AutoMapper;
using Entools.Model.Requests.Machines;
using Entools.Model.Requests.Operations;
using Entools.Model.Requests.Parts;
using Entools.Model.Requests.Request;
using Entools.Model.Requests.Tools;
using Entools.Model.Requests.Users;
using Entools.Model.Requests.VersionRequest;
using Entools.Model.Requests.Versions;

namespace Entools
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Machines, Model.Machines>().ReverseMap();
            CreateMap<Database.Machines, InsertUpdateRequest>().ReverseMap();

            CreateMap<Database.Tools, Model.Tools>().ReverseMap();
            CreateMap<Database.Tools, ToolsInsertUpdateRequest>().ReverseMap();

            CreateMap<Database.Users, Model.Users>().ReverseMap();
            CreateMap<Database.Users, AddUserRequest>().ReverseMap();

            CreateMap<Database.Parts, Model.Parts>().ReverseMap();
            CreateMap<Database.Parts, PartInsertUpdateRequest>().ReverseMap();

            CreateMap<Database.Versions, Model.Versions>().ReverseMap();
            CreateMap<Database.Versions, VersionInsertUpdateRequest>().ReverseMap();

            CreateMap<Database.Users, Model.Users>().ReverseMap();
            CreateMap<Database.Users, AddUserRequest>().ReverseMap();

            CreateMap<Database.Request, Model.Request>().ReverseMap();
            CreateMap<Database.Request, RequestInsertUpdateRequest>().ReverseMap();

            CreateMap<Database.VersionRequest, Model.VersionRequest>().ReverseMap();
            CreateMap<Database.VersionRequest, VersionRequestInsertUpdateRequest>().ReverseMap();

            CreateMap<Database.Operations, Model.Operations>().ReverseMap();
            CreateMap<Database.Operations, OperationsInsertUpdateRequest>().ReverseMap();

            CreateMap<Database.PartOperations, Model.PartOperations>().ReverseMap();

            CreateMap<Database.Roles, Model.Roles>().ReverseMap();


        }
    }
}
