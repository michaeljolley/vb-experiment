using DotNetEnv;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;

namespace VbGIJoeTestProject.Base;

public class BaseTest
{
    private static WindowsDriver<WindowsElement> ?driver;

    [OneTimeSetUp]
    public void Setup()
    {
        // Load environment variables from .env file
        Env.TraversePath().Load();
        Process.Start(ProjectConfig.WinAppDriverPath);
    }

    [SetUp]
    public void Start_Browser()
    {
        var options = new AppiumOptions();
        options.AddAdditionalCapability("app", $@"{ProjectConfig.VbGiJoeAppPath}");
        options.AddAdditionalCapability("deviceName", $"{ProjectConfig.DeviceName}");
        driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [TearDown]
    public void TestCleanup()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
    }


    [OneTimeTearDown]
    public void SuiteCleanup()
    {
        // Killing WinAppDriver process
        var winDriverProcesses = Process.GetProcessesByName("WinAppDriver");
        foreach (var winProcess in winDriverProcesses)
        {
            winProcess.Kill();
        }
    }

    public WindowsDriver<WindowsElement> GetDriver()
    {
        return driver;
    }

}
