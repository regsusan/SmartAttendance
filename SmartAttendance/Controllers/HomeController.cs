using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmartAttendance.Models;

namespace SmartAttendance.Controllers
{
    public class HomeController : Controller
    {

        private static List<AttendanceViewModel> _attendanceRecords = new();

        [HttpPost("ReceiveAttendance")]
        public IActionResult ReceiveAttendance([FromBody] List<AttendanceViewModel> attendanceData)
        {
            if (attendanceData == null || attendanceData.Count == 0)
                return BadRequest(new { message = "Invalid or empty data" });

            _attendanceRecords = attendanceData;
            return Ok(new { message = "Success Response" });
        }
        public IActionResult Index()
        {
            return View(_attendanceRecords);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
