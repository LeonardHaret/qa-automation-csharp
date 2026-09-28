using Tests.Pages;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;


[TestFixture]
 public class LoginTest : PageTest
{
    [Test]
    public async Task Login()
    {
        var loginPage = new LoginPage(Page);
        var inventoryPage =  new InventoryPage(Page);
         await loginPage.GotoLogin();
         await loginPage.Login("standard_user","secret_sauce");
         await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
         await Expect(inventoryPage.Header).ToBeVisibleAsync();
    }
}