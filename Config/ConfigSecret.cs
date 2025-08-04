using Microsoft.Extensions.Configuration;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Saucedemo_Example.Config
{
    public class ConfigSecret
    {
        public static string GetStandarUser_Password()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<ConfigSecret>()
                .Build();

            return configuration["Credentials:standar:Pass"];
        }
        
        public static string GetStandarUser_Name()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<ConfigSecret>()
                .Build();
    
            return configuration["Credentials:standar:User"];
        }
    }
}
