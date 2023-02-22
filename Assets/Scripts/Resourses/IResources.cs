public interface IResources
{
    public float Count { get; set; }

    void Add(float value);
    void Remove(float value);
    void Show();
}