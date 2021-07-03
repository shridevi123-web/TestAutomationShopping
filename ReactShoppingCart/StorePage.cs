using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using ReactShoppingCart.Common;


namespace ReactShoppingCart
{
  public class StorePage
    {  
            public static IWebDriver driver;

            public StorePage()
            {
               // StorePage.driver = driver;
            }
        
        private IWebElement item_1 => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div[1]/div/button"));
       // private IWebElement item_1 => driver.FindElement(By.ClassName("btn btn-primary btn-sm"));
        private IWebElement cart => driver.FindElement(By.LinkText("/cart"));

        public StorePage Click_AddToCart_Itsm_1()
        {
            Driver.RetryClick(item_1);
            return this;
        }
        public StorePage Click_Cart()
        {
            Driver.RetryClick(cart);
            return this;
        }
    }
    
}
