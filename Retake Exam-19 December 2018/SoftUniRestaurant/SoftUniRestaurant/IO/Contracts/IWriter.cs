namespace SoftUniRestaurant.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string message);

        void AppendLine(string message);

        void WriteAllLines();
    }
}
