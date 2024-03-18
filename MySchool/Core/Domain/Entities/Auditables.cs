namespace MySchool.Core.Domain.Entities
{
    public abstract class Auditables
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
