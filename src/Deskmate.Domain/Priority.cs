namespace Deskmate.Domain;

public enum Impact
{
    OnlyMe,
    MyTeam,
    WholeCompany
}

public enum Priority
{
    Low,
    Medium,
    High,
    Critical
}

public static class PriorityClassifier
{
    public static Priority Classify(Impact impact, bool blocksWork, bool sameDayCommitment)
    {
        if (impact != Impact.OnlyMe && blocksWork)
        {
            return Priority.Critical;
        }

        if (blocksWork || sameDayCommitment)
        {
            return Priority.High;
        }
        
        return Priority.Medium;

    }
}