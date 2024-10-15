using Data.DTO;
using Data;
using Logic.Model;

namespace Logic
{
	public class UserService
	{
		private readonly UserRepository userRepository;
		public UserService(UserRepository userRepository)
		{
			this.userRepository = userRepository;
		}
		public UserModel GetUserById(int id)
		{
			UserDTO userDTO = userRepository.LoadUserById(id);
			UserModel user = new UserModel(userDTO.Id, userDTO.Email, userDTO.Password);
			return user;
		}

	}
}