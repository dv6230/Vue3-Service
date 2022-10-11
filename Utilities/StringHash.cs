using System.Security.Cryptography;
using System.Text;

namespace Vue3_Service.Utilities
{
	public static class StringHash
	{
		public static string MD5(string str)
		{
			using (var cryptoMD5 = System.Security.Cryptography.MD5.Create())
			{
				//將字串編碼成 UTF8 位元組陣列
				var bytes = Encoding.UTF8.GetBytes(str);

				//取得雜湊值位元組陣列
				var hash = cryptoMD5.ComputeHash(bytes);

				//取得 MD5
				var md5 = BitConverter.ToString(hash)
				  .Replace("-", String.Empty)
				  .ToLower();

				return md5;
			}
		}

		public static string SHA256(string str)
		{
			var hashText = "";
			// SHA256 is disposable by inheritance.  
			using (var sha256 = System.Security.Cryptography.SHA256.Create())
			{
				// Send a sample text to hash.  
				var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
				// Get the hashed string.  
				hashText = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
			}
			return hashText;
		}

	}
}
