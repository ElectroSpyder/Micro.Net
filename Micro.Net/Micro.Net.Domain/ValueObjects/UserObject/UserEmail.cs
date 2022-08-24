
namespace Micro.Net.Domain.ValueObjects.UserObject
{
    public record UserEmail
    {
        public string Value { get; init; }
        internal UserEmail(string value) { Value = value; }
        public static UserEmail Create(string value) { return new UserEmail(value); }
        private static void Validate(string value)
        {
            if(string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");
        }
    }
}
