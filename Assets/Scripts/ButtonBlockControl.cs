using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBlockControl : MonoBehaviour
{
    public Material button_mat;
    public GameManager gm; // used to tell game manager if the ball is arrived
    public GameObject block;
    public Vector3 block_destination;
    private Color normal_color = new Color(0f, 0f, 1f, 1); // blue color
    private Color arrived_color = new Color(1f, 1f, 1f, 1f); // white color
    private bool move = false;
    

    // set color to normal on start
    void Start()
    {
        this.button_mat.color = this.normal_color;
        

        
    }

    // on collision, change color, and move the block to designated place
    void OnCollisionEnter(Collision other)
    {
        this.button_mat.color = this.arrived_color;
        this.move = true;
        // while (System.Math.Abs(block.transform.position.y) < System.Math.Abs(block_destination.y)){
        //     block.transform.position = block.transform.position + new Vector3(0,-1,0);
        // }
        // block.transform.position = block_destination;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.move == true && System.Math.Abs(block.transform.position.y) < System.Math.Abs(block_destination.y)){
                block.transform.position = block.transform.position + new Vector3(0,(float)-0.05,0);
        }
        
    }
}
