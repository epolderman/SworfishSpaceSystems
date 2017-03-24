using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpineModule : MonoBehaviour
{
    [HideInInspector]
    public GameObject spines;
    public GameObject spinesRight;
    public GameObject hudButton;
    public Button hudButt;

    private string[] speech = { "MODULE-X65", "MODULE-X84a-Z", "MODULE-X840A", "MODULE-X84a", "MODULE-X84", "PLASMA-X01z", "MODULE-X01z", "MODULE-X01", "MODULE-345i" };
    List<Color> theColorList;
    private int speechIterator;

    void Start()
    {
        theColorList = new List<Color>();
        theColorList.Add(Color.red);
        theColorList.Add(Color.green);
        theColorList.Add(Color.blue);
        theColorList.Add(Color.magenta);
        theColorList.Add(Color.yellow);
        theColorList.Add(Color.blue);
        theColorList.Add(Color.red);
        theColorList.Add(Color.green);
        theColorList.Add(Color.magenta);
        speechIterator = 0;
        StartCoroutine(Initialize());
    }

	void Update ()
    {
        spines.transform.Rotate(0, 0, 100 * Time.deltaTime, Space.Self);
        spinesRight.transform.Rotate(0, 0, -100 * Time.deltaTime, Space.Self);
        //hudButton.transform.Rotate(40 * Time.deltaTime, 0, 0, Space.Self);
    }
    //initialize the button
    IEnumerator Initialize()
    {
        

        for (int i = 0; i < 1000; i++)
        {
            //Debug.Log("Speech Iterator is " + speechIterator);

            if (speechIterator > 8)
                speechIterator = 0;

           
            yield return new WaitForSeconds(4.0f);
            hudButt.GetComponentInChildren<Text>().text = speech[speechIterator] + "...";
            hudButt.GetComponentInChildren<Text>().color = theColorList[speechIterator];
            speechIterator++;

        }
    }
}
