using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public static UIManager instance = null;

    //REFS
    public HPBar playerOneBar; //CONVERTIR EN ARRAY
    public HPBar playerTwoBar; //

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetPlayerMaxLife(int player, int value)
    {
        if (player == 1)
            playerOneBar.SetMaxLife(value);
        else if (player == 2)
            playerTwoBar.SetMaxLife(value);
    }

    public void SetPlayerLife(int player, int value)
    {
        if (player == 1)
            playerOneBar.SetLife(value);
        else if (player == 2)
            playerTwoBar.SetLife(value);
    }

}
