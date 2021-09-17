using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsHandler.Models
{
    public class UserModel
    {
        public UserModel()
        {
            this.UserName = "";
            this.Password = "";
            this.DisplayName = "";
            this.Active = false;
            this.DetailsCorrect = false;
        }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public bool DetailsCorrect { get; set; }
    }   
}
