using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class HotelTest
    {
        IWebDriver driver;

        [Test]
        public void TestCreateHouse()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://localhost:44425/listhouse");
            Thread.Sleep(3000);

            var rowCountBefore = GetRowCount();

            var createHouseButton = driver.FindElement(By.ClassName("createhouse"));
            createHouseButton.Click();
            Thread.Sleep(3000);


            var numberOfBedsInput = driver.FindElement(By.ClassName("inp-number-of-beds"));
            numberOfBedsInput.SendKeys("2");

            var priceInput = driver.FindElement(By.ClassName("inp-price"));
            priceInput.SendKeys("1200");


            var houseNumberInput = driver.FindElement(By.ClassName("inp-house-number"));
            houseNumberInput.SendKeys("7");

            var createButton = driver.FindElement(By.ClassName("but-create"));
            createButton.Click();
            Thread.Sleep(3000);


            var rowCountAfter = GetRowCount();


            Assert.AreEqual(rowCountBefore + 1, rowCountAfter, "Помилка: Кількість рядків не змінилась на 1 після додавання будинку.");
        

           

        }
        private int GetRowCount()
        {
            var rows = driver.FindElements(By.CssSelector("table.table tbody tr"));
            return rows.Count;
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
