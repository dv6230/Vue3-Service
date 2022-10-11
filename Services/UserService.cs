namespace Vue3_Service.Services
{
	public class UserService
	{

		Entity.MyDBContext _context;
		public UserService(Entity.MyDBContext myDB)
		{
			this._context = myDB;
		}

		public Entity.User? CheckUser(Parameter.Login login)
		{
			var user = _context.Users.Where(x => x.Email == login.Email).Where(x => x.Password == login.Password).FirstOrDefault();

			if (user != null) return user;

			return null;
		}


		public bool LoginRecord(int userId, string token)
		{
			_context.UserLogins.Add(new Entity.UserLogin() { Token = token, UserId = userId, ExpireTime = DateTime.Now.AddHours(1) });

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
