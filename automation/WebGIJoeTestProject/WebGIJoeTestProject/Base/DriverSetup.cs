using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System.Configuration;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebGIJoeTestProject.Base;

public class DriverSetup
{
    private static string? RunEnivorment = ProjectConfig.RunEnvironment;
    private static string? browser_name = ProjectConfig.Browser;
    public static IWebDriver LocalBrowserSetup(IWebDriver driver)
    {
        if (BrowserType.Chrome.ToString().Equals(browser_name))
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
        }
        else if (BrowserType.Firefox.ToString().Equals(browser_name))
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }
        else if (BrowserType.IE.ToString().Equals(browser_name))
        {
            new DriverManager().SetUpDriver(new InternetExplorerConfig());
            driver = new InternetExplorerDriver();
        }
        else
        {
            Console.WriteLine("Default Browser is initated, please check browser details in your .env file");
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        return driver;

    }
}
