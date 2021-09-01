using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxieCard
{
    public string name;
    public string bodyname;
    public string bodypart;
    public int energycost;
    public attackType attacktype;
    public int attack;
    public int shield;
    public string effect;
    public axieType axietype;
    public string Imageurl;
    // public AxieCard(string name, string bodyname, string bodypart, int energycost, attackType attacktype, int attack, int shield, string effect, axieType axietype, string Imageurl)
    // {
    //     this.name = name;
    //     this.bodyname = bodyname;
    //     this.bodypart = bodypart;
    //     this.energycost = energycost;
    //     this.attacktype = attacktype;
    //     this.attack = attack;
    //     this.shield = shield;
    //     this.effect = effect;
    //     this.axietype = axietype;
    //     this.Imageurl = Imageurl;
    // }
}
public enum axieType
{
    Beast, Bird, Bug, Fish, Plant, Reptil
}

public enum attackType
{
    melee, ranged, support
}