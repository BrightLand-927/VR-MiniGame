using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp_One_ : MonoBehaviour
{


    private void OnEnable()
    {
        this.transform.localPosition = new Vector3(transform.localPosition.x, -1.5f, transform.localPosition.z);
        this.transform.localRotation = Quaternion.Euler(Vector3.zero);

        int i = this.transform.childCount;
        int j = Random.Range(0, i);
        
        this.transform.GetChild(j).gameObject.SetActive(true);
    }

}
