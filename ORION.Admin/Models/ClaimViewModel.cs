using System;
using System.Linq;

namespace ORION.Admin.Models
{
    public class ClaimViewModel
    {
        public ClaimViewModel(string id, string username, string permission, string businessOwnerName)
        {
            Id = id;
            Username = username;
            Permission = permission;
            BusinessOwnerName = businessOwnerName;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Permission { get; set; }
        public string BusinessOwnerName { get; set; }
    }
}