using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineModule : MonoBehaviour {

    //left
    [HideInInspector]
    public GameObject outerL;
    public GameObject innerL;
    public GameObject coreL;
    //right
    public GameObject outerR;
    public GameObject innerR;
    public GameObject coreR;
    //text module
    public Text textModule;



    private string[] speech = { "Engine","reading","is","loading","and","initializing", "at","0-800", "hours" };
    private int speechIterator;

   void Start()
    {
        speechIterator = 0;
        StartCoroutine(Initialize());
    }

	// Update is called once per frame
	void Update ()
    {
        //left module
        outerL.transform.Rotate(0, 0, 100 * Time.deltaTime, Space.Self);
        innerL.transform.Rotate(0, 0, -100 * Time.deltaTime, Space.Self);
        coreL.transform.Rotate(0, 0, 50 * Time.deltaTime, Space.Self);

        //right module
        outerR.transform.Rotate(0, 0, -75 * Time.deltaTime, Space.Self);
        innerR.transform.Rotate(0, 0, 120 * Time.deltaTime, Space.Self);
        coreR.transform.Rotate(0, 0, 15 * Time.deltaTime, Space.Self);
    }

    private void loadText()
    {
        for(int i = 0; i < 9; i++)
        {
            textModule.text = speech[0];
        }
    }


    //initialize the screen
    IEnumerator Initialize()
    {
        yield return new WaitForSeconds(15.0f);
        textModule.text += " " + speech[speechIterator];
        speechIterator += 1;

        for (int i = 0; i < 1000; i++)
        {
            if (speechIterator > 8)
                speechIterator = 0;
            //Debug.Log("Speech Iterator is " + speechIterator);

            yield return new WaitForSeconds(1.5f);
            textModule.text += " " + speech[speechIterator];
            speechIterator += 1;
        }
    }
}
