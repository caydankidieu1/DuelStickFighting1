using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAllBannerUI2 : MonoBehaviour
{
    void OnEnable()
    {
        ManagerAds.Ins.ShowBanner();
    }
}
