using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class is for when the player arrived destination

Private Methods:
Start, OnCollisionEnter, OnCollisionStay, OnCollisionExit
*/
public class Arrived : MonoBehaviour
{
    public Material destinate_mat; // destination texture, used to change color
    public GameManager gm; // used to tell game manager if the ball is arrived
    private Color normal_color = new Color(1f, 0f, 0f, 0.5f); // red color
    private Color arrived_color = new Color(0f, 1f, 0f, 0.5f); // green color
    private float contact_timer; // it is a timer for how long does player stay at destination

    // initialize destination color to unarrived color (red)
    void Start()
    {
        this.destinate_mat.color = this.normal_color;
    }

    /* when the player collide with the destination cube, start timer */
    void OnCollisionEnter(Collision other)
    {
        this.destinate_mat.color = this.arrived_color;
        this.contact_timer = Time.time;
    }

    /*
    When the player is staying on the destination, keep checking timer, 
    when the timer > 1, win
    */
    private void OnCollisionStay(Collision other) {
        if (Time.time - this.contact_timer > 1) {
            this.gm.is_win = true;
        }
    }

    /* When the player leaves desination, reset timer to -1 */
    void OnCollisionExit(Collision other)
    {
        this.contact_timer = -1f;
        this.destinate_mat.color = this.normal_color;
    }
}
