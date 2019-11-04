﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    [Header("Vibration")]
    public SettingControllerUI setting;
    public bool Activevibration;

    [Header("Button And Slide HP bar")]
    public Slider slider;
    public Slider sliderPVP;

    [Header("Values")]
    public float HP = 100f;
    public float trueDamage = 10; // damage base weapon
    public float trueDamageSkill = 0; // damage skill
    public float trueReceiveDamage = 10; // damage phai nhan vao
    public float trueReceiveDamageSkill = 10; // damage phai nhan vao
    public float trueReceiveDamageBase;
    public float timeTrueDeath = 4f;
    [Space]
    public float forceKB;
    public float forceKBReceive;
    public float forceKBBase;
    [Space]
    public bool trueDeath = false;

    [Header("Compane")]
    private HingeJoint2D[] hinge;
    private Animator[] anim;

    [Header("-------------------------------------------------------")]
    public SetSkillController setJoy;
    public SetSkillController setJoy2;
    public SystemDamage systemDamage;
    public CameraShakeController shake;
    public PickWeapon pick;

    public float maxHP;
    public float spellHP;
    [SerializeField]
    private bool protect;
    [SerializeField]
    private float timeProtect = 30;
    [SerializeField]
    private float beforeTimeProtect;
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField] private AnimationController[] body;

    [Header("Quest")]
    public Quest quest;

    [Header("------------------ Effect Spell ---------------------")]
    public ParticleSystem heal;
    public ParticleSystem protectSpell;
    public ParticleSystem FreezeSpell;
    public ParticleSystem PowSpell;

    [Header("------------------ PVP -------------------------------")]
    [SerializeField] private LocalForPVP localPVP;

    [Header("Audio")]
    private Audio audioManager;
    public string nameSoundPunch;
    public string nameSoundPunch2;
    public string nameSoundHeal;
    public string nameSoundProtect;
    public string nameSoundFrezze;
    public string nameSoundPower;

    private Vector3 newLocal;
    public float timeCDWeapon;

    void Start()
    {
        audioManager = Audio.instance;
        if (audioManager == null)
        {
            Debug.Log("No found any audio");
        }
        //-------------------------------------------------------------------------------------------
        setJoy.spell1.onClick.RemoveAllListeners();
        setJoy.spell1.onClick.AddListener(HealSpell);

        setJoy.spell2.onClick.RemoveAllListeners();
        setJoy.spell2.onClick.AddListener(Protect);

        setJoy.spell3.onClick.RemoveAllListeners();
        setJoy.spell3.onClick.AddListener(Freeze);

        setJoy.spell4.onClick.RemoveAllListeners();
        setJoy.spell4.onClick.AddListener(Block);
        //---------------------------------------------------------------------------------------------
        setJoy2.spell1.onClick.RemoveAllListeners();
        setJoy2.spell1.onClick.AddListener(HealSpell);

        setJoy2.spell2.onClick.RemoveAllListeners();
        setJoy2.spell2.onClick.AddListener(Protect);

        setJoy2.spell3.onClick.RemoveAllListeners();
        setJoy2.spell3.onClick.AddListener(Freeze);

        setJoy2.spell4.onClick.RemoveAllListeners();
        setJoy2.spell4.onClick.AddListener(Block);

        spellHP = (HP * 20) / 100;
        beforeTimeProtect = timeProtect;
        //--------------------------------------------------

        hinge = GetComponentsInChildren<HingeJoint2D>();
        anim = GetComponentsInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        localPVP = GetComponentInParent<LocalForPVP>();
        pick = GetComponent<PickWeapon>();
        body = GetComponentsInChildren<AnimationController>();


        heal.gameObject.SetActive(false);
        PowSpell.gameObject.SetActive(false);
        protectSpell.gameObject.SetActive(false);
    }
    void Update()
    {
        Activevibration = setting.Vibration;

        slider.value = HP;
        sliderPVP.value = HP;
        //death();

        if (protect)
        {
            trueReceiveDamage = 0;
            trueReceiveDamageSkill = 0;
            trueReceiveDamageBase = 0;
            timeProtect -= Time.deltaTime;
            if (timeProtect <= 0)
            {
                protect = false;
                protectSpell.gameObject.SetActive(false);
                timeProtect = beforeTimeProtect;
            }
        }
        else
        {
            trueReceiveDamage = systemDamage.trueDamageEnemy; // get true damage receive from Enemy (SystemDamage)
            trueReceiveDamageSkill = systemDamage.trueDamageSkillEnemy; // get true damage skill receive from enemy (systemDamage)
            trueReceiveDamageBase = systemDamage.damageBase;
            forceKBReceive = systemDamage.trueKnockBEnemy;
            forceKBBase = systemDamage.KnockBase;
        }
        systemDamage.trueDamagePlayer = trueDamage; // set true damage Player to SystemDamage
        systemDamage.trueKnockBPlayer = forceKB;
        systemDamage.local = transform.position;
        systemDamage.trueDamageSkillPlayer = trueDamageSkill;
        //Debug.Log("name: " + gameObject.name + " HP: " + HP);

        if (HP > 0)
        {
            newLocal = transform.position;
        }

        if (HP <= 0)
        {
            pick.weaponController = null;

            nameSoundPunch = null;
            nameSoundPunch2 = null;
            gameObject.transform.position = newLocal;
        }

        if (timeCDWeapon != 0)
        {
            systemDamage.timeP1 = timeCDWeapon;
        }
        else
        {
            systemDamage.timeP1 = 0;
        }
    }
    void Damage(float damage)
    {
        //HP -= trueReceiveDamage * damage;
        if (nameSoundPunch != null)
        {
            audioManager.PlaySound(nameSoundPunch);
        }

        if (localPVP == null && HP > 0)
        {
            slider.GetComponent<ControllerHPBar>().attack();
        }
        else if (localPVP)
        {
            sliderPVP.GetComponent<ControllerHPBar>().attack();
        }

        if (shake)
        {
            shake.activeShake(); // rung ma hinh
        }

        if (Activevibration)
        {
            Handheld.Vibrate(); // lam rung
        }

        if (HP <= 0)
        {
            //trueDeath = true;
            sendHideBody();
            StartCoroutine(waitToDeath());

        }
        else
        {
            trueDeath = false;
            systemDamage.trueDeath = trueDeath;
        }

        if (HP <= 0)
        {
            foreach (HingeJoint2D item in hinge)
            {
                item.breakForce = 1;
                item.breakTorque = 1;
                item.enabled = false;
            }

            foreach (Animator item in anim)
            {
                item.enabled = false;
            }

            StartCoroutine("wait");
        }
    }
    void DamageBySkill(float damage)
    {
        //HP -= trueReceiveDamageSkill * damage;

        if (nameSoundPunch != null)
        {
            audioManager.PlaySound(nameSoundPunch);
        }

        if (localPVP == null && HP > 0)
        {
            slider.GetComponent<ControllerHPBar>().attack();
        }
        else if (localPVP)
        {
            sliderPVP.GetComponent<ControllerHPBar>().attack();
        }

        if (shake)
        {
            shake.activeShake(); // rung ma hinh
        }

        if (Activevibration)
        {
            Handheld.Vibrate(); // lam rung
        }

        if (HP <= 0)
        {
            //trueDeath = true;
            sendHideBody();
            StartCoroutine(waitToDeath());

        }
        else
        {
            trueDeath = false;
            systemDamage.trueDeath = trueDeath;
        }

        if (HP <= 0)
        {
            foreach (HingeJoint2D item in hinge)
            {
                item.breakForce = 1;
                item.breakTorque = 1;
                item.enabled = false;
            }

            foreach (Animator item in anim)
            {
                item.enabled = false;
            }

            StartCoroutine("wait");
        }
    }
    void DamageBase(float damage)
    {
        //HP -= trueReceiveDamageBase * damage;

        if (nameSoundPunch != null)
        {
            audioManager.PlaySound(nameSoundPunch);
        }

        if (localPVP == null && HP > 0)
        {
            slider.GetComponent<ControllerHPBar>().attack();
        }
        else if (localPVP)
        {
            sliderPVP.GetComponent<ControllerHPBar>().attack();
        }

        if (Activevibration)
        {
            Handheld.Vibrate(); // lam rung
        }

        if (HP <= 0)
        {
            //trueDeath = true;
            sendHideBody();
            StartCoroutine(waitToDeath());
        }
        else
        {
            trueDeath = false;
            systemDamage.trueDeath = trueDeath;
        }

        if (HP <= 0)
        {
            foreach (HingeJoint2D item in hinge)
            {
                item.breakForce = 1;
                item.breakTorque = 1;
                item.enabled = false;
            }

            foreach (Animator item in anim)
            {
                item.enabled = false;
            }

            StartCoroutine("wait");
        }
    }
    void DamageTrap(float damage)
    {
        //HP -= trueReceiveDamageBase * damage;

        audioManager.PlaySound("hurt2");

        if (localPVP == null && HP > 0)
        {
            slider.GetComponent<ControllerHPBar>().attack();
        }
        else if (localPVP)
        {
            sliderPVP.GetComponent<ControllerHPBar>().attack();
        }

        //Debug.Log("damage trap");

        if (shake)
        {
            shake.activeShake();
        }

        if (HP <= 0)
        {
            //trueDeath = true;
            sendHideBody();
            StartCoroutine(waitToDeath());
        }
        else
        {
            trueDeath = false;
            systemDamage.trueDeath = trueDeath;
        }

        if (HP <= 0)
        {
            foreach (HingeJoint2D item in hinge)
            {
                item.breakForce = 1;
                item.breakTorque = 1;
                item.enabled = false;
            }

            foreach (Animator item in anim)
            {
                item.enabled = false;
            }

            StartCoroutine("wait");
        }
    }
    IEnumerator waitToDeath()
    {
        yield return new WaitForSeconds(systemDamage.timeDelayLose);
        trueDeath = true;
        systemDamage.trueDeath = trueDeath;
        if (localPVP)
        {
            localPVP.SendMessage("deathP1");
            localPVP = null;
        }
        yield return 0;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(timeTrueDeath);
        Destroy(gameObject);
        yield return 0;
    }
    public void HealSpell() // Spell 1
    {
        if (HP > 0)
        {
            audioManager.PlaySound(nameSoundHeal);
            heal.gameObject.SetActive(true);
            heal.Clear();
            heal.Play();
            HP += spellHP;
            if (HP > maxHP)
            {
                HP = maxHP;
            }

            quest.number++;
        }
    }
    public void Protect() // Spell 2
    {
        if (HP > 0)
        {
            audioManager.PlaySound(nameSoundProtect);

            protectSpell.gameObject.SetActive(true);
            protect = true;
            protectSpell.Clear();
            protectSpell.Play();
            timeProtect = beforeTimeProtect;

            quest.number++;
        }
    }
    public void Freeze() // Spell 3
    {
        if (HP > 0)
        {
            audioManager.PlaySound(nameSoundFrezze);

            if (GetComponentInParent<Local>())
            {
                var test = GetComponentInParent<Local>();

                test.FreezeEnemy();
            }
            if (GetComponentInParent<LocalForSurvival>())
            {
                var test = GetComponentInParent<LocalForSurvival>();

                test.FreezeEnemy();
            }
            Debug.Log("nothing happen");

            quest.number++;
        }
    }
    public void Block() //Spell 4
    {
        if (HP > 0)
        {
            if (nameSoundPower != null && audioManager != null)
            {
                audioManager.PlaySound(nameSoundPower);
            }
          
            PowSpell.gameObject.SetActive(true);
            PowSpell.Play();
            systemDamage.knockBack = true;
            quest.number++;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Vector2 pos;

        if (col.tag == "weaponEnemy")
        {
            HP -= trueReceiveDamage;
            if (nameSoundPunch2 != null)
            {
                audioManager.PlaySound(nameSoundPunch2);
            }

            pos = transform.position - col.gameObject.transform.position;
            var distance = pos.magnitude;
            var direction = pos / distance;

            //rb2d.velocity = new Vector2(-100, rb2d.velocity.y);
            rb2d.velocity = direction * forceKBReceive * 25 * 100 * Time.deltaTime;
        }

        if (col.tag == "skillE")
        {
            HP -= trueReceiveDamageSkill;
            if (nameSoundPunch2 != null)
            {
                audioManager.PlaySound(nameSoundPunch2);
            }

            pos = transform.position - col.gameObject.transform.position;
            var distance = pos.magnitude;
            var direction = pos / distance;

            //rb2d.velocity = new Vector2(-100, rb2d.velocity.y);
            rb2d.velocity = direction * forceKBReceive * 25 * 100 * Time.deltaTime;
        }

        if (col.tag == "weaponBaseE")
        {
            HP -= trueReceiveDamageBase;
            if (nameSoundPunch2 != null)
            {
                audioManager.PlaySound(nameSoundPunch2);
            }

            pos = transform.position - col.gameObject.transform.position;
            var distance = pos.magnitude;
            var direction = pos / distance;

            rb2d.velocity = direction * forceKBBase * 33 * 100 * Time.deltaTime;
        }

        if (col.tag == "trap")
        {
            HP -= trueReceiveDamageBase;
            if (nameSoundPunch2 != null)
            {
                audioManager.PlaySound(nameSoundPunch2);
            }

            pos = transform.position - col.gameObject.transform.position;
            var distance = pos.magnitude;
            var direction = pos / distance;

            rb2d.velocity = direction * 2.5f * 25 * 100 * Time.deltaTime;
        }
    } // knock Back
    void sumHitHead()
    {
        if (localPVP)
        {
            localPVP.SendMessage("sumHitHeadP1");
        }
    }
    void sumHit()
    {
        if (localPVP)
        {
            localPVP.SendMessage("sumHitP1");
        }
    }
    void sendHideBody()
    {
        for (int i = 0; i < body.Length; i++)
        {
            if (body[i] != null)
            {
                body[i].destination = null;
                body[i].ExploreBody();
                body[i].activelDis();
                body[i] = null;
            }
        }
    }

    public void offAudio()
    {
        audioManager.StopSound(nameSoundPunch);
    }
}

