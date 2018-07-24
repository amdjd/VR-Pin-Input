using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButtonInputManagerBasic : MonoBehaviour {

    #region Public Variables
    [Header("Essentials")]
    public TextMesh outputText;
    public GameObject Buttons;
    #endregion

    #region Private Variables
    private System.String pass = "2735";
    private System.String inputpass = "";
    #endregion

    #region Public Methods
    public void ButtonInput_Num(TextMesh n)
    {
        Inputpass(n);
        string temp = "";
        for (int i = 0; i < inputpass.Length; i++)
            temp += "*";

        outputText.text = temp;

    }
    public void ButtonInput_Back()
    {
        inputpass = inputpass.Substring(0, inputpass.Length - 1);
        
        string temp = "";
        for (int i = 0; i < inputpass.Length; i++)
            temp += "*";

        outputText.text = temp;
    }
    public void ButtonInput_Enter(int n)
    {
        Checkpass();
    }
    #endregion

    #region Private Methods
    private void Inputpass(TextMesh n)
    {
        inputpass = inputpass + n.text;
    }

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
        }

    }
    #endregion

}
