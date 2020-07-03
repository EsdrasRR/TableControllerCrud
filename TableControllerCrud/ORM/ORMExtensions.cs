using BiFrost.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Naylah;
using System;

namespace TableControllerCrud.ORM
{
    public static class ORMExtensions
    {
        public static void DefaultModel<IEntity>(ModelBuilder modelBuilder) where IEntity : class, IEntity<string>
        {
            modelBuilder.Entity<IEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<IEntity>().Property(x => x.Id).HasValueGenerator(typeof(IdValueGenerator));
        }

        public class IdValueGenerator : ValueGenerator<string>
        {
            public override bool GeneratesTemporaryValues => true;

            public override string Next(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry)
            {
                return Guid.NewGuid().ToString("N");
            }
        }
    }
}
