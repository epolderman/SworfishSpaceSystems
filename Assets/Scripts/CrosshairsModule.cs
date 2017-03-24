using UnityEngine;
using System.Collections;

public class CrosshairsModule : MonoBehaviour {

    [HideInInspector]
    public GameObject spines;
    public GameObject crosshairs;
    public GameObject halfinner;

	// Update is called once per frame
	void Update ()
    {
        spines.transform.Rotate(-15 * Time.deltaTime, -45 * Time.deltaTime, 100 * Time.deltaTime, Space.Self);
        crosshairs.transform.Rotate(0, 0, -100 * Time.deltaTime, Space.Self);
        halfinner.transform.Rotate(-55 * Time.deltaTime, -35 * Time.deltaTime, 0, Space.Self);
    }
}
