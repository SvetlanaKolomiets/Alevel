using Homework18.Services.Abstractions;
namespace Homework18
{
	public class App
	{
		private readonly IUserService _userService;

		public App(IUserService userService)
		{
			_userService = userService;
		}

		public async Task Start()
		{
			var user = await _userService.GetUserById(2);
			var userNotFound = await _userService.GetUserById(23);
			var userInfo = await _userService.CreateUser("morpheus", "leader");
			var users = await _userService.GetUserListByPage(2);
			var resources = await _userService.GetResourceList();
			var resource = await _userService.GetResourceById(2);
			var resourceNotFound = await _userService.GetResourceById(23);
			var updatedUserByPut = await _userService.UpdateUserByPut(2, "morpheus", "zion resident");
			var updatedUserByPatch = await _userService.UpdateUserByPatch(2, "morpheus", "zion resident");
			var deletedUser = await _userService.DeleteUserById(2);
			var successfulRegisteredUser = await _userService.RegisterUser("eve.holt@reqres.in", "pistol");
			var unsuccessfulUserRegistration = await _userService.RegisterUser("sydney@fife");
			var successfulLoggedInUser = await _userService.LoginUser("eve.holt@reqres.in", "cityslicka");
			var unsuccessfulUserLogin = await _userService.LoginUser("peter@klaven");
			var usersListWithDelay = await _userService.GetUserListWithDelay(3);
		}
	}
}

