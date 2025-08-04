using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Saucedemo_Example.ItemWebElement;

namespace Saucedemo_Example.Page
{
    public class TiendaPage
    {
        private readonly IWebDriver driver; //PROPIEDAD DEL DRIVER DE SELENIUM
        public TiendaPage(IWebDriver driver) //CONSTRUCTOR DE LA CLASE
        {
            this.driver = driver;
        }

        //-----------------------------------------------------SELECTORES-----------------------------------------------------//
        public IWebElement Title => driver.FindElement(By.ClassName("title"));           //TITLE DE LA PÁGINA DE LA TIENDA
        //--------------------------------------------------------------------------------------------------------------------//
    }
}