using Dmitriy_Vysotskyy2._0.Models;
using Dmitriy_Vysotskyy2._0.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dmitriy_Vysotskyy2._0.Tests;

public class DragAndDropTest
{
    private IWebDriver _driver = new ChromeDriver();
    // private IWebDriver _driver = new EdgeDriver();
    private DragAndDropPage _dragAndDrop;
        
    [SetUp] 
    public void Setup() 
    {
        _dragAndDrop = new DragAndDropPage(_driver);
        _dragAndDrop.Navigate();
    }
    
    [Test]
    public void DragAndDropImage_ValidProcess_ShouldBeDroppedSuccessfully()
    {
        _dragAndDrop.DragAndDrop();
        Thread.Sleep(5000);
    }
    
    [TearDown]
    public void EndTest()
    {
        _driver.Quit();
    }
}