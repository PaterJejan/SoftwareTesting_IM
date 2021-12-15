using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium;

public class DragAndDrop
{
    IWebDriver Driver;

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();

        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        Driver.Url = "https://test.qatechhub.com/drag-and-drop";
    }

    [Test]
    public void VerifyDragAndDrop()
    {
        Actions action = new Actions(Driver);
        IWebElement source = Driver.FindElement(By.Id("draggable"));
        IWebElement target = Driver.FindElement(By.Id("droppable"));

        string colorBeforeDragAndDrop = target.GetCssValue("color");
        action.DragAndDrop(source,target).Perform();
        string colorAfterDragAndDrop = target.GetCssValue("color");

       Assert.AreNotEqual(colorAfterDragAndDrop,colorBeforeDragAndDrop);
    }

    [TearDown]
    public void TearDown(){
        Driver.Quit();
    }
}