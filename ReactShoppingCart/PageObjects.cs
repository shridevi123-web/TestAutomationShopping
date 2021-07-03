using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace ReactShoppingCart
{
    public class PageObjects
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\Kranthi\\source\\chrome_home");
        }

        [Test]
        public void SampleTest()
        {
            driver.Url = "http://www.google.co.in";
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

        [Test]

        public void cssDemo()
        {
            driver = new ChromeDriver("C:\\Users\\Kranthi\\source\\chrome_home");
            driver.Url = "https://react-shooping-cart.netlify.app/";
           // driver.Manage().Window.Maximize();
            //IWebelement link = driver.FindElement(By.XPath(".//*[@id='rt-header']//div[2]/div/ul/li[2]/a"));
          //  link.Click();
            driver.Close();
        }
    }
}
