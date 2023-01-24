using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scroll : MonoBehaviour
{
    [SerializeField] GameObject[] viewers;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(viewers[0].transform.position);
        }
    }
}
