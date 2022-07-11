
namespace DungeonFinderWebApp.Domain.Models.Response
{
    public class ListResponse<T> : BaseResponse
    {
        public List<T> Items;
    }
}
