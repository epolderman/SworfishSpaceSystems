using UnityEngine;
using System.Collections;

public class LoadingModule : MonoBehaviour
{
    [HideInInspector]
    public GameObject outer;
    public GameObject outer1;
    public GameObject inner1;
    public GameObject inner;

	// Update is called once per frame
	void Update ()
    {
        outer.transform.Rotate(-15 * Time.deltaTime, -45 * Time.deltaTime, 100 * Time.deltaTime, Space.Self);
        outer1.transform.Rotate(0, 0, -100 * Time.deltaTime, Space.Self);
        inner1.transform.Rotate(-55 * Time.deltaTime, -35 * Time.deltaTime, 50 * Time.deltaTime, Space.Self);
        inner.transform.Rotate(-15 * Time.deltaTime, -65 * Time.deltaTime, -20 * Time.deltaTime, Space.Self);
    }
}
