using ConsoleApp2.Page;
using log4net;
using log4net.Repository.Hierarchy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ConsoleApp2.Consts;
using ConsoleApp2.MyLogger;

namespace SeleniumWebOtomation
{
    internal class Program 
    {
     
        static MainPage page;
        static WebDriver driver = new ChromeDriver();
        
        static Program()
        {
            

        
                //_logger.("Program başladı",1);
                page = new MainPage(driver);
        }

        public static void Main(string[] args)
        {

            String currentURL = driver.Url;
            MyLog.Log("Geçerli URL => " + currentURL); //URL Kontrolü

            MyLog.Log("Ürün araması yapıyoruz.",LoggerCons.INFO);
            page.search("ceket");
            MyLog.Log("Ürün araması başarılı.", LoggerCons.INFO);
            
            MyLog.Log("Aramayı tamamlamak için arama kutusuna Enter tuşu gönderiyoruz.", LoggerCons.INFO);
            page.sendKeys(Cons.INPUT_SEARCH, OpenQA.Selenium.Keys.Enter);
            MyLog.Log("Aramayı tamamlamak için arama kutusuna Enter tuşu gönderildi.", LoggerCons.INFO);
            String currentURL2 = driver.Url;
            MyLog.Log("Geçerli URL => " + currentURL2); //URL Kontrolü

            MyLog.Log("Daha fazla yükle butonuna basıyoruz", LoggerCons.INFO);
            page.click(Cons.LOAD_MORE);
            MyLog.Log("Daha fazla yükle butonuna basıldı", LoggerCons.INFO);
            Thread.Sleep(3000);
            String currentURL3 = driver.Url;
            MyLog.Log("Geçerli URL => " + currentURL3); //URL Kontrolü
            MyLog.Log("İndirimli ürün bulunmaya çalışıyor", LoggerCons.INFO);
            
            
            string price = page.GetPriceByItem(Cons.DISCOUNTED_ITEM);

            
            IWebElement element = page.hoverElementAndReturn(Cons.DISCOUNTED_ITEM);
            //page.hoverElement(Cons.DISCOUNTED_ITEM);
            MyLog.Log("İndirimli ürün bulundu, hoverlanıyor", LoggerCons.INFO);
            Thread.Sleep(3000);
            string attr = page.getText(element);
            //cartItem__attrValue
            MyLog.Log("Sadece aktif olan bedenler arasından rastgele bir tanesini seçmeyi deniyoruz...", LoggerCons.INFO);
            element = page.getSizesAndRandomize(element);
            MyLog.Log("Aktif Olan Bedenler Bulundu", LoggerCons.INFO);
            Thread.Sleep(500);
            MyLog.Log("Seçebileceğimiz aktif bedeni seçmeye çalışıyoruz.", LoggerCons.INFO);
            page.Release(element);
    
            Thread.Sleep(500);
            page.click(element);
            
            page.patchElement();
            MyLog.Log("Seçebileceğimiz aktif bedenlerden rastgele birini seçtik.", LoggerCons.INFO);
           
            MyLog.Log("Sepete Git'e Tıklıyoruz...", LoggerCons.INFO);
            
            Thread.Sleep(500);
            
            page.click(Cons.ADD_TO_CART);

            string finalPrice = page.getText(Cons.FINAL_PRODUCT_PRICE);
            string finalAttr = page.getText(Cons.ITEM_ATTR);

            MyLog.Log("Ürünün İndirimli Fiyatı: " + price, LoggerCons.INFO);
            MyLog.Log("İndirim Oranı: " + attr, LoggerCons.INFO);
            MyLog.Log("Ürünün Eski Fiyatı: " + finalPrice, LoggerCons.INFO);
            MyLog.Log("Bedeni: " + finalAttr, LoggerCons.INFO);
            
            MyLog.Log("Devam Et'e Tıkladık.", LoggerCons.INFO);

            Thread.Sleep(5000);
            MyLog.Log("Satın alıma geçiyoruz...", LoggerCons.INFO);
            page.click(Cons.CONTINUE_TO_BUY);
            MyLog.Log("Satın alıma geçtik...", LoggerCons.INFO);

            MyLog.Log("Giriş yapıyoruz...", LoggerCons.INFO);
            page.Login();
            MyLog.Log("Giriş yaptık...", LoggerCons.INFO);

            MyLog.Log("Network Simgesine Tıklanıyor...", LoggerCons.INFO);
            page.click(Cons.LOGO);
            MyLog.Log("Network Simgesine Tıklandı.", LoggerCons.INFO);

            MyLog.Log("Shopping Bag Simgesine Tıklanıyor...", LoggerCons.INFO);
            page.click(Cons.SHOPPING);
            MyLog.Log("Shopping Bag Simgesine Tıklandı.", LoggerCons.INFO);

            MyLog.Log("Sepetteki Ürünler Siliniyor...", LoggerCons.INFO);
            page.click(Cons.DELETE_SHOPPING);
            page.click(Cons.DELETE_ITEM_SHOPPING);
            MyLog.Log("Sepetteki Ürünler Silindi.", LoggerCons.INFO);
            MyLog.Log("Sepetin Boş Olduğu Doğrulanıyor...", LoggerCons.INFO);
            page.click(Cons.SHOPPING);
            MyLog.Log("Sepetiniz Boş.", LoggerCons.INFO);
            MyLog.Log("Tüm İşlemler Başarıyla Gerçekleşti Programı Kapatabilirsiniz.", LoggerCons.INFO);

        }
    }


        
 
}