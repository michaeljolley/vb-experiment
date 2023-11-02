using DotNetEnv;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebGIJoeTestProject.Base;

public class BaseSetup
{
    private static IWebDriver driver;

    [OneTimeSetUp]
    public void Setup()
    {
        Env.TraversePath().Load();
    }

    [SetUp]
    public void Start_Browser()
    {
        driver = SetBrowser();
        string? url = ProjectConfig.Url;
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();
    }

    private IWebDriver SetBrowser()
    {
        string? RunEnivorment = ProjectConfig.RunEnvironment;

        if (RunEnivorment.ToLower() != null && RunEnivorment.Equals("local"))
        {

            driver = DriverSetup.LocalBrowserSetup(driver);
        }
        else if (RunEnivorment.ToLower() != null && RunEnivorment.Equals("remote"))
        {
            // Code for remote execution
        }
        else
        {
            Console.WriteLine("Please check browser name and run enivorment value in your .env file");

        }

        return driver;
    }

    public IWebDriver GetDriver()
    {
        return driver;
    }

    [TearDown]
    public void SetTestResults()
    {
        driver.Quit(); // warning CS8602: Dereference of a possibly null reference
    }
}
