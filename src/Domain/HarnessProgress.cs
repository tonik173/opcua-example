namespace Domain;

public class HarnessProgress
{
    public string Cavity { get; set; }
    public string Housing { get; set; }
    public string LeadSetEnd { get; set; }

    public static HarnessProgress CreateSample()
    {
        return new HarnessProgress()
        {
            Cavity = $"cavity-{Random.Shared.Next(1, 31)}",
            Housing = $"housing-{Random.Shared.Next(80, 100)}",
            LeadSetEnd = $"end-{Random.Shared.Next(1, 3)}"
        };
    }
}