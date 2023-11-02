using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using NUnit.Framework.Internal;
using DotNetEnv;
using VbGIJoeTestProject;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class VbGIJoeTests
{
    private WindowsDriver<WindowsElement> _driver;
    private VbGIJoeMainView _GIJoeMainView;

    [OneTimeSetUp]
    public void LoadEnvironmentVariables()
    {
        // Load environment variables from .env file
        Env.TraversePath().Load(); 
    }

    [SetUp]
    public void TestInit()
    {
        var options = new AppiumOptions();
        options.AddAdditionalCapability("app", $@"{ProjectConfig.VbGiJoeAppPath}");
        options.AddAdditionalCapability("deviceName", $"{ProjectConfig.DeviceName}");
        _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _GIJoeMainView = new VbGIJoeMainView(_driver);
    }

    [TearDown]
    public void TestCleanup()
    {
        if (_driver != null)
        {
            _driver.Quit();
            _driver = null;
        }
    }

    [Test]
    public void VerifyLoadButtonAction()
    {
        _GIJoeMainView.ClickOnLoadDataButton();
        Assert.IsTrue(_GIJoeMainView.DownloadedRecordsLabelIsDisplayed(), "The Downloaded label is not visible", "The Downloaded label is visible");
        _GIJoeMainView.ClickOnOkButton();
        Assert.False(_GIJoeMainView.DownloadedRecordsLabelIsDisplayed(), "The Downloaded label is visible", "The Downloaded label is not visible");
    }

    [Test]
    public void VerifyNextButtonAction()
    {
        string name1 = _GIJoeMainView.GetTextFromNameInput();
        Console.WriteLine("Name value first time: " + name1);
        _GIJoeMainView.ClickOnNextButton();
        string name2 = _GIJoeMainView.GetTextFromNameInput();
        Console.WriteLine("Name value after click on next button: " + name2);
        Assert.AreNotEqual(name2, name1);
    }

    [Test]
    public void VerifyNextButtonChangesAllegiance()
    {
        string allegiance1 = _GIJoeMainView.GetTextFromAllegianceInput();
        string allegiance2 = "";
        Console.WriteLine("Allegiance value first time: " + allegiance1);
        int tries = 5;

        while (tries-- > 0)
        {
            _GIJoeMainView.ClickOnNextButton();
            allegiance2 = _GIJoeMainView.GetTextFromAllegianceInput();
            if (allegiance1 != allegiance2)
            {
                break;
            }
        }
        Console.WriteLine("Allegiance value out of the while: " + allegiance2);
        Assert.AreNotEqual(allegiance1, allegiance2, "Allegiance values are not different");
    }
}