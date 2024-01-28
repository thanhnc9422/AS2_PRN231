using BusinessObject.Model;

namespace DataAccess
{
    internal interface IUserRepository
    {
        void deleteUser(int id);
        void updateUser(User user);
        void createUser(User user);
        List<User> listUser();
    }
}
