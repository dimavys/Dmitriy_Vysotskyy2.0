using Dmitriy_Vysotskyy2._0.PageObjects;
using OpenQA.Selenium;

namespace Dmitriy_Vysotskyy2._0.Common;

public abstract class FeatureHelper
{
    protected static IWebDriver _driver;

    protected static HomePage _homePage;
    protected static IndexPage _indexPage;
    protected static ItemPage _itemPage;
    protected static CartPage _cartPage;
}