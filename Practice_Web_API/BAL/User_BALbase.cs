using Practice_Web_API.DATA;
using Practice_Web_API.Models;

namespace Practice_Web_API.BAL
{
    public class User_BALbase
    {
        private readonly UserRepository _userRepository;

        public User_BALbase(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserModel> GetAllUsers()
        {
            try
            {
                List<UserModel> umodel = _userRepository.GetAllUsers().ToList();
                if (umodel != null)
                {
                    return umodel;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }
        }
    }
}
