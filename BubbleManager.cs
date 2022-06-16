using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BubbleManager : MonoBehaviour
{
    public float timee;
    public GameObject GameMngr;
    public bool hiddenStatus;
    private void OnEnable()
    {
        GameObject tempBubble = GameObject.Find(GameMngr.GetComponent<GameManager>().tempTargets[System.Convert.ToInt32(GameMngr.GetComponent<GameManager>().targetNum)]);

        List<string> tempEl = tempBubble.GetComponent<Targets>().targetEl;
        transform.GetChild(0).GetComponent<Text>().text = tempEl[Random.Range(0, tempEl.Count)];
    }
    private void FixedUpdate()
    {
        timee -= Time.deltaTime;
        if (timee <= 0 && !hiddenStatus)
        {
            gameObject.GetComponent<Image>().enabled = false;
            transform.GetChild(0).GetComponent<Text>().text = "";
            timee = 2;
            hiddenStatus = true;
        }
        else if(timee <= 0 && hiddenStatus)
        {
            GameObject tempBubble = GameObject.Find(GameMngr.GetComponent<GameManager>().tempTargets[System.Convert.ToInt32(GameMngr.GetComponent<GameManager>().targetNum)]);

            List<string> tempEl = tempBubble.GetComponent<Targets>().targetEl;
            transform.GetChild(0).GetComponent<Text>().text = tempEl[Random.Range(0, tempEl.Count)];
            gameObject.GetComponent<Image>().enabled = true;
            timee = 3;
            hiddenStatus = false;
        }
    }
}
