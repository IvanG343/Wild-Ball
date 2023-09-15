using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            gameObject.SetActive(false);
    }
}
