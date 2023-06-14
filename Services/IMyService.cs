namespace Services
{
	public interface IMyService
	{
		Task<string> GetNameClaimValue();
	}
}