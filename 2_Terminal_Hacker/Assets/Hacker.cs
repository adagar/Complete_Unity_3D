using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
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
        else if(input == "4")
        {
            Terminal.WriteLine("Holy shit, too advanced!");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
        }
    }
}
