using AutoMapper;
using BiFrost.Core.Abstractions;
using BiFrost.Web.DataManagement;
using BiFrost.Web.DataManagement.Tables;
using Microsoft.AspNetCore.Mvc;
using Naylah;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TableControllerCrud.Controllers.Base
{
    public abstract class CustomTableController<TEntity, TModel> : TableController<TEntity, TModel>
    where TEntity : class, IEntityUpdate<TModel>, IEntity<string>, new()
    where TModel : class, new()
    {
        private readonly IRepository<TEntity> repository;

        protected CustomTableController(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
        }
        protected override IOrderedQueryable<TEntity> GetEntitiesAsQueryable()
        {
            var type = typeof(TEntity);
            if (type.GetProperty("Name") != null)
            {
                var param = Expression.Parameter(type, "x");
                var exp = Expression.Lambda<Func<TEntity, object>>(Expression.Property(param, "Name"), param);
                return repository.GetAllAsQueryable().OrderBy(exp);
            }
            else if (type.GetProperty("Year") != null)
            {
                var param = Expression.Parameter(type, "x");
                var exp = Expression.Lambda<Func<TEntity, Int32>>(Expression.Property(param, "Year"), param);
                return repository.GetAllAsQueryable().OrderByDescending(exp);
            }
            else if (type.GetProperty("Order") != null)
            {
                var param = Expression.Parameter(type, "x");
                var exp = Expression.Lambda<Func<TEntity, Int32>>(Expression.Property(param, "Order"), param);
                return repository.GetAllAsQueryable().OrderBy(exp);
            }
            else
            {
                return repository.GetAllAsQueryable().OrderByDescending(x => x.CreatedAt);
            }
        }

        /// <summary>
        /// Return all data, with OData filter and pagging.
        /// </summary>
        /// <returns>Paged list of items.</returns>
        public override Task<object> GetAllAsync()
        {
            return base.GetAllAsync();
        }

        /// <summary>
        /// Update or insert items.
        /// </summary>
        /// <param name="model">Item to update or insert.</param>
        /// <returns>Updated/Inserted item.</returns>
        public override Task<object> UpsertAsync([FromBody] JToken model)
        {
            return base.UpsertAsync(model);
        }

        /// <summary>
        /// Delete an item, with SoftDelete option.
        /// </summary>
        /// <param name="id">Item Id.</param>
        /// <param name="softDelete">Logical removal (TRUE: marks the record as removed | FALSE: delete the base record)</param>
        /// <returns></returns>
        public override Task DeleteAsync(string id, bool softDelete = true)
        {
            return base.DeleteAsync(id, softDelete);
        }
    }
}
