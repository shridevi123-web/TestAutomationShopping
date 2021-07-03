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
    public class CartPage
    {
        IWebDriver driver;
    

        private IWebElement totalNumberOfItemsInCart => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/p[1]/following-sibling::h4[@class=' mb-3 txt-right']"));

        private IWebElement totalPaymentInCart => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/p[2]/following-sibling::h3[@class='m-0 txt-right']"));

        private IWebElement deleteButton => driver.FindElement(By.XPath("//div[@id='root']/ main/div/div[2]/div[1]/div/div/div/div[4]/button[2]"));

        private IWebElement clearButton => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/div/button[2]"));

        public string Check_TotalItemsInCart()
        {
            var numOfItems = totalNumberOfItemsInCart.GetAttribute("value");
            return numOfItems;
        }

        public string Check_TotalPaymentInCart()
        {
            var totalPayment = totalPaymentInCart.GetAttribute("value");
            return totalPayment;
        }

      /*  Check that Delete button appears for the added item */
      public bool Check_DeleteButtonExists()
        {
          
            if(deleteButton.Displayed)
            {               
                return true;
            }
            return false;
        }

        /* Click Clear button */
        public CartPage Click_ClearButton()
        {
            Driver.RetryClick(clearButton);
            return this;
        }

    }
}
