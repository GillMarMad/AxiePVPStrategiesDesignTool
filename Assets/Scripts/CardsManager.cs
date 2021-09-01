using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.Linq;

public class CardsManager : MonoBehaviour
{
    public GameObject prefab;
    public Transform container; 
    List<AxieCard> AxieCards;
    private string dataPath;
    public IEnumerator Init(Action OnComplete)
    {
        yield return GetJsonData();
        yield return CardsCreation();
        OnComplete();
    }
    public IEnumerator GetRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            // Send the request and wait for a response
            yield return request.SendWebRequest();
            callback(request);
        }
    }
    public IEnumerator GetJsonData()
    {
        yield return GetRequest("https://gillmarmad.github.io/databseaxie/AxieCards.json", (UnityWebRequest req) =>
        {
            if (req.result == UnityWebRequest.Result.ConnectionError)
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            else
            {
                AxieCard[] cards = JsonConvert.DeserializeObject<AxieCard[]>(req.downloadHandler.text);
                AxieCards = cards.OfType<AxieCard>().ToList();
            }
        });
    }
    public IEnumerator CardsCreation()
    {
        float totalcards = AxieCards.Count;
        float CardsReady = 0;
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
            yield return axiecardobj.Init();
            CardsReady++;
            LoadingView.UpdateProgressbar(CardsReady / totalcards);
        }
    }
}
