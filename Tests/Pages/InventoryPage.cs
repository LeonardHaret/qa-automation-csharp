using Microsoft.Playwright;
namespace Tests.Pages;

public class InventoryPage
{
    private IPage _page;
    private ILocator _header;
    private string _url ="https://www.saucedemo.com/inventory.html" ;
    private ILocator _addToCartBackpack;
    private ILocator _shoppingCartBadge;
    private ILocator _removeFromCartBackpack;
     public InventoryPage(IPage page)
    {
        _page = page;
       
        _addToCartBackpack = _page.Locator("[data-test = \"add-to-cart-sauce-labs-backpack\"]");
        _header = _page.Locator("[data-test = \"title\"]");
        _shoppingCartBadge = _page.Locator("[data-test = \"shopping-cart-badge\"]");
        _removeFromCartBackpack = _page.Locator("[data-test = \"remove-sauce-labs-backpack\"]");
        
    }
    public IPage inventoryPage => _page;
    public string Url => _url;
    public ILocator Header => _header;
    public ILocator AddToCartBackpack => _addToCartBackpack;
    public ILocator ShoppingCartBadge => _shoppingCartBadge;
    public ILocator RemoveFromCartBackpack => _removeFromCartBackpack;
}

