using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RightAlphaScript : MonoBehaviour
{

    public Text textModule;
    private string[] speech = { "Engine", "reading", "is", "loading", "and", "initializing", "at", "0-800", "hours" };
    private int speechIterator;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Initialize());
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator Initialize()
    {
        yield return new WaitForSeconds(2.5f);
        textModule.text += " " + speech[speechIterator];
        speechIterator += 1;

        for (int i = 0; i < 1000; i++)
        {
            if (speechIterator > 8)
                speechIterator = 0;
            //Debug.Log("Speech Iterator is " + speechIterator);

            yield return new WaitForSeconds(0.5f);
            textModule.text += " " + speech[speechIterator];
            speechIterator += 1;
        }
    }
}
