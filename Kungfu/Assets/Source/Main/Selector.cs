using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour {
    int now = 0;

    public Text[] list = new Text[5];
    public string[] nameString;
    public Image left, right;
    // Use this for initialization
    void Start () {
        ChangeText(now,true);
        left.GetComponent<RectTransform>().anchoredPosition = new Vector2(left.GetComponent<RectTransform>().anchoredPosition.x, list[now % 5].GetComponent<RectTransform>().anchoredPosition.y);
        right.GetComponent<RectTransform>().anchoredPosition = new Vector2(right.GetComponent<RectTransform>().anchoredPosition.x, list[now % 5].GetComponent<RectTransform>().anchoredPosition.y);
        list[now % 5].gameObject.GetComponent<TextColorChanger>().isChange = true;
    }
	
	// Update is called once per frame
	void Update () {
        MoveControl();
        

    }

    void MoveControl()
    {
        if (Input.GetKeyUp(KeyCode.W) == true)
        {
            if (now != 0) {
                list[now % 5].gameObject.GetComponent<TextColorChanger>().off();
                now--;
                list[now % 5].gameObject.GetComponent<TextColorChanger>().isChange = true;
                left.GetComponent<RectTransform>().anchoredPosition = new Vector2(left.GetComponent<RectTransform>().anchoredPosition.x, list[now % 5].GetComponent<RectTransform>().anchoredPosition.y);
                right.GetComponent<RectTransform>().anchoredPosition = new Vector2(right.GetComponent<RectTransform>().anchoredPosition.x, list[now % 5].GetComponent<RectTransform>().anchoredPosition.y);
                ChangeText(now,false);
                Debug.Log(now);
            }
        }
        if (Input.GetKeyUp(KeyCode.S) == true)
        {
            if (now != nameString.Length - 1)
            {
                list[now % 5].gameObject.GetComponent<TextColorChanger>().off();
                now++;
                list[now % 5].gameObject.GetComponent<TextColorChanger>().isChange = true;

                left.GetComponent<RectTransform>().anchoredPosition = new Vector2(left.GetComponent<RectTransform>().anchoredPosition.x, list[now % 5].GetComponent<RectTransform>().anchoredPosition.y);
                right.GetComponent<RectTransform>().anchoredPosition = new Vector2(right.GetComponent<RectTransform>().anchoredPosition.x, list[now % 5].GetComponent<RectTransform>().anchoredPosition.y);
                ChangeText(now,true);
                Debug.Log(now);

            }
        }
        if (Input.GetKeyUp(KeyCode.Return) == true) {
            //Application.LoadLevel("SplashScene");
			if(now == 4)
				UnityEngine.SceneManagement.SceneManager.LoadScene("StageScene2");

			else
				UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");

			
        }
    }

    void ChangeText(int now, bool isDown) {
        if (isDown)
        {
            if (now % 5 == 0)
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (now + i < nameString.Length)
                        list[i].gameObject.GetComponent<Text>().text = nameString[now + i];
                    else
                        list[i].gameObject.GetComponent<Text>().text = "";
                }
            }
        }
        else if (!isDown) {
            if ((now+1)% 5 == 0)
            {
                Debug.Log("in");
                for (int i = 0; i < 5; ++i)
                {
                    if (now - i >= 0)
                        list[4-i].gameObject.GetComponent<Text>().text = nameString[now - i];
                }
            }
        }
    }
}
