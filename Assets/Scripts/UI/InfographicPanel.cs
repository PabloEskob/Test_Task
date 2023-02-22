using UnityEngine;

public class InfographicPanel : MonoBehaviour
{
    [SerializeField] private OpenInfographicPanelButton _openInfographicPanelButton;

    private CanvasGroup _canvasGroup;
    public ClosePanelButton ClosePanelButton { get; private set; }
    public ButtonSellOil ButtonSellOil { get; private set; }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ClosePanelButton = GetComponentInChildren<ClosePanelButton>();
        ButtonSellOil = GetComponentInChildren<ButtonSellOil>();
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