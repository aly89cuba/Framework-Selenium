using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Saucedemo_Example.Config;
using Saucedemo_Example.Page;
using Saucedemo_Example.Config;


namespace Saucedemo_Example.Test
{
    public class LoginTest : BaseTest
    {

        [Test, Category("Login")]
        [TestCase("Swag Labs")]
        [TestCase("Swag")]
        public void Test1(string pageTitle_Expected)
        {
            LoginPage loginPage = new LoginPage(driver);    //CREAMOS UN OBJETO DE LA CLASE LOGINPAGE PARA ACCEDER A SUS MÉTODOS
            string pageTitle = loginPage.LabelTitle.Text;   //OBTENEMOS EL TITLE DE LA PÁGINA POR LA PROPIEDAD LABLETITLE.TEXT PQ ES UN WEBELEMENT Y SU TEXTO SE OBIENE ASI

            //Manejo de errores
            if (pageTitle_Expected == pageTitle)
                TestContext.WriteLine($"✅ El testCase con valor '{pageTitle_Expected}' pasó correctamente");
            else TestContext.WriteLine($"❌ El testCase con valor '{pageTitle_Expected}' no pasó correctamente");

            Assert.AreEqual(pageTitle_Expected, pageTitle, "El título no coincide");  //Assert (primero igual a segundo sino mensaje)
        }

        Config.ConfigSecret configSecret = new Config.ConfigSecret(); 

        [Test, Category("Login")]
        [TestCase("standard_user", "secret_sauce")]  //LOGIN CORRECTO USER AND PASS
        [TestCase("standard_user", "egwerg")]        //LOGIN INCORRECTO USER OK PASS INCORRECTO
        [TestCase("afq", "secret_sauce")]             //LOGIN INCORRECTO USER INCORRECTO PASS OK
        public void TC1_01(string user, string pass)
        {
            string titleExpected = "Products";
            LoginPage loginPage = new LoginPage(driver); //CREAMOS EL OBJETO DE LA CLASE LOGINPAGE DONDE ESTAN TODOS LOS SELECTORES Y METODOS NECESARIOS

            loginPage.EscribirUserPass(user, pass); //LLAMAMOS EL METODO ESCRIBIR INPUT PARA LLENAR USER Y PASS Y PASAMOS VALORES CORRECTOS PARA LOGIN EXITOSO

            TiendaPage tiendaPage = loginPage.ClicLogin(); //DAMOS CLIC A LOGIN Y DEFINIMOS UN OBEJTO DE LA CLASE A LA QUE VAMOS A ACCEDER QUE ES LO QUE EL METODO RETORNA UN OBJETO DE ESTA CLASE

            string titleObten = tiendaPage.Title.Text;

            //Manejo de errores
            if (titleExpected != titleObten)
                TestContext.WriteLine($"❌ El usuario no puedo acceder correctamente a la tienda");
            else TestContext.WriteLine($"✅ El usuario accedió correctamente a la tienda");

            titleObten.Should().Be(titleExpected); //USAMOS EN ESTE CASO EL SHOULD BE(DEBERIA SER)
        }


        [Test, Category("Login")]
        public void TC1_04()
        {
            LoginPage loginPage = new LoginPage(driver); 
            loginPage.EscribirUserPass("locked_out_user", "secret_sauce");
            loginPage.ClicLoginErrores();

            string messageExpect = "Epic sadface: Sorry, this user has been locked out.";
            string messageObten = loginPage.ErrorMensage.Text;

            //Manejo de Mensajes
            if (messageExpect == messageObten)
                TestContext.WriteLine($"✅ El test pasó correcto: Este user está bloqueado");
            else TestContext.WriteLine($"❌ El test NO PASÓ CORRECTO: Se esperaba el mensaje: 'Epic sadface: Sorry, this user has been locked out.'");


            Assert.AreEqual(messageExpect, messageObten, "Se esperaba el mensaje: 'Epic sadface: Sorry, this user has been locked out.'");
        }


        [Test, Category("Login")]
        [TestCase("", "secret_sauce")] //user vacío
        [TestCase("standard_user", "")] //pass vacío
        public void TC1_05(string user, string pass)
        {
            LoginPage loginPage = new LoginPage(driver); 
            loginPage.EscribirUserPass(user, pass);
            loginPage.ClicLoginErrores();

            string messageExpect = "";
            if (user == "")
            { messageExpect = "Epic sadface: Username is required"; }           //EL MENSAJE ESPERADO CAMBIA SI DEJO EN BLANCO EL USER O EL PAS 
            else { messageExpect = "Epic sadface: Password is required";}

            string messageObten = loginPage.ErrorMensage.Text;

            //Manejo de Mensajes
            if (messageExpect == messageObten)
                TestContext.WriteLine($"✅ El test pasó correcto: El campo es requerido");
            else TestContext.WriteLine($"❌ El test NO PASÓ CORRECTO: Se esperaba el mensaje: 'Epic sadface: Sorry, this user has been locked out.'");


            Assert.AreEqual(messageExpect, messageObten, "Se esperaba el mensaje: 'Epic sadface: Username is required'");
        }
    }
}

