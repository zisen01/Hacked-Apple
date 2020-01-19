using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
This class control all changes in setting potentially made by the player
*/
public class SettingControl : MonoBehaviour
{
    public GameManager gm; // game manager may be needed (not used a.t.m. )
    public PlayerControl pc; // player control is needed to update move sensitivity
    public Slider sensitivity; // sensitivity slider in setting bar
    public Text sensititivty_text; // sensitivity text is needed to show slider value

    // intialize all texts
    void Start()
    {
        this.sensititivty_text.text = "Sensitivity: " + ((float)this.sensitivity.value).ToString();
    }

    // check if any setting is changed and apply these changes
    void Update()
    {
        // check sensitivity change and apply changes to player control
        if ((int)this.sensitivity.value != (int)this.pc.forceVector.x) {
            this.pc.resetForce(this.sensitivity.value);
            this.sensititivty_text.text = "Sensitivity: " + ((int)this.sensitivity.value).ToString();
        }
    }
}
