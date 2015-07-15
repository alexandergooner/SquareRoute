using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SquareRouteProject.Domain.Entities
{
    public class User
    {
        #region Fields
        private ICollection<Claim> _claims;
        private ICollection<ExternalLogin> _externalLogins;
        private ICollection<Role> _roles;
        #endregion

        #region Scalar Properties
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }        
                
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int RoleType { get; set; }
        public string Address { get; set; }
        public string City {get; set;}
        public string PostalCode { get; set; }
        public string ImageUrl { get; set; }
        public string MobileDeviceId { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Claim> Claims
        {
            get { return _claims ?? (_claims = new List<Claim>()); }
            set { _claims = value; }
        }

        public virtual ICollection<ExternalLogin> Logins
        {
            get
            {
                return _externalLogins ??
                    (_externalLogins = new List<ExternalLogin>());
            }
            set { _externalLogins = value; }
        }

        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            set { _roles = value; }
        }

        public virtual ICollection<RouteUser> Routes { get; set; }
        public virtual ICollection<AccessCodeUser> AccessCodes { get; set; }
        #endregion
    }
}
