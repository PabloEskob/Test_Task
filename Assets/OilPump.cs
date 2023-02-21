using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OilPump : MonoBehaviour,IPointerClickHandler
{
    public event Action Clicked;
    
    public void OnPointerClick(PointerEventData eventData)
    {
       Clicked?.Invoke();
    }
}
