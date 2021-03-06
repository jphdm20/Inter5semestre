using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial_Sistem : MonoBehaviour
{

    public GameObject[] HUDs;
    int counter = 0;
    public GameObject dialogueSistem;
    public GameObject[] dialogues;
    public TextMeshProUGUI text;
    [TextArea (3,10)]
    public string[] sentences;    
    float pressCD;
    bool dialogueOn;
    bool nextStep;
    public SpawnManager spawnManager;
    public PJ_Character chef;
    PJ_Character[] players;

    void Start()
    {
        counter = 0;
        players = FindObjectsOfType<PJ_Character>();
    
    }


    void Update()
    {
        CD();

        if(counter == 0) text.text = sentences[0];
        
        if(counter != sentences.Length)
        {
            if(counter == 7 || counter == 11|| counter == 13 || counter == 15 || counter == 17 || counter == 19 || counter == 27) ToogleDialgueCanvas(0, true);
            else ToogleDialgueCanvas(1, true);
            
            if(counter == 4)
            {
                HUDs[0].SetActive(true);
            } 
            else if(counter == 5)
            {
                HUDs[1].SetActive(true);
            }
            else if(counter == 6)
            {
                HUDs[2].SetActive(true);
            }
             else if(counter == 8)
            {
                HUDs[3].SetActive(true);
            }
             else if(counter == 12)
            {
                HUDs[4].SetActive(true);
            }
            else if(counter == 13)
            {
                HUDs[5].SetActive(true);
            }
            else if(counter == 18)
            {
                HUDs[6].SetActive(true);
            }
            else if(counter == 20)
            {
                HUDs[7].SetActive(true);
            }
            else if(counter == 24)
            {
                HUDs[8].SetActive(true);
            }
            else DeactiveHUD();
            

        }
        

        if(checkE() && nextStep == true)
        {
             if(counter == sentences.Length)
                {
                    dialogueSistem.SetActive(false);
                    spawnManager._TutorialEnded = true;
                    chef.characterOn = true;
                    foreach(PJ_Character p in players){p.TutorialOff = true;}
                    Destroy(this.gameObject);
                }
                else StartDialogue(sentences[counter]);
        }

    }
    
    void DeactiveHUD()
    {

        foreach(GameObject obj in HUDs){ obj.SetActive(false);}

    }
    
    void CD()
    {
        pressCD += Time.deltaTime;
        if(pressCD > 0.2f)
        {
            nextStep = true;
        }
    }
    

    bool checkE()
    {
        return MacroSistema.sistema.input_Manager.pressedE;
    }


    public void ToogleDialgueCanvas(int i , bool onOff)
    {
        if(onOff == false)
        {
             dialogues[0].gameObject.SetActive(false);
             dialogues[1].gameObject.SetActive(false);
             dialogueSistem.SetActive(false);
             dialogueOn = false;
        }
        else 
        {
            dialogueSistem.SetActive(true);
            dialogues[0].gameObject.SetActive(false);
            dialogues[1].gameObject.SetActive(false);
            dialogues[i].gameObject.SetActive(true);
            dialogueOn = true;
        }

    }


    void StartDialogue(string sentences)
    {
        text.text = sentences;
        counter ++;
        nextStep = false;
    }


}
