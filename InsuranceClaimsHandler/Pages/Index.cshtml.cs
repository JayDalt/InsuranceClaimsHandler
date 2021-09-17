using InsuranceClaimsHandler.Classes;
using InsuranceClaimsHandler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsHandler.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty, Required(ErrorMessage = "Username is required"), MaxLength(10), MinLength(2, ErrorMessage = "Username should contain at least 2 characters")]
        public string UserName { get; set; }

        [BindProperty, Required(ErrorMessage = "Password is required"), MaxLength(20), MinLength(5, ErrorMessage = "Password should contain at least 5 characters")]
        public string Password { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var userInput = new UserModel();
                var userHandler = new UserDbHandler();

                userInput.UserName = UserName;
                userInput.Password = Password;

                userInput = userHandler.ValidateUserInput(UserName, Password);

                if (userInput.DetailsCorrect)
                {
                    return RedirectToPage("GroupLossTypeViewer", new {userInput.DisplayName});
                }
                else
                {
                    ErrorMessage = "Incorrect username or password, please try again";
                }   
            }
            return Page();
        }
    }
}

