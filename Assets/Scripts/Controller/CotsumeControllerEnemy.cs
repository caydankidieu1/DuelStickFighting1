using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CotsumeControllerEnemy : MonoBehaviour
{
    [Header("-------------------------------")]
    public Cotsume cotsume;
    public ControllerSystemSkins ControllerSkins;

    [Header("Only Enemy to change HP")]
    public float HP;
    public int id;

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
        if (id > 0)
        {
            for (int i = 0; i < ControllerSkins.cotsume.Length; i++)
            {
                if (ControllerSkins.cotsume[i].id == id)
                {
                    cotsume = ControllerSkins.cotsume[i];
                }
            }
        }
        else
        {
            List<Cotsume> testAllSkins = new List<Cotsume>();

            testAllSkins.Clear();
            for (int i = 0; i < ControllerSkins.cotsume.Length; i++)
            {
                if (ControllerSkins.cotsume[i].checkBuy)
                {
                    testAllSkins.Add(ControllerSkins.cotsume[i]);
                }
            }

            Debug.Log(testAllSkins.Count);
            if (testAllSkins.Count >= 1)
            {
                cotsume = testAllSkins[Random.Range(0, (int)testAllSkins.Count)];
            }
            else
            {
                cotsume = ControllerSkins.cotsume[52];
            }
            

            //cotsume = ControllerSkins.cotsume[0];
        }

        if (cotsume)
        {
            gameObject.GetComponent<EnemyManager>().HP = HP;

            if (gameObject.GetComponent<EnemyManager>().Slider)
            {
                gameObject.GetComponent<EnemyManager>().Slider.maxValue = HP;
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
