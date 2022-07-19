

namespace DungeonFinderWebApp.Domain.Models.Request
{
    public class CreateFileRequest
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }

        public CreateFileRequest(string fileName, byte[] data, string contentType)
        {
            FileName = fileName;
            Data = data;    
            ContentType = contentType;  
        }
    }
}
