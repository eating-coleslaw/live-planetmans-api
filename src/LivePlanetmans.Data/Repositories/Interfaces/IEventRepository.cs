using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlanetmans.Data.Repositories
{
    public interface IEventRepository
    {
        Task AddAsync<T>(T entity) where T : class;
    }
}
