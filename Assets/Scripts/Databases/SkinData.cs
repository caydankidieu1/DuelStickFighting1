﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkinData
{
    public List<skin> W = new List<skin>();

    public SkinData (SkinUI skinUI)
    {
        W.Clear();
        for (int i = 0; i < skinUI.cotsume.Length; i++)
        {
            skin test = new skin();
            test.id = skinUI.cotsume[i].id;
            test.HP = skinUI.cotsume[i].HP;
            test.checkBuy = skinUI.cotsume[i].checkBuy;
            test.checkUse = skinUI.cotsume[i].checkUse;

            W.Add(test);
        }
    }
}

[System.Serializable]
public class skin
{
    public int id;
    public int HP;
    public bool checkBuy;
    public bool checkUse;
}
