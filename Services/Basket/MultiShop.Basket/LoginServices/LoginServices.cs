namespace MultiShop.Basket.LoginServices;

public class LoginServices : ILoginServices
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginServices(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;

}
