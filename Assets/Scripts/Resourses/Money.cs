using TMPro;
using UnityEngine;

public class Money : MonoBehaviour, IResources
{
    [SerializeField] private float _initialCount;

    private TextMeshProUGUI _textMeshProUGUI;
    
    public float Count { get; set; }

    private void Awake() => 
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();

    private void Start()
    {
        Count = _initialCount;
        Show();
    }

    public void Add(float value)
    {
        Count += value;
        Show();
    }

    public void Remove(float value)
    {
        Count -= value;
        Show();
    }

    public void Show() => 
        _textMeshProUGUI.text = Count.ToString();
}