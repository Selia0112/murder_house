using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum DoorType
{
    DungeonDoor,
    BasementDoor,
    BedroomDoor,
    Gate
}

public class OpenDoorCtrl : MonoBehaviour
{
    public Vector3 OpenDoorAngle;
    public DoorType doorType;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RHand"))
        {
            if (doorType==DoorType.DungeonDoor&&GameManager.Instance.DungeonKey)
            {              
                GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Audios/开门声"));
                transform.DOLocalRotate(OpenDoorAngle, 2).OnComplete(() =>
                {
                   
                });
            }
            else if (doorType == DoorType.BasementDoor && GameManager.Instance.BasementKey)
            {             
                GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Audios/开门声"));
                transform.DOLocalRotate(OpenDoorAngle, 2).OnComplete(() =>
                {

                });
            }
            else if (doorType == DoorType.BedroomDoor && GameManager.Instance.BedroomKey)
            {
                GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Audios/开门声"));
                transform.DOLocalRotate(OpenDoorAngle, 2).OnComplete(() =>
                {

                });
            }
            else if (doorType == DoorType.Gate && GameManager.Instance.GateKey)
            {
                GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Audios/开门声"));
                transform.DOLocalRotate(OpenDoorAngle, 2).OnComplete(() =>
                {

                });
            }
            else
            {
                GameManager.Instance.ShowOpenDoorErrorRemain();
            }           
        }
    }
}
