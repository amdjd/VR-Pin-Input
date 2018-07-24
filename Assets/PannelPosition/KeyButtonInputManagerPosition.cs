using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButtonInputManagerPosition : MonoBehaviour {

    #region Public Variables
    [Header("Essentials")]
    public Transform Panel;
    public Transform Buttons;
    public TextMesh outputText;

    #endregion

    #region Private Variables
    private System.String pass = "1234";
    private System.String inputpass="";
    #endregion

     void Awake()
    {
        int shuffleNum = new System.Random().Next(1, Buttons.childCount - 1);
        ShuffleButton(shuffleNum);
    }

    #region Public Methods
    public void ButtonInput_Num(TextMesh n)
    {
        int shuffleNum = new System.Random().Next( 1, Buttons.childCount-1);
        Inputpass(n);
        string temp="";
        for (int i = 0; i < inputpass.Length; i++)
            temp += "*";
        outputText.text =temp;
        ShuffleButton(shuffleNum);
        if (outputText.text.Length == 4)
            Checkpass();
    }


    public void ShufflePosition(Transform t)
    {
        Panel.transform.position = t.position;
    }
    #endregion

    #region Private Methods
    private void Checkpass()
    {
        Debug.Log(""+inputpass);
        if (inputpass.Equals(pass))
        {
            outputText.text = "OK";
            inputpass = "";
        }
            
        else
        {
            outputText.text = " Wrong password";
            inputpass = "";
            Panel.transform.position = new Vector3(0.0000f,0.0000f,0.0000f);
        }
           
    }
    private void Inputpass(TextMesh n)
    {
        inputpass = inputpass + n.text;
    }

    private void ShuffleButton(int n)
    {
        for (int i = 0; i < Buttons.childCount; i++)
        {
            Buttons.GetChild(i).GetChild(0).GetChild(1).GetComponent<TextMesh>().text=((i+n)%Buttons.childCount)+"";
        }
    }

    #endregion

}
