using Microsoft.AspNetCore.Mvc;
using QLBH.Data;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RegisterController(ApplicationDBContext context)
        {
            _context = context;
        }


       
    }
}
