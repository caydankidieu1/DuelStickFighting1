using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBannerPopUp2 : MonoBehaviour
{
    public BattleUI battle;

    private void OnDisable()
    {
        if (battle.activelSecondChange == false)
        {
            ManagerAds.Ins.ShowInterstitial();
            Debug.Log("show Video");
        }
    }
}
