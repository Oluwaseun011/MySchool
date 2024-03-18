namespace MySchool.Core.Application.Interfaces.Repositories
{
    public interface IFileRepository
    {
        string Upload(IFormFile file);
    }
}
