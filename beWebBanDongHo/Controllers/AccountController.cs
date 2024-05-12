using beWebBanDongHo.DTO;
using beWebBanDongHo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace beWebBanDongHo.Controllers
{
    public class AccountController : Controller
    {
        private WebBanDongHoContext _dB { get; set; }
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _config;

        public AccountController(WebBanDongHoContext WebBanDongHoContext, ILogger<AccountController> logger, IConfiguration configuration)
        {
            this._dB = WebBanDongHoContext;
            _logger = logger;
            _config = configuration;
        }


        [HttpPost]
        [Route("registerAccountUser")]
        public async Task<IActionResult> registerAccountUser([FromBody] AccountRegister data)
        {

            var account = this._dB.TblAccounts.Where(g => g.SEmail == data.SEmail).FirstOrDefault();
            if (account != null)
            {
                return StatusCode(400, "Đã tồn tại userName này");

            }
            var tblAccounteAdd = new TblAccount();
            tblAccounteAdd.PkId = null;
            tblAccounteAdd.SPhoneNumber = data.SPhoneNumber;
            tblAccounteAdd.SAddress = data.SAddress;
            tblAccounteAdd.SPassword = data.SPassword;
            tblAccounteAdd.SCity = data.SCity;
            tblAccounteAdd.SEmail = data.SEmail;
            tblAccounteAdd.SFullName = data.SFullName;
            tblAccounteAdd.SRole = "User";
            this._dB.TblAccounts.Add(tblAccounteAdd);
            this._dB.SaveChanges();
            return Ok(this._dB.TblAccounts.ToList());
        }



        [HttpPost]
        [Route("loginAccount")]
        public async Task<IActionResult> loginAccount([FromBody] loginAccount data)
        {
            var account = this._dB.TblAccounts.Where(g => g.SEmail == data.SEmail && g.SPassword == data.SPassword).FirstOrDefault();

            if (account != null)
            {
                var claims = new[]
               {
                new Claim("fullName",account.SFullName),
                new Claim("email",account.SEmail),
                new Claim("phoneNumber",account.SPhoneNumber),
                new Claim(ClaimTypes.Role,account.SRole),
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                    _config["Tokens:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(30),
                    signingCredentials: creds);

                var resuil = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    Role = account.SRole,
                };
                return Ok(resuil);
            }
            return StatusCode(400, "Tài khoản hoặc mật khẩu sai");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
