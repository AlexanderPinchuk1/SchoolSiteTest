using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SchoolSiteTest
{
    class Program
    {
        const int NUM_PHOTOS = 12;
        const int TIMEOUT = 0;
        const string URL = "https://www.school-66.gorodgomel.by/";

        [Obsolete]
        static void Main()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = URL;
            driver.Manage().Window.Maximize();

            _ = driver.Manage().Timeouts().ImplicitWait;
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));


            IWebElement element;
            Actions actions = new Actions(driver);

            Thread.Sleep(TIMEOUT);
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.LinkText("О школе")));
            element = driver.FindElement(By.LinkText("О школе"));
            actions.MoveToElement(element).Build().Perform();

            Thread.Sleep(TIMEOUT);
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Фотогалерея")));
            element = driver.FindElement(By.LinkText("Фотогалерея"));
            element.Click();

            Thread.Sleep(TIMEOUT);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 400)", "");

            Thread.Sleep(TIMEOUT);
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".sectiontableentry1 > .jg_element_gal:nth-child(2) b")));
            element = driver.FindElement(By.CssSelector(".sectiontableentry1 > .jg_element_gal:nth-child(2) b"));
            element.Click();

            Thread.Sleep(TIMEOUT);
            js.ExecuteScript("window.scrollBy(0, 400)", "");

            Thread.Sleep(TIMEOUT);
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".jg_row:nth-child(4) > .jg_element_cat:nth-child(1) .jg_photo")));
            element = driver.FindElement(By.CssSelector(".jg_row:nth-child(4) > .jg_element_cat:nth-child(1) .jg_photo"));
            element.Click();
            
            for (int i = 1; i < NUM_PHOTOS; i++)
            {
                Thread.Sleep(TIMEOUT);
                waitForElement.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Дальше >")));
                element = driver.FindElement(By.LinkText("Дальше >"));
                element.Click();
            }

            Thread.Sleep(TIMEOUT);
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Закрыть")));
            element = driver.FindElement(By.LinkText("Закрыть"));
            element.Click();

            Thread.Sleep(TIMEOUT);
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Главная")));
            element = driver.FindElement(By.LinkText("Главная"));
            element.Click();

            Thread.Sleep(TIMEOUT);
        }
    }
}
