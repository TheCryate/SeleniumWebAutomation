using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Consts
{
    public static class Cons
    {
        public static string BASE_URL { get; set; } = "https://www.network.com.tr/";
        
        public static By LOGO = By.ClassName("headerCheckout__logo__img");

        public static By INPUT_SEARCH = By.Name("searchKey");

        public static By INPUT_EMAIL = By.Name("Email");
        
        public static By INPUT_PASSWORD = By.Name("Password");

        public static By LOAD_MORE = By.XPath("//*[@id=\"pagedListContainer\"]/div[2]/div[2]");

        public static By DISCOUNTED_ITEM = By.ClassName("product__discountPercent");

        public static By ITEM_SIZES_BASE = By.XPath(".. /../../../*");

        public static By ADD_TO_CART = By.XPath("/html/body/div[2]/header/div/div/div[3]/div[2]/div/div/div[3]/a");

        public static By CONTINUE_TO_BUY = By.ClassName("continueButton");

        public static By PRODUCT_PRICE = By.ClassName("product__item");

        public static By FINAL_PRODUCT_PRICE = By.ClassName("summaryItem__value");

        public static By ITEM_ATTR = By.ClassName("cartItem__attrValue");

        public static By SHOPPING = By.ClassName("-shoppingBag");

        public static By DELETE_ITEM = By.XPath("/html/body/div/div/div[1]/div[1]/div[1]/div[2]/section/div[3]/div/div/div[2]/div[3]/button");

        public static By DELETE_SHOPPING = By.ClassName("header__basketProductRemove");

        public static By DELETE_ITEM_SHOPPING = By.XPath("/html/body/div[5]/div[2]/div/div[2]/button[2]");  

        

        //public static By RETURN_MAIN = By.XPath("");
    }
}
