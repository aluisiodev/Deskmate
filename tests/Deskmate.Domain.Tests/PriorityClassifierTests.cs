using Deskmate.Domain;
    
namespace Deskmate.Domain.Tests;

public class PriorityClassifierTests
{
    [Theory]
    [InlineData(Impact.WholeCompany)]
    [InlineData(Impact.MyTeam)]
    public void Classify_MyTeamOrWholeCompanyBlocked_ReturnsCritical(Impact impact)
    {
        var resultado = PriorityClassifier.Classify(impact, true, false);
        
        Assert.Equal(Priority.Critical, resultado);
    }
    
    [Theory]
    [InlineData(Impact.OnlyMe)]
    [InlineData(Impact.WholeCompany)]
    [InlineData(Impact.MyTeam)]
    public void Classify_OnlyMeOrMyTeamOrWholeCompanySameDayCommitment_ReturnsHigh(Impact impact)
    {
        var resultado = PriorityClassifier.Classify(impact, false, true);

        Assert.Equal(Priority.High, resultado);
    }

    [Fact]
    public void Classify_OnlyMeBlocked_ReturnsHigh()
    {
        var resultado = PriorityClassifier.Classify(Impact.OnlyMe, true, false);
        
        Assert.Equal(Priority.High, resultado);
    }

    [Theory]
    [InlineData(Impact.OnlyMe)]
    [InlineData(Impact.MyTeam)]
    [InlineData(Impact.WholeCompany)]
    public void Classify_OnlyMeOrMyTeamOrWholeCompany_ReturnsMedium(Impact impact)
    {
        var resultado = PriorityClassifier.Classify(impact, false, false);

        Assert.Equal(Priority.Medium, resultado);
    }
}
