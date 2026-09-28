using System.Dynamic;
using Microsoft.Playwright.NUnit;

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