using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CycleInput : MonoBehaviour {

    #region Public Variables
    [Header("Essentials")]
    public Transform Panel1;
    public Transform Panel2;
    public Transform Panel3;
    public Transform Panel4;
    public Transform hand;
    public Text text;
    #endregion
    #region Private Variables
    private Quaternion setangle;
    int Click1, Click2, Click3, Click4, flexEnter;
    float TmepAngle1, TmepAngle2, TmepAngle3, TmepAngle4 = 0;
    float PanelAngle1, PanelAngle2, PanelAngle3, PanelAngle4;
    int pass1, pass2, pass3, pass4;
    string inputpass = "";
    string pass = "1234";
    #endregion

    // Use this for initialization
    void Start () {
        ShufflePanel();
    }
	
	// Update is called once per frame
	void Update () {
        pass1 = (int)(Panel1.transform.rotation.eulerAngles.z + 18)/36;
        pass2 = (int)(Panel2.transform.rotation.eulerAngles.z + 18) / 36;
        pass3 = (int)(Panel3.transform.rotation.eulerAngles.z + 18) / 36;
        pass4 = (int)(Panel4.transform.rotation.eulerAngles.z + 18) / 36;
        if (pass1 == 10) pass1 = 0;
        if (pass2 == 10) pass2 = 0;
        if (pass3 == 10) pass3 = 0;
        if (pass4 == 10) pass4 = 0;
        inputpass = "" + pass1 + "" + pass2 + "" + pass3 + "" + pass4;
        Debug.Log(inputpass);

        if ((hand.GetComponent<degree>().GetFlexEnter()))
        {
            Checkpass();
        }

        if (!(hand.GetComponent<degree>().GetFlexState1()))
        {
            TmepAngle1 = hand.transform.rotation.eulerAngles.z;
            PanelAngle1 = Panel1.transform.rotation.eulerAngles.z;
            Click1 = 1;

        }
        if (Click1 == 1)
        {
            //text.text = " ";
            Panel1.transform.rotation = Quaternion.Euler(0, 0, PanelAngle1 + TmepAngle1 - hand.transform.rotation.eulerAngles.z);
        }

        if (!(hand.GetComponent<degree>().GetFlexState2()))
        {
            TmepAngle2 = hand.transform.rotation.eulerAngles.z;
            PanelAngle2 = Panel2.transform.rotation.eulerAngles.z;
            Click2 = 1;
        }
        if (Click2 == 1)
        {
            //text.text = " ";
            Panel2.transform.rotation = Quaternion.Euler(0, 0, PanelAngle2 + TmepAngle2 - hand.transform.rotation.eulerAngles.z);
        }

        if (!(hand.GetComponent<degree>().GetFlexState3()))
        {
            TmepAngle3 = hand.transform.rotation.eulerAngles.z;
            PanelAngle3 = Panel3.transform.rotation.eulerAngles.z;
            Click3 = 1;
        }
        if (Click3 == 1)
        {
            //text.text = " ";
            Panel3.transform.rotation = Quaternion.Euler(0, 0, PanelAngle3 + TmepAngle3 - hand.transform.rotation.eulerAngles.z);
        }

        if (!(hand.GetComponent<degree>().GetFlexState4()))
        {
            TmepAngle4 = hand.transform.rotation.eulerAngles.z;
            PanelAngle4 = Panel4.transform.rotation.eulerAngles.z;
            Click4 = 1;
        }
        if (Click4 == 1)
        {
            //text.text = " ";
            Panel4.transform.rotation = Quaternion.Euler(0, 0, PanelAngle4 + TmepAngle4 - hand.transform.rotation.eulerAngles.z);
        }

    }
    #region Public Methods

    #endregion

    #region Private Methods
    private void ShufflePanel()
    {
        int[] shuffleNum = new int[4];

        System.Random r = new System.Random();
        for (int i = 0; i < 4; i++)
        {
            shuffleNum[i] = r.Next(1, Panel1.childCount - 1);
        }

        Panel1.transform.rotation = Quaternion.Euler(0, 0, shuffleNum[0] * 36);
        Panel2.transform.rotation = Quaternion.Euler(0, 0, shuffleNum[1] * 36);
        Panel3.transform.rotation = Quaternion.Euler(0, 0, shuffleNum[2] * 36);
        Panel4.transform.rotation = Quaternion.Euler(0, 0, shuffleNum[3] * 36);
    }

    private void Turn(Transform Panel, Quaternion angle)
    {
        Panel.transform.rotation = angle;
    }


    private void Checkpass()
    {
        if (inputpass.Equals(pass))
        {
            text.text = "OK";
        }


    }
    #endregion
}
