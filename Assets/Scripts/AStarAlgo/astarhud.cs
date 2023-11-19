using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astarhud : MonoBehaviour
{
    public GameObject hud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pausemenu.gameIsPaused)
        {
            hud.SetActive(false);
        }
        if(!pausemenu.gameIsPaused) {
            hud.SetActive(true);
        }
    }
}
