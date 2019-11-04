using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBannerPopUp : MonoBehaviour
{
    private void OnEnable()
    {
        ManagerAds.Ins.ShowInterstitial();
        Debug.Log("show Video");
        //ManagerAds.Ins.ShowBanner();
    }

    private void OnDisable()
    {
        Debug.Log("no");
    }
}
