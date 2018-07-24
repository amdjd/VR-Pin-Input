using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    #region Public Variables
    [Header("Essentials")]
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    #endregion

    #region Private Variables
    private string pass = "1234";
    private string InputPass ="";
    private static int[] num = new int[4];
    #endregion

    private void Start()
    {
        int[] shuffleNum = new int[4];

        System.Random r = new System.Random();
        for (int i = 0; i < 4; i++)
        {
            shuffleNum[i] = r.Next(1, 9);
        }
        Panel1.transform.rotation = Quaternion.Euler(0, shuffleNum[0] * 36, 0);
        Panel2.transform.rotation = Quaternion.Euler(0, shuffleNum[1] * 36, 0);
        Panel3.transform.rotation = Quaternion.Euler(0, shuffleNum[2] * 36, 0);
        Panel4.transform.rotation = Quaternion.Euler(0, shuffleNum[3] * 36, 0);
    }
    #region Public Methods
    public void Unlock()
    {
        SetNum();
        if (Check()) {
            GetComponent<Leap.Unity.Interaction.InteractionSlider>().enabled = false;
            Debug.Log("ok");
        }
        
            //Debug.Log("no");
    }
    #endregion

    #region Private Methods
    private void SetNum()
    {
        num[0] = 10 - (int)Panel1.transform.localRotation.eulerAngles.y / 36;
        num[1] = 10 - (int)Panel2.transform.localRotation.eulerAngles.y / 36;
        num[2] = 10 - (int)Panel3.transform.localRotation.eulerAngles.y / 36;
        num[3] = 10 - (int)Panel4.transform.localRotation.eulerAngles.y / 36;
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i] == 10)
                num[i] = 0;
        }
        InputPass = ""+num[0]+ num[1]+ num[2]+ num[3];
        Debug.Log(InputPass);
    }
    private bool Check()
    {
        if (pass.Equals(InputPass))
        {
            return true;
        }
        else
           return false;
    }
    #endregion
}
