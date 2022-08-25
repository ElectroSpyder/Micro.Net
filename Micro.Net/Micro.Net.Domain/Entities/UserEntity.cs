namespace Micro.Net.Domain.Entities
{
    using Micro.Net.Domain.Common;
    using Micro.Net.Domain.ValueObjects.UserObject;

    public class UserEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public UserName Name { get; set; }
        public UserPassword Password { get; set; }
        public UserEmail Email { get; set; }
    }
}
