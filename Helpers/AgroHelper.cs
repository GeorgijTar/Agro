
using System.Security.Cryptography;
using System.Text;

namespace Helpers;

/// <summary>
/// Класс помощник
/// </summary>
public static class AgroHelper
{
    /// <summary>
    /// Метод вычисляющий Hash указанного пароля с солью
    /// </summary>
    /// <param name="clearTextPassword"> Исходный пароль </param>
    /// <param name="salt"> Соль </param>
    /// <returns></returns>
   public static string CalculateHash(string clearTextPassword, string salt)
    {
        // Переводим пароль и соль в массив байт
        byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
        // вычесляем хэш
        HashAlgorithm algorithm = new SHA256Managed();
        byte[] hash = algorithm.ComputeHash(saltedHashBytes);
        // Возвращаем хэш в виде строки в кодировке Base64
        return Convert.ToBase64String(hash);
    }
}
