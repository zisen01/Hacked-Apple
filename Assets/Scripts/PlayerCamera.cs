using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class controls player camera, it allows camera to follow the player
*/
public class PlayerCamera : MonoBehaviour
{
    public Transform camera_trans; // main camera transform
    public Transform player_trans; // player transform
    private Vector3 pos_offset = new Vector3(0f, 3.5f, -6.5f); // the offset of camera position

    /* Every frame, update camera position,
    camera pos = player pos + pos offset
    */
    void Update()
    {
        this.camera_trans.position = this.player_trans.position + this.pos_offset;
    }
}
