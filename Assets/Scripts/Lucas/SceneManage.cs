using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [SerializeField]
    static int numberOfScenes;

    [SerializeField]
    static int actualScene = 0;
    [SerializeField]
    static string[] sceneName;

    // Start is called before the first frame update
    void Start()
    {
        numberOfScenes = 4;
        sceneName = new string[numberOfScenes];
//#if UNITY_EDITOR
//        Scene scene = SceneManager.GetActiveScene();
//        actualScene = scene.buildIndex;
//        Debug.Log(actualScene + " ac");
//#endif
        StartSceneNames();
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene(bool loadNext)
    {
        //if true load next, if false load actualScene
        if(loadNext)
            actualScene += 1;
        else
            actualScene -= 1;

        SceneManager.LoadScene(sceneName[actualScene]);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(sceneName[actualScene]);
    }    
    
    public void GoToMenu()
    {
        actualScene = 0;
        SceneManager.LoadScene(sceneName[actualScene]);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    void StartSceneNames()
    {
        // Corrige a contagem de cenas pro for, considerando o index 0 como a cena 1
        int number = numberOfScenes - 1;
        for (int i = 0; i < numberOfScenes; i++)
        {
            Debug.Log(i);
            if (i != 0 && i != number)
                sceneName[i] = "Level " + i.ToString();
            else if (i == number)
            {
                sceneName[i] = "Credits";
                Debug.Log("passou = " + i);
            }
            else
                sceneName[i] = "Menu";
        }
    }
}