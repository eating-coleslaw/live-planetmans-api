using LivePlanetmans.Data.Models.Events;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbContextHelper _dbContextHelper;

        public EventRepository(IDbContextHelper dbContextHelper)
        {
            _dbContextHelper = dbContextHelper;
        }

        // Credit to Lampjaw
        public async Task AddAsync<T>(T entity) where T : class
        {
            using var factory = _dbContextHelper.GetFactory();
            var dbContext = factory.GetDbContext();

            try
            {
                dbContext.Add(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when ((ex.InnerException as PostgresException)?.SqlState == "23505")
            {
                // Ignore unique constraint errors (https://www.postgresql.org/docs/current/static/errcodes-appendix.html)
            }
        }

        public async Task<IEnumerable<Death>> GetDeathsForWorldInTimeRange(int worldId, DateTime start, DateTime end)
        {
            using var factory = _dbContextHelper.GetFactory();
            var dbContext = factory.GetDbContext();

            var deaths = new List<Death>();

            try
            {
                return await dbContext.Deaths.Where(d => d.WorldId == worldId
                                                      && d.Timestamp >= start
                                                      && d.Timestamp <= end)
                                             .ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
