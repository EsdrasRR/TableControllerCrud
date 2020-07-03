using AutoMapper;
using BiFrost.Web.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableControllerCrud.ORM;

namespace TableControllerCrud.Services
{
    public class EmployeeService : EntityFrameworkRepository<Context, Entities.Employee>
    {
        private readonly IMapper mapper;
        private readonly Context dbContext;

        public EmployeeService(IMapper mapper, Context dbContext) : base(dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
    }
}
