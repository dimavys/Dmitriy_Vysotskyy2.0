using Dmitriy_Vysotskyy2._0.Common;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Dmitriy_Vysotskyy2._0.S;

[Binding]
public class DragAndDropsSteps : FeatureHelper
{
    private string _imageName1;
    private string _imageName2;
    
    [When(@"user drag and drops them to trash")]
    public void WhenUserDragAndDropsThemToTrash()
    {
        _dragAndDropPage.DragAndDrop(_imageName1, _imageName2);
    }

    [Then(@"images are in trash")]
    public void ThenImagesAreInTrash()
    {
        _dragAndDropPage.CheckImageStatus(_imageName1, _imageName2)
            .Should().Be(true);
    }

    [Given(@"a user has selected ""(.*)"" and ""(.*)"" imgs")]
    public void GivenAUserHasSelectedAndImgs(string img1, string img2)
    {
        _imageName1 = img1;
        _imageName2 = img2;
    }
}