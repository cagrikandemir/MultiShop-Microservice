using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityservice;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityservice)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityservice = identityservice;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            await _identityservice.SignIn(loginDto);
            return RedirectToAction("Index", "User");
        }


        //[HttpGet]
        //public async Task<IActionResult> SignUp()
        //{
        //    return View();
        //}
         //[HttpPost]
         public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            loginDto.UserName = "cagrikandemir";
            loginDto.Password = "123456aA*";
            await _identityservice.SignIn(loginDto);
            return RedirectToAction ("Index", "User");

        }
    }
}
