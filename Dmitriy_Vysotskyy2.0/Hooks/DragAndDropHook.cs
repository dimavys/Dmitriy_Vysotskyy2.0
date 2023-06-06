using Dmitriy_Vysotskyy2._0.Common;
using Dmitriy_Vysotskyy2._0.PageObjects;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.Hooks;

[Binding]
public class DragAndDropHook
{
    [BeforeFeature("DragAndDropTag")]
    public static void BeforeFeature()
    {
        var driver = DriverWrapper.GetInstance();
        FeatureHelper.DragAndDropPage = new DragAndDropPage(driver);
        FeatureHelper.DragAndDropPage.Navigate();
    }
}