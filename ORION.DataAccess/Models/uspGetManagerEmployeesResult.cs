﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Human.Resources.API.Models
{
    public partial class uspGetManagerEmployeesResult
    {
        public int? RecursionLevel { get; set; }
        public string OrganizationNode { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public int? BusinessEntityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}