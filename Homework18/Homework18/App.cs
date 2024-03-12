using Homework18.Services.Abstractions;
namespace Homework18
{
	public class App
	{
		private readonly IUserService _userService;
		private readonly IResourceService _resourceService;
		private readonly IAuthenticationService _authenticationService;

        public App(
			IUserService userService,
			IResourceService resourceService,
			IAuthenticationService authenticationService)
		{
			_userService = userService;
			_resourceService = resourceService;
			_authenticationService = authenticationService;
		}

		public async Task Start()
		{
			var user = await _userService.GetUserById(2);
			var userNotFound = await _userService.GetUserById(23);
			var userInfo = await _userService.CreateUser("morpheus", "leader");
			var users = await _userService.GetUserListByPage(2);
			var resources = await _resourceService.GetResourceList();
			var resource = await _resourceService.GetResourceById(2);
			var resourceNotFound = await _resourceService.GetResourceById(23);
			var updatedUserByPut = await _userService.UpdateUserByPut(2, "morpheus", "zion resident");
			var updatedUserByPatch = await _userService.UpdateUserByPatch(2, "morpheus", "zion resident");
			var deletedUser = await _userService.DeleteUserById(2);
			var successfulRegisteredUser = await _authenticationService.RegisterUser("eve.holt@reqres.in", "pistol");
			var unsuccessfulUserRegistration = await _authenticationService.RegisterUser("sydney@fife");
			var successfulLoggedInUser = await _authenticationService.LoginUser("eve.holt@reqres.in", "cityslicka");
			var unsuccessfulUserLogin = await _authenticationService.LoginUser("peter@klaven");
			var usersListWithDelay = await _userService.GetUserListWithDelay(3);
		}
	}
}

