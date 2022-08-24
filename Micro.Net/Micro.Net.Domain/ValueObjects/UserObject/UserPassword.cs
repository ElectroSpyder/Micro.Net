namespace Micro.Net.Domain.ValueObjects.UserObject
{
    public record UserPassword
    {
        public string Value { get; init; }
        internal UserPassword(string value) { Value = value; }

        public static UserPassword Create(string value) { return new UserPassword(value); }
        private static void Validate(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentOutOfRangeException("Debe ingresar una Contraseña valida");
        }
    }
}
