namespace DungeonFinderDomain.Model.Response
{
    public class GenericResponse<T> 
    {
        public T Response { get; set; }

        public BaseResponse BaseResponse { get; set; }

        public GenericResponse()
        {
            BaseResponse = new BaseResponse();
        }
    }
}
