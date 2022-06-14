using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    float score, timee;
    float levelTime;
    int level;
    string targetNum;
    public List<string> targets = new List<string>();
    public List<string> tempTargets = new List<string>();
    public Image targetImg;
    public Text levelText;

    public GameObject bubbles;

    void Start()
    {
        level = 1;
        levelText.text = "Level " + level;
        score = 0;          //
        timee = 0;
        levelTime = 20;
        foreach (var item in targets)
        {
            tempTargets.Add(item);
        }

        TargetGeneration();
       
    }

    // Update is called once per frame
    void Update()
    {
        levelTime -= Time.deltaTime;
        if (levelTime <= 0)
        {
            if (tempTargets.Count > 0)
            {
                TargetGeneration();
                levelTime = 20;
            }
            else
            {
                Debug.Log("GameCompleted");
            }
            level++;
            levelText.text = "Level " + level;

        }
    }

    public void TargetGeneration()
    {
        targetNum = Random.Range(0, tempTargets.Count).ToString();
        targetImg.transform.GetChild(0).GetComponent<Text>().text = tempTargets[System.Convert.ToInt32(targetNum)];
        GameObject tempBubble = GameObject.Find(tempTargets[System.Convert.ToInt32(targetNum)]);
        List<string> tempEl = tempBubble.GetComponent<Targets>().targetEl;
        bubbles.transform.GetChild(0).GetComponent<Text>().text = tempEl[Random.Range(0,tempEl.Count)];
        tempTargets.RemoveAt(System.Convert.ToInt32(targetNum));

    }

    public void CheckAns(GameObject curBubble)
    {
        string expsn = curBubble.transform.GetChild(0).GetComponent<Text>().text;
        ExpressionEvaluator.Evaluate(expsn, out float result);
        if(result== System.Convert.ToInt32(tempTargets[System.Convert.ToInt32(targetNum)]))
        {
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("wrong");
        }
    }
}
