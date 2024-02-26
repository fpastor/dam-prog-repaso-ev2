
namespace repasoProgEV2
{
    public class repasoGenericos
    {
        class Generico<T>
        {
            public double Id;
            public string Name = string.Empty;
            public List<T> Data = new();
        }

    }
}
