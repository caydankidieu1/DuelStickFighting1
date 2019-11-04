using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [Header("slider")]
    public bool P2;
    public Slider Slider;

    [Header("Values")]
    public float HP = 100f;
    public float trueDamage = 10;
    public float trueDamageSkill = 10;
    public float trueReceiveDamage = 10; // damage base phai nhan
    public float trueReceiveDamageSkill = 10; // damage skill phai nhan
    public float trueDamageBase;
    public float timeTrueDeath = 4f;
    public bool trueDeath;

    public bool CheckAttackFromEnemy; // kiem tra enemy[i] voi damage khac nhau

    [Header("Compane")]
    private WeaponController weaponController;
    private Collider2D[] weaponBase;
    private AI ai;
    private HingeJoint2D[] hinge;
    private Animator[] anim;
    public SystemDamage systemDamage;
    [Space]
    public float forceKB;
    public float forceKBReceive;
    public float forceKBBase;
    
    [Header("value Pop-up")]
    private Local local;
    public float IsSumHitHead;
    public float IsSumHit;

    public Rigidbody2D rb2d;
    [Header("-------------------------- PVP ---------------------------")]
    [SerializeField] private LocalForPVP localPVP;
    [Header("-------------------------- Survival ----------------------")]
    [SerializeField] private LocalForSurvival localSur;
    [SerializeField] private CreateWeaponE WeaponE;
    [Space]
    private AnimationControllerEnemy[] body;

    [Header("Audio")]
    private Audio audioManager;
    public string nameSoundPunch;

    [Space]
    public float timeCDWeapon;

    void Start()
    {
        audioManager = Audio.instance;
        if (audioManager == null)
        {
            Debug.Log("No found any audio");
        }


        if (!systemDamage)
        {
            systemDamage = GameObject.FindObjectOfType<SystemDamage>();
        }
        rb2d = GetComponent<Rigidbody2D>();
        local = GetComponentInParent<Local>();
        hinge = GetComponentsInChildren<HingeJoint2D>();
        anim = GetComponentsInChildren<Animator>();
        localPVP = GetComponentInParent<LocalForPVP>();
        localSur = GetComponentInParent<LocalForSurvival>();
        ai = GetComponent<AI>();
        weaponBase = GetComponentsInChildren<Collider2D>();
        WeaponE = GetComponent<CreateWeaponE>();
        body = GetComponentsInChildren<AnimationControllerEnemy>();
        weaponController = GetComponentInChildren<WeaponController>();

        ChangeLayer();
    }
    void Update()
    {
        if (Slider)
        {
            Slider.value = HP;
        }
        //death();
        if (systemDamage)
        {
            trueReceiveDamageSkill = systemDamage.trueDamageSkillPlayer; // get value receive damage skill Enemy
            trueReceiveDamage = systemDamage.trueDamagePlayer; // get value receive damage Enemy = damage player from SystemDamage
            trueDamageBase = systemDamage.damageBase;

            forceKBReceive = systemDamage.trueKnockBPlayer;
            forceKBBase = systemDamage.KnockBase;

            if (CheckAttackFromEnemy)
            {
                systemDamage.trueDamageEnemy = trueDamage;
                systemDamage.trueDamageSkillEnemy = trueDamageSkill;
                systemDamage.trueKnockBEnemy = forceKB;
            }
        }
      

        if (HP <= 0)
        {
            StartCoroutine(waitGetDeath());
            trueDamage = 0;
            trueDamageSkill = 0;
            trueReceiveDamage = 0;
            trueDamageBase = 0;
            trueReceiveDamageSkill = 0;
            if (ai != null)
            {
                ai.DropWeapon();
                ai.enabled = false;
                ai = null;
            }
            for (int i = 0; i < weaponBase.Length; i++)
            {
                if (weaponBase[i].tag == "weaponBaseE")
                {
                    weaponBase[i].gameObject.SetActive(false);
                }
            }

            if (WeaponE)
            {
                if (WeaponE.weaponManager.GetComponent<Collider2D>())
                {
                    WeaponE.weaponManager.GetComponent<Collider2D>().enabled = false;
                }
            }
        }

        KnockBackMe();

        if (timeCDWeapon != 0 && P2)
        {
            systemDamage.timeP2 = timeCDWeapon;
        }
        else if (timeCDWeapon == 0 && P2)
        {
            systemDamage.timeP2 = 0;
        }
    }
    void Damage(float damage)
    {
        HP -= trueReceiveDamage * damage;

        if (P2 && localPVP)
        {
            Slider.GetComponent<ControllerHPBar>().attack();
        }

        if (HP <= 0)
        {
            trueDeath = true;
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

            sendHideBody();
            StartCoroutine("wait");
        }
    }
    void Damage2(float damage)
    {
        HP -= trueReceiveDamageSkill * damage;

        if (P2 && localPVP)
        {
            Slider.GetComponent<ControllerHPBar>().attack();
        }

        if (HP <= 0)
        {
            trueDeath = true;
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

            sendHideBody();
            StartCoroutine("wait");
        }
    }
    void DamageBase(float damage)
    {
        HP -= trueDamageBase * damage;

        if (nameSoundPunch != null)
        {
            audioManager.PlaySound(nameSoundPunch);
        }

        if (P2 && localPVP)
        {
            Slider.GetComponent<ControllerHPBar>().attack();
        }

        if (HP <= 0)
        {
            trueDeath = true;
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

            sendHideBody();
            StartCoroutine("wait");
        }
    }
    void DamageTrap(float damage)
    {
        HP -= 10 * damage;

        if (P2 && localPVP)
        {
            Slider.GetComponent<ControllerHPBar>().attack();
        }

        if (HP <= 0)
        {
            //trueDeath = true;
            StartCoroutine(waitGetDeath());
        }
        else
        {
            trueDeath = false;
            if (systemDamage)
            {
                systemDamage.trueDeath = trueDeath;
            }
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

            sendHideBody();
            StartCoroutine("wait");
        }
    }
    void sumHitHead()
    {
        if (local)
        {
            IsSumHitHead++;
            local.SendMessage("sumHitHead");
        }
        if (localPVP)
        {
            localPVP.SendMessage("sumHitHeadP2");
        }
        if (localSur)
        {
            IsSumHitHead++;
            localSur.SendMessage("sumHitHead");
        }
    }
    void sumHit()
    {
        if (local)
        {
            IsSumHit++;
            local.SendMessage("sumHit");
        }
        if (localPVP)
        {
            localPVP.SendMessage("sumHitP2");
        }
        if (localSur)
        {
            localSur.SendMessage("sumHit");
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(timeTrueDeath);
        Destroy(gameObject);
        yield return 0;
    }
    IEnumerator waitGetDeath()
    {
        yield return new WaitForSeconds(.001f);
        if (local)
        {
            local.SendMessage("death");
            local = null;
        }

        if (localPVP)
        {
            localPVP.SendMessage("deathP2");
            localPVP = null;
        }

        if (localSur)
        {
            localSur.SendMessage("death");
            localSur = null;
        }

        systemDamage = null;
        yield return 0;
    }
    private void KnockBackMe()
    {
        if (systemDamage)
        {
            if (systemDamage.knockBack)
            {
                Vector2 pos;
                float force = 0;

                pos = transform.position - systemDamage.local;
                var distance = pos.magnitude;
                var direction = pos / distance;
                Debug.Log(distance);
                if (distance > 10)
                {
                    force = 0;
                }
                else
                {
                    force = 2;
                }

                rb2d.velocity = direction * force * 25 * 50 * Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Vector2 pos;

        if (col.tag == "weapon" || col.tag == "skillP")
        {
            // print(col.gameObject.name);
            // print(col.gameObject.transform.position);

            pos = transform.position - col.gameObject.transform.position;
            var distance = pos.magnitude;
            var direction = pos / distance;

            //rb2d.velocity = new Vector2(-100, rb2d.velocity.y);
            rb2d.velocity = direction * forceKBReceive * 25 * 100 * Time.deltaTime;
        }

        if (col.tag == "weaponBaseP")
        {

            pos = transform.position - col.gameObject.transform.position;
            var distance = pos.magnitude;
            var direction = pos / distance;

            //rb2d.velocity = new Vector2(-100, rb2d.velocity.y);
            rb2d.velocity = direction * forceKBBase * 27 * 100 * Time.deltaTime;
        }

        if (col.tag == "trap" && localPVP)
        {
            // Damage(1);

            pos = transform.position - col.gameObject.transform.position;
            var distance = pos.magnitude;
            var direction = pos / distance;

            rb2d.velocity = direction * 4f * 25 * 100 * Time.deltaTime;
        }
    } // knock Back
    void sendHideBody()
    {
        if (WeaponE)
        {
            WeaponE.weaponController.enableWeapon = true;
        }
        
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
    public void ChangeLayer()
    {
        for (int i = 0; i < body.Length; i++)
        {
            body[i].gameObject.layer = 9;
        }
        StartCoroutine(waitTochangeNormal());
    }
    IEnumerator waitTochangeNormal()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < body.Length; i++)
        {
            body[i].gameObject.layer = 11;
        }
        yield return 0;
    }
}
