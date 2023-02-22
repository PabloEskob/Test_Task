using System;
using TMPro;
using UnityEngine;

public class Oil : MonoBehaviour, IResources
{
    [SerializeField] private int _initialCount;

    private TextMeshProUGUI _textMeshProUGUI;

    public float Count { get; set; }

    public event Action<float> Changed;

    private void Awake()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        Count = _initialCount;
    }

    private void Start()
    {
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

    public void Show()
    {
        _textMeshProUGUI.text = Count.ToString();
        Changed?.Invoke(Count);
    }
}