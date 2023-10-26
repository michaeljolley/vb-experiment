using OpenQA.Selenium.Appium.Windows;

public partial class VbGIJoeMainView
{
    private WindowsElement NextButton => _driver.FindElementByName("Next");
    private WindowsElement LoadDataButton => _driver.FindElementByName("Load Data");
    private WindowsElement NameInput => _driver.FindElementByXPath("//*[@ClassName='ThunderRT6TextBox'][2]");
    private WindowsElement AllegianceInput => _driver.FindElementByXPath("//*[@ClassName='ThunderRT6TextBox'][1]");
    private WindowsElement OkButton => _driver.FindElementByName("OK");
    private WindowsElement DownloadedLabelDialog => findElementByXpath("//*[contains(@Name, 'Downloaded')]");
}
