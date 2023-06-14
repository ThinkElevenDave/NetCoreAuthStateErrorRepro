# NetCoreAuthStateErrorRepro
Repro of the AuthenticationStateProvider "GetAuthenticationStateAsync was called before SetAuthenticationState." error

To reproduce
--

 1. Run the app and click the button to create an authentication cookie via a Razor page.
 2. You are then redirected back to Blazor where two things occur:
    - An injected service within the Blazor component reads a claim from the cookie
    - An image controller attempts to read the same claim **via the same service** before returning an image, but fails with the above error.
 
 The injected service uses AuthenticationStateProvider which appears to cause the error.
