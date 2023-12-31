﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BlazorApp1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{

		private IMyService _myService;

		public ValuesController(IMyService myService)
		{
			_myService = myService;
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> TestAsync()
		{
			try
			{
				var x = await _myService.GetNameClaimValue();
			}
			catch (Exception ex)
			{

				/*
				 "GetAuthenticationStateAsync was called before SetAuthenticationState."
				    at Microsoft.AspNetCore.Components.Server.ServerAuthenticationStateProvider.GetAuthenticationStateAsync()
					at Services.MyService.<GetNameClaimValue>d__2.MoveNext() in C:\Users\DavidClough\source\repos\BlazorApp1\Services\MyService.cs:line 18
					at BlazorApp1.Controllers.ValuesController.<TestAsync>d__2.MoveNext() in C:\Users\DavidClough\source\repos\BlazorApp1\BlazorApp1\Controllers\ValuesController.cs:line 24
				 */

				throw;
			}


			return Ok("data:image/png;base64,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");
		}
	}
}
