using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private CloseUpgradePanelButton _closeUpgradePanelButton;

    private void OnEnable()
    {
        _closeUpgradePanelButton.Clicked += Deactivate;
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _closeUpgradePanelButton = GetComponentInChildren<CloseUpgradePanelButton>();
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
        _closeUpgradePanelButton.Clicked -= SetActive;
    }
}