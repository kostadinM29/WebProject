using MedEx.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MedEx.Data
{
    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(ApplicationDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ApplicationDbContext Context { get; set; }

        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }
    }
}
