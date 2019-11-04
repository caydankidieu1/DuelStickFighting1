using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAllBannerUI : MonoBehaviour
{
    public bool activelRandomShowInter;
    void OnEnable()
    {
        ManagerAds.Ins.ShowBanner();

        var test = Random.Range(0, 100);

        if (test >= 75 && activelRandomShowInter)
        {
            ManagerAds.Ins.ShowInterstitial();
        }
    }

    void OnDisable()
    {
        ManagerAds.Ins.HideBanner();
    }
}
