using Logic.Interfaces;
using Logic.Model;
using Logic.DTO;

namespace Logic
{
	public class UserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
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