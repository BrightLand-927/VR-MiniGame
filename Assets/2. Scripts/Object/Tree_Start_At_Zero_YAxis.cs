using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Start_At_Zero_YAxis : MonoBehaviour
{
    private void OnEnable()
    {
        this.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer.Equals(8))
        {
            //Debug.Log("On Floor");
            StartCoroutine(Increase());
        }
    }

    IEnumerator Increase()
    {
        float duration = 0f;

        this.transform.localRotation = Quaternion.Euler(Vector3.zero);
        this.transform.localPosition = new Vector3(transform.localPosition.x, -.5f, transform.localPosition.z);

        while(IsReach())
        {
            duration += .3f;

            this.transform.localScale += new Vector3(0.01f * duration, 0.01f * duration, 0.01f * duration);

            yield return null;
        }

        var r = this.GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.FreezeAll;
        r.useGravity = false;


        yield break;

        bool IsReach()
        {
            if (this.transform.localScale.y <= 1.0f) return true;
            else return false;
        }
    }
}
