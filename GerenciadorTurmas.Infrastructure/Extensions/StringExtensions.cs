namespace GerenciadorTurmas.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string HashPassword(this string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }
    }
}
