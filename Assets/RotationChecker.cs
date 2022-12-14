using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChecker : MonoBehaviour
{
    public GameObject cube;
    public GameObject fireLight;
    public GameObject boatLight;
    double x;
    double z;
    Vector3 rotation;
    bool normalLight = true;
    bool upsideDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation.eulerAngles;
        fireLight.GetComponent<Light>().enabled = true;
        boatLight.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotation = transform.rotation.eulerAngles;
        if (((Mathf.Abs(rotation.x) > 150 && (Mathf.Abs(rotation.x) < 200))) || ((Mathf.Abs(rotation.z) > 150 && (Mathf.Abs(rotation.z) < 200)))) {
            upsideDown = true;
        } else {
            if (upsideDown == true) {
                upsideDown = false;

                if (normalLight == true) {
                    normalLight = false;
                    fireLight.GetComponent<Light>().enabled = false;
                    boatLight.GetComponent<Light>().enabled = true;
                } else {
                    normalLight = true;
                    fireLight.GetComponent<Light>().enabled = true;
                    boatLight.GetComponent<Light>().enabled = false;
                }
            }
        }
    }
}
