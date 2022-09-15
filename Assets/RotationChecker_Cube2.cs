using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChecker_Cube2 : MonoBehaviour
{
    public GameObject cube;
    public GameObject car1Light1;
    public GameObject car1Light2;
    public GameObject car2Light1;
    public GameObject car2Light2;
    public GameObject sunLight;
    double x;
    double z;
    Vector3 rotation;
    bool normalLight = true;
    bool upsideDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation.eulerAngles;
        car1Light1.GetComponent<Light>().enabled = false;
        car1Light2.GetComponent<Light>().enabled = false;
        car2Light1.GetComponent<Light>().enabled = false;
        car2Light2.GetComponent<Light>().enabled = false;
        sunLight.GetComponent<Light>().enabled = true;
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
                    sunLight.GetComponent<Light>().enabled = false;
                    car1Light1.GetComponent<Light>().enabled = true;
                    car1Light2.GetComponent<Light>().enabled = true;
                    car2Light1.GetComponent<Light>().enabled = true;
                    car2Light2.GetComponent<Light>().enabled = true;
                } else {
                    normalLight = true;
                    sunLight.GetComponent<Light>().enabled = true;
                    car1Light1.GetComponent<Light>().enabled = false;
                    car1Light2.GetComponent<Light>().enabled = false;
                    car2Light1.GetComponent<Light>().enabled = false;
                    car2Light2.GetComponent<Light>().enabled = false;
                }
            }
        }
    }
}
