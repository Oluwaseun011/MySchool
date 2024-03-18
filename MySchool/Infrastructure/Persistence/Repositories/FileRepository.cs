using MySchool.Core.Application.Interfaces.Repositories;

namespace MySchool.Infrastructure.Persistence.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IWebHostEnvironment _environment;
        public FileRepository(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public string Upload(IFormFile file)
        {
            var a = file.ContentType.Split('/');
            var newName = $"{a[0]}{Guid.NewGuid()}.{a[1]}";

            var b = Path.Combine(_environment.WebRootPath, "Files");
            if(!Directory.Exists(b))
            {
                Directory.CreateDirectory(b);
            }

            var c = Path.Combine(b, newName);

            using(var d = new FileStream(c, FileMode.Create))
            {
                file.CopyTo(d);
            }

            return newName;
        }
    }
}
