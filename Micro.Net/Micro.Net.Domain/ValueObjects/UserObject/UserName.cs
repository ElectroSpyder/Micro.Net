
namespace Micro.Net.Domain.ValueObjects.UserObject
{
    public record UserName
    {
        public string Value { get; init; }
        internal UserName(string value){ this.Value = value;}

        public static UserName Create(string value){ return new UserName(value); }

        private static void Validate(string value)
        {
            if (value.Length < 0) { throw new ArgumentException("Debe ingresar un nombre valido"); }
        }
    }
}
