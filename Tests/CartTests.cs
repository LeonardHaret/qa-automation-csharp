using Tests.Pages;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;


[TestFixture]

public class CartTests : PageTest
{
    private InventoryPage? _inventoryPage;
    private LoginPage? _loginPage;
    
    [SetUp]
    public async Task SetUp()
    {
     _loginPage = new LoginPage(Page);
     _inventoryPage = new InventoryPage(Page);
     await _loginPage.GotoLogin();
     await _loginPage.Login("standard_user","secret_sauce");
     await Expect(Page).ToHaveURLAsync(_inventoryPage.Url);   
    }

    [Test]

    public async Task seeCartUpdates()
    {
        await _inventoryPage.AddToCartBackpack.ClickAsync();
        await Expect(_inventoryPage.ShoppingCartBadge).ToHaveTextAsync("1");          

    }




}