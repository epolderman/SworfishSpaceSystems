using UnityEngine;
using System.Collections;

public class SystemManager : MonoBehaviour {

    //invokes a valid menu via the button from the inspector

    //instances
    public MenuSystem theCurrentMenu;
    private string menuName;
    public string MenuName
    {
        get {return menuName;}
    }

	// Use this for initialization
	public void Start ()
    {
        DisplayMenu(theCurrentMenu);
	}

    //display the menu that is open via the button from the inspector
    public void DisplayMenu(MenuSystem Menu)
    {
        if (theCurrentMenu != null)
        theCurrentMenu.AreYouOpen = false;

        theCurrentMenu = Menu;
        theCurrentMenu.AreYouOpen = true;

        menuName = theCurrentMenu.gameObject.transform.name;
    }
	
}
