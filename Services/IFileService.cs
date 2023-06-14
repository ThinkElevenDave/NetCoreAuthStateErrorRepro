namespace Services
{
	public interface IFileService
	{
		Task<string> GetNameClaimValue();
	}
}