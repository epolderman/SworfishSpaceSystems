using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class InterfaceLogic : MonoBehaviour
{

    //*all menu, UI art provided by @amandasaenz*/

    //Interface Manager and Logic Script
    //Controls the loading & sorting of cards, user validation

    //unity objects
    [HideInInspector]
    public Button loginClick;
    [HideInInspector]
    public GameObject CardOne, CardTwo, CardThree, CardFour, CardFive;
    [HideInInspector]
    public InputField loginInputName;
    [HideInInspector]
    public Image cardoneImage, cardtwoImage, cardthreeImage, cardfourImage, cardfiveImage;
    [HideInInspector]
    public Text ValidationText;
    [HideInInspector]
    public GameObject CardMenu;

    private GameObject SystemManager;
    private SystemManager SystemManagerScript;    

    //suits
    public enum Suit
    {
        Heart, //0
        Diamond, //1
        Club, //2
        Spade //3
    }

    //card values (ace being the highest..and so on)
    public enum CardValue
    {
        Ace,
        King,
        Queen,
        Jack,
        Nine
    }

    //cards
    private struct Card
    {
        //sprite string path
        public string path;
        //what suit
        public Suit theSuits;
        //value in each suit
        public CardValue theValue;
        
        public Card(string p, Suit su, CardValue tv)
        {
            path = p;
            theSuits = su;
            theValue = tv;
        }

    }

    //placement objects
    private struct PlacementObject
    {
        //are you sorted?
        public bool isSorted;
        //card placement on canvas via Gameobject
        public GameObject Placement;
        //what card is being displayed (image)
        public Image Display;
        //gameObject placement value (cardOne = 5 last in the sorted list)
        public int Value;
        //what card is placed on the placementObject?
        public Card theCard;

        public PlacementObject(bool r, GameObject go, Image i, int v, Card c)
        {
            isSorted = r;
            Placement = go;
            Display = i;
            Value = v;
            theCard = c;
        }
    }

    //data structures
    private List<PlacementObject> thePlacements;
    private HashSet<PlacementObject> theHashset;
    
    // Use this for initialization
    void Start ()
    {
        //determining what menu is active(find that script)
        SystemManager = GameObject.Find("Canvas");
        SystemManagerScript = SystemManager.GetComponent<SystemManager>();

        //loads the data structures
        loadData();

        //set validation text to false so it disappears
        ValidationText.gameObject.SetActive(false);

      
    }
	// Update is called once per frame
	void Update ()
    {
        //am i on the card menu? and is the placementObjects sorted values set to true? if not keep calling...
        if (SystemManagerScript.MenuName == "CardMenu" && thePlacements.All(x => x.isSorted) == false)
        {
            CheckHandArea();
        }
      
    }
    //create placementObjects and cards to add to list
    private void loadData()
    {
        theHashset = new HashSet<PlacementObject>();
        thePlacements = new System.Collections.Generic.List<PlacementObject>();
        //card placement one
        thePlacements.Add(new PlacementObject(false, CardOne, cardoneImage, 4, new Card("Art/Cards/kingHearts", Suit.Heart, CardValue.King)));
        //card placement two
        thePlacements.Add(new PlacementObject(false, CardTwo, cardtwoImage, 3, new Card("Art/Cards/jackSpade", Suit.Spade, CardValue.Jack)));
        //card placement three
        thePlacements.Add(new PlacementObject(false, CardThree, cardthreeImage, 2, new Card("Art/Cards/aceSpade", Suit.Spade, CardValue.Ace)));
        //card placement four
        thePlacements.Add(new PlacementObject(false, CardFour, cardfourImage, 1, new Card("Art/Cards/nineDiamond", Suit.Diamond, CardValue.Nine)));
        //card placement five
        thePlacements.Add(new PlacementObject(false, CardFive, cardfiveImage, 0, new Card("Art/Cards/queenDiamond", Suit.Diamond, CardValue.Queen)));

        //load the sprites to display onto the gameobjects
        loadImages(thePlacements);

    }
    //grabs the path from the card and sets the image to the gameobject
    private void loadImages(List<PlacementObject> listReadytoDisplay)
    {
        Sprite tempSprite = new Sprite();

        for (int i = 0; i < listReadytoDisplay.Count; i++)
        {
            tempSprite = Resources.Load<Sprite>(listReadytoDisplay[i].theCard.path);
            listReadytoDisplay[i].Display.GetComponentInChildren<Image>().sprite = tempSprite;
        }

    }
    //check the rect transform of the gameObjects simulating card placements in the "hand" area
    //*if the list(data structure size) was any bigger than a handful of items i would have approached this algorithm very differently*
    private void CheckHandArea()
    {
              
        for(int i = 0; i < thePlacements.Count; i++)
        {
            //have you reached the hand area? 
            if(thePlacements[i].Placement.GetComponent<RectTransform>().offsetMax.y == 350)
            {
                //add to hashet (dont add duplicates)
                theHashset.Add(thePlacements[i]);
                
            }
        }

        //make list from the hashset
        var theList = theHashset.ToList();

        //sort new list according to suit -> card value
        var thesortedList = theList.OrderBy(x => x.theCard.theSuits).ThenBy(x => x.theCard.theValue).ToList();

        //sort the placement(gameobjects as they enter the hand area) of cards from least to greatest
        theList = theList.OrderBy(x => x.Value).ToList();

        //actively sort as each card enters the hand area and diplay
        ActiveSort(theList, thesortedList);

        if(thesortedList.Count == 5)
        {
            //sync the final sorted card list into the Placement list on the last iteration of the function
            for(var i = 0; i < thePlacements.Count; i++)
            {
                thePlacements[i] = new PlacementObject(true, thePlacements[i].Placement,
                                                      thePlacements[i].Display, thePlacements[i].Value,
                                                      thesortedList[i].theCard);
            }

        }

    }
    //display the correct image 
    private void ActiveSort(List<PlacementObject> placeValueSorted, List<PlacementObject> cardValueSorted)
    {
        Sprite tempSprite = new Sprite();

        for (int i = 0; i < placeValueSorted.Count; i++)
        {
            tempSprite = Resources.Load<Sprite>(cardValueSorted[i].theCard.path);
            placeValueSorted[i].Display.GetComponentInChildren<Image>().sprite = tempSprite;
                    
        }
      

    }
    //check that user entered a name to allow or not allow transition
    public void CheckUsername()
    {    
        if(loginInputName.text == string.Empty)
        {
            ValidationText.gameObject.SetActive(true);
        }
        else
        {
            SystemManagerScript.DisplayMenu(CardMenu.GetComponent<MenuSystem>());
            ValidationText.gameObject.SetActive(false);
           
        }


    }
  
    
  
}

