using Tests.Pages;
using Microsoft.Playwright.NUnit;




[TestFixture]

 public class LoginTest : PageTest
{
    private  LoginPage _loginPage;
    private InventoryPage _inventoryPage;
    
    [SetUp]
    public async Task SetUp()
    {
     _loginPage = new LoginPage(Page);
     _inventoryPage = new InventoryPage(Page);
     await _loginPage.GotoLogin();   
    }
    
    [Test]
    public async Task ValidCredentials_RedirectsToInventory()
    {
         await _loginPage.Login("standard_user","secret_sauce");
         await Expect(Page).ToHaveURLAsync(_inventoryPage.Url);
         await Expect(_inventoryPage.Header).ToBeVisibleAsync();
    }

    
    [TestCase("standard_user","wrongpass","Epic sadface: Username and password do not match any user in this service")]
    [TestCase("locked_out_user","secret_sauce","Epic sadface: Sorry, this user has been locked out.")]
    [TestCase("","","Epic sadface: Username is required")]
    [TestCase("standard_user","","Epic sadface: Password is required")]
    public async Task InvalidLogin_ShowsExpectedError(string username, string password, string expectedError)
    {
        await _loginPage.Login(username,password);
        await Expect(_loginPage.ErrorMessage).ToHaveTextAsync(expectedError);
        await Expect(Page).Not.ToHaveURLAsync(_inventoryPage.Url);
    }
}




