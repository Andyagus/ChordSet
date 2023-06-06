using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyStatus : MonoBehaviour
{

    public CommandCanvas commandCanvas;
    // public TextMeshProUGUI _;
    
    
    public List<Command> availableCommands;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftCommand))
        {
            foreach (var command in availableCommands)
            {
                if (command.modToAccess == Mods.COMMAND)
                {
                    commandCanvas.gameObject.SetActive(true);

                    commandCanvas.title.text = command.title;
                    commandCanvas.letter.text = command.letter;
                    commandCanvas.icon.sprite = command.logo;
                    // commandCanvas.background.color = command.color;
                    // commandCanvas.background.GetComponent<Image>().color = ColorPicker.Blue;
                    
                }
            }
        }
        
        
        
        // if (Input.GetKeyDown(KeyCode.LeftCommand))
        // {
        //     
        //     
        //     // commandCanvas.title = 
        //     // commandCanvas.gameObject.SetActive(true);
        // }
    }
}
