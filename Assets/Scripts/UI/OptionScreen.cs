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
        if (height == 1440 && width == 2960)
        {
            var test = rightHome.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(91, 19);
            test.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1440 && width == 3040)
        {
            var test = rightHome.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(100, 13);
            test.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 720 && width == 1600)
        {
            var test = rightHome.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(9, 3);
            test.localScale = new Vector3(0.95f, 0.95f, 0.95f);
        }
        if (height == 1080 && width == 2280)
        {
            var test = rightHome.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(100, 23);
            test.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1080 && width == 2160)
        {
            var test = rightHome.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(85, 0);
            test.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1080 && width == 2340)
        {
            var test = rightHome.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(100, 29);
            test.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 720 && width == 1560)
        {
            var test = rightHome.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(100, 8);
            test.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 720 && width == 1600)
        {
            var test = rightHome.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(100, 8);
            test.localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 480 && width == 800)
        {
            var test = rightHome.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(0, -12);
            test.localScale = new Vector3(0.95f, 0.95f, 0.95f);
        }
    }
    void MoveLeftHome()
    {
        if (height == 1080 && width == 2160)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(10,  -24);
        }
        if (height == 1440 && width == 2960)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
        if (height == 1440 && width == 3040)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(-8, -8);
        }
        if (height == 1440 && width == 2560)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -56);
        }
        if (height == 1080 && width == 2280)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(-8, -8);
        }
        if (height == 1080 && width == 2340)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(-18, 5);
        }
        if (height == 720 && width == 1560)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(-18, -8);
        }
        if (height == 720 && width == 1600)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(-28, 8);
        }
        if (height == 1080 && width == 1920)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, -48);
        }
        if (height == 480 && width == 800)
        {
            leftHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(69, -56);
        }
    }
    void MoveLevel()
    {
        if (height == 1080 && width == 2160)
        {
            level.GetComponent<RectTransform>().anchoredPosition = new Vector2(35, -23);
        }
        if (height == 1440 && width == 2960)
        {
            level.GetComponent<RectTransform>().anchoredPosition = new Vector2(47, -15);
        }
        if (height == 1440 && width == 3040)
        {
            BtnBackOnLevel.SetActive(false);
            level.GetComponent<RectTransform>().anchoredPosition = new Vector2(58, -17);
        }
        if (height == 1080 && width == 2280)
        {
            BtnBackOnLevel.SetActive(false);
            level.GetComponent<RectTransform>().anchoredPosition = new Vector2(59, -21);
        }
        if (height == 1080 && width == 2340)
        {
            BtnBackOnLevel.SetActive(false);
            level.GetComponent<RectTransform>().anchoredPosition = new Vector2(66, -21);
        }
        if (height == 720 && width == 1560)
        {
            BtnBackOnLevel.SetActive(false);
            level.GetComponent<RectTransform>().anchoredPosition = new Vector2(67, -20);
        }
        if (height == 720 && width == 1600)
        {
            BtnBackOnLevel.SetActive(false);
            level.GetComponent<RectTransform>().anchoredPosition = new Vector2(73, -20);
        }
    }
    void DailyGift()
    {
        if (height == 1080 && width == 2160)
        {
            panelReward.GetComponent<GridLayoutGroup>().constraintCount = 3;
            var test = titleDailyGift.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);

            BtnClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 183);
            BtnHideClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 183);
            BtnClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            BtnHideClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1440 && width == 2960)
        {
            panelReward.GetComponent<GridLayoutGroup>().constraintCount = 3;
            var test = titleDailyGift.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);

            BtnClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 183);
            BtnHideClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 183);
            BtnClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            BtnHideClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1440 && width == 3040)
        {
            var test = titleDailyGift.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);

            BtnClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 183);
            BtnHideClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 183);
            BtnClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            BtnHideClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1440 && width == 2560)
        {
            var test = titleDailyGift.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(-103, 462);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);

            BtnClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 234);
            BtnHideClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 234);
            BtnClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            BtnHideClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1080 && width == 2280)
        {
            var test = titleDailyGift.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);

            BtnClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 180);
            BtnHideClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,180);
            BtnClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            BtnHideClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 1080 && width == 2340)
        {
            var test = titleDailyGift.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);
            test.localScale = new Vector2(0.4f, 0.4f);

            BtnClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 172);
            BtnHideClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 172);
            BtnClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            BtnHideClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 720 && width == 1560)
        {
            var test = titleDailyGift.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(-103, 420);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);
            test.localScale = new Vector2(0.4f, 0.4f);

            BtnClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 174);
            BtnHideClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 174);
            BtnClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            BtnHideClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (height == 720 && width == 1600)
        {
            var test = titleDailyGift.GetComponent<RectTransform>();
            test.anchoredPosition = new Vector2(-103, 407);
            test.sizeDelta = new Vector2(2086.8f, 237.4f);
            test.anchorMin = new Vector2(0.5f, 0.5f);
            test.anchorMax = new Vector2(0.5f, 0.5f);
            test.localScale = new Vector3(0.4f,0.4f,0.4f);

            BtnClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 159);
            BtnHideClaim.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 159);
            BtnClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            BtnHideClaim.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
    void ScreenStore()
    {
        if (height == 1080 && width == 2160)
        {
            Store.GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1440 && width == 2960)
        {
            Store.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 10);
            Store.GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (height == 1440 && width == 3040)
        {
            Store.GetComponent<RectTransform>().localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 1080 && width == 2280)
        {
            Store.GetComponent<RectTransform>().localScale = new Vector3(0.85f, 0.85f, 0.85f);
            Store.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 10);
        }
        if (height == 1080 && width == 2340)
        {
            Store.GetComponent<RectTransform>().localScale = new Vector3(0.85f, 0.85f, 0.85f);
        }
        if (height == 720 && width == 1560)
        {
            Store.GetComponent<RectTransform>().localScale = new Vector3(0.85f, 0.85f, 0.85f);
            Store.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 10);
        }
        if (height == 720 && width == 1600)
        {
            Store.GetComponent<RectTransform>().localScale = new Vector3(0.85f, 0.85f, 0.85f);
            Store.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 10);
        }
        if (height == 1080 && width == 1920)
        {
            Store.GetComponent<RectTransform>().localScale = new Vector3(0.95f, 0.95f, 0.95f);
        }
        if (height == 720 && width == 1280)
        {
            Store.GetComponent<RectTransform>().localScale = new Vector3(0.96f, 0.96f, 0.96f);
        }
    }
}
