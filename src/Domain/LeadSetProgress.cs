namespace Domain;

public class LeadSetProgress
{
    public int LeadSetProduced { get; set; }

    private static int _produced = 0;
    public static LeadSetProgress CreateSample()
    {
        return new LeadSetProgress()
        {
            LeadSetProduced = ++_produced
        };
    }
}