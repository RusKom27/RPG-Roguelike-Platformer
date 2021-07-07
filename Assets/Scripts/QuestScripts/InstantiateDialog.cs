using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateDialog : MonoBehaviour
{
    public TextAsset ta;
    public Dialog dialog;
    public int currentNode;
    public bool ShowDialogue;
    public List<Answer> answers = new List<Answer>();
    public int playerZIndex = -2; // -2 Front; 8 Back;

    private float speed, jumpSpeed;
    private bool inTrigger;
    private Animator pressE;
    private Player playerScript;
    private GameObject player, fade, panel, girlImage, girlName, NPCImage, NPCName, NPCTask, buttons, _HUD;
    private List<GameObject> button = new List<GameObject>();

    private void Awake()
    {
        pressE = GameObject.Find("Canvas/PressE").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        fade = GameObject.Find("Canvas/Dialog/Fade");
        panel = GameObject.Find("Canvas/Dialog/Panel");
        girlImage = GameObject.Find("Canvas/Dialog/GirlImage");
        girlName = GameObject.Find("Canvas/Dialog/GirlName");
        buttons = GameObject.Find("Canvas/Dialog/Buttons");
        button.AddRange(GameObject.FindGameObjectsWithTag("ChooseButton"));
        NPCImage = GameObject.Find("Canvas/Dialog/" + name + "Image");
        NPCName = GameObject.Find("Canvas/Dialog/NPCName");
        NPCTask = GameObject.Find("Canvas/Dialog/NPCTask");
        _HUD = GameObject.Find("Canvas/HUD");
        dialog = Dialog.Load(ta);
    }

    private void Start()
    {
        speed = playerScript.speed;
        jumpSpeed = playerScript.jumpSpeed;
        for (int i = 0; i < button.Count; i++)
        {
            button[i].SetActive(false);
        }
        ActivateDialog(false);
    }
    private void ActivateDialog(bool choise)
    {
        fade.SetActive(choise);
        girlName.SetActive(choise);
        panel.SetActive(choise);
        girlImage.SetActive(choise);
        NPCImage.SetActive(choise);
        NPCName.SetActive(choise);
        NPCTask.SetActive(choise);
        buttons.SetActive(choise);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inTrigger = true;
            pressE.SetBool("inTrigger", true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            inTrigger = false;
            pressE.SetBool("inTrigger", false);
        }
    }

    private void UpdateAnswers()
    {
        answers.Clear();
        for (int i = 0; i < dialog.nodes[currentNode].answers.Length; i++)
        {
            if (dialog.nodes[currentNode].answers[i].QuestName == null || dialog.nodes[currentNode].answers[i].NeedQuestValue == PlayerPrefs.GetInt(dialog.nodes[currentNode].answers[i].QuestName))
                answers.Add(dialog.nodes[currentNode].answers[i]);
        }
    }

    private void Update()
    {
        int count = 0;
        for (int i = 0; i < button.Count; i++)
        {
            if (button[i].activeSelf)
                count++;
        }

        UpdateAnswers();

        if (inTrigger && player.transform.position.z == playerZIndex)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Time.timeScale == 1)
                    Time.timeScale = 0;
                playerScript.speed = 0;
                playerScript.jumpSpeed = 0;
                _HUD.SetActive(false);
                ShowDialogue = true;
            }
        }

        if (ShowDialogue)
        {
            NPCName.GetComponent<Text>().text = name;
            NPCTask.GetComponent<Text>().text = dialog.nodes[currentNode].NpcText;
            ActivateDialog(true);

            for (int i = 0; i < answers.Count; i++)
            {
                button[i].GetComponentInChildren<Text>().text = answers[i].text;
                button[i].SetActive(true);

                for (int j = 0; j < button.Count; j++)
                {
                    if (count > answers.Count)
                        button[j].SetActive(false);
                }

                if (button[i].GetComponent<ButtonsTrigger>().isPressed)
                {
                    if (answers[i].QuestValue > 0)
                    {
                        PlayerPrefs.SetInt(answers[i].QuestName, answers[i].QuestValue);
                        for (int b = 0; b < button.Count; b++)
                        {
                            button[b].SetActive(false);
                        }
                    }

                    if (answers[i].end == "true")
                    {
                        for (int b = 0; b < button.Count; b++)
                        {
                            button[b].SetActive(false);
                        }
                        _HUD.SetActive(true);
                        ActivateDialog(false);
                        ShowDialogue = false;
                        if (Time.timeScale == 0)
                            Time.timeScale = 1;
                        playerScript.speed = speed;
                        playerScript.jumpSpeed = jumpSpeed;
                    }

                    button[i].GetComponent<ButtonsTrigger>().isPressed = false;
                    currentNode = answers[i].nextNode;
                }
            }
        }
    }
}