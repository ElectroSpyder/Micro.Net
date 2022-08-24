namespace Micro.Net.Domain.Entities
{
    using Micro.Net.Domain.Common;
    public class UserEntity : AuditableEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
    }
}
