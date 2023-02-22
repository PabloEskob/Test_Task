using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private ClosePanelButton _closePanelButton;

    private void OnEnable()
    {
        _closePanelButton.Clicked += Deactivate;
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _closePanelButton = GetComponentInChildren<ClosePanelButton>();
    }

    public void SetActive()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    private void Deactivate()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _closePanelButton.Clicked -= SetActive;
    }
}