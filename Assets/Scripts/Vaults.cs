using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Vaults : MonoBehaviour {

    private CharacterController hitbox;
    private FirstPersonController fps;
    private GameObject vaultedObject;
    private float originalHeight;
    private Vector3 forward;
    private bool konging;
    private bool popVaulting;
    private bool wallHanging;
    private float heightDifference;
    RaycastHit hit;

    public void Start()
    {
        hitbox = GameObject.Find("Player").GetComponent<CharacterController>();
        originalHeight = hitbox.height;
        fps = GameObject.Find("Player").GetComponent<FirstPersonController>();
        forward = hitbox.transform.eulerAngles;
        konging = false;
        popVaulting = false;
        wallHanging = false;

    }

    public void Update()
    {
        //Trajectory = hitbox.transform.eulerAngles;
        /*if (Physics.Raycast(forward, Vector3.down, out hit, 2f) && konging)
        {
            vaultedObject = hit.collider.gameObject;
            LongKong();
        }
        konging = false;*/
    }

    public void TypeChecker(GameObject vaultedIn)
    {
        vaultedObject = vaultedIn;
        heightDifference = GameObject.Find("vaultedObject").transform.up.y - hitbox.transform.up.y;
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
        }
    }
    public void Kong()
    {
        //animate kong
        //konging = true;
        hitbox.height = originalHeight / 2;
    }

    public void LongKong()
    {
        forward.y = (fps.JumpSpeed / 4);
    }

    public void PopVault()
    {

    }

    public void WallClimb()
    {

    }
}
