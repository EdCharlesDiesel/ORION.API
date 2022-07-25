using System;
using ORION.Admin;
using ORION.Admin.Controllers;
using ORION.Admin.UnitTests.Security;
using ORION.DataAccess.Models;
using Xunit;

namespace ORION.Admin.UnitTests.Security
{
    public class BusinessOwnerControllerSecurityTest
    {
        private Type SystemUnderTest
        {
            get
            {
                return typeof(BusinessOwnerController);
            }
        }

        [Fact]
        public void EditMethodRequiresAdministratorRole_Int32()
        {
            SecurityAttributeUtility.AssertAuthorizeAttributeRolesOnMethod(
                SecurityConstants.RoleName_Admin, SystemUnderTest, "Edit", typeof(int)
            );
        }

        [Fact]
        public void EditMethodRequiresAdministratorRole_BusinessOwner()
        {
            SecurityAttributeUtility.AssertAuthorizeAttributeRolesOnMethod(
                SecurityConstants.RoleName_Admin, SystemUnderTest, "Edit", typeof(BusinessOwner)
            );
        }


        [Fact]
        public void EditMethodRequiresEditBusinessOwnerPolicy_Int32()
        {
            SecurityAttributeUtility.AssertAuthorizeAttributePolicyOnMethod(
                SecurityConstants.PolicyName_EditBusinessOwner, 
                SystemUnderTest, "Edit", typeof(int)
            );
        }

        [Fact]
        public void EditMethodRequiresEditBusinessOwnerPolicy_BusinessOwner()
        {
            SecurityAttributeUtility.AssertAuthorizeAttributePolicyOnMethod(
                SecurityConstants.PolicyName_EditBusinessOwner, 
                SystemUnderTest, "Edit", typeof(BusinessOwner)
            );
        }


        [Fact]
        public void ControllerRequiresAdministratorRole()
        {
            SecurityAttributeUtility.AssertAuthorizeAttributeRolesOnClass(
                SecurityConstants.RoleName_Admin, SystemUnderTest
            );
        }


        [Fact]
        public void IndexMethodAllowsAnonymous()
        {
            SecurityAttributeUtility.AssertAllowAnonymousAttributeOnMethod(
                SystemUnderTest, "Index");
        }

        [Fact]
        public void DetailsMethodAllowsAnonymous()
        {
            SecurityAttributeUtility.AssertAllowAnonymousAttributeOnMethod(
                   SystemUnderTest, "Details", typeof(int));
        }
    }
}