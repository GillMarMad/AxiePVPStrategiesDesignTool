using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{
    public Image testImage;
    public GameObject prefab;
    public Transform container; 
    private string[] headers = new string[10]{"name","bodyname","bodypart","energycost","type","attack","shield","effect","axietype","Imageurl"};
    private DataManager data;
    List<AxieCard> AxieCards;
    private string dataPath;
    private void CreateCards()
    {
        data = new DataManager("Data","AxieCards.csv",headers);
        AxieCards = data.ReadFile();
    }
    void Start()
    {
        CreateCards();
        StartCoroutine(InstantiateCard());
    }
    
    private IEnumerator InstantiateCard()
    {
        foreach(AxieCard card in AxieCards)
        {
            var cardobj = Instantiate(prefab, container);
            var axiecardobj = cardobj.GetComponent<AxieCardPrefab>();
            axiecardobj.BodyName = card.bodyname;
            axiecardobj.CardName = card.name;
            axiecardobj.EnergyCost = card.energycost.ToString();
            axiecardobj.Attack = card.attack.ToString();
            axiecardobj.Shield = card.shield.ToString();
            axiecardobj.effect = card.effect;
            axiecardobj.BodyName = card.bodyname;
            axiecardobj.axietype = card.axietype;
            axiecardobj.Imageurl = card.Imageurl;
            axiecardobj.Init();
            yield return null;
        }
    }
}
