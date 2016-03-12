using UnityEngine;
using System.Collections;

public class JumpLogic : MonoBehaviour {

    private GameObject player = GameObject.Find("Player");
    private Vector3 forward;
    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        forward = player.transform.TransformDirection(Vector3.forward);
        GameObject jumpObject = null;
        RaycastHit hitObstacle;
        if(Input.GetKeyDown("space")&&/*player.getMotion()=="running")&&*/Physics.Raycast(transform.position, forward, out hitObstacle, 1)/*the xz direction of motion of the player (+1m - the y difference between the object and player) is filled by an object*/ )
        {
            jumpObject = hitObstacle.collider.gameObject;
            float height = jumpObject.GetComponent<MeshFilter>().mesh.bounds.size.y;
            if(height<=1)
            {
                //call kong
            }
            else if(height<=2)
            {
                //call pop vault
            }
            else if(height<=3)
            {
                //call wall climb
            }
            else
            {
                //call wallrun
            }
        }
	}
}
