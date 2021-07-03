using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    //controls
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode interactKey = KeyCode.Z;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode cancelKey = KeyCode.X;
    public KeyCode viewRight = KeyCode.E;
    public KeyCode viewLeft = KeyCode.Q;

    //character controls
    //private SpriteAnimator sprAnim;
    private Rigidbody rb;

    //camera and rotation
    public bool controlCam;
    private Transform cam;
    public float rotY = 0.0f;

    //sprite directiomn
    public string dir = "";
    public string sec_dir = "";
    private bool lockDir = false;

    //speed modifiers
    public float moveSpeed = 2.0f;
    public float camSpeed = 1.0f;
    //private bool moving = false;
    public float jumpForce = 5.0f;

    //interaction
    private Transform interactBox;

    // Start is called before the first frame update
    void Start() {
        //sprAnim = GetComponent<SpriteAnimator>();
        rb = GetComponent<Rigidbody>();
        //interactBox = transform.Find("InteractBox");
        cam = transform.Find("Main Camera");
        rotY = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update() {
        //sprite animation and direction
        LockDirKey();
        //SetDir();
        //SetAnimation();

        //interaction box
        /*
        if(interactBox)
            SetInteractBoxPos();
        */

        //camera movement
        if(cam)
            RotateCamera();

        //arrow key movement
        int horDir = 0;
        if (Input.GetKey(leftKey))
            horDir = -1;
        else if (Input.GetKey(rightKey))
            horDir = 1;

        int verDir = 0;
        if (Input.GetKey(downKey))
            verDir = -1;
        else if (Input.GetKey(upKey))
            verDir = 1;

        float velZ = verDir * moveSpeed * Time.deltaTime;
        float velX = horDir * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + ((transform.right*velX)+(transform.forward*velZ)));

        //jump/fly
        if(Input.GetKeyDown(jumpKey)){
            rb.AddForce(Vector3.up*jumpForce*10, ForceMode.Impulse);
        }
    }

    /*
    //set's the animation of the sprite
    private void SetAnimation() {
        //walking animation
        if(moving) {
            if (Input.GetKey(leftKey) && dir == "west") {
                sprAnim.PlayAnim("walk_left");
            }
            else if (Input.GetKey(rightKey) && dir == "east") {
                sprAnim.PlayAnim("walk_right");
            }
            else if (Input.GetKey(upKey) && dir == "north") {
                sprAnim.PlayAnim("walk_back");
            }
            else if (Input.GetKey(downKey) && dir == "south") {
                sprAnim.PlayAnim("walk_front");
            }
        }
        //idle animation
        else {
            if (dir == "west")
                sprAnim.PlayAnim("idle_left");
            else if (dir == "east")
                sprAnim.PlayAnim("idle_right");
            else if (dir == "north")
                sprAnim.PlayAnim("idle_back");
            else if (dir == "south")
                sprAnim.PlayAnim("idle_front");
        }

        sprAnim.animating = true;

    }
    */

    //allows the camera to rotate around the player
    public void RotateCamera() {
        if (Input.GetKey(viewLeft))
            rotY -= camSpeed;
        else if (Input.GetKey(viewRight))
            rotY += camSpeed;

        transform.eulerAngles = new Vector3(0, rotY, 0);
    }

    //check if a movement key is held
    public bool anyMoveKey() {
        return (Input.GetKey(leftKey) || Input.GetKey(rightKey) || Input.GetKey(upKey) || Input.GetKey(downKey));
    }

    //check if 2 movement keys are held
    public bool twoMoveKey() {
        int ct = 0;
        if (Input.GetKey(leftKey))
            ct++;
        if (Input.GetKey(rightKey))
            ct++;
        if (Input.GetKey(upKey))
            ct++;
        if (Input.GetKey(downKey))
            ct++;

        return ct > 1;
    }

    //allow multi-directional movement (LttP style)
    private void LockDirKey() {
        // if (anyMoveKey())
        //     moving = true;
        // else
        //     moving = false;

        //lock the direction
        if(!lockDir && anyMoveKey()) {
            if (Input.GetKey(upKey))
                dir = "north";
            else if (Input.GetKey(downKey))
                dir = "south";
            else if (Input.GetKey(leftKey))
                dir = "west";
            else if (Input.GetKey(rightKey))
                dir = "east";

            lockDir = true;
            sec_dir = "";
        }

        //reset the lock
        if (lockDir) {
            if ((!Input.GetKey(upKey) && dir == "north") || (!Input.GetKey(downKey) && dir == "south") || (!Input.GetKey(leftKey) && dir == "west") || (!Input.GetKey(rightKey) && dir == "east"))
                lockDir = false;
        }

        if (lockDir) {
            if (!twoMoveKey()) {
                sec_dir = "";
                return;
            }

            if (Input.GetKey(upKey) && (dir != "north"))
                sec_dir = "north";
            if (Input.GetKey(downKey) && (dir != "south"))
                sec_dir = "south";
            if (Input.GetKey(leftKey) && (dir != "west"))
                sec_dir = "west";
            if (Input.GetKey(rightKey) && (dir != "east"))
                sec_dir = "east";
        }
    }

    /*
    //sets the position of the character's interact box
    private void SetInteractBoxPos() {
        if (dir == "north")
            interactBox.localPosition = new Vector3(0, 0, 0.55f);
        else if (dir == "south")
            interactBox.localPosition = new Vector3(0, 0, -0.55f);
        else if (dir == "west")
            interactBox.localPosition = new Vector3(-1f, 0f, 0f);
        else if (dir == "east")
            interactBox.localPosition = new Vector3(1f, 0f, 0f);
    }
    */
}
