using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Pvr_UnitySDKAPI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject TeleportPointGo;

    public GameObject DungeonKeyGo;
    [Header("Keys")]
    public bool DungeonKey;
    public bool BasementKey;
    public bool BedroomKey;
    public bool GateKey;
    [Header("Interaction Setting")]
    public GameObject OpenDoorRemain;
    public bool isGameOver;
    public GameObject EndPanel;

    public bool isEscape;
    public Button btn_Restart;

    public GameObject StartNPC;
    public Transform StartNPCDIS;
    [Header("声音时间")]
    public float NpcTime=5;
    [Header("延迟时间")]
    public float DelayTime=5;

    public bool isDoll;
    public float GhostSpeed = .1f;
    public int DestroyNum = 0;
    public int Number_Doll=0;
    //public bool isZombieCool;
    public GameObject DollPrefab;

    
    public GraphicRaycaster graphicRaycaster;

    public BoxCollider[] BigDoorBoxCollider;
    public BoxCollider[] BigDoorBoxCollider2;

    public Transform EndPos;
    public Transform Player;
    private void Awake()
    {
        Instance = this;

        btn_Restart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Invoke("ShowNpcSound", DelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        graphicRaycaster.enabled = true;
        GhostSpeed = 1f + (DestroyNum * .15f);

        if (isGameOver)
        {
            EndPanel.SetActive(true);
            EndPanel.transform.GetChild(0).GetComponent<Text>().text = "You were killed by a ghost! \nPress the A key on the right-hand joystick to restart the game";
            //TeleportPointGo.SetActive(false);
            Time.timeScale = 0;

            if (Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.A))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }

        if (isEscape)
        {
            EndPanel.SetActive(true);
            EndPanel.transform.GetChild(0).GetComponent<Text>().text = "Congratulations, you have successfully escaped!\nPress the A key on the right-hand joystick to restart the game";

            Time.timeScale = 0;

            if (Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.A))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }

        //if (DestroyNum>=2)
        //{
        //    foreach (var item in BigDoorBoxCollider)
        //    {
        //        item.enabled = true;
        //    }
        //}

        if (Number_Doll>0)
        {
            isDoll = true;
            if (Input.GetKeyDown(KeyCode.Space)|| Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.B))
            {
                Number_Doll--;
                isDoll = false;
                //isZombieCool = true;
                Instantiate(DollPrefab, Player.transform.localPosition+new Vector3(1,0,0), Quaternion.identity);
                //Invoke("ShowZombieAttack", 5);
            }
        }
        else
        {
            isDoll = false;
        }



        if (DestroyNum >=7)
        {
            foreach (var item in BigDoorBoxCollider2)
            {
                item.enabled = true;
            }
        }

        if (Vector3.Distance(Player.position,EndPos.position)<=5)
        {
            isEscape = true;
        }
    }

    public void ShowNpcSound()
    {
        StartNPC.GetComponent<AudioSource>().enabled = true;
        Invoke("StartNPCMove", 55);       
    }

    public void StartNPCMove()
    {
        StartNPC.GetComponent<NavMeshAgent>().SetDestination(StartNPCDIS.position);
        StartNPC.GetComponent<Animator>().SetBool("IsWalk", true);
        Invoke("ShowDungeonKey", NpcTime);
    }

    public void ShowDungeonKey()
    {
        DungeonKeyGo.SetActive(true);
        StartNPC.GetComponent<Animator>().SetBool("IsWalk", false);
        StartNPC.SetActive(false);
    }

    public void ShowOpenDoorErrorRemain()
    {
        OpenDoorRemain.SetActive(true);
        Invoke("CloseOpenDoorRemain", 3);
    }

    void CloseOpenDoorRemain()
    {
        OpenDoorRemain.SetActive(false);
    }


    //    void ShowZombieAttack()
    //    {
    //        isZombieCool = false;
    //    }
}
