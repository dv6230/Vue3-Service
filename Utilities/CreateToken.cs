namespace Vue3_Service.Utilities
{
	public static class Token
	{
		public static string CreateToken(string str)
		{
			str += "&&" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			return StringHash.SHA256(str);			 
		}
	}
}
