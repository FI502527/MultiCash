using Data;
using Data.DTO;
using Logic.Model;

namespace Logic
{
	public class UserService
	{
		private readonly UserRepository _userRepository;
		public UserService(UserRepository userRepository)
		{
			this._userRepository = userRepository;
		}
		public UserModel GetUserById(int id)
		{
			UserDTO userDTO = _userRepository.LoadUserById(id);
			UserModel user = new UserModel(userDTO.Id, userDTO.Email, userDTO.Password);
			return user;
		}
	}
}