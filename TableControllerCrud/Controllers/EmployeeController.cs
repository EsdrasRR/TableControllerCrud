using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableControllerCrud.Controllers.Base;
using TableControllerCrud.Entities;
using TableControllerCrud.Services;

namespace TableControllerCrud.Controllers
{
    public class EmployeeController : CustomTableController<Employee, Models.Employee>
    {
        private readonly EmployeeService repository;

        public EmployeeController(EmployeeService repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
        }
    }
}
