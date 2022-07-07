using DungeonFinderInfra.DbConnect;

namespace DungeonFinderInfra.Repository
{
    public abstract class BaseRepository 
    {
        public DbSession _session;

        public BaseRepository(DbSession session)
        {
            _session = session;
        }
    }
}
