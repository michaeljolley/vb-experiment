using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebGIJoeTestProject.Base;

namespace WebGIJoeTestProject.Pages;

public class HomePage : BaseDriver
{

    [FindsBy(How = How.XPath, Using = "//*[@id='cmdNext']//button")]
    private IWebElement NextButton { get; set; }

    [FindsBy(How = How.XPath, Using = "//*[@id='btnLoadData']//button")]
    private IWebElement LoadDataButton { get; set; }

    [FindsBy(How = How.XPath, Using = "//*[@id='txtName']//input")]
    private IWebElement NameInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//*[@id='txtAllegiance']//input")]
    private IWebElement AllegianceInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
    private IWebElement OkButton { get; set; }

    [FindsBy(How = How.XPath, Using = "//*[@class='Msg_message' and contains(text(),'Downloaded')]")]
    private IWebElement DownloadedLabelDialog { get; set; }

    public HomePage(IWebDriver driver) : base(driver)
    {
        
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
        string inputText = NameInput.GetAttribute("ng-reflect-model");
        return inputText;
    }

    public string GetTextFromAllegianceInput()
    {
        string inputText = AllegianceInput.GetAttribute("ng-reflect-model");
        return inputText;
    }

    public void waitUntilInputNameChanged(string name)
    {
        wait.Until(AttributeValueChanged(NameInput,"ng-reflect-model" , name));
    }
}
