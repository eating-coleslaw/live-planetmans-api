// Credit to Lampjaw

using System;
using System.Threading.Tasks;

namespace CensusStore
{
    public interface IUpdateable
    {
        string StoreName { get; }
        TimeSpan UpdateInterval { get; }
        Task RefreshStore();
    }
}
