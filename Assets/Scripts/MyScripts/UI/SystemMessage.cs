using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMessage : MonoBehaviour
{
    private static int msgNum = 0;
    
    public static void SystemMessageCreate(string msg)
    {
        GameObject systemMessage = new GameObject(msg, typeof(RectTransform));
        systemMessage.AddComponent<Text>();
        systemMessage.AddComponent<SystemMessage>().Init_Msg(msg);

    }

    float timer = 0f;
    int myMsgNum = 0;
    int msgNum_Temp = 0;
    RectTransform rTransform;
    Text myText;

    public void Init_Msg(string msg)
    {
        myText = GetComponent<Text>();
        myText.text = msg;
        myText.fontSize = 40;
        myText.alignment = TextAnchor.MiddleCenter;

        rTransform = GetComponent<RectTransform>();
        rTransform.sizeDelta = new Vector2(2000f, 100f);

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        myText.font = ArialFont;
        myText.material = ArialFont.material;

        myMsgNum = msgNum;
        msgNum_Temp = msgNum;
        msgNum++;

        transform.SetParent(PlayManager.Instance.GetSystemMessageCanvas().transform);
    }


    void Update()
    {
        if (timer >= 5f)
            StartCoroutine(DestroyCall());

        if (myMsgNum >= 0 && msgNum_Temp > msgNum)
        {
            myMsgNum--;
        }
        msgNum_Temp = msgNum;

        rTransform.localPosition = new Vector3(0, 350f - myMsgNum * 50f, 0f);

        timer += Time.deltaTime;
    }

    IEnumerator DestroyCall()
    {
        float fadeOutTimer = 0f;
        
        while(true)
        {
            if (fadeOutTimer > 1f)
                break;

            myText.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, fadeOutTimer));

            fadeOutTimer += Time.deltaTime;
            yield return null;
        }

        msgNum--;
        Destroy(gameObject);
    }

}
