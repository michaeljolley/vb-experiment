using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace WebGIJoeTestProject.Base;

public class BaseDriver
{
    private IWebDriver driver;
    public WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(5));

    public BaseDriver(IWebDriver driver)
    {
        this.driver = driver;
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        PageFactory.InitElements(driver, this);
    }

    public IWebElement WaitForElementToBeVisible(By element)
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(element));
    }

    public static bool IsDisplayed(IWebElement element)
    {
        try
        {
            return element.Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static Func<IWebDriver, bool> AttributeValueChanged(IWebElement element, string attributeName, string oldValue)
    {
        return driver =>
        {
            try
            {
                string attributeValue = element.GetAttribute(attributeName);
                if (attributeValue != oldValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (StaleElementReferenceException)
            {
                // Handle the case where the element becomes stale
                return false;
            }
        };
    }
}
