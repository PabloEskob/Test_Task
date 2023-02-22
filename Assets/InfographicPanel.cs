using UnityEngine;

public class InfographicPanel : MonoBehaviour
{
   [SerializeField] private OpenPanelButton _openPanelButton;

   private CanvasGroup _canvasGroup;
   private ClosePanelButton _closePanelButton;

   private void Awake()
   {
      _canvasGroup = GetComponent<CanvasGroup>();
      _closePanelButton = GetComponentInChildren<ClosePanelButton>();
   }

   private void OnEnable()
   {
      _openPanelButton.Clicked += Activate;
      _closePanelButton.Clicked += Deactivate;
   }

   private void OnDisable()
   {
      _openPanelButton.Clicked -= Activate;
      _closePanelButton.Clicked -= Deactivate;
   }

   private void Activate()
   {
      _canvasGroup.alpha = 1;
      _canvasGroup.blocksRaycasts = true;
   }

   private void Deactivate()
   {
      _canvasGroup.alpha = 0;
      _canvasGroup.blocksRaycasts =false;
      _openPanelButton.Activate();
   }
}
