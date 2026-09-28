using System.Data;
using Microsoft.Playwright;
namespace Tests.Pages;

public class InventoryPage
{
    private IPage _page;
    private ILocator _header;

     public InventoryPage(IPage page)
    {
        _page = page;
        _header = _page.Locator("[data-test=\"title\"]");
    }
    
    public ILocator Header => _header;
}

