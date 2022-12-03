using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace ConsoleApp2.Base
{
    public abstract class BasePage
    {
        WebDriver? driver = null;
        WebDriverWait? wait = null;
        
        public BasePage(WebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            driver.Manage().Window.Maximize();
        }
        public IWebElement findElement(By by)
        {
            
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            return driver.FindElement(by);
            
        }
        public void sendKeys(By by, string text)
        {
            findElement(by).SendKeys(text);
        }
        public void click(By by)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            findElement(by).Click();
        }
        public void click(IWebElement by)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            by.Click();
        }
        public void hoverElement(By by)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(findElement(by)).Perform();
        }
        public void Release(By by)
        {
            Actions actions = new Actions(driver);
            actions.Release(findElement(by)).Perform();
        }
        public void Release(IWebElement by)
        {
            Actions actions = new Actions(driver);
            actions.Release(by).Perform();
        }

        public string getText(By by)
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            return driver.FindElement(by).Text;
        }
        public string getText(IWebElement by)
        { 
            return by.Text;
        }

    }
}
