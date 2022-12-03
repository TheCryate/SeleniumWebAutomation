using ConsoleApp2.Base;
using ConsoleApp2.Consts;
using ConsoleApp2.MyLogger;
using CsvHelper;
using CsvHelper.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Page
{
    public  class MainPage : BasePage
    {
        WebDriver _driver;
        
        public MainPage(WebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(Cons.BASE_URL);
            _driver = driver;
            
        }
        public void search(string key)
        {
            sendKeys(Cons.INPUT_SEARCH, key);      
        }
        public IWebElement getSizesAndRandomize(IWebElement element)
        {
            var discountParent = element.FindElement(By.XPath(".. /../../../*"));
            var sizeContent = discountParent.FindElement(By.ClassName("product__sizeContent"));
            var sizeList = sizeContent.FindElement(By.ClassName("product__sizeList"));
            var sizeItem = sizeList.FindElement(By.ClassName("product__sizeItem"));
            var sizeItems = sizeItem.FindElements(By.ClassName("product__size"));
            
            var enabledInputs = sizeItems.Where(x => x.FindElement(By.TagName("input")).Enabled).ToList();
            var randomInput = enabledInputs[new Random().Next(0, enabledInputs.Count)];
            var randomInputLabel = randomInput.FindElement(By.TagName("label"));
            
            foreach (var item in enabledInputs)
            {
                MyLog.Log(item.Text, LoggerCons.INFO);
            }
            return randomInputLabel;
        }
      
        public string GetPriceByItem(By element)
        {
            var price = findElement(element).FindElement(By.XPath("./..")).FindElements(By.ClassName("product__price"))[1];
            //MyLog.Log(price.Text, LoggerCons.WARN);
            return price.Text;
        }
        public void GetPriceByItem(IWebElement element)
        {
            MyLog.Log(element.GetDomAttribute("innerHTML"));
            
            var price = element.FindElements(By.ClassName("product__item"));
            foreach(var item in price)
            {
                MyLog.Log(item.Text, LoggerCons.INFO);
            }
        }
        public IWebElement hoverElementAndReturn(By by)
        {
            IWebElement element = findElement(by);
            hoverElement(by);
            return element;
        }

        
        public void patchElement()
        {
            _driver.ExecuteJavaScript("document.getElementsByClassName('header__basket')[0].setAttribute('class','header__basket js-basket header__basketLink -basketOpen')");
            //MyLog.Log("Patchledik");
        }
        

        public void Login()
        {

            Users.Users user = new Users.Users();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader("password.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Users.Users>();
                user.Email = records.ElementAt(0).Email;
                user.Password = records.ElementAt(0).Password;

            }
               
            var email = findElement(Cons.INPUT_EMAIL);
            email.SendKeys(user.Email);
            var password = findElement(Cons.INPUT_PASSWORD);
            password.SendKeys(user.Password);
        }

    }
}
