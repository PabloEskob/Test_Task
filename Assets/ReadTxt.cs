using System.Collections.Generic;
using UnityEngine;

public class ReadTxt : MonoBehaviour
{
    private const string Path = "Txt/Test";

    private List<string> _oilPrice;
    private object _content;
    private string[] _strings;

    private void Awake()
    {
        _oilPrice = new List<string>();
        FindThePriceOfOil();
    }
    
    public string GetOilPrice(int value)
    {
        return _oilPrice[value];
    }

    private string[] StringSplit()
    {
        TextAsset textAsset = Resources.Load<TextAsset>(Path);
        _strings = textAsset.text.Split('\n');
        return _strings;
    }

    private void FindThePriceOfOil()
    {
        int positionLastIndex;
        string newText;

        foreach (var variable in StringSplit())
        {
            positionLastIndex = variable.LastIndexOf(',');
            newText = variable.Substring(0, positionLastIndex);
            positionLastIndex = newText.LastIndexOf(',') + 1;
            newText = newText.Substring(positionLastIndex);
            newText = newText.Replace('.', ',');
            newText = $"{newText:f2}";
            
            _oilPrice.Add(newText);
        }
    }
}