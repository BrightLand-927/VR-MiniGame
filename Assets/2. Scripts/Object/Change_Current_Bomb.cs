using System.Collections;
using UnityEngine;
using Valve.VR;

using Valve.VR.Extras;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Change_Current_Bomb : MonoBehaviour
{
    public GameObject[] BombPrefab;
    public Rigidbody attachPoint;

    public AudioSource buff;
    public AudioSource deBuff;

    GameObject currentBomb;

    // Snap Trigger Button
    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

    // Snap Turn Left And Right.
    public SteamVR_Action_Boolean snapLeftAction = SteamVR_Input.GetBooleanAction("SnapTurnLeft");
    public SteamVR_Action_Boolean snapRightAction = SteamVR_Input.GetBooleanAction("SnapTurnRight");

    // Add Actions.
    SteamVR_Behaviour_Pose trackedObj;
    FixedJoint joint;

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void FixedUpdate()
    {
        if (joint == null && spawn.GetStateDown(trackedObj.inputSource))
        {
            currentBomb = Instantiate(BombPrefab[GetRandomN(0, BombPrefab.Length)]) as GameObject;
            currentBomb.transform.position = attachPoint.transform.position;

            joint = currentBomb.AddComponent<FixedJoint>();
            joint.connectedBody = attachPoint;
        }
        else if (joint != null && spawn.GetStateUp(trackedObj.inputSource))
        {
            GameObject go = joint.gameObject;
            Rigidbody rigidbody = go.GetComponent<Rigidbody>();
            Object.DestroyImmediate(joint);
            joint = null;
            Object.Destroy(go, 15.0f);


            Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
            if(origin != null)
            {
                rigidbody.velocity = origin.TransformVector(trackedObj.GetVelocity());
                rigidbody.angularVelocity = origin.TransformVector(trackedObj.GetAngularVelocity());
            }
            else
            {
                rigidbody.velocity = trackedObj.GetVelocity();
                rigidbody.angularVelocity = trackedObj.GetAngularVelocity();
            }

            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
        }




        if(joint != null)
        {
            if (snapLeftAction.GetStateDown(SteamVR_Input_Sources.Any))
            {
                Destroy(currentBomb);
                buff.Play();
                bombIndex--;
                if (bombIndex < 0)
                    bombIndex = BombPrefab.Length - 1;

                currentBomb = Instantiate(BombPrefab[bombIndex]) as GameObject;
                currentBomb.transform.position = attachPoint.transform.position;

                joint = currentBomb.AddComponent<FixedJoint>();
                joint.connectedBody = attachPoint;

                Debug.Log("Snap Left");
            }
            else if (snapRightAction.GetStateDown(SteamVR_Input_Sources.Any))
            {
                Destroy(currentBomb);
                deBuff.Play();
                bombIndex++;
                if (bombIndex >= BombPrefab.Length)
                    bombIndex = 0;

                currentBomb = Instantiate(BombPrefab[bombIndex]) as GameObject;
                currentBomb.transform.position = attachPoint.transform.position;

                joint = currentBomb.AddComponent<FixedJoint>();
                joint.connectedBody = attachPoint;

                Debug.Log("Snap Right");
            }
        }
    }


    int bombIndex;
    int GetRandomN(int min, int max)
    {
        bombIndex = Random.Range(min, max);
        return bombIndex;
    }
}