using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using EnergySimplyDAL.EF;

namespace EnergySimplyDAL.Repos
{
    public abstract class BaseRepo<T>: IDisposable where T:class,new()
    {
        public EnergySimplyEntities Context { get; } = new EnergySimplyEntities(); // Must be public to use in the test project
        protected DbSet<T> Table;
        private bool _disposed = false;

        /// <summary>
        /// Wrapper for the SaveChanges() method of the DbContext. Placed here so that all 
        /// derived repositories can share the implementation.
        /// Exception handlers are stubbed...in production, these would need to be implemented.
        /// </summary>
        /// <returns></returns>
        internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Throw for concurrency exceptions.
                // Here, we just rethrow:
                throw;
            }
            catch (DbUpdateException ex)
            {
                // Thrown when database update fails.
                // Examine the InnerException(s) for additional details and affected objects.
                throw;
            }
            catch (CommitFailedException ex)
            {
                // Handles transaction failures.
                // Rethrow for now...
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        } // end SaveChanges()

        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // for now, just rethrow
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        } // end SaveChangesAsync()


        // Retrieval methods:

        /// <summary>
        /// Wraps DbSet<T>.Find()
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        public T GetOne(int? id) => Table.Find(id);

        /// <summary>
        /// Wraps DbSet<T>.FindAsync()
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<T></returns>
        public Task<T> GetOneAsync(int? id) => Table.FindAsync(id);

        public List<T> GetAll() => Table.ToList();
        public Task<List<T>> GetAllAsync() => Table.ToListAsync();

        // Here are the retrieval methods which receive SQL:
        // (Keep in mind that accepting SQL, especially via user input, is at risk of
        // SQL injection attacks. Security must be considered if using these...)
        public List<T> ExecuteQuery(string sql) => Table.SqlQuery(sql).ToList();
        public Task<List<T>> ExecuteQueryAsync(string sql) =>
            Table.SqlQuery(sql).ToListAsync();

        public List<T> ExecuteQuery(string sql, object[] sqlParamsObjects) =>
            Table.SqlQuery(sql, sqlParamsObjects).ToList();
        public Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParamsObjects) =>
            Table.SqlQuery(sql, sqlParamsObjects).ToListAsync();

        // Adding Records methods:

        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }

        public Task<int> AddAsync(T entity)
        {
            Table.Add(entity);
            return SaveChangesAsync();
        }

        public int AddRange(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }

        public Task<int> AddRangeAsync(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChangesAsync();
        }

        // Save Records:
        // We first set EntityState.Modified, then call SaveChanges(Async)().
        // Setting the state ensures that the context will propagate the changes to the server.

        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        // Delete Records:
        // Similar to Save, we set the state to EntityState.Deleted to ensure changes are propagated to the server.

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        // Implement IDisposable:
        //bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Context.Dispose();

                // Free any managed objects here:
                //
            }

            // Free any unmanaged objects here:
            //

            _disposed = true;
        }
    }
}
