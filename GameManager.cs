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
    public string targetNum;
    public List<string> targets = new List<string>();
    public List<string> tempTargets = new List<string>();
    public Image targetImg;
    public Text levelText;
    public Text scoreText;
    public Text gameoverText;

    public GameObject bubble1, bubble2, bubble3, bubble4;

    void Start()    //start function executes only one time.
    {
        level = 1;
        levelText.text = "Level " + level;
        score = 0;
        scoreText.text = score.ToString();
        timee = 0;
        levelTime = 20;
        foreach (var item in targets)
        {
            tempTargets.Add(item);
        }

        TargetGeneration();

    }

    // Update is called once per frame
    void Update()   //update function executes for every frame.
    {
        levelTime -= Time.deltaTime;
        if (levelTime <= 0)
        {
            tempTargets.RemoveAt(System.Convert.ToInt32(targetNum));
            if (tempTargets.Count > 0)
            {
                TargetGeneration();
                levelTime = 20;
            }
            else
            {
                gameoverText.text = "Score " + score  + "\n" + "Game Over...!!!" ;
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
        bubble1.transform.GetChild(0).GetComponent<Text>().text = tempEl[Random.Range(0, tempEl.Count)];
        bubble2.transform.GetChild(0).GetComponent<Text>().text = tempEl[Random.Range(0, tempEl.Count)];
        bubble3.transform.GetChild(0).GetComponent<Text>().text = tempEl[Random.Range(0, tempEl.Count)];
        bubble4.transform.GetChild(0).GetComponent<Text>().text = tempEl[Random.Range(0, tempEl.Count)];

    }

    public void CheckAns(GameObject curBubble)
    {
        
        string expsn = curBubble.transform.GetChild(0).GetComponent<Text>().text;
        ExpressionEvaluator.Evaluate(expsn, out float result);
        if (result == System.Convert.ToInt32(tempTargets[System.Convert.ToInt32(targetNum)]))
        {
            score += 3;
            scoreText.text = score.ToString();

        }
        else
        {
            score -= 2;
            scoreText.text = score.ToString();
        }
        curBubble.GetComponent<Image>().enabled = false;
        curBubble.transform.GetChild(0).GetComponent<Text>().text = "";
        timee = 2;
        curBubble.GetComponent<BubbleManager>().hiddenStatus = true;
    }
}
