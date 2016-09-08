using System.Collections.Generic;
using System.Reflection;
using Hazeltek.Data.Common;
using Hazeltek.Data.EFx;
using Microsoft.EntityFrameworkCore;

namespace Hazeltek.UtiliTrak
{
    public class Context: DbContext, IDbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {
        }

        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string.</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql, parameters);
        }

        /// <summary>
        /// Creates a new SQL query that will return elements of the given
        /// generic type.
        /// </summary>
        /// <param name="sql">The sql query string.</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        public IEnumerable<TEntity> FromSql<TEntity>(string sql,
               params object[] parameters) where TEntity: BaseEntity, new()
        {
            return Set<TEntity>().FromSql(sql, parameters);
        }

        /// <summary>
        /// Gets the DbSet for the given generic type.
        /// </summary>
        public new DbSet<TEntity> Set<TEntity>() where TEntity: BaseEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembly = GetType().GetTypeInfo().Assembly;
            builder.AddEntityConfigurationsFromAssembly(assembly);
            base.OnModelCreating(builder);
        }
    }


}