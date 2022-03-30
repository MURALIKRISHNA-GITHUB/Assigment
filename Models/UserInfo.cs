using System;
using System.Collections.Generic;

namespace SelfAssignment_MvcVersion.Models
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public int LastName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
