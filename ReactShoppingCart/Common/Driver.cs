using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
namespace ReactShoppingCart.Common
{
   public static class Driver
    {

        public static IWebDriver Instance { get; private set; }
        public static bool RetryClick(IWebElement element)
        {
            var result = false;
            var attempts = 0;
            while (attempts < 5 )
            {
                try
                {
                    element.Click();
                    
                    result = true;
                    break;
                }
                catch (StaleElementReferenceException) { }
                catch (InvalidOperationException) { }
                catch (ElementNotVisibleException) { }
                catch (WebDriverException) { }
                attempts++;
            }

            // define wait

            return result;

        }

        public static void Initialise(IWebDriver webDriver)
        {
            Instance = webDriver;
        }
        
    }
}
