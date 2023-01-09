namespace DependencyInjectionScopes
{
    public interface IMyManager
    {
        int Value { get; set; }
    }

    public class MyManager : IMyManager
    {
        public int Value { get; set; }

        public MyManager()
        {
            Value = 20;
        }
    }
}
