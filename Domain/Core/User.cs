using Microsoft.AspNetCore.Identity;

namespace RestApi.Domain.Core
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets name for the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets surname for the user
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets a refresh token for the user
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
