using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InsuranceClaimsHandler.Classes;
using InsuranceClaimsHandler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InsuranceClaimsHandler.Pages
{
    public class ControlPanelModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string DisplayName { get; set; }
        public List<LossTypeModel> LossTypes { get; set; }

        public void OnGet()
        {
            var lossHandler = new LossTypeDbHandler();

            LossTypes = lossHandler.AllLossTypeData();
        }
    }
}
