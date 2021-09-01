using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using  TMPro;
using UnityEngine.Networking;

public class AxieCardPrefab : MonoBehaviour
{
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
    public string Imageurl;
    public IEnumerator Init()
    {
        BodyName_TMP.text = BodyName;
        CardName_TMP.text = CardName;
        EnergyCost_TMP.text = EnergyCost;
        Attack_TMP.text = Attack;
        Shield_TMP.text = Shield;
        effect_TMP.text = effect;
        yield return ImageDownload(Imageurl);
    }
    IEnumerator ImageDownload(string url)
    {
         // Start a download of the given URL
         UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);            
         // wait until the download is done
         yield return www.SendWebRequest();
         //Validate result
         if (www.result != UnityWebRequest.Result.Success)
            Debug.Log(www.error);
        else 
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Rect rec = new Rect(0, 0, texture.width, texture.height);
            Sprite spriteToUse = Sprite.Create(texture,rec,new Vector2(0.5f,0.5f),100);
            CardImage.sprite = spriteToUse;
            yield return null;
        }
         www.Dispose();
     }
}
