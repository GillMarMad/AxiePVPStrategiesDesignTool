using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  TMPro;
// using UnityEngine.AddressableAssets;

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
    public string Imageurl;
    public void Init()
    {
        // Addressables.LoadAssetAsync<Sprite>("Assets/Sprites/"+axietype.ToString()+"/" + CardName + ".png").Completed += OnLoadDone;
        BodyName_TMP.text = BodyName;
        CardName_TMP.text = CardName;
        EnergyCost_TMP.text = EnergyCost;
        Attack_TMP.text = Attack;
        Shield_TMP.text = Shield;
        effect_TMP.text = effect;
        StartCoroutine(isDownloading(Imageurl));
    }
    // private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<Sprite> obj)
    // {
    //     CardImage.sprite = obj.Result;
    // }
    IEnumerator isDownloading(string url)
    {
         // Start a download of the given URL
         var www = new WWW(url);            
         // wait until the download is done
         yield return www;
         // Create a texture in DXT1 format
         Texture2D texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
         
         // assign the downloaded image to sprite
         www.LoadImageIntoTexture(texture);
         Rect rec = new Rect(0, 0, texture.width, texture.height);
         Sprite spriteToUse = Sprite.Create(texture,rec,new Vector2(0.5f,0.5f),100);
         CardImage.sprite = spriteToUse;
 
         www.Dispose();
         www = null;
     }
}
