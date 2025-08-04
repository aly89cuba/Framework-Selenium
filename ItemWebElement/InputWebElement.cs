using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Saucedemo_Example.ItemWebElement
{
    public class InputWebElement
    { 
        public void EscribirInput(string texto, IWebElement elementoInput)  //ESCRIBIR 
        {
            elementoInput.Clear();
            elementoInput.SendKeys(texto);
        }
    }
}