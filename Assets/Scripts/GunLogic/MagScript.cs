using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Yes!");
    }

}
