using TMPro;
using UnityEngine;

public class Money : MonoBehaviour, IResourses
{
    [SerializeField] private int _initialCount;

    private TextMeshProUGUI _textMeshProUGUI;
    
    public int Count { get; set; }

    private void Awake()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        Count = _initialCount;
        Show();
    }

    public void Add(int value)
    {
        Count += value;
        Show();
    }

    public void Remove(int value)
    {
        Count -= value;
        Show();
    }

    public void Show()
    {
        _textMeshProUGUI.text = Count.ToString();
    }
}