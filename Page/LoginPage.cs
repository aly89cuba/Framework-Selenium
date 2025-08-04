using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Saucedemo_Example.ItemWebElement;
using SeleniumExtras.WaitHelpers;

namespace Saucedemo_Example.Page
{
    public class LoginPage
    {
        private readonly IWebDriver driver; //PROPIEDAD DEL DRIVER DE SELENIUM

        public LoginPage(IWebDriver driver) //CONSTRUCTOR DE LA CLASE
        {
            this.driver = driver;
        }

        //-----------------------------------------------------SELECTORES-----------------------------------------------------//

        private IWebElement InputUser => driver.FindElement(By.Id("user-name"));                        //INPUT USER
        private IWebElement InputPass => driver.FindElement(By.Id("password"));                         //INPUT PASS
        private IWebElement BtnLogin => driver.FindElement(By.Id("login-button"));                      //BOTÓN LOGIN
        public IWebElement LabelTitle => driver.FindElement(By.ClassName("login_logo"));                //TITLE DE LA WEB
        public IWebElement ErrorMensage => driver.FindElement(By.CssSelector("h3[data-test='error'"));  //MENSAJE DE ERROR

        //--------------------------------------------------------------------------------------------------------------------//



        //----------------------------------------------------MÉTODOS DE LA PAGINA--------------------------------------------//

        public void EscribirUserPass(string username, string pass)
        {
            InputWebElement inputUser = new InputWebElement(); //CREAMOS UN OBJETO DE LA CLASE INPUTWEBDRIVER PARA EL INPUT USER
            InputWebElement inputPass = new InputWebElement(); //CREAMOS UN OBJETO DE LA CLASE INPUTWEBDRIVER PARA EL INPUT PASS

            inputUser.EscribirInput(username, InputUser);      //ACCEDEMOS AL METODO ESCRIBIR Y LE PASAMOS LO QUE TIENE QUE ESCRIBIR EN EL INPUT USER QUE DEFINIMOS ARRIBA COMO SELECTOR
            inputPass.EscribirInput(pass, InputPass);          //LO MISMO PARA EL INPUT DEL PASSWORD
        }

        public TiendaPage ClicLogin()
        {
            BtnLogin.Click();
            TiendaPage tiendaPage = new TiendaPage(driver);

            WebDriverWait espera = new WebDriverWait(driver, TimeSpan.FromSeconds(5));   //AQUI HACEMOS UN OBJETO DE LA CLASE DE ESPERAS LE PASAMOS EL DRIVER Y LE PEDIMOS ESPERE 3 SEG.
            espera.Until(driver => tiendaPage.Title.Displayed);                         //DEFINIMOS QUE LA ESPERA VA A SALTAR SI ANTES APARECE EL TITULO DE LA PAG DE LA TIENDA


            return tiendaPage;
        }

        public void ClicLoginErrores()
        {
            BtnLogin.Click();

            WebDriverWait espera = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            espera.Until(driver => ErrorMensage.Displayed);
        }

        //--------------------------------------------------------------------------------------------------------------------//
    }
}