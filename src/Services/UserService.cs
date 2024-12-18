using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        void CreateUser(UserModel user);
        bool UpdateUser(int id, UserModel user);
        bool DeleteUser(int id);
        bool ActivateUser(int id);
        bool DeactivateUser(int id);
        IEnumerable<UserModel> SearchUsers(string name, string role);
    }

    public class UserService : IUserService
    {
        private readonly List<UserModel> _users = new();

        public IEnumerable<UserModel> GetAllUsers() => _users;

        public UserModel GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);

        public void CreateUser(UserModel user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
        }

        public bool UpdateUser(int id, UserModel updatedUser)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            _users.Remove(user);
            return true;
        }

        public bool ActivateUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;
            user.IsActive = true;
            return true;
        }

        public bool DeactivateUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;
            user.IsActive = false;
            return true;
        }

        public IEnumerable<UserModel> SearchUsers(string name, string role)
        {
            return _users.Where(u =>
                (string.IsNullOrEmpty(name) || u.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(role) || u.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
            );
        }
    }
}
