using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAssigner : MonoBehaviour
{
   [SerializeField] int playerCount;
   public Player player1;
   public Player player2;
   bool P1Exist = false;
   bool P2Exist = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerCount = Gamepad.all.Count;

        
        if (playerCount >= 1 && P1Exist == false)
        {
            Instantiate(player1);
            player1.Controller = Gamepad.all[0];
            P1Exist = true;
            Debug.Log("Player 1 controller assigned.");
        }

        if (playerCount >= 2 && P2Exist == false )
        {
            Instantiate(player2);
            player1.Controller = Gamepad.all[1];
            P2Exist = true;
            Debug.Log("Player 2 controller assigned.");
        }
    }
}
    
    

