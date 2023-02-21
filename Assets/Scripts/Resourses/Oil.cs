using System;
using TMPro;
using UnityEngine;

public class Oil : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;

    public int Count { get; set; }

    private void Awake()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Add(int value)
    {
        Count += value;
        _textMeshProUGUI.text = Count.ToString();
    }
}