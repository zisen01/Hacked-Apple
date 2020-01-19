using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning_Beh : MonoBehaviour
{
    public Transform owner;
    public Vector3 turn_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        this.owner.Rotate(turn_speed * Time.deltaTime);
    }
}
