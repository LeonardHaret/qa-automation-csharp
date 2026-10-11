using Tests.Pages;
using Microsoft.Playwright.NUnit;
namespace Tests;



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

    public async Task AddItemToCart_UpdatesBadgeCount()
    {
        await _inventoryPage.AddToCartBackpack.ClickAsync();
        await Expect(_inventoryPage.ShoppingCartBadge).ToHaveTextAsync("1");          
    }


[Test]
    public async Task RemoveItemFromCart_UpdatesBadgeCount()
    {
       await _inventoryPage.AddToCartBackpack.ClickAsync();
       await _inventoryPage.RemoveFromCartBackpack.ClickAsync();
       await Expect(_inventoryPage.ShoppingCartBadge).ToBeHiddenAsync();
    }
}