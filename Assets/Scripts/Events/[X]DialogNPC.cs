/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNPC : MonoBehaviour
{
    public int playerZIndex = -2; // -2 Front; 8 Back;

    private bool inTrigger;
    private float speed;
    private Player PlayerScript;
    private GameObject player, fade, panel, girlImage, girlName, choise1, choise2;
    private GameObject NPCImage, NPCName, NPCTask;
    private Text NPCTaskText, NPCNameText, Choise1Text, Choise2Text;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = player.GetComponent<Player>();
        fade = GameObject.Find("Canvas/Fade");
        panel = GameObject.Find("Canvas/Dialog/Panel");
        girlImage = GameObject.Find("Canvas/Dialog/GirlImage");
        girlName = GameObject.Find("Canvas/Dialog/GirlName");
        choise1 = GameObject.Find("Canvas/Dialog/Choise1");
        choise2 = GameObject.Find("Canvas/Dialog/Choise2");
        Choise1Text = choise1.GetComponentInChildren<Text>();
        Choise2Text = choise2.GetComponentInChildren<Text>();
        NPCImage = GameObject.Find("Canvas/Dialog/" + name + "Image");
        NPCName = GameObject.Find("Canvas/Dialog/" + name + "Name");
        NPCTask = GameObject.Find("Canvas/Dialog/" + name + "Task");
        NPCNameText = NPCName.GetComponent<Text>();
        NPCTaskText = NPCTask.GetComponent<Text>();
    }
    private void Start()
    {
        ActivateDialog(false);
    }

    private void ActivateDialog(bool choise)
    {
        fade.SetActive(choise);
        girlName.SetActive(choise);
        panel.SetActive(choise);
        girlImage.SetActive(choise);
        choise1.SetActive(choise);
        choise2.SetActive(choise);
        NPCImage.SetActive(choise);
        NPCName.SetActive(choise);
        NPCTask.SetActive(choise);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            inTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            inTrigger = false;
    }
    private void Update()
    {
        if (inTrigger && player.transform.position.z == playerZIndex)
        {
            if (PlayerScript.speed > 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    speed = PlayerScript.speed;
                    PlayerScript.speed = 0;
                    ActivateDialog(true);
                }
            }
        }
    }

    private void ChangeText()
    {
        if (name == "Mage" && inTrigger)
        {
            if (MageProgress == "Mage0.0")
            {
                NPCTaskText.text = "Здравствуй";  //NPC

                Choise1Text.text = "Привет"; //Choise 1 Mage0.0
                Choise2Text.text = "Пока";   //Choise 2 Mage0.0
            }
            if (PlayerScript.choise1Pressed == true && MageProgress == "Mage0.0") // "Привет"
            {
                PlayerScript.choise1Pressed = false;
                MageProgress = "Mage1.1";  // Mage(Name of NPC)1.(Stage of dialog)1(number of choise)
            }
            if (PlayerScript.choise2Pressed == true && MageProgress == "Mage0.0") // "Пока"
            {
                PlayerScript.choise1Pressed = false;
                PlayerScript.speed = speed;
                ActivateDialog(false);
                MageProgress = "Mage0.0";
            }
            if (MageProgress == "Mage1.1")
            {
                NPCTaskText.text = "Как тебя зовут?";

                Choise1Text.text = "А зачем вам?";
                Choise2Text.text = "Берекка";
            }
            if (PlayerScript.choise1Pressed == true && MageProgress == "Mage1.1") // "А зачем вам?"
            {
                PlayerScript.choise1Pressed = false;
                MageProgress = "Mage2.1";
            }
            if (PlayerScript.choise2Pressed == true && MageProgress == "Mage1.1") // "Берекка"
            {
                PlayerScript.choise2Pressed = false;
                MageProgress = "Mage2.2";
            }
            if (MageProgress == "Mage2.1")
            {
                NPCTaskText.text = "Мне нужно знать, с кем я разговариваю";

                Choise1Text.text = "Я не помню";
                Choise2Text.text = "Прощай";
            }
            if (MageProgress == "Mage2.2")
            {
                NPCTaskText.text = "У меня есть задание, если принесешь мне ветку маленького дерева, то я скажу, что делать дальше";

                Choise1Text.text = "Хорошо";
                Choise2Text.text = "Прощай";
            }
            if (PlayerScript.choise1Pressed == true && MageProgress == "Mage2.1") // "Я не помню"
            {
                PlayerScript.choise1Pressed = false;
                choise2.SetActive(false);
                MageProgress = "Mage3.1";
            }
            if (PlayerScript.choise2Pressed == true && MageProgress == "Mage2.1" || MageProgress == "Mage2.2") // "Прощай"
            {
                PlayerScript.choise2Pressed = false;
                PlayerScript.speed = speed;
                ActivateDialog(false);
                MageProgress = "Mage0.0";
            }
            if (PlayerScript.choise1Pressed == true && MageProgress == "Mage2.2") // "Хорошо"
            {
                PlayerScript.choise2Pressed = false;
                
                PlayerScript.speed = speed;
                ActivateDialog(false);
                MageProgress = "Mage0.0";
            }
            if (MageProgress == "Mage3.1")
            {
                NPCTaskText.text = "Когда вспомнишь, приходи";

                Choise1Text.text = "Прощай";
                Choise2Text.text = "";
            }
            if (PlayerScript.choise1Pressed == true && MageProgress == "Mage3.1") // "Прощай"
            {
                PlayerScript.choise1Pressed = false;
                choise2.SetActive(true);
                PlayerScript.speed = speed;
                ActivateDialog(false);
                MageProgress = "Mage0.0";
            }
        }
        if (name == "Woman" && inTrigger)
        {
            if (WomanProgress == "Woman0.0")
            {
                NPCTaskText.text = "Hi";
                Choise1Text.text = "Шо";
                Choise2Text.text = "Пока";
            }
        }
    }
}*/