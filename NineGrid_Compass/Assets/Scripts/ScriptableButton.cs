using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptableButton : MonoBehaviour
{
    public Button ButtonClick;

    // Start is called before the first frame update
    void Start()
    {
        ButtonClick.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Clicked");
    }
}
