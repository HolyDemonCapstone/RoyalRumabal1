using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlayerM : MonoBehaviour


{

    

    [Header("PlayerStats")]
    [SerializeField]
    private float playerSpeed = 5; // player base speed
    [SerializeField]
    private float jumpHight = 5; // players base jump 
    
   

    [Header("Controler Config")]
    [SerializeField]
    private KeyCode jumpNameGP; // key for jump game pad
    [SerializeField]
    private KeyCode jumpNameKB; // key for jump keybord 
    [SerializeField]
    private KeyCode attackNameGP; // key for attack gamepad
    [SerializeField]
    private KeyCode attackNameKB; // key for attack keybord 
    [SerializeField]
    private KeyCode pickupNameGP; // key for pickup gamepad
    [SerializeField]
    private KeyCode pickupNameKB; // key for pickup keybord

    private float feetcheck = 0.1f; //player bast grond cheak
    private LayerMask ground;
    private Transform feet;
    private bool IsGrounded;
    private float PlayerVolasity;
    private Vector2 playerSize; 
    private Rigidbody2D PRB;
    private bool hasGun;
    //private string jumpName;
    private string leftStickName;
    

    public enum PlayerIDenum {P1, P2, P3, P4}; 
    public PlayerIDenum playerID;

    

   
    // Start is called before the first frame update
    void Start()
    {
        PRB = GetComponent<Rigidbody2D>(); // setter for rigidboddy
        feet = transform.GetChild(0); // setter for feet
        ground = LayerMask.GetMask("Ground"); // setter for gorund layer mask
        playerSize = this.transform.localScale; // sets definent size for player
        hasGun = false; // start match with no wepon
    }
    private void FixedUpdate()
    {
          IsGrounded = Physics2D.OverlapCircle(feet.position, feetcheck, ground);  // sets grounderd to true if transform Game object feet is ovelaping anything on ground layer 
    }
    // Update is called once per frame
    void Update()
    {
        // switch for witch controler controles witch player
        switch (playerID)
        {
            case PlayerIDenum.P1:
                {
                    //jumpName = "PJump1";
                    leftStickName = "PHorizontal1";
                Debug.Log("p1 is conected");

                break;
                }
            case PlayerIDenum.P2:
                {
                    Debug.Log("p2 is conected");
                    leftStickName = "PHorizontal2";
                    break;
                }
            case PlayerIDenum.P3:
                {
                    Debug.Log("p3 is conected");

                    break;
                }
            case PlayerIDenum.P4:
                {
                    Debug.Log("p4 is conected");

                    break;
                }

        } 
        
        Player_Walk(); // player walk

        // jump conditions 
        if ((Input.GetKeyDown(jumpNameGP) || Input.GetKeyDown(jumpNameKB)) && IsGrounded) // conditions for player jump 
        {
           Player_Jump();
        }

        // pick up conditions
        if (((Input.GetKeyDown(pickupNameGP)) || (Input.GetKeyDown(pickupNameKB))) ) // conditions for player jump 
        {
            if(!hasGun)
            {
                Player_Pickup();
            }
            else if(hasGun)
            {
                Player_Trow();
            }
           
        }
    }

   
void Player_Walk()
    {
        PlayerVolasity = playerSpeed * Input.GetAxisRaw(leftStickName);
        PRB.velocity = new Vector2(PlayerVolasity, PRB.velocity.y);

        if (PRB.velocity.x > 0)
        {
            transform.localScale = new Vector2(playerSize.x, playerSize.y); // sets player to not fliped  
        }
        else if (PRB.velocity.x < 0)
        {
            transform.localScale = new Vector2(-playerSize.x, playerSize.y); // flips the player 
        }
    } // player movment

void Player_Jump()
    {
        
        PRB.velocity = new Vector2(PRB.velocity.x, jumpHight);
    } // Jump for Player

void Player_Pickup()
    {
        if(hasGun == false)
        {
            hasGun = true;
            Debug.Log("player has item");
        }
    } // pickup

void Player_Trow()
    {
        if(hasGun == true)
        {
            hasGun = false;
            Debug.Log("player no has item");
        }
        
        
    }// throw
}
/* code for controler reconishion for latter

public string[] controlerID;
controlerID = Input.GetJoystickNames();
if(controlerID[0].Length > 0 )
 {
     Debug.Log(controlerID[0].Length);
 }*/

