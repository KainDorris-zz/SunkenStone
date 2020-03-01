using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        if (player == null) player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerHotKeys();
    }
    
    private void PlayerMovement()
    {
        float speed = player.GetSpeed();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        if (horizontalInput != 0 && verticalInput != 0)
        {
            player.transform.Translate(direction * ((speed * 0.7f ) * Time.deltaTime));
        }
        else
        {
            player.transform.Translate(direction * (speed * Time.deltaTime));
        }
    }
    
    private void PlayerHotKeys()
    {
        // TODO: Determine Default Keys for Hot Swapping Monsters. For Now: 1 , 2 , 3 are used to allow WSDA Movement.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.SwapMinions(0);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.SwapMinions(1);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.SwapMinions(2);
        }
    }

}
