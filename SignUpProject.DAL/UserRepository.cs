using SignUpProject.Context;
using SignUpProject.Entities;
using System.Linq;
using System.Web.Security;

namespace BarberShop.DAL
{
    public class UserRepository
    {
        private static DatabaseContext db = new DatabaseContext();

        public static User AddUser(User data)
        {
            User user = new User() { FirstName=data.FirstName,LastName=data.LastName,Phone=data.Phone,Email=data.Email ,ComeFrom=data.ComeFrom};
            user.Password = Membership.GeneratePassword(5, 1);
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }
        public static bool IsUserExists(string email)
        {
            User user=db.Users.FirstOrDefault(c => c.Email == email);
            if (user!=null)
            {
                user.SignAgain = true;
                db.SaveChanges();
            }
            return user!=null;
        }

    }
}
