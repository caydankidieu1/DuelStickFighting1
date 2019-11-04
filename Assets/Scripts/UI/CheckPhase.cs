using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPhase : MonoBehaviour
{
    [Header("-------------------------- Check Me  ----------------------")]
    public bool Begin;
    public bool Inter;
    public bool Advan;
    public bool Expert;
    public bool Master;
    public StarController star;

    [Header("Value")]
    public int conditionStar = 30;
    public int sumStar;

    [Header("value")]
    public GameObject backMode;
    public GameObject nextMode;

    [Header("Check Mode Lock")]
    public bool activeUnlock;

    [Header("Location Condition Star")]
    public Text checkCondition;
    public Text checkCondition2;
    public Phase[] phase;

    [Header("Next Phase")]
    public CheckPhase phaseClone; // kiem tra Phase truoc co du dieu kien de mo khoa map khong

    private void Awake()
    {
        checkLockWave();
    }

    // Start is called before the first frame update
    void Start()
    {
        phase = GetComponentsInChildren<Phase>();
    }
    // Update is called once per frame
    void Update()
    {
        allStar();
        checkCondition.text = sumStar + " / " + conditionStar;
        checkCondition2.text = conditionStar.ToString();

        checkPlayed();
    }
    private void FixedUpdate()
    {
        checkLockWave();
    }
    void checkLockWave()
    {
        if (phaseClone)
        {
            if (phaseClone.sumStar >= phaseClone.conditionStar)
            {
                activeUnlock = true;
            }
            else if (phaseClone.sumStar < phaseClone.conditionStar)
            {
                activeUnlock = false;
            }
        }
        else
        {
            activeUnlock = true;
        }
    }
    void allStar()
    {
        sumStar = phase[0].IsStar +
            phase[1].IsStar +
            phase[2].IsStar +
            phase[3].IsStar +
            phase[4].IsStar +
            phase[5].IsStar +
            phase[6].IsStar +
            phase[7].IsStar +
            phase[8].IsStar;
    }
    public void ButtonLeft()
    {
      /*  if (backMode)
        {
            backMode.SetActive(true);
            gameObject.SetActive(false);
        }*/

        if (Inter)
        {
            star.OnBeginner();
        }
        else if (Advan)
        {
            star.Intermediate();
        }
        else if (Expert)
        {
            star.Advance();
        }
        else if (Master)
        {
            star.Expert();
        }
    }
    public void ButtonRight()
    {
        /*if (nextMode)
        {
            nextMode.SetActive(true);
            gameObject.SetActive(false);
        }*/

        if (Begin)
        {
            star.Intermediate();
        }
        else if (Inter)
        {
            star.Advance();
        }
        else if (Advan)
        {
            star.Expert();
        }
        else if (Expert)
        {
            star.Master_();
        }
    }
    public void checkPlayed()
    {
        for (int i = 0; i < phase.Length; i++)
        {
            for (int k = 1; k < phase.Length; k++)
            {
                if (phase[i].IsStar >= 1 && phase[k].IsStar == 0)
                {
                    if (!((i + 1) >= phase.Length))
                    {
                        phase[i + 1].checkNext = true;
                    }
                }
                else
                {
                    phase[0].checkNext = true;
                }
            }     
        }
    }
}
