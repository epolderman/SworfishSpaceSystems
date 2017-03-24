using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitanLogic : MonoBehaviour
{
    [HideInInspector]
    public MovieTexture top;
    public MovieTexture bottom;
    public MovieTexture middleLeft;
    public MovieTexture middleRight;

    [HideInInspector]
    public GameObject rawTop;
    public GameObject rawBottom;
    public GameObject rawMiddleLeft;
    public GameObject rawMiddleRight;

    [HideInInspector]
    public GameObject titanMenu;
    public GameObject consoleModule;
    
   
    void Start()
    {
        titanMenu.GetComponent<AudioSource>().Play();

        rawTop.GetComponent<RawImage>().color = Color.black;
        rawBottom.GetComponent<RawImage>().color = Color.black;

        top.Play();
        top.loop = true;

        bottom.Play();
        bottom.loop = true;

        middleLeft.Play();
        middleLeft.loop = true;

        middleRight.Play();
        middleRight.loop = true;

        StartCoroutine(Initialize());
    }
    void Update()
    {
        
        if (consoleModule.GetComponent<CanvasGroup>().alpha == 1.0 &&
            consoleModule.GetComponent<AudioSource>().isPlaying == false &&
             titanMenu.GetComponent<AudioSource>().isPlaying == true)
        {
            consoleModule.GetComponent<AudioSource>().Play();
        }
       
    }

    //initialize the screen
    IEnumerator Initialize()
    {
        yield return new WaitForSeconds(2.0f);
        rawMiddleLeft.GetComponent<RawImage>().texture = middleLeft as MovieTexture;

        yield return new WaitForSeconds(2.0f);
        rawMiddleRight.GetComponent<RawImage>().texture = middleRight as MovieTexture;

        yield return new WaitForSeconds(.6f);
        rawTop.GetComponent<RawImage>().color = Color.white;

        yield return new WaitForSeconds(.6f);
        rawBottom.GetComponent<RawImage>().color = Color.white;
    }
}
