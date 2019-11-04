using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBannerPopUp : MonoBehaviour
{
    [SerializeField] private BattleUI battle;

    private void OnEnable()
    {
        if (!battle.activelSecondChange)
        {
            ManagerAds.Ins.ShowInterstitial();
            Debug.Log("Show Video Inter for GameWin");
        }
    }
}
