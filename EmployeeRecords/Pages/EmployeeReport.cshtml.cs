using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeRecords.Pages
{
    public class EmployeeReportModel : PageModel
    {
        public string ReportType { get; set; }

        public void OnPost()
        {
            // Capture the selected report type from the form
            ReportType = Request.Form["reportType"];

            // Logic to load the RDLC or Crystal Report based on the selected type
            if (ReportType == "employeeWise")
            {
                // Load Employee-wise report
                LoadEmployeeWiseReport();
            }
            else if (ReportType == "designationWise")
            {
                // Load Designation-wise report
                LoadDesignationWiseReport();
            }
            // Add other cases for other report types
        }

        private void LoadEmployeeWiseReport()
        {
            // Logic to load the RDLC/Crystal Report for Employee-wise report
            // For RDLC, you can use the LocalReport object to load the report
            // For Crystal Reports, you can use the ReportDocument object
        }

        private void LoadDesignationWiseReport()
        {
            // Logic to load Designation-wise report
        }
    }

}
