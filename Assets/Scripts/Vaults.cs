using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Vaults : MonoBehaviour {

    private CharacterController hitbox;
    private FirstPersonController fps;
    private GameObject vaultedObject;
    private float originalHeight; //The default height of the player model. Height at any point may be modified by character actions
    private float originalSpeed; //The default speed of the player. Speed at any point may be modified by character actions
    private Vector3 forward;
    private int numKongs; //the number of times the player has done a kong vault without landing. Kongs stop working at 2
    private bool wallJumping;
    private bool wallHanging;
    private float heightDifference;
    private Vector3 Motion; //contains the x, y, and z speeds of the player
    RaycastHit hit;
	GameObject vaultedIn;

    public void Start()
    {
        hitbox = GameObject.Find("Player").GetComponent<CharacterController>();
        originalHeight = hitbox.height;
        fps = GameObject.Find("Player").GetComponent<FirstPersonController>();
        forward = hitbox.transform.eulerAngles;
        numKongs = 0;
        wallJumping = false;
        wallHanging = false;
		vaultedObject = null;

    }

    public void Update()
    {
        //Trajectory = hitbox.transform.eulerAngles;
        /*if (Physics.Raycast(forward, Vector3.down, out hit, 2f) && konging)
        {
            vaultedObject = hit.collider.gameObject;
            LongKong();
        }
        konging = false;
        */
        Motion = fps.MoveDir;
    }

    public void TypeChecker(GameObject vaultedIn)
    {
        vaultedObject = vaultedIn;
        if (numKongs == 0 && Physics.Raycast(forward, Vector3.forward, out hit, 3f))
        {
            WallJump();
        }
        if (Physics.Raycast(forward, (Vector3.forward + Vector3.down), out hit, 3f) && numKongs<2)
        {
            Kong();
        }
        /*heightDifference = vaultedObject.transform.up.y - hitbox.transform.up.y;
        print(heightDifference);
        if ( heightDifference <= 1)
        {
            Kong();
        }
        if(heightDifference <= 2)
        {
            PopVault();
        }
        if (heightDifference <= 3)
        {
            WallClimb();
        }*/
    }
    public void Kong()
    {
        //animate kong
        //konging = true;
        Motion.y = fps.JumpSpeed * 4;
        fps.MoveDir = Motion;
        hitbox.height = originalHeight / 2;
    }

    public void LongKong()
    {
        forward.y = (fps.JumpSpeed / 4);
    }

    public void WallJump()
    {
        Motion.y = fps.JumpSpeed * 10;
        fps.MoveDir = Motion;

    }

    public void WallClimb()
    {

    }
    
    /*private void OnTriggerStay(Collider colliding)
    {
        if (!popVaulting)
        {
            popVaulting = true;
            PopVault(colliding);
        }
        else if(!wallHanging)
        {
            WallClimb();
        }
    }*/
}
