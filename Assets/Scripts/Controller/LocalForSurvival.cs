using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalForSurvival : MonoBehaviour
{
    [Header("-------")]
    public PlayerManager playerManager;
    public Transform player;
    public bool checkEnemy;
    public int sumEnemy;

    [Header("-----------------------------")]
    public SystemDamage system;
    public BattleUI battleUI;

    [Header("value Pop-Up")]
    public float sumKills;
    public float sumHits;
    public float sumHitHeads;
    public float sumCoin;
    public float combo; // so combo cao nhat ma trong wave dat duoc trong 3s
    [SerializeField]
    private float comboClone;
    [SerializeField]
    private float comboTestTime;
    private float test;
    [Header("-------------------------------------- Auto Create Enemy ----------------")]
    public WeaponManager weapons;
    public ControllerSystemSkins skins;
    public GameObject localtionEnemy;
    public GameObject prefabEnemy;
    public int amoutEnemysAccepted = 3;
    public float timeToCheckEnemys = 5f;
    private float cloneTimeCheck;
    [Space]
    public int HpStart = 100;
    public int limitOneWave = 5;

    [Header("Second Change")]
    public bool secondchange;

    private void Start()
    {
        secondchange = false;
        system.secondChange = false;
        system.loser = false;
        system.victory = false;

        playerManager = GetComponentInChildren<PlayerManager>();
        cloneTimeCheck = timeToCheckEnemys;
        test = system.timeCombo;
    }
    private void Update()
    {
        SumCombo();

        SumcoinsReward();
        battleUI.sumCoins = sumCoin;
        setValuePopUp();

        if (playerManager)
        {
            if (playerManager.HP > 0)
            {
                CheckAllEnemy();
            }
        }
       
        if (sumKills >= limitOneWave)
        {
            HpStart += 200;
            limitOneWave += (int)sumKills;
        }

        if (system)
        {
            system.secondChange = secondchange;
        }
    }

    public void SumcoinsReward()
    {
        if (sumKills > 1 && sumKills < 6)
        {
            sumCoin = 50;
        }
        else if (sumKills >= 6 && sumKills <= 10)
        {
            sumCoin = 60;
        }
        else if (sumKills >= 11 && sumKills <= 15)
        {
            sumCoin = 70;
        }
        else if (sumKills >= 16 && sumKills <= 20)
        {
            sumCoin = 80;
        }
        else if (sumKills >= 21 && sumKills <= 25)
        {
            sumCoin = 90;
        }
        else if (sumKills >= 26 && sumKills <= 30)
        {
            sumCoin = 100;
        }
        else if (sumKills >= 31 && sumKills <= 35)
        {
            sumCoin = 110;
        }
        else if (sumKills >= 36 && sumKills <= 40)
        {
            sumCoin = 120;
        }
        else if (sumKills >= 36 && sumKills <= 40)
        {
            sumCoin = 120;
        }
        else if (sumKills >= 41 && sumKills <= 45)
        {
            sumCoin = 130;
        }
        else if (sumKills >= 46 && sumKills <= 50)
        {
            sumCoin = 140;
        }
        else if (sumKills >= 51)
        {
            sumCoin = 150;
        }
        else if (sumKills <= 0)
        {
            sumCoin = 0;
        }
    }
    #region InfoCombo
    void setValuePopUp()
    {
        battleUI.VKill.text = sumKills.ToString();
        battleUI.VHeadshots.text = sumHitHeads.ToString();
        battleUI.VCombo.text = combo.ToString();
        battleUI.VCoins.text = sumCoin.ToString();

        battleUI.LKill.text = sumKills.ToString();
        battleUI.LHeadshots.text = sumHitHeads.ToString();
        battleUI.LCombo.text = combo.ToString();
        battleUI.LCoins.text = sumCoin.ToString();
    }
    void sumHit()
    {
        sumHits++;
        comboTestTime = test;

        if (comboTestTime >= 0)
        {
            comboClone++;
        }
    }
    void SumCombo()
    {
        comboTestTime -= Time.deltaTime;

        if (comboTestTime <= 0f)
        {
            if (comboClone > combo)
            {
                combo = comboClone;
                comboClone = 0;
            }
            else
            {
                comboClone = 0;
            }
        }
    }
    void sumHitHead()
    {
        sumHitHeads++;
    }
    void death()
    {
        sumKills++;
    }
    #endregion
    public void CheckAllEnemy()
    {
        timeToCheckEnemys -= Time.deltaTime;

        if (timeToCheckEnemys <= 0)
        {
            var test = GetComponentsInChildren<EnemyManager>().Length;
            //Debug.Log("Amount Enemys: " + test);
            if (test < amoutEnemysAccepted)
            {
                AutoCreateEnemy();
            }

            timeToCheckEnemys = cloneTimeCheck;
        }
    }
    public void AutoCreateEnemy()
    {
        GameObject T = Instantiate(prefabEnemy, localtionEnemy.transform.position, Quaternion.identity);
        T.gameObject.SetActive(true);
        T.GetComponent<AI>().force = Random.Range(40, (int)65);
        T.GetComponent<AI>().timeSkill = 5; ;
        T.transform.SetParent(gameObject.transform);
        T.GetComponent<CotsumeControllerEnemy>().id = RandomSkin();
        T.GetComponent<CotsumeControllerEnemy>().HP = HpStart;
        T.GetComponent<CreateWeaponE>().idItem = RandomWeapon();
    }
    int RandomSkin()
    {
        List<Cotsume> testAllSkinBuy = new List<Cotsume>();
        for (int i = 0; i < skins.cotsume.Length; i++)
        {
            testAllSkinBuy.Add(skins.cotsume[i]);
        }

        Cotsume skinEnemys = testAllSkinBuy[Random.Range(0, (int)testAllSkinBuy.Count)];
        return skinEnemys.id;
    }
    string RandomWeapon()
    {
       /* ManagerAds.Ins.ShowInterstitial();
        ManagerAds.Ins.ShowRewardedVideo(isSuccess =>
        {
            if (isSuccess)
            {

            }
        });
        ManagerAds.Ins.ShowBanner();
        ManagerAds.Ins.HideBanner();

        ManagerAds.Ins.RemoveAds();

        ManagerAds.Ins.RateApp();
        ManagerAds.Ins.MoreGame();*/

        List<Weapon> testAllWeaponBuy = new List<Weapon>();
        for (int i = 0; i < weapons.weaponItem.Length; i++)
        {
             testAllWeaponBuy.Add(weapons.weaponItem[i]);
        }

        Weapon weaponEnemys = testAllWeaponBuy[Random.Range(0, (int)testAllWeaponBuy.Count)];
        return weaponEnemys.id;
    }

    public void FreezeEnemy()
    {
        for (int i = 0; i < GetComponentsInChildren<EnemyManager>().Length; i++)
        {
            GetComponentsInChildren<EnemyManager>()[i].rb2d.bodyType = RigidbodyType2D.Static;
            GetComponentsInChildren<EnemyManager>()[i].GetComponent<AI>().enabled = false;
        }

        StartCoroutine(ActivelMove());
    }
    IEnumerator ActivelMove()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < GetComponentsInChildren<EnemyManager>().Length; i++)
        {
            GetComponentsInChildren<EnemyManager>()[i].rb2d.bodyType = RigidbodyType2D.Dynamic;
            GetComponentsInChildren<EnemyManager>()[i].GetComponent<AI>().enabled = true;
        }
        yield return 0;
    }

    private void OnEnable()
    {
        ManagerAds.Ins.HideBanner();
    }

    private void OnDisable()
    {
        system.trueDeath = false;
        system.loser = false;
    }
}
