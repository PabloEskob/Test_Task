using System.Collections;
using TMPro;
using UnityEngine;

public class OilPrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private readonly int _timer = 60;
    private Coroutine _coroutine;

    public float Well { get; private set; } = 1;

    private void OnDisable() =>
        StopCoroutine(_coroutine);
    
    private void Start() => 
        _coroutine = StartCoroutine(OneDay());

    public void SetText(float value) => 
        _text.text = $"Current price: {value * Well}";

    private IEnumerator OneDay()
    {
        var day = new WaitForSeconds(_timer);

        while (true)
        {
            yield return day;
            Well++;
        }
    }
}