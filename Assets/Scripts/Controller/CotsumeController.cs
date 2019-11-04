using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CotsumeController : MonoBehaviour
{
    public Cotsume cotsume;

    [Header("Only Enemy to change HP")]
    public float HP;
    public string id;

    [Header("Local Cotsume")]
    public int HPCotsume;
    public GameObject Head;
    public GameObject Chest;
    public GameObject Hip;

    [Header("Arms")]
    public GameObject UpperArm_R;
    public GameObject LowerArm_R;
    public GameObject UpperArm_L;
    public GameObject LowerArm_L;

    [Header("legs")]
    public GameObject UpperLeg_R;
    public GameObject lowerLeg_R;
    public GameObject UpperLeg_L;
    public GameObject lowerLeg_L;


    private void Start()
    {
        actionCotsume();
    }

    void actionCotsume()
    {
        if (cotsume)
        {
            HPCotsume = cotsume.HP;
            if (gameObject.GetComponent<PlayerManager>())
            {
                gameObject.GetComponent<PlayerManager>().HP = cotsume.HP;
                gameObject.GetComponent<PlayerManager>().maxHP = cotsume.HP;
                gameObject.GetComponent<PlayerManager>().slider.maxValue = cotsume.HP;
                gameObject.GetComponent<PlayerManager>().sliderPVP.maxValue = cotsume.HP;
                gameObject.GetComponent<PlayerManager>().spellHP = (cotsume.HP * 30) / 100;
            }

            if (gameObject.GetComponent<EnemyManager>())
            {
                gameObject.GetComponent<EnemyManager>().HP = HP;
            }

            Head.GetComponent<SpriteRenderer>().sprite = cotsume.Head;
            Chest.GetComponent<SpriteRenderer>().sprite = cotsume.Chest;
            Hip.GetComponent<SpriteRenderer>().sprite = cotsume.Hip;

            UpperArm_R.GetComponent<SpriteRenderer>().sprite = cotsume.UpperArm_R;
            LowerArm_R.GetComponent<SpriteRenderer>().sprite = cotsume.LowerArm_R;
            UpperArm_L.GetComponent<SpriteRenderer>().sprite = cotsume.UpperArm_L;
            LowerArm_L.GetComponent<SpriteRenderer>().sprite = cotsume.LowerArm_L;

            UpperLeg_R.GetComponent<SpriteRenderer>().sprite = cotsume.UpperLeg_R;
            lowerLeg_R.GetComponent<SpriteRenderer>().sprite = cotsume.LowerLeg_R;
            UpperLeg_L.GetComponent<SpriteRenderer>().sprite = cotsume.UpperLeg_L;
            lowerLeg_L.GetComponent<SpriteRenderer>().sprite = cotsume.LowerLeg_L;
        }
    }
}
