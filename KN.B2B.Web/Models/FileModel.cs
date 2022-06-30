using Microsoft.AspNetCore.Http;

namespace KN.B2B.Web.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Content{ get; set; }
        public string Path { get; set; }
    }
    public class Content
    {
        public IFormFile file { get; set; }
    }
}
