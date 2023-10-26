using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;


public partial class VbGIJoeMainView
{
    private WindowsDriver<WindowsElement> _driver;

    public VbGIJoeMainView(WindowsDriver<WindowsElement> driver)
    {
        _driver = driver;
    }

    public void ClickOnLoadDataButton()
    {
        LoadDataButton.Click();
    }

    public void ClickOnOkButton()
    {
        OkButton.Click();
    }

    public bool DownloadedRecordsLabelIsDisplayed()
    {
        return IsDisplayed(DownloadedLabelDialog);
    }

    public void ClickOnNextButton()
    {
        NextButton.Click();
    }

    public string GetTextFromNameInput()
    {
        return NameInput.Text;
    }

    public string GetTextFromAllegianceInput()
    {
        return AllegianceInput.Text;
    }

    public static bool IsDisplayed(WindowsElement element)
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

    public WindowsElement findElementByXpath(string xpath)
    {
        try
        {
            return _driver.FindElementByXPath(xpath);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
