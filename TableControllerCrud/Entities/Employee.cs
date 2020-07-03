using BiFrost.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Naylah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableControllerCrud.ORM;

namespace TableControllerCrud.Entities
{
    public class Employee : IEntity<string>, IEntityUpdate<Models.Employee>
    {
        public string Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string Version { get; set; }
        public bool Deleted { get; set; }

        internal static void EntityConfigure(ModelBuilder modelBuilder)
        {
            ORMExtensions.DefaultModel<Employee>(modelBuilder);
        }

        public bool IsSame(Models.Employee source)
        {
            return Id == source.Id;
        }

        public void UpdateFrom(Models.Employee source)
        {
            throw new NotImplementedException();
        }
    }
}
