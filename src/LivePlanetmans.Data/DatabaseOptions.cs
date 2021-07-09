// Credit to Lampjaw

namespace LivePlanetmans.Data
{
    public class DatabaseOptions
    {
        public string DBConnectionString { get; set; }
        public int PoolSize { get; set; } = 100;
    }
}