using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    internal class UserDAO
    {
        readonly PRN231_AS2Context _context = new PRN231_AS2Context();
        public UserDAO() { }
        public UserDAO(PRN231_AS2Context context)
        {
            _context = context;
        }

        public void createUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void deleteUser(int id)
        {
            User u = _context.Users.FirstOrDefault(x => x.UserId == id);
            if (u != null)
            {
                _context.Users.Remove(u);
                _context.SaveChanges();
            }
        }

        public List<User> listUser()
        {
            return _context.Users.Include(x => x.Role).ToList();
        }

        public void updateUser(User user)
        {
            User u = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
            if (u != null)
            {
                u.EmailAddress = user.EmailAddress;
                u.Password = user.Password;
                u.Source = user.Source;
                u.FirstName = user.FirstName;
                u.MiddleName = user.MiddleName;
                u.LastName = user.LastName;
                u.RoleId = user.RoleId;
                u.PubId = user.PubId;
                u.HireDate = user.HireDate;
                _context.Users.Update(u);
                _context.SaveChanges();
            }
        }
    }
}
