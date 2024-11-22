namespace Domain;

public class CoordinationUnitProgress
{
    public int ItemsProduced { get; set; }

    private static int _produced = 0;
    public static CoordinationUnitProgress CreateSample()
    {
        return new CoordinationUnitProgress()
        {
            ItemsProduced = ++_produced
        };
    }
}