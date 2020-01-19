using UnityEngine;

/*
This class controls all player behaviors, including move control, speed control

Private_methods:
Start, FixedUpdate, actionW, actionS, actionA, actionD, actionJump, OnCollisionStay

Public_methods:
resetForce
*/
public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb; // rigidbody of player
    public Vector3 forceVector; // how much force applied to player when moving
    private ForceMode fm = ForceMode.VelocityChange; // force mode
    public bool is_jumping; // true if press space, false when collide

    void Start()
    {
        this.resetForce(6);
    }

    /* 
    Every frame try to get user input, and move to a direction or jump
    according to the user input
    */
    void FixedUpdate()
    {
        // get user input (WASD or direction arrows), note that the player
        // is able to hold these keys to add continues force.
        if (Input.anyKey) {
            Vector3 realForce = this.forceVector * Time.deltaTime;
            if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow)) {
                this.actionW(realForce);
            }
            if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow)) {
                this.actionS(realForce);
            }
            if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) {
                this.actionA(realForce);
            }
            if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) {
                this.actionD(realForce);
            }
        }

        // when space is pressed, the player jumps, but u cannot hold the key
        if (Input.GetKeyDown(KeyCode.Space) & !this.is_jumping) {
            this.is_jumping = true;
            Vector3 realForce = this.forceVector * Time.deltaTime;
            this.actionJump(realForce);
        }
    }

    /*
    Reset all forces applied to player, this is used when sensitivity is changed
    in setting UI, or maybe changed by some object behaviors
    */
    public void resetForce(float new_force) {
        this.forceVector = new Vector3(new_force, new_force, new_force);
    }

    /* Move further */
    private void actionW(Vector3 rf) {
        Vector3 norm = new Vector3(0f, 0f, 1f);
        this.rb.AddForce(Vector3.Scale(rf, norm), this.fm);
    }

    /* Move closer */
    private void actionS(Vector3 rf) {
        Vector3 norm = new Vector3(0f, 0f, -1f);
        this.rb.AddForce(Vector3.Scale(rf, norm), this.fm);
    }

    /* Move to the left */
    private void actionA(Vector3 rf) {
        Vector3 norm = new Vector3(-1f, 0f, 0f);
        this.rb.AddForce(Vector3.Scale(rf, norm), this.fm);
    }
    
    /* Move to the right */
    private void actionD(Vector3 rf) {
        Vector3 norm = new Vector3(1f, 0f, 0f);
        this.rb.AddForce(Vector3.Scale(rf, norm), this.fm);
    }

    /* apply an upward force, make the player jump */
    private void actionJump(Vector3 rf) {
        Vector3 norm = new Vector3(0f, 35f, 0f);
        this.rb.AddForce(Vector3.Scale(rf, norm), this.fm);
    }

    /* When the player stay collide with another object, it is not jumping */
    void OnCollisionStay(Collision other)
    {
        this.is_jumping = false;
    }

}
