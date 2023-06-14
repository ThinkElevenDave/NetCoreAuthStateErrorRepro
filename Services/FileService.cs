using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;


namespace Services
{
	public class FileService : IFileService
	{
		private readonly AuthenticationStateProvider _stateProvider;

		public FileService(AuthenticationStateProvider authenticationStateProvider)
		{
			_stateProvider = authenticationStateProvider;
		}

		public async Task<string> GetNameClaimValue()
		{
			var x = await _stateProvider.GetAuthenticationStateAsync();
			return x.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
		}
	}
}