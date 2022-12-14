using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItemProperty : MonoBehaviour
{
    [SerializeField] Transform PointRotate;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PointRotate.rotation.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
