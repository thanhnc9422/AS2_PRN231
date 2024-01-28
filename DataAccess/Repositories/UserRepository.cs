using BusinessObject.Model;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    { 
        private UserDAO userDAO = new UserDAO();

        public void createUser(User user)
        {
           userDAO.createUser(user);
        }

        public void deleteUser(int id)
        {
            userDAO.deleteUser(id);
        }

        public List<User> listUser()
        {
            return userDAO.listUser();
        }

        public void updateUser(User user)
        {
           userDAO.updateUser(user);
        }
    }
}
