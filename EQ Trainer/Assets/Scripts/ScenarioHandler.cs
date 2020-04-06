using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioHandler : MonoBehaviour
{
    private string fileName = "Assets/Data/testScenarioData.xml";
    [SerializeField]
    private Text scenarioText;
    [SerializeField]
    private Button[] buttonList;

    private int currentScenarioIndex;
    private Scenario currentScenario;
    private Scenario[] scenariosArray;
    private Scenarios scenarios;
    private string buttonText;


    // Start is called before the first frame update
    void Start()
    {
        currentScenarioIndex = 0;
        ReadScenarioXML();
        SetScenario(currentScenarioIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadScenarioXML()
    {
        scenarios = Scenarios.Load(fileName);
        scenariosArray = scenarios.scenariosArray;
    }
    void SetScenario(int scenarioNumber)
    {
        currentScenario = scenariosArray[scenarioNumber];


        scenarioText.text = currentScenario.text;

        //Debug.Log(currentScenario.Options.Count);


        for (int i = 0; i < buttonList.Length; i++)
        {
            
            System.Console.WriteLine(currentScenario.Options[i].optionText);
            Debug.Log(currentScenario.Options[i].optionText);
            buttonList[i].GetComponent<RewardScript>().score = currentScenario.Options[i].score;
            buttonList[i].GetComponentInChildren<Text>().text = currentScenario.Options[i].optionText;
        }
    }
}