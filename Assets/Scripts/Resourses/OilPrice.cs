using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class OilPrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private ReadTxt _readTxt;
    private readonly int _timer = 60;
    private Coroutine _coroutine;
    private int _day;

    public float Well { get; private set; }

    public event Action<float, int> Changed;

    private void OnDisable() =>
        StopCoroutine(_coroutine);

    private void Awake() =>
        _readTxt = GetComponent<ReadTxt>();

    private void Start() =>
        _coroutine = StartCoroutine(OneDay());

    private void SetText() =>
        _text.text = $"Current price: {Well} $";

    private IEnumerator OneDay()
    {
        var day = new WaitForSeconds(_timer);
        Well = Convert.ToSingle(_readTxt.GetOilPrice(_day));
        Changed?.Invoke(Well,_day);
        SetText();

        while (true)
        {
            yield return day;
            _day++;

            if (_readTxt.GetOilPrice(_day) == null)
                _day = 0;

            Well = Convert.ToSingle(_readTxt.GetOilPrice(_day));
            Changed?.Invoke(Well,_day);

            SetText();
        }
    }
}