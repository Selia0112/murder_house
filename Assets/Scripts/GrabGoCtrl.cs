using Pvr_UnitySDKAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGoCtrl : MonoBehaviour
{
    Pvr_ControllerModuleInit conmodinit;
    Rigidbody ri;
    FixedJoint joint;
    void Start()
    {
        conmodinit = this.transform.parent.GetComponent<Pvr_ControllerModuleInit>();
    }

    private void Update()
    {
        //按下Y和B键放下物体
        if (/*Controller.UPvr_GetKeyDown(0, Pvr_KeyCode.Y) || */Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.B))
        {
            joint = GetComponent<FixedJoint>();
            Destroy(joint);
        }
    }

    void OnTriggerStay(Collider collider)
    {

        //扣下扳机拾取物体
        if (/*Controller.UPvr_GetKeyDown(0, Pvr_KeyCode.TRIGGER) ||*/
            Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.TRIGGER))
        {          
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collider.GetComponent<Rigidbody>();
        }

    }

}
