using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadingView : MonoBehaviour
{
    [SerializeField] private GameObject CardsView, LoadindView, FilterPanel;
    [SerializeField] private Image LoadingBar;

    private CardsManager cardsManager;
    private Action OnLoadingComplete;
    public static Action<float> UpdateProgressbar;
     void Awake()
     {
         FilterPanel.SetActive(false);
         cardsManager = CardsView.GetComponent<CardsManager>();
         OnLoadingComplete += HideView;
         UpdateProgressbar += ProgressbarFill;
     }
     void Start()
     {
         StartCoroutine(cardsManager.Init(OnLoadingComplete));
     }
     void ProgressbarFill(float progress)
     {
         LoadingBar.fillAmount = progress;
     }
     private void HideView()
     {
         LoadindView.SetActive(false);
         FilterPanel.SetActive(true);
     }
}
