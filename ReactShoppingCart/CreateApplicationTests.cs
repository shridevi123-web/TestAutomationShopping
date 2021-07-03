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

    public class CreateApplicationTests
    {
        public static IWebDriver driver;
        private IWebElement totalNumberOfItemsInCart => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/p[1]/following-sibling::h4[@class=' mb-3 txt-right']"));

        private IWebElement totalPaymentInCart => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/p[2]/following-sibling::h3[@class='m-0 txt-right']"));

        private IWebElement deleteButton => driver.FindElement(By.XPath("//div[@id='root']/ main/div/div[2]/div[1]/div/div/div/div[4]/button[2]"));

        private IWebElement clearButton => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/div/button[2]"));

        private IWebElement reduceButton => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[1]/div/div/div[1]/div[4]/button[2]"));

        private IWebElement deleteButtonForSecondItem => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[1]/div/div/div[2]/div[4]/button[2]"));

        private IWebElement checkoutDisplayMessage => driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div/div[2]"));
         [Test, Category("Scenario_1")]
        public void Test_case_Scenario_1()
        {
            driver = new ChromeDriver("C:\\Users\\Kranthi\\source\\chrome_home");
            driver.Url = "https://react-shooping-cart.netlify.app/";
            /* click one item Add to Cart*/
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div[1]/div/button")).Click();

            /*Click on Cart */
            driver.FindElement(By.XPath("//div[@id='root']/header/a[3]")).Click();

            Assert.AreEqual(Check_TotalItemsInCart(), "1");
            Assert.AreEqual(Check_TotalPaymentInCart(), "$39.11");
            Assert.IsTrue(Check_DeleteButtonExists());

            /*clear cart */
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/div/button[2]")).Click();            
           
            driver.Close();
        }


        [Test, Category("Scenario_2")]
        public void Test_case_Scenario_2()
        {
            driver = new ChromeDriver("C:\\Users\\Kranthi\\source\\chrome_home");
            driver.Url = "https://react-shooping-cart.netlify.app/";

            /* click first item- Add to Cart*/
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div[1]/div/button")).Click();

            /* click second item- Add to Cart*/
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div[2]/div/button")).Click();


            /*Click on Cart */
            driver.FindElement(By.XPath("//div[@id='root']/header/a[3]")).Click();

            /* For the first item, increase quantity to 3 */
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[1]/div/div/div[1]/div[4]/button[1]")).Click();
             driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[1]/div/div/div[1]/div[4]/button[1]")).Click();

            /*Check value of Total Items, Total Payment */
            Assert.AreEqual(Check_TotalItemsInCart(), "4");
            Assert.AreEqual(Check_TotalPaymentInCart(), "$375.25");

            /*Check that Reduce button displays for the first item */
            Assert.IsTrue(Check_ReduceButtonExists());

            /*Check that Delete button displays for the second item */
            Assert.IsTrue(Check_DeleteButtonExistsSecondItem());

            /*For the first item, decrease quantity to 2 */
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[1]/div/div/div[1]/div[4]/button[2]")).Click();
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[1]/div/div/div[1]/div[4]/button[2]")).Click();


            /*Check value of Total Items, Total Payment */
            Assert.AreEqual(Check_TotalItemsInCart(), "2");
            Assert.AreEqual(Check_TotalPaymentInCart(), "$297.03");

            /*Delete the second item*/
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[1]/div/div/div[2]/div[4]/button[2]")).Click();

            /* Check that the first item is removed from cart */
            Assert.AreEqual(Check_TotalItemsInCart(), "1");
            Assert.AreEqual(Check_TotalPaymentInCart(), "$39.11");

            /*Click Checkout button*/
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/div/button[1]")).Click();

            /*Check that message “Checkout successfully” display*/
            string checkOutSuccessfullMessage = checkoutDisplayMessage.Text;
            Assert.IsTrue(checkOutSuccessfullMessage.Contains("Checkout successfull"), checkoutDisplayMessage + "Checkout is Unsuccessfull" );
            driver.Close();

        }

        public string Check_TotalItemsInCart()
        {
            var numOfItems = totalNumberOfItemsInCart.Text;
            return numOfItems;
        }

        public string Check_TotalPaymentInCart()
        {
            var totalPayment = totalPaymentInCart.Text;
            return totalPayment;
        }

        /*  Check that Delete button appears for the added item */
            public bool Check_DeleteButtonExists()
        {

            if (deleteButton.Displayed)
            {
                return true;
            }
            return false;
        }

        /* Click Clear button */
        public CreateApplicationTests Click_ClearButton()
        {
            Driver.RetryClick(clearButton);
            return this;
        }

        /*  Check that reduce button appears for first Item  */
        public bool Check_ReduceButtonExists()
        {

            if (reduceButton.Displayed)
            {
                return true;
            }
            return false;
        }
        /*  Check that delete button appears for second Item  */
        public bool Check_DeleteButtonExistsSecondItem()
        {

            if (deleteButtonForSecondItem.Displayed)
            {
                return true;
            }
            return false;
        }

        /* reduce item one */
        public CreateApplicationTests Click_ReducerButtonItem_1()
        {
            Driver.RetryClick(clearButton);
            return this;
        }
     
    }

    
}
