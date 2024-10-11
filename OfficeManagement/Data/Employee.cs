using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OfficeManagement.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }
        public DateTime HireDate { get; set; }

        // Foreign key for IdentityUser
        public string? ApplicationUserId { get; set; }

        // Navigation property for IdentityUser
        public ApplicationUser? ApplicationUser { get; set; }
    }
}