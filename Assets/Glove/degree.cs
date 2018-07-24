using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class degree : MonoBehaviour
{
    #region Public Variables
    [Header("Essentials")]
    public Transform Panel;
    #endregion
    SerialPort sp = new SerialPort("COM3", 9600);  //set Serial port
    Quaternion setQ = new Quaternion();
    Quaternion newQ = new Quaternion();
    Vector3 dir = Vector3.zero;
    int flexVal1, flexVal2, flexVal3, flexVal4, flexVal5;

    bool flexVal1_down = false;
    bool flexVal1_temp = false;
    bool flexVal2_down = false;
    bool flexVal2_temp = false;
    bool flexVal3_down = false;
    bool flexVal3_temp = false;
    bool flexVal4_down = false;
    bool flexVal4_temp = false;
    bool flexenter_down = false;
    bool flexenter_temp = false;
    // Use this for initialization
    private void Awake()
    {
        sp.Open();  //Serial port open
        sp.ReadTimeout = 1;  //set Serial timeout

    }
    void Start()
    {

        string[] parsed = sp.ReadLine().Split();
        setQ.w = float.Parse(parsed[1],
         System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        setQ.x = float.Parse(parsed[2],
         System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        setQ.y = float.Parse(parsed[3],
            System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        setQ.z = float.Parse(parsed[4],
            System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        setQ = Quaternion.Inverse(setQ);
        setQ = Quaternion.Euler(0, setQ.eulerAngles.z, 0);
        Panel.transform.rotation = setQ;


    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                string[] parsed = sp.ReadLine().Split();
                newQ.w = float.Parse(parsed[1],
                 System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                newQ.x = -float.Parse(parsed[2],
                 System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                newQ.z = float.Parse(parsed[3],
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                newQ.y = float.Parse(parsed[4],
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                flexVal1 = int.Parse(parsed[5],
                 System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                flexVal2 = int.Parse(parsed[6],
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                flexVal3 = int.Parse(parsed[7],
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                flexVal4 = int.Parse(parsed[8],
                 System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                //flexVal5 = int.Parse(parsed[9],
                //   System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                newQ = Quaternion.Inverse(newQ);
                //newQ = Quaternion.Euler(-newQ.eulerAngles.x, newQ.eulerAngles.z , newQ.eulerAngles.y);
                transform.rotation = newQ; ;

                FlexState(flexVal1, flexVal2, flexVal3, flexVal4);
                //Debug.Log(flexVal1 + "   " + flexVal2 + "   " + flexVal3 + "   " + flexVal4);
                //Debug.Log(flexVal1_down + "  " + flexVal2_down + "  " + flexVal3_down + "  " + flexVal4_down + "  ");
                
            }
            catch (System.Exception) { }
        }
    }
    #region Public Methods
    public bool GetFlexEnter()
    {
        return flexenter_down;
    }
    public bool GetFlexState1()
    {
        return flexVal1_down;
    }
    public bool GetFlexState2()
    {
        return flexVal2_down;
    }
    public bool GetFlexState3()
    {
        return flexVal3_down;
    }
    public bool GetFlexState4()
    {
        return flexVal4_down;
    }
    #endregion

    #region Private Methods
    void FlexState(int flexVal1, int flexVal2, int flexVal3, int flexVal4)
    {
        if (flexVal1 > 55) flexVal1_down = true;
        else flexVal1_down = false;

        if (flexVal1 < 0) flexenter_down = true;
        else flexenter_down = false;

        if (flexVal2 > 55) flexVal2_down = true;
        else flexVal2_down = false;

        if (flexVal3 > 80) flexVal3_down = true;
        else flexVal3_down = false;

        if (flexVal4 > 60) flexVal4_down = true;
        else flexVal4_down = false;

        if (flexVal1_down && !flexVal1_temp) flexVal1_temp = true;
        else if (!flexVal1_down && flexVal1_temp) flexVal1_temp = false;

        if (flexVal2_down && !flexVal2_temp) flexVal2_temp = true;
        else if (!flexVal2_down && flexVal2_temp) flexVal2_temp = false;

        if (flexVal3_down && !flexVal3_temp) flexVal3_temp = true;
        else if (!flexVal3_down && flexVal3_temp) flexVal3_temp = false;

        if (flexVal4_down && !flexVal4_temp) flexVal4_temp = true;
        else if (!flexVal4_down && flexVal4_temp) flexVal4_temp = false;



    }
    #endregion
}