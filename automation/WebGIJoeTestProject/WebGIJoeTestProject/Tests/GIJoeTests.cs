using NUnit.Framework;
using WebGIJoeTestProject.Base;
using WebGIJoeTestProject.Pages;

namespace WebGIJoeTestProject.Tests;

[TestFixture]
public class GIJoeTests : BaseSetup
{

    [Test]
    public void VerifyLoadButtonAction()
    {
        var homePage = new HomePage(GetDriver());
        homePage.ClickOnLoadDataButton();
        Assert.IsTrue(homePage.DownloadedRecordsLabelIsDisplayed(), "The Downloaded label is not visible", "The Downloaded label is visible");
        homePage.ClickOnOkButton();
        Assert.False(homePage.DownloadedRecordsLabelIsDisplayed(), "The Downloaded label is visible", "The Downloaded label is not visible");
    }

    [Test]
    public void VerifyNextButtonAction()
    {
        var homePage = new HomePage(GetDriver());
        string name1 = homePage.GetTextFromNameInput();
        Console.WriteLine("Name value first time: " + name1);
        homePage.ClickOnNextButton();
        homePage.waitUntilInputNameChanged(name1);
        string name2 = homePage.GetTextFromNameInput();
        Console.WriteLine("Name value after click on next button: " + name2);
        Assert.That(name1, Is.Not.EqualTo(name2));
    }

    [Test]
    public void VerifyNextButtonChangesAllegiance()
    {
        var homePage = new HomePage(GetDriver());
        string allegiance1 = homePage.GetTextFromAllegianceInput();
        string allegiance2 = "";
        Console.WriteLine("Allegiance value first time: " + allegiance1);
        int tries = 5;

        while (tries-- > 0)
        {
            homePage.ClickOnNextButton();
            allegiance2 = homePage.GetTextFromAllegianceInput();
            if (allegiance1 != allegiance2)
            {
                break;
            }
        }
        Console.WriteLine("Allegiance value out of the while: " + allegiance2);
        Assert.That(allegiance1, Is.Not.EqualTo(allegiance2));
    }
}
