using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
This class controls all game events, includes wining, losing, show title, 
show or hide setting bar

Private Methods:
Start, Update, win, lose, fadeText

Public Methods:
*/
public class GameManager : MonoBehaviour
{
    public Vector3 respawn_pos; // player respawning position
    public Transform player_trans; // player tansform
    public Rigidbody player_rb; // player rigidbody
    public Text title; // the title of this level
    public Canvas setting; // the setting ui window
    public bool is_win; // true if win
    private bool title_showed = false; // true when title's alpha reaches 1

    /* hide setting bar at the beginning */
    void Start()
    {
        this.setting.enabled = false;
    }

    /* Game controls and events are checked every frame */
    void Update()
    {
        // show title and fade out
        this.fadeText(this.title);

        // when press ESC, setting bar is visible
        if (Input.GetKeyDown(KeyCode.Escape)) {
            this.setting.enabled = !this.setting.enabled;
        }

        // check if win or lose
        if (this.is_win) {
            this.win();
        }
        else if (this.player_trans.position.y < -20f) {
            this.lose();
        }
    }

    /* Print win, more formal win events will be added in the future */
    private void win() {
        Debug.Log("Win!");
    }

    /* Print lose and reset the player position to beginning, and reset player force */
    private void lose() {
        Debug.Log("Lose!");
        // back to starting pos
        // Vector3 start_pos = new Vector3(0, 7, 0);
        this.player_trans.position = respawn_pos ;
        // these two lines reset player acceleration and velocity
        this.player_rb.constraints = RigidbodyConstraints.FreezePosition;
        this.player_rb.constraints = RigidbodyConstraints.None;
    }

    /* Change alpha of title text from 0 to 1 and back to 0 */
    private void fadeText(Text t){
        if (this.title.color.a < 1 & !this.title_showed) {
            // from 0 to 1
            var temp_color = this.title.color;
            temp_color.a =  temp_color.a + 0.005f;
            this.title.color = temp_color;
        }
        else if (this.title.color.a > 0) {
            // from 1 to 0
            this.title_showed = true;
            var temp_color = this.title.color;
            temp_color.a =  temp_color.a - 0.005f;
            this.title.color = temp_color;
        }
    }
}
