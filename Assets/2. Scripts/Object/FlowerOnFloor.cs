using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerOnFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(8))
        {
            this.transform.localRotation = Quaternion.Euler(Vector3.zero);
            Debug.Log("On Floor");
        }
    }
}
