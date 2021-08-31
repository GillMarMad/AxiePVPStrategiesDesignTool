using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  TMPro;
using UnityEngine.AddressableAssets;

public class AxieCardPrefab : MonoBehaviour
{
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public TMP_Text BodyName_TMP;
    public TMP_Text CardName_TMP;
    public TMP_Text EnergyCost_TMP;
    public TMP_Text Attack_TMP;
    public TMP_Text Shield_TMP;
    public TMP_Text effect_TMP;
    public Image CardImage;
    public axieType axietype;
    public string BodyName;
    public string CardName;
    public string EnergyCost;
    public string Attack;
    public string Shield;
    public string effect;
    public void Init()
    {
        Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/"+axietype.ToString()+"/" + CardName + ".png").Completed += OnLoadDone;
        BodyName_TMP.text = BodyName;
        CardName_TMP.text = CardName;
        EnergyCost_TMP.text = EnergyCost;
        Attack_TMP.text = Attack;
        Shield_TMP.text = Shield;
        effect_TMP.text = effect;
    }
    private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<Sprite> obj)
    {
        CardImage.sprite = obj.Result;
    }
}
