using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenInfographicPanelButton : MonoBehaviour,IPointerClickHandler
{
    private CanvasGroup _canvasGroup;

    public event Action Clicked;
    
    private void Awake() => 
        _canvasGroup = GetComponent<CanvasGroup>();

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke();
        Deactivate();
    }

    public void Activate()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    private void Deactivate()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }
}
