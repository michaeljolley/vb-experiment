using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using NUnit.Framework.Internal;
using DotNetEnv;
using VbGIJoeTestProject;
using NUnit.Framework;
using System.Diagnostics;
using VbGIJoeTestProject.Base;

namespace Tests;

[TestFixture]
public class VbGIJoeTests : BaseTest
{ 


    [Test]
    public void VerifyLoadButtonAction()
    {
        VbGIJoeMainView GIJoeMainView = new VbGIJoeMainView(GetDriver());
        GIJoeMainView.ClickOnLoadDataButton();
        Assert.IsTrue(GIJoeMainView.DownloadedRecordsLabelIsDisplayed(), "The Downloaded label is not visible", "The Downloaded label is visible");
        GIJoeMainView.ClickOnOkButton();
        Assert.False(GIJoeMainView.DownloadedRecordsLabelIsDisplayed(), "The Downloaded label is visible", "The Downloaded label is not visible");
    }

    [Test]
    public void VerifyNextButtonAction()
    {
        VbGIJoeMainView GIJoeMainView = new VbGIJoeMainView(GetDriver());
        string name1 = GIJoeMainView.GetTextFromNameInput();
        Console.WriteLine("Name value first time: " + name1);
        GIJoeMainView.ClickOnNextButton();
        string name2 = GIJoeMainView.GetTextFromNameInput();
        Console.WriteLine("Name value after click on next button: " + name2);
        Assert.AreNotEqual(name2, name1);
    }

    [Test]
    public void VerifyNextButtonChangesAllegiance()
    {
        VbGIJoeMainView GIJoeMainView = new VbGIJoeMainView(GetDriver());
        string allegiance1 = GIJoeMainView.GetTextFromAllegianceInput();
        string allegiance2 = "";
        Console.WriteLine("Allegiance value first time: " + allegiance1);
        int tries = 5;

        while (tries-- > 0)
        {
            GIJoeMainView.ClickOnNextButton();
            allegiance2 = GIJoeMainView.GetTextFromAllegianceInput();
            if (allegiance1 != allegiance2)
            {
                break;
            }
        }
        Console.WriteLine("Allegiance value out of the while: " + allegiance2);
        Assert.AreNotEqual(allegiance1, allegiance2, "Allegiance values are not different");
    }
}