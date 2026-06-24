using UnityEngine;

public class Bat : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public override void Use() { Debug.Log("Bat was swung, killing player2 in the process!"); }

}
