using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour {
    public bool isChange = true;
    float changeTimer = 0f;
    public Color[] colors = new Color[3];
    int now = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isChange && changeTimer > 0.07f)
        {
            gameObject.GetComponent<Text>().color = colors[now % 3];
            now++;
            changeTimer = 0f;
        }

        changeTimer += Time.deltaTime;
    }
    public void off() {
        gameObject.GetComponent<Text>().color = new Color(255, 255, 255, 255);
        isChange = false;
    }
}
