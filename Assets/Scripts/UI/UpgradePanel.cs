using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    public ClosePanelButton ClosePanelButton { private set; get;}
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ClosePanelButton = GetComponentInChildren<ClosePanelButton>();
    }

    public void SetActive()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Deactivate()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }
}