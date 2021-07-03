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
using OpenQA.Selenium.Remote;

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
        [Obsolete]
        public void Test_case_Scenario_1_ChromeBrowser()
        {
 
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("os", "windows");
            capabilities.SetCapability("browserstack.user", "shridevireddy_pOY0ka");
            capabilities.SetCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84");
            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capabilities);

            // Add these capabilities to your test script
            OpenQA.Selenium.Chrome.ChromeOptions chromeCapability = new OpenQA.Selenium.Chrome.ChromeOptions();
            chromeCapability.AddAdditionalCapability("os", "Windows", true);
            chromeCapability.AddAdditionalCapability("os_version", "10", true);
            chromeCapability.AddAdditionalCapability("browser", "Chrome", true);
            chromeCapability.AddAdditionalCapability("browser_version", "latest", true);

            driver.Navigate().GoToUrl("https://react-shooping-cart.netlify.app/");

            /* click one item Add to Cart*/
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div[1]/div/button")).Click();

            /*Click on Cart */
            driver.FindElement(By.XPath("//div[@id='root']/header/a[3]")).Click();

            Assert.AreEqual(Check_TotalItemsInCart(), "1");
            Assert.AreEqual(Check_TotalPaymentInCart(), "$39.11");
            Assert.IsTrue(Check_DeleteButtonExists());

            /*clear cart */
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/div/button[2]")).Click();            
           
           // driver.Close();
        }


        [Test, Category("Scenario_2")]
        [Obsolete]
        public void Test_case_Scenario_2_ChromeBrowser()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("os", "windows");
            capabilities.SetCapability("browserstack.user", "shridevireddy_pOY0ka");
            capabilities.SetCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84");
            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capabilities);

            // Add these capabilities to your test script
            OpenQA.Selenium.Chrome.ChromeOptions chromeCapability = new OpenQA.Selenium.Chrome.ChromeOptions();
            chromeCapability.AddAdditionalCapability("os", "Windows", true);
            chromeCapability.AddAdditionalCapability("os_version", "10", true);
            chromeCapability.AddAdditionalCapability("browser", "Chrome", true);
            chromeCapability.AddAdditionalCapability("browser_version", "latest", true);

            driver.Navigate().GoToUrl("https://react-shooping-cart.netlify.app/");

            // Testing the home page

            chromeCapability.AddAdditionalCapability("project", "React_TestSecnario_2", true);           
            chromeCapability.AddAdditionalCapability("name", "TestScenario_2", true);


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


        [Test, Category("Scenario_1")]
        
        public void Test_case_Scenario_1_FirefoxBrowser()
        {

            DesiredCapabilities capabilities = new DesiredCapabilities(); 
            capabilities.SetCapability("os", "windows");
            capabilities.SetCapability("browserstack.user", "shridevireddy_pOY0ka");
            capabilities.SetCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84");
            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capabilities);

            // Add these capabilities to your test script
            OpenQA.Selenium.Firefox.FirefoxOptions fireFoxCapability = new OpenQA.Selenium.Firefox.FirefoxOptions();
            fireFoxCapability.AddAdditionalCapability("os", "Windows", true);
            fireFoxCapability.AddAdditionalCapability("os_version", "10", true);
            fireFoxCapability.AddAdditionalCapability("browser", "Firefox", true);
            fireFoxCapability.AddAdditionalCapability("browser_version", "latest", true);

            driver.Navigate().GoToUrl("https://react-shooping-cart.netlify.app/");

            /* click one item Add to Cart*/
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div[1]/div/button")).Click();

            /*Click on Cart */
            driver.FindElement(By.XPath("//div[@id='root']/header/a[3]")).Click();

            Assert.AreEqual(Check_TotalItemsInCart(), "1");
            Assert.AreEqual(Check_TotalPaymentInCart(), "$39.11");
            Assert.IsTrue(Check_DeleteButtonExists());

            /*clear cart */
            driver.FindElement(By.XPath("//div[@id='root']/main/div/div[2]/div[2]/div/div/button[2]")).Click();

            // driver.Close();
        }


        [Test, Category("Scenario_2")]
        [Obsolete]
        public void Test_case_Scenario_2_FirefoxBrowser()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("os", "windows");
            capabilities.SetCapability("browserstack.user", "shridevireddy_pOY0ka");
            capabilities.SetCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84");
            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capabilities);

            // Add these capabilities to your test script
            OpenQA.Selenium.Firefox.FirefoxOptions firefoxCapability = new OpenQA.Selenium.Firefox.FirefoxOptions();
            firefoxCapability.AddAdditionalCapability("os", "Windows", true);
            firefoxCapability.AddAdditionalCapability("os_version", "10", true);
            firefoxCapability.AddAdditionalCapability("browser", "Firefox", true);
            firefoxCapability.AddAdditionalCapability("browser_version", "latest", true);

            driver.Navigate().GoToUrl("https://react-shooping-cart.netlify.app/");

            // Testing the home page

            firefoxCapability.AddAdditionalCapability("project", "React_TestSecnario_2", true);
            firefoxCapability.AddAdditionalCapability("name", "TestScenario_2", true);


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
            Assert.IsTrue(checkOutSuccessfullMessage.Contains("Checkout successfull"), checkoutDisplayMessage + "Checkout is Unsuccessfull");
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

   public void BrowserstackMethodForInitialise(String browser, String version, String os, String os_version)
        {
            //DesiredCapabilities capabilities = new DesiredCapabilities();
            //capabilities.SetCapability("os", "windows");
            //capabilities.SetCapability("browserstack.user", "shridevireddy_pOY0ka");
            //capabilities.SetCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84");

          

            //// Add these capabilities to your test script
            //OpenQA.Selenium.Chrome.ChromeOptions chromeCapability = new OpenQA.Selenium.Chrome.ChromeOptions();
            //chromeCapability.AddAdditionalCapability("os", "Windows", true);
            //chromeCapability.AddAdditionalCapability("os_version", "10", true);
            //chromeCapability.AddAdditionalCapability("browser", "Chrome", true);
            //chromeCapability.AddAdditionalCapability("browser_version", "latest", true);

            switch (browser)
            {
                case "safari": //If browser is Safari, following capabilities will be passed to 'executeTestWithCaps' function
                    OpenQA.Selenium.Safari.SafariOptions safariCapability = new OpenQA.Selenium.Safari.SafariOptions();
                    safariCapability.AddAdditionalCapability("os_version", os_version);
                    safariCapability.AddAdditionalCapability("browser", browser);
                    safariCapability.AddAdditionalCapability("browser_version", version);
                    safariCapability.AddAdditionalCapability("os", os);
                    safariCapability.AddAdditionalCapability("browserstack.user", "shridevireddy_pOY0ka");
                    safariCapability.AddAdditionalCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84");
                    driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), safariCapability);
                    //executeTestWithCaps(safariCapability);
                    break;
                case "chrome": //If browser is Chrome, following capabilities will be passed to 'executeTestWithCaps' function
                    OpenQA.Selenium.Chrome.ChromeOptions chromeCapability = new OpenQA.Selenium.Chrome.ChromeOptions();
                    chromeCapability.AddAdditionalCapability("os_version", os_version, true);
                    chromeCapability.AddAdditionalCapability("browser", browser, true);
                    chromeCapability.AddAdditionalCapability("browser_version", version, true);
                    chromeCapability.AddAdditionalCapability("os", os, true);

                    chromeCapability.AddAdditionalCapability("browserstack.user", "shridevireddy_pOY0ka", true);
                    chromeCapability.AddAdditionalCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84", true);
                    //driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), chromeCapability);
                    //  executeTestWithCaps(chromeCapability);
                    break;
                case "firefox": //If browser is Firefox, following capabilities will be passed to 'executeTestWithCaps' function
                    OpenQA.Selenium.Firefox.FirefoxOptions firefoxCapability = new OpenQA.Selenium.Firefox.FirefoxOptions();
                    firefoxCapability.AddAdditionalCapability("os_version", os_version, true);
                    firefoxCapability.AddAdditionalCapability("browser", browser, true);
                    firefoxCapability.AddAdditionalCapability("browser_version", version, true);
                    firefoxCapability.AddAdditionalCapability("os", os, true);

                    firefoxCapability.AddAdditionalCapability("browserstack.user", "shridevireddy_pOY0ka", true);
                    firefoxCapability.AddAdditionalCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84", true);
                    driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), firefoxCapability);
                    // executeTestWithCaps(firefoxCapability);
                    break;
                case "edge": //If browser is Edge, following capabilities will be passed to 'executeTestWithCaps' function
                    OpenQA.Selenium.Edge.EdgeOptions edgeCapability = new OpenQA.Selenium.Edge.EdgeOptions();
                    edgeCapability.AddAdditionalCapability("os_version", os_version);
                    edgeCapability.AddAdditionalCapability("browser", browser);
                    edgeCapability.AddAdditionalCapability("browser_version", version);
                    edgeCapability.AddAdditionalCapability("os", os);
                   
                    edgeCapability.AddAdditionalCapability("browserstack.user", "shridevireddy_pOY0ka");
                    edgeCapability.AddAdditionalCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84");
                    driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), edgeCapability);
                    //   executeTestWithCaps(edgeCapability);
                    break;
                case "ie": //If browser is IE, following capabilities will be passed to 'executeTestWithCaps' function
                    OpenQA.Selenium.IE.InternetExplorerOptions ieCapability = new OpenQA.Selenium.IE.InternetExplorerOptions();
                    ieCapability.AddAdditionalCapability("os_version", os_version, true);
                    ieCapability.AddAdditionalCapability("browser", browser, true);
                    ieCapability.AddAdditionalCapability("browser_version", version, true);
                    ieCapability.AddAdditionalCapability("os", os, true);

                    ieCapability.AddAdditionalCapability("browserstack.user", "shridevireddy_pOY0ka", true);
                    ieCapability.AddAdditionalCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84", true);
                    driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), ieCapability);
                    //  executeTestWithCaps(ieCapability);
                    break;
                default:
                    break;
            }
            switch (os)
            {
                case "ios": //If OS is ios, following capabilities will be passed to 'executeTestWithCaps' function
                    OpenQA.Selenium.Safari.SafariOptions iosCapability = new OpenQA.Selenium.Safari.SafariOptions();
                    iosCapability.AddAdditionalCapability("real_mobile", "true");
                    iosCapability.AddAdditionalCapability("browser", "iPhone");
                    iosCapability.AddAdditionalCapability("os_version", version);
                    iosCapability.AddAdditionalCapability("device", browser);

                    iosCapability.AddAdditionalCapability("browserstack.user", "shridevireddy_pOY0ka");
                    iosCapability.AddAdditionalCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84");
                    driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), iosCapability);
                    // executeTestWithCaps(iosCapability);
                    break;
                case "android": //If OS is androis, following capabilities will be passed to 'executeTestWithCaps' function
                    OpenQA.Selenium.Chrome.ChromeOptions androidCapability = new OpenQA.Selenium.Chrome.ChromeOptions();
                    androidCapability.AddAdditionalCapability("real_mobile", "true", true);
                    androidCapability.AddAdditionalCapability("browser", "Android", true);
                    androidCapability.AddAdditionalCapability("os_version", version, true);
                    androidCapability.AddAdditionalCapability("device", browser, true);

                    androidCapability.AddAdditionalCapability("browserstack.user", "shridevireddy_pOY0ka", true);
                    androidCapability.AddAdditionalCapability("browserstack.key", "Ge52czmmUuqFnBrUUE84", true);
                    driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), androidCapability);
                    // executeTestWithCaps(androidCapability);
                    break;
                default:
                    break;
            }
        }
     
    }


    
    
}
