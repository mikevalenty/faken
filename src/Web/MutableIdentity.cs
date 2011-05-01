using System.Security.Principal;

namespace FakeN.Web
{
	/// <summary>
	/// An implementation of IIdentity that can be modified
	/// </summary>
	public class MutableIdentity : IIdentity
	{
		public string Name { get; set; }

		public bool IsAuthenticated { get; set; }

		public string AuthenticationType { get; set; }
	}
}