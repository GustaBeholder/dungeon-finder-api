namespace DungeonFinderAPI.Model.Response
{
    public class ListResponse<T> : BaseResponse where T : class
    {
        public List<T> Items;

        public ListResponse(List<T> items)
        {
            Items = items;
        }
        public ListResponse()
        {

        }
    }
}
