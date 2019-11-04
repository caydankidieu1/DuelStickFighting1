using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [Header("values")]
    public Transform target;
    public float force = 10f;
    public float DistanceActiveAi = 5f;
    public float delay = 0f;
    public float timeSkill = 2f;
    private float timeCD;

    [SerializeField] private float cloneTime;
    public Rigidbody2D rigi;
    private Vector2 pos;
    public WeaponController weaponController;
    public LayerMask whatToHit;
    private float timeToMoveTarget = 1f;

    private void Start()
    {
        timeCD = timeSkill;
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>() ? GameObject.FindGameObjectWithTag("player").GetComponent<Transform>() : gameObject.transform; 
        }
        
        weaponController = GetComponentInChildren<WeaponController>();
    }

    void FixedUpdate()
    {
        timeToMoveTarget -= Time.deltaTime;
        if (target)
        {
            if (timeToMoveTarget > 0)
            {
                moveAIAway();
            }
            else { moveAI(); }
          
        }

        AttackSkill();
    }
    public void setWeaponController()
    {
        weaponController = GetComponentInChildren<WeaponController>();
    }
    void moveAI()
    {
        pos = transform.position - target.position;
        var distance = pos.magnitude;
        var direction = pos / distance;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position, distance, whatToHit);
        //Debug.DrawLine(transform.position, target.position, Color.red, 100);

        if (hit.collider != null)
        {
            cloneTime += Time.deltaTime;
            if (cloneTime > 0 && cloneTime <= 1.8f)
            {
                rigi.velocity = (Vector2.up * force * Time.deltaTime * 10 * 1.5f);
            }
            else if (cloneTime > 1.8f && cloneTime <= 4f)
            {
                rigi.velocity = (-direction * force * Time.deltaTime * 10 * 1.5f);
            }
            else if (cloneTime > 4 && cloneTime <= 6f)
            {
                rigi.velocity = (direction * force * Time.deltaTime * 10 * 1.5f);
            }
            else
            {
                cloneTime = 0;
            }
        }
        else
        {
            cloneTime = 0;

            if (Vector2.Distance(transform.position, target.position) > DistanceActiveAi)
            {
                rigi.velocity = (-direction * force * Time.deltaTime * 10);
            }
            else if (Vector2.Distance(transform.position, target.position) < DistanceActiveAi)
            {
                rigi.velocity = (-direction * force * Time.deltaTime * 5);
            }
        }
    }
    void moveAIAway()
    {
        pos = transform.position - target.position;
        var distance = pos.magnitude;
        var direction = pos / distance;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position, distance, whatToHit);

        if (hit.collider != null)
        {
            cloneTime += Time.deltaTime;
            if (cloneTime > 0 && cloneTime <= 1.8f)
            {
                rigi.velocity = (Vector2.up * force * Time.deltaTime * 10 * 1.5f);
            }
            else if (cloneTime > 1.8f && cloneTime <= 4f)
            {
                rigi.velocity = (direction * force * Time.deltaTime * 10 * 1.5f);
            }
            else if (cloneTime > 4 && cloneTime <= 6f)
            {
                rigi.velocity = (-direction * force * Time.deltaTime * 10 * 1.5f);
            }
            else
            {
                cloneTime = 0;
            }
        }
        else
        {
            cloneTime = 0;

            if (Vector2.Distance(transform.position, target.position) > DistanceActiveAi)
            {
                rigi.velocity = (direction * force * Time.deltaTime * 10);
            }
            else if (Vector2.Distance(transform.position, target.position) < DistanceActiveAi)
            {
                rigi.velocity = (direction * force * Time.deltaTime * 5);
            }
        }
    }
    void AttackSkill()
    {
        if (weaponController)
        {
            timeSkill -= Time.deltaTime;
            if (timeSkill <= 0)
            {
                weaponController.Skill();
                timeSkill = timeCD;
            }
        }
    }
    public void DropWeapon()
    {
        var test = Random.Range(0, 100);
        if (test >= 70)
        {
            if (weaponController)
            {
                weaponController.Throw();
            }
            else Debug.Log("don't have weapon");
        }
    }
}
