using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    
    public GameBehaviour gameManager;
    
    void Start()
    {                 
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
    }
    
   void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");
            
            gameManager.Items += 1;
            
            gameManager.PrintLootReport();
        }
    }
}
