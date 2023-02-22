public interface IResources
{
    public int Count { get; set; }

    void Add(int value);
    void Remove(int value);
    void Show();
}