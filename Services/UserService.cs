namespace Vue3_Service.Services
{
	public class UserService
	{

		Entity.MyDBContext _context;
		public UserService(Entity.MyDBContext myDB)
		{
			this._context = myDB;
		}

		public bool CheckUser(Parameter.Login login)
		{
			var user = _context.Users.Where(x => x.Email == login.Email).FirstOrDefault();



			return false;
		}


		public bool InsertLogin(int userId)
		{
			_context.UserLogins.Add(new Entity.UserLogin() { Token = "tt", UserId = userId, ExpireTime = DateTime.Now });

			try
			{
				_context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
	}
}
