using Microsoft.Playwright;
namespace Tests.Pages;
public class LoginPage
{
    private IPage _page;
    private ILocator _username;
    private ILocator _password;
    private ILocator _loginButton;
    
    public LoginPage(IPage page) 
    {
        _page = page;
        _username = _page.Locator("#user-name");
        _password = _page.Locator("#password");
        _loginButton = _page.Locator("#login-button");

    }

    public async Task GotoLogin()
    {
        await _page.GotoAsync("https://www.saucedemo.com");
    }
    public async Task Login(string username, string password)
    {
        await _username.FillAsync(username);
        await _password.FillAsync(password);
        await _loginButton.ClickAsync();
    }

}

