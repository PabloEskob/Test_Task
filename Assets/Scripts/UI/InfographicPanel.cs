using UnityEngine;

public class InfographicPanel : MonoBehaviour
{
    [SerializeField] private OpenInfographicPanelButton _openInfographicPanelButton;

    private CanvasGroup _canvasGroup;
    public ClosePanelButton ClosePanelButton { get; set; }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ClosePanelButton = GetComponentInChildren<ClosePanelButton>();
    }

    public void Activate()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Deactivate()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _openInfographicPanelButton.Activate();
    }
}