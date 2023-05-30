using Dmitriy_Vysotskyy2._0.Common;
using Dmitriy_Vysotskyy2._0.PageObjects;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Hooks;

[Binding]
public class DragAndDropHook : FeatureHelper
{
    [BeforeScenario("DragAndDropTag")]
    public static void BeforeFeature()
    {
        var driver = DriverWrapper.GetInstance();
        _dragAndDropPage = new DragAndDropPage(driver);
        _dragAndDropPage.Navigate();
    }
}