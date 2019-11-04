using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScreen : MonoBehaviour
{
    public int height;
    public int width;

    [Header("GameObject need option with multiScreen")]
    public GameObject rightHome;
    public GameObject leftHome;
    public GameObject level;
    [Space]
    public GameObject panelReward;
    public GameObject titleDailyGift;
    public GameObject BtnClaim;
    public GameObject BtnHideClaim;
    [Space]
    public GameObject Store;
    public GameObject BtnBackOnLevel;

    void Start()
    {
        height = Screen.height;
        width = Screen.width;
        MoveRightHome();
        MoveLeftHome();
        MoveLevel();
        DailyGift();
        ScreenStore();

        Debug.Log(width / height);
    }

    void MoveRightHome()
    {
        var rectRightHome = rightHome.GetComponent<RectTransform>();

        if (height == 1440 && width == 2960)
        {
            rectRightHome.anchoredPosition = new Vector2(91, 19);
            rectRightHome.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1440 && width == 3040)
        {
            rectRightHome.anchoredPosition = new Vector2(100, 13);
            rectRightHome.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 720 && width == 1600)
        {
            rectRightHome.anchoredPosition = new Vector2(9, 3);
            rectRightHome.localScale = new Vector3(0.95f, 0.95f, 0.95f);
        }
        if (height == 1080 && width == 2280)
        {
            rectRightHome.anchoredPosition = new Vector2(100, 23);
            rectRightHome.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1080 && width == 2160)
        {
            rectRightHome.anchoredPosition = new Vector2(85, 0);
            rectRightHome.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1080 && width == 2340)
        {
            rectRightHome.anchoredPosition = new Vector2(100, 29);
            rectRightHome.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 720 && width == 1560)
        {
            rectRightHome.anchoredPosition = new Vector2(100, 8);
            rectRightHome.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 720 && width == 1600)
        {
            rectRightHome.anchoredPosition = new Vector2(100, 8);
            rectRightHome.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 480 && width == 800)
        {
            rectRightHome.anchoredPosition = new Vector2(0, -12);
            rectRightHome.localScale = new Vector3(0.95f, 0.95f, 0.95f);
        }
        if (height == 1080 && width == 2248)
        {
            rectRightHome.anchoredPosition = new Vector2(48, -12);
            rectRightHome.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
    }
    void MoveLeftHome()
    {
        var rectLeftHome = leftHome.GetComponent<RectTransform>();

        if (height == 1080 && width == 2160)
        {
            rectLeftHome.anchoredPosition = new Vector2(10,  -24);
        }
        if (height == 1440 && width == 2960)
        {
            rectLeftHome.anchoredPosition = new Vector2(0, 0);
        }
        if (height == 1440 && width == 3040)
        {
            rectLeftHome.anchoredPosition = new Vector2(-8, -8);
        }
        if (height == 1440 && width == 2560)
        {
            rectLeftHome.anchoredPosition = new Vector2(50, -56);
        }
        if (height == 1080 && width == 2280)
        {
            rectLeftHome.anchoredPosition = new Vector2(-8, -8);
        }
        if (height == 1080 && width == 2340)
        {
            rectLeftHome.anchoredPosition = new Vector2(-18, 5);
        }
        if (height == 720 && width == 1560)
        {
            rectLeftHome.anchoredPosition = new Vector2(-18, -8);
        }
        if (height == 720 && width == 1600)
        {
            rectLeftHome.anchoredPosition = new Vector2(-28, 8);
        }
        if (height == 1080 && width == 1920)
        {
            rectLeftHome.anchoredPosition = new Vector2(50, -48);
        }
        if (height == 480 && width == 800)
        {
            rectLeftHome.anchoredPosition = new Vector2(69, -56);
        }
        if (height == 1080 && width == 2248)
        {
            rectLeftHome.anchoredPosition = new Vector2(-6, -30);
        }
    }
    void MoveLevel()
    {
        var rectLevel = level.GetComponent<RectTransform>();

        if (height == 1080 && width == 2160)
        {
            rectLevel.anchoredPosition = new Vector2(35, -23);
        }
        if (height == 1440 && width == 2960)
        {
            rectLevel.anchoredPosition = new Vector2(47, -15);
        }
        if (height == 1440 && width == 3040)
        {
            BtnBackOnLevel.SetActive(false);
            rectLevel.anchoredPosition = new Vector2(58, -17);
        }
        if (height == 1080 && width == 2280)
        {
            BtnBackOnLevel.SetActive(false);
            rectLevel.anchoredPosition = new Vector2(59, -21);
        }
        if (height == 1080 && width == 2340)
        {
            BtnBackOnLevel.SetActive(false);
            rectLevel.anchoredPosition = new Vector2(66, -21);
        }
        if (height == 720 && width == 1560)
        {
            BtnBackOnLevel.SetActive(false);
            rectLevel.anchoredPosition = new Vector2(67, -20);
        }
        if (height == 720 && width == 1600)
        {
            BtnBackOnLevel.SetActive(false);
            rectLevel.anchoredPosition = new Vector2(73, -20);
        }
        if (height == 1080 && width == 2248)
        {
            BtnBackOnLevel.SetActive(false);
            rectLevel.anchoredPosition = new Vector2(51, -26);
        }
    }
    void DailyGift()
    {
        var rectTitleDaily = titleDailyGift.GetComponent<RectTransform>();
        var rectBtnClaim = BtnClaim.GetComponent<RectTransform>();
        var rectBtnHideClaim = BtnHideClaim.GetComponent<RectTransform>();

        if (height == 1080 && width == 2160)
        {
            panelReward.GetComponent<GridLayoutGroup>().constraintCount = 3;

            rectTitleDaily.anchoredPosition = new Vector2(-103, 420);
            rectTitleDaily.sizeDelta = new Vector2(2086.8f, 237.4f);
            rectTitleDaily.anchorMin = new Vector2(0.5f, 0.5f);
            rectTitleDaily.anchorMax = new Vector2(0.5f, 0.5f);

            rectBtnClaim.anchoredPosition = new Vector2(0, 183);
            rectBtnHideClaim.anchoredPosition = new Vector2(0, 183);
            rectBtnClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rectBtnHideClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1440 && width == 2960)
        {
            panelReward.GetComponent<GridLayoutGroup>().constraintCount = 3;
            var test = rectTitleDaily;
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);

            rectBtnClaim.anchoredPosition = new Vector2(0, 183);
            rectBtnHideClaim.anchoredPosition = new Vector2(0, 183);
            rectBtnClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rectBtnHideClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1440 && width == 3040)
        {
            var test = rectTitleDaily;
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);

            rectBtnClaim.anchoredPosition = new Vector2(0, 183);
            rectBtnHideClaim.anchoredPosition = new Vector2(0, 183);
            rectBtnClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rectBtnHideClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1440 && width == 2560)
        {
            var test = rectTitleDaily;
            test.anchoredPosition = new Vector2(-103, 462);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);

            rectBtnClaim.anchoredPosition = new Vector2(0, 234);
            rectBtnHideClaim.anchoredPosition = new Vector2(0, 234);
            rectBtnClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rectBtnHideClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1080 && width == 2280)
        {
            var test = rectTitleDaily;
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);

            rectBtnClaim.anchoredPosition = new Vector2(0, 180);
            rectBtnHideClaim.anchoredPosition = new Vector2(0,180);
            rectBtnClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rectBtnHideClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1080 && width == 2340)
        {
            var test = rectTitleDaily;
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);
            test.localScale = new Vector2(0.4f, 0.4f);

            rectBtnClaim.anchoredPosition = new Vector2(0, 172);
            rectBtnHideClaim.anchoredPosition = new Vector2(0, 172);
            rectBtnClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rectBtnHideClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 720 && width == 1560)
        {
            var test = rectTitleDaily;
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);
            test.localScale = new Vector2(0.4f, 0.4f);

            rectBtnClaim.anchoredPosition = new Vector2(0, 174);
            rectBtnHideClaim.anchoredPosition = new Vector2(0, 174);
            rectBtnClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rectBtnHideClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 720 && width == 1600)
        {
            var test = rectTitleDaily;
            test.anchoredPosition = new Vector2(-103, 407);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);
            test.localScale = new Vector3(0.4f,0.4f,0.4f);

            rectBtnClaim.anchoredPosition = new Vector2(0, 159);
            rectBtnHideClaim.anchoredPosition = new Vector2(0, 159);
            rectBtnClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rectBtnHideClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1080 && width == 2248)
        {
            var test = rectTitleDaily;
            test.anchoredPosition = new Vector2(-95, 423);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);
            test.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            rectBtnClaim.anchoredPosition = new Vector2(0, 189);
            rectBtnHideClaim.anchoredPosition = new Vector2(0, 189);
            rectBtnClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            rectBtnHideClaim.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
    void ScreenStore()
    {
        var rectStore = Store.GetComponent<RectTransform>();

        if (height == 1080 && width == 2160)
        {
            rectStore.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1440 && width == 2960)
        {
            rectStore.anchoredPosition = new Vector2(0, 10);
            rectStore.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1440 && width == 3040)
        {
            rectStore.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 1080 && width == 2280)
        {
            rectStore.localScale = new Vector3(0.85f, 0.85f, 0.85f);
            rectStore.anchoredPosition = new Vector2(0, 10);
        }
        if (height == 1080 && width == 2340)
        {
            rectStore.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 720 && width == 1560)
        {
            rectStore.localScale = new Vector3(0.85f, 0.85f, 0.85f);
            rectStore.anchoredPosition = new Vector2(0, 10);
        }
        if (height == 720 && width == 1600)
        {
            rectStore.localScale = new Vector3(0.85f, 0.85f, 0.85f);
            rectStore.anchoredPosition = new Vector2(0, 10);
        }
        if (height == 1080 && width == 1920)
        {
            rectStore.localScale = new Vector3(0.95f, 0.95f, 0.95f);
        }
        if (height == 720 && width == 1280)
        {
            rectStore.localScale = new Vector3(0.96f, 0.96f, 0.96f);
        }
        if (height == 1080 && width == 2248)
        {
            rectStore.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
    }
}
