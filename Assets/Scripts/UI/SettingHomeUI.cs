using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingHomeUI : MonoBehaviour
{
    [Header("GameObjetc")]
    public GameObject coins;
    public GameObject leftHome;
    public GameObject leftHomeClone;
    public GameObject rightHome;
    public GameObject Level;
    public GameObject Setting;
    public GameObject Store;
    public GameObject Quest;

    [Header("Button")]
    public Button btnCoins;
    public Button setting;
    public Button back;

    public GameObject MainMenu;
    public StoreUI storeUI;
    public SettingMenuUI menuUI;
    // Start is called before the first frame update
    [Header("Controller all Button Home")]
    public Button adventure;
    public Button survival;
    public Button PVP;
    public Button store;
    public Button quest;
    public Button ads;
    public Button luckySpin;
    public Button opensetting;
    public Button opencoins;

    void Start()
    {
        setting.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        coins.SetActive(true);
        leftHome.SetActive(true);
        rightHome.SetActive(true);
        Level.SetActive(false);
        Setting.SetActive(false);
        Store.SetActive(false);

        leftHomeClone.SetActive(false);

        ManagerAds.Ins.ShowBanner();

    }

    public void SettingUI()
    {
        /*setting.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        back.enabled = true;
        coins.SetActive(true);
        leftHome.SetActive(false);
        rightHome.SetActive(false);
        Level.SetActive(false);
        Setting.SetActive(true);
        Store.SetActive(false);
        Quest.SetActive(false);*/

        unActivelAllButton();
        StartCoroutine(CloneSettingUI());
    }
    public IEnumerator CloneSettingUI()
    {
        yield return new WaitForSeconds(0.75f);

        setting.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        back.enabled = true;
        coins.SetActive(true);
        leftHome.SetActive(false);
        rightHome.SetActive(false);
        Level.SetActive(false);
        Setting.SetActive(true);
        Store.SetActive(false);
        Quest.SetActive(false);

        yield return 0;
    }

    public void backHome()
    {
        ManagerAds.Ins.ShowBanner();

        setting.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        coins.SetActive(true);
        leftHome.SetActive(true);
        rightHome.SetActive(true);
        Level.SetActive(false);
        Setting.SetActive(false);
        Store.SetActive(false);
        Quest.SetActive(false);

        leftHomeClone.SetActive(false);

        activelAllButton();
    }
    public void Adventure()
    {
        /*setting.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        coins.SetActive(true);
        leftHome.SetActive(true);
        rightHome.SetActive(false);
        Level.SetActive(true);
        Setting.SetActive(false);
        Store.SetActive(false);
        Quest.SetActive(false);*/

        unActivelAllButton();
        StartCoroutine(CloneAdvanture());
    }
    public IEnumerator CloneAdvanture()
    {
        yield return new WaitForSeconds(0.75f);

        setting.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        coins.SetActive(true);
        leftHome.SetActive(true);
        rightHome.SetActive(false);
        Level.SetActive(true);
        Setting.SetActive(false);
        Store.SetActive(false);
        Quest.SetActive(false);

        leftHomeClone.SetActive(true);

        activelAllButton();
        GetComponent<SettingMenuUI>().activelClone2();
        yield return 0;
    }

    public void StoreUI()
    {
        /*setting.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        coins.SetActive(true);
        leftHome.SetActive(false);
        rightHome.SetActive(false);
        Level.SetActive(false);
        Setting.SetActive(false);
        Store.SetActive(true);
        storeUI.Weapon();
        Quest.SetActive(false);*/

        back.enabled = false;
        unActivelAllButton();
        StartCoroutine(CloneStoreUI());
    }
    public IEnumerator CloneStoreUI()
    {
        activelAnimationStore3();

        yield return new WaitForSeconds(0.75f);

        setting.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        coins.SetActive(true);
        leftHome.SetActive(false);
        rightHome.SetActive(false);
        Level.SetActive(false);
        Setting.SetActive(false);
        Store.SetActive(true);
        storeUI.Weapon();
        Quest.SetActive(false);

        leftHomeClone.SetActive(false);

        yield return new WaitForSeconds(1f);
        back.enabled = true;

        yield return 0;
    }
    public void activelAnimationStore()
    {
        if (MainMenu != null)
        {
            Animator animator = MainMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("store");
                animator.SetBool("store", !isOpen);
            }
        }
    }
    public void activelAnimationStore2()
    {
        if (MainMenu != null)
        {
            Animator animator = MainMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("store");
                animator.SetBool("store", false);
            }
        }
    }
    public void activelAnimationStore3()
    {
        if (MainMenu != null)
        {
            Animator animator = MainMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("store");
                animator.SetBool("store", true);
            }
        }
    }

    public void QuestUI()
    {
        Quest.SetActive(true);
    }
    public void CloseQuestUI()
    {
        Quest.SetActive(false);
    }

    public void OpenIAP()
    {
        /*setting.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        coins.SetActive(true);
        leftHome.SetActive(false);
        rightHome.SetActive(false);
        Level.SetActive(false);
        Setting.SetActive(false);
        Store.SetActive(true);
        storeUI.IAP();
        Quest.SetActive(false);*/

        StartCoroutine(CloneOpenIAP());
    }
    public IEnumerator CloneOpenIAP()
    {
        yield return new WaitForSeconds(0.75f);

        setting.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        coins.SetActive(true);
        leftHome.SetActive(false);
        rightHome.SetActive(false);
        Level.SetActive(false);
        Setting.SetActive(false);
        Store.SetActive(true);
        storeUI.IAP();
        Quest.SetActive(false);

        leftHomeClone.SetActive(false);

        yield return 0;
    }
    public void CloneOpenIAP2()
    {
        setting.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
        coins.SetActive(true);
        leftHome.SetActive(false);
        rightHome.SetActive(false);
        Level.SetActive(false);
        Setting.SetActive(false);
        Store.SetActive(true);
        storeUI.IAP();
        Quest.SetActive(false);

        leftHomeClone.SetActive(false);
    }

    public void activelAllButton()
    {
        ManagerAds.Ins.ShowBanner();

        adventure.enabled = true;
        survival.enabled = true;
        PVP.enabled = true;
        store.enabled = true;
        quest.enabled = true;
        ads.enabled = true;
        luckySpin.enabled = true;
        opensetting.enabled = true;
        opencoins.enabled = true;
    }
    public void unActivelAllButton()
    {
        adventure.enabled = false;
        survival.enabled = false;
        PVP.enabled = false;
        store.enabled = false;
        quest.enabled = false;
        ads.enabled = false;
        luckySpin.enabled = false;
        opensetting.enabled = false;
        opencoins.enabled = false;
    }
}
