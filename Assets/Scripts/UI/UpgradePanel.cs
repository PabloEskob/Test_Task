using System;
using TMPro;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    private ActorUi _actorUi;
    private CanvasGroup _canvasGroup;
    private UpgradeButton _upgradeButton;

    public ClosePanelButton ClosePanelButton { private set; get; }

    public event Action<int> Changed;

    private void OnEnable()
    {
        _upgradeButton.Clicked += SetUpgrade;
    }

    private void OnDisable()
    {
        _upgradeButton.Clicked -= SetUpgrade;
    }

    private void Awake()
    {
        _actorUi = GetComponentInParent<ActorUi>();
        _canvasGroup = GetComponent<CanvasGroup>();
        ClosePanelButton = GetComponentInChildren<ClosePanelButton>();
        _upgradeButton = GetComponentInChildren<UpgradeButton>();
    }

    private void Start()
    {
        SetText();
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

    private void SetUpgrade()
    {
        if (_actorUi.GameResources.Money.Count >= _actorUi.OilPump.GetValueDictionary())
        {
            Changed?.Invoke(_actorUi.OilPump.GetValueDictionary());
            _actorUi.OilPump.LevelUp();
            SetText();
        }
    }

    private void SetText()
    {
        _textMeshProUGUI.text = _actorUi.OilPump.Level == 3 ? "Max Lvl" :
            $"{_actorUi.OilPump.Level}lvl {_actorUi.OilPump.GetValueDictionary()}/{_actorUi.GameResources.Money.Count}";
    }
}