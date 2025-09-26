using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
    
namespace Services.Facade
{
    public static class CryptographyService
    {
        /// <summary>
        /// Hashea input con SHA-256 usando salt (concatenado antes del input) y devuelve hex en minúsculas.
        /// Si salt es null se trata como cadena vacía.
        /// </summary>
        public static string Hash(string input, string salt = null)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            salt = salt ?? string.Empty;

            using (var sha = SHA256.Create())
            {
                // orden: salt + input (determinístico; mantén consistencia al verificar)
                var bytes = Encoding.UTF8.GetBytes(salt + input);
                var hash = sha.ComputeHash(bytes);
                return ToHex(hash);
            }
        }

        /// <summary>
        /// Verifica si hash == Hash(input, salt). Comparación en "constant time" para evitar timing attacks.
        /// </summary>
        public static bool Verify(string input, string salt, string expectedHexHash)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (expectedHexHash == null) throw new ArgumentNullException(nameof(expectedHexHash));
            salt = salt ?? string.Empty;

            var actual = Hash(input, salt);

            return AreEqualConstantTime(actual, expectedHexHash);
        }

        // ---- helpers ----
        private static string ToHex(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
                sb.Append(b.ToString("x2")); // minúsculas
            return sb.ToString();
        }

        // comparación en tiempo constante sobre strings hex (convierte internamente a bytes)
        private static bool AreEqualConstantTime(string aHex, string bHex)
        {
            if (aHex == null || bHex == null) return false;
            if (aHex.Length != bHex.Length) return false;

            // comparar como bytes para evitar short-circuit
            int diff = 0;
            for (int i = 0; i < aHex.Length; i++)
            {
                diff |= aHex[i] ^ bHex[i];
            }
            return diff == 0;
        }
    }
}
