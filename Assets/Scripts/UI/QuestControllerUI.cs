using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class QuestControllerUI : MonoBehaviour
{
    [Header("Get Coins")]
    public Coins coins;

    [Header("Info Local Create Button")]
    public Transform local;
    public GameObject prefab;
    public string idCheck;

    private QuestButtonUI[] buttonUI;

    [Header("Quest")]
    public Quest[] quest;

    void Start()
    {
        LoadQuest(); //
        CreateNewSlotSkin();
        buttonUI = GetComponentsInChildren<QuestButtonUI>();
    }
    void CreateNewSlotSkin()
    {
        foreach (Quest item in quest)
        {
            if (item)
            {
                GameObject T = Instantiate(prefab) as GameObject;
                T.transform.SetParent(local);
                T.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                T.GetComponent<QuestButtonUI>().quest = item;
                T.GetComponent<QuestButtonUI>().idQuest = item.id;
                T.GetComponent<QuestButtonUI>().nameQuest.text = item.Description;
                T.GetComponent<QuestButtonUI>().CostPresent.text = item.present.ToString();
                T.GetComponent<QuestButtonUI>().image.sprite = item.iconQuest;
                T.GetComponent<QuestButtonUI>().numberProcess.text = item.number + " / " + item.numberMax;
                if (item.checkClaim)
                {
                    T.GetComponent<QuestButtonUI>().Claim.SetActive(true);
                    if (item.checkReceived)
                    {
                        T.GetComponent<QuestButtonUI>().process.SetActive(false);
                        T.GetComponent<QuestButtonUI>().Claim.SetActive(false);
                    }
                }
            }
        }
    }

    public void SaveQuest()
    {
        SaveSystem.SaveQuest(this);
    }
    public void LoadQuest()
    {
        string pathQuest = Application.persistentDataPath + "/Quest.dat";
        if (File.Exists(pathQuest))
        {
            QuestData data = SaveSystem.LoadQuest();

            for (int i = 0; i < quest.Length; i++)
            {
                for (int k = 0; k < data.Q.Count; k++)
                {
                    if (quest[i].id == data.Q[k].id)
                    {
                        quest[i].number = data.Q[k].number;
                        quest[i].checkClaim = data.Q[k].CheckClaim;
                        quest[i].checkReceived = data.Q[k].CheckReceived;
                    }
                }
            }
        }
    }
    public void ResetQuest()
    {
        for (int i = 0; i < quest.Length; i++)
        {
            quest[i].number = 0;
            quest[i].checkClaim = false;
            quest[i].checkReceived = false;
        }

        SaveQuest();
        LoadQuest();
    }
}
