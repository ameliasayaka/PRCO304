using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioHandler : MonoBehaviour
{
    private string fileName = "testScenarioData";
    [SerializeField]
    private Text scenarioText;
    [SerializeField]
    private Button[] buttonList;

    private int currentScenarioIndex;
    private Scenario currentScenario;
    private Scenario[] scenariosArray;
    private Scenario[] randScenarioArray;

    private Scenarios scenarios;
    private string buttonText;
    private int testScore;
    private int maxScore;


    //review panel to fade in
    public GameObject reviewPanel;
    public Text scoreText;
    public Text adviceText;

    private CanvasGroup panelCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        currentScenarioIndex = 0;
    
        ReadScenarioXML();
        randScenarioArray = new Scenario[scenariosArray.Length];
        randScenarioArray = ShuffleScenarioArray(scenariosArray);

        maxScore = randScenarioArray.Length * 5;

        SetScenario(currentScenarioIndex);

        panelCanvasGroup = reviewPanel.GetComponent<CanvasGroup>();
    }

    void ReadScenarioXML()
    {
        scenarios = Scenarios.Load(fileName);
        scenariosArray = scenarios.scenariosArray;
    }
    public void LoadNextScenario()
    {
        currentScenarioIndex += 1;

        if(currentScenarioIndex == randScenarioArray.Length -1)
        {
            //Finish Test
            // Show Review Panel
            DisplayTotalScorePercent();
            panelCanvasGroup.GetComponent<UIFadeScript>().CallFadeForAttachedCanvas(true);
        }
        else
        {
            SetScenario(currentScenarioIndex);
        }
    }
    private void SetScenario(int scenarioNumber)
    {
        currentScenario = randScenarioArray[scenarioNumber];


        scenarioText.text = currentScenario.text;

        //Debug.Log(currentScenario.Options.Count);


        for (int i = 0; i < buttonList.Length; i++)
        {
            
            System.Console.WriteLine(currentScenario.Options[i].optionText);
            Debug.Log(currentScenario.Options[i].optionText);
            buttonList[i].GetComponent<RewardScript>().Score = currentScenario.Options[i].score;
            //buttonList[i].GetComponentInChildren<Text>().text = currentScenario.Options[i].optionText;
        }
    }

    public void AddScoreButton(GameObject button)
    {

        testScore += button.GetComponent<RewardScript>().Score;
    }


    public Scenario[] ShuffleScenarioArray(Scenario[] scenarioArray)
    {
        System.Random rand = new System.Random();
        int randElement;
        Scenario[] array = new Scenario[scenarioArray.Length];

        for (int i = 0; i < scenarioArray.Length; i++)
        {
            randElement = rand.Next(0, scenarioArray.Length);

            while (scenarioArray[randElement] == null) // check element is not null
            {
                randElement = rand.Next(0, scenarioArray.Length);
            }
            array[i] = scenarioArray[randElement];
            scenarioArray[randElement] = null; //set to null to prevent duplicates         
        }

        return array;
    }

    public void DisplayTotalScorePercent()
    {
        float totalScore;
        float maxScore = randScenarioArray.Length * 5f;

        totalScore = (testScore / maxScore) * 100f;

        scoreText.text = "Your score is: " + (int)totalScore + "%";
    }


}