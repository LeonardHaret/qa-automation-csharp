using Microsoft.Playwright.NUnit;
namespace Tests;

[TestFixture]
public class SmokeTest:PageTest
{

    
    [Test]
    public async Task Navigate()
    {   
        await Page.GotoAsync("https://www.saucedemo.com");
       string pageTitle = await Page.TitleAsync();
       Assert.That(pageTitle, Is.EqualTo("Swag Labs"));
    }

}