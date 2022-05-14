using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Solution : MonoBehaviour
{
    public GameObject brokenShip;
    public GameObject repairedShip;
    private bool levelComplete;

    public Text xValTextRaw;
    private string xValText;
    private string xVal = "";

    public Text yValTextRaw;
    private string yValText;
    private string yVal = "";

    [SerializeField] int nextSceneNum;
    [SerializeField] string answer1;
    [SerializeField] string answer2;
    [SerializeField] bool lessThan;
    [SerializeField] bool greaterThan;
    [SerializeField] bool lessThanEqual;
    [SerializeField] bool greaterThanEqual;
    [SerializeField] bool equals;
    [SerializeField] bool AND;
    [SerializeField] bool OR;
    [SerializeField] bool TwoVariables;

    // Update is called once per frame
    void Update()
    {
        xValText = xValTextRaw.text;
        xVal = xValText.Replace("x = ", "");

        yValText = yValTextRaw.text;
        yVal = yValText.Replace("y = ", "");
    }


    public void checkAnswer()
    {
        if (TwoVariables && (answer1 == "" || answer2 == "")) { }
        else if (AND)
        {
            if (answerPart(xVal, answer1) && answerPart(yVal, answer2))
            {
                StartCoroutine(NextScene(nextSceneNum));
            }
        }
        else if (OR)
        {
            if (answerPart(xVal, answer1) || answerPart(yVal, answer2))
            {
                StartCoroutine(NextScene(nextSceneNum));
            }
        }
        else if (equals)
        {
            if (answerPart(xVal, answer1))
            {
                StartCoroutine(NextScene(nextSceneNum));
            }
        }
    }

    private bool answerPart(string playerValue, string answerToCheck)
    {
        Debug.Log("Calling Function");
        if (lessThan)
        {
            if (float.Parse(playerValue) < float.Parse(answerToCheck))
            {
                return true;
            }
        }
        else if (greaterThan)
        {
            if (float.Parse(playerValue) > float.Parse(answerToCheck))
            {
                return true;
            }
        }
        else if (greaterThanEqual)
        {
            if (float.Parse(playerValue) >= float.Parse(answerToCheck))
            {
                Debug.Log("Working");
                return true;
            }
        }
        else if (lessThanEqual)
        {
            if (float.Parse(playerValue) <= float.Parse(answerToCheck))
            {
                return true;
            }
        }
        else if (equals)
        {
            if (playerValue == answerToCheck)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator NextScene(int sceneNum)
    {
        brokenShip.SetActive(false);
        repairedShip.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneNum);
        StopAllCoroutines();
    }
}
