using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("How do you want to use your abilities?");
        Terminal.WriteLine("\n");
        Terminal.WriteLine("1 White - I hack to help");
        Terminal.WriteLine("2 Gray - I hack to find");
        Terminal.WriteLine("3 Black - I hack to hurt");
        Terminal.WriteLine("\n");
        Terminal.WriteLine("Choose Level to Begin: ");
    }

    void OnUserInput(string input)
    {
       if(input == "menu")
        {
            ShowMainMenu();
        }
        else
        {
            if (Int32.TryParse(input, out level))
            {
                StartGame();

            }
            else
            {
                Terminal.WriteLine("Please select a valid level");
            }
        }
        
    }

    void StartGame()
    {
        Terminal.WriteLine("You have chosen level " + level);
    }


}
