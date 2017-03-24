using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour
{
    //script that controls the animator and canvasgroup
    //makes all elements in the children of the canvas group non interactable/non clickable

    //instances
    private Animator theAnimator;
    private CanvasGroup theCanvasGroup;

    //for state transitions
    public bool AreYouOpen
    {
        get { return theAnimator.GetBool("AreYouOpen");  }
        set { theAnimator.SetBool("AreYouOpen", value);  }
    }

    //sets position of menu's in center of canvas(edit mode -> sits below)
    public void Awake()
    {
        theAnimator = GetComponent<Animator>();
        theCanvasGroup = GetComponent<CanvasGroup>();

        var theRectTransform = GetComponent<RectTransform>();
        theRectTransform.offsetMax = theRectTransform.offsetMin = new Vector2(0, 0);

    }

    //talks to the animation controller
    //if open allow interaction
    //if not disable interaction
    public void Update()
    {
        if(!theAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            theCanvasGroup.blocksRaycasts = theCanvasGroup.interactable = false;
        }
        else
        {
            theCanvasGroup.blocksRaycasts = theCanvasGroup.interactable = true;
        }

    }



	


}
