namespace NanoPublicApi.Entities.Output;

public class RepresentativesOnline
{
    public IDictionary<string, RepresentativesOnline_Weight> Representatives { get; set; }

    public class RepresentativesOnline_Weight
    {
        public string Weight { get; set; }
    }
}