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
    public class LossTypeViewerModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int LossTypeId { get; set; }

        public LossTypeModel LossType { get; set; }
        public void OnGet()
        {
            var lossType = new LossTypeViewerModel();
            var lossHandler = new LossTypeDbHandler();

            lossType.LossTypeId = LossTypeId;

            LossType = lossHandler.LossTypeData(LossTypeId);
        }

        public IActionResult OnPostGoBack()
        {
            return RedirectToPage("/GroupLossTypeViewer");
        }
    }
}
