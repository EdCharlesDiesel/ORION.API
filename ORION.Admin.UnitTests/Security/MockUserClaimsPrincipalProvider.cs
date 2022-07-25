using ORION.Admin.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ORION.Admin.UnitTests.Security
{
    public class MockUserClaimsPrincipalProvider : IUserClaimsPrincipalProvider
    {
        public MockUserClaimsPrincipalProvider()
        {
            InitializeReturnValue();
        }

        public ClaimsPrincipal ReturnValue { get; private set; }

        public ClaimsPrincipal GetUser()
        {
            return ReturnValue;
        }

        private List<Claim> _Claims;
        private List<Claim> Claims
        {
            get
            {
                if (_Claims == null)
                {
                    _Claims = new List<Claim>();
                }

                return _Claims;
            }
        }

        public void AddClaim(string claimType, string claimValue)
        {
            Claims.Add(new Claim(claimType, claimValue));

            InitializeReturnValue();
        }

        private void InitializeReturnValue()
        {
            var identity = new ClaimsIdentity(Claims);

            ReturnValue = new ClaimsPrincipal(identity);
        }

        internal void AddClaim(object claimsType)
        {
            throw new NotImplementedException();
        }
    }
}
