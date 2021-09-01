using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class CardFilter : MonoBehaviour
{
    [SerializeField] private CardsManager Cards;
    public TMP_Dropdown AxieType;
    public TMP_Dropdown EnergyCost;
    public TMP_Dropdown BodyPart;
    public TMP_Dropdown AttackType;
    public TMP_Dropdown Sort;
    public Button Search;
    public TMP_InputField txt_search;

    void Start()
    {
        List<axieType> axietype = new List<axieType>();
        List<int> energycost = new List<int>();
        List<string> bodypart = new List<string>();
        List<attackType> attacktype = new List<attackType>();

        foreach(AxieCard card in Cards.AxieCards)
        {
            if(!axietype.Contains(card.axietype))
                axietype.Add(card.axietype);
            if(!energycost.Contains(card.energycost))
                energycost.Add(card.energycost);
            if(!bodypart.Contains(card.bodypart))
                bodypart.Add(card.bodypart);
            if(!attacktype.Contains(card.attacktype))
                attacktype.Add(card.attacktype);
        }
        foreach(var item in energycost)
            EnergyCost.options.Add(new TMP_Dropdown.OptionData(){text = item.ToString()});
        foreach(var item in axietype)
            AxieType.options.Add(new TMP_Dropdown.OptionData(){text = item.ToString()});
        foreach(var item in bodypart)
            BodyPart.options.Add(new TMP_Dropdown.OptionData(){text = item.ToString()});
        foreach(var item in attacktype)
            AttackType.options.Add(new TMP_Dropdown.OptionData(){text = item.ToString()});
    }

    public void search()
    {
        var result = Cards.AxieCardObj.Where(c => c.GetComponent<AxieCardPrefab>().axietype.ToString() != string.Empty);
        if(AxieType.options[AxieType.value].text != "Any")
            result = result.Where(c => c.GetComponent<AxieCardPrefab>().axietype.ToString() == AxieType.options[AxieType.value].text);
        if(EnergyCost.options[EnergyCost.value].text != "Any")
            result = result.Where(c => c.GetComponent<AxieCardPrefab>().EnergyCost.ToString() == EnergyCost.options[EnergyCost.value].text);
        if(BodyPart.options[BodyPart.value].text != "Any")
            result = result.Where(c => c.GetComponent<AxieCardPrefab>().bodypart.ToString() == BodyPart.options[BodyPart.value].text);
        if(AttackType.options[AttackType.value].text != "Any")
            result = result.Where(c => c.GetComponent<AxieCardPrefab>().AttackType.ToString() == AttackType.options[AttackType.value].text);
        foreach(var obj in Cards.AxieCardObj)
            if(result.Contains(obj))
                obj.SetActive(true);
            else
                obj.SetActive(false);
        StartCoroutine(scrollmovement());
    }
    public void text_search()
    {
        string search = txt_search.text.ToUpper();
        var result = Cards.AxieCardObj.Where(c => c.GetComponent<AxieCardPrefab>().axietype.ToString() != string.Empty);
        if(search != string.Empty)
            result = Cards.AxieCardObj.Where(c => c.GetComponent<AxieCardPrefab>().axietype.ToString().ToUpper().Contains(search)
            || c.GetComponent<AxieCardPrefab>().BodyName.ToString().ToUpper().Contains(search)
            || c.GetComponent<AxieCardPrefab>().bodypart.ToString().ToUpper().Contains(search)
            || c.GetComponent<AxieCardPrefab>().CardName.ToString().ToUpper().Contains(search)
            || c.GetComponent<AxieCardPrefab>().AttackType.ToString().ToUpper().Contains(search));
        foreach(var obj in Cards.AxieCardObj)
            if(result.Contains(obj))
                obj.SetActive(true);
            else
                obj.SetActive(false);
        StartCoroutine(scrollmovement());
    }
    IEnumerator scrollmovement()
    {
        var intialvalue = Cards.scrollbar.value;
        float time = 1;
        float elapsed = 0;
        while(elapsed < time)
        {
            Cards.scrollbar.value = Mathf.Lerp(intialvalue, 1, elapsed / time);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
    public void StopAutoScroll()
    {
        StopAllCoroutines();
    }
}
