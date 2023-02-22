using System;
using ChartAndGraph;
using UnityEngine;

public class StreamGraph : MonoBehaviour
{
    [SerializeField] private OilPrice _oilPrice;

    private CustomChartPointer _customChartPointer;
    private GraphChart _graph;

    private void OnEnable() =>
        _oilPrice.Changed += OnChanged;

    private void OnDisable() =>
        _oilPrice.Changed -= OnChanged;

    private void Awake() =>
        _graph = GetComponent<GraphChart>();
    
    private void OnChanged(float value, int day)
    {
        _graph.DataSource.AddPointToCategory("Oil", day, value);
    }
}