using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
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
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenuInput(input);
        } else if(currentScreen == Screen.Password)
        {
            RunCheckPassword(input);
        }

    }

    void RunMainMenuInput(string input)
    {
        if (Int32.TryParse(input, out level) && level <= 3 && level > 0)
        {
            currentScreen = Screen.Password;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
        }
    }

    void RunCheckPassword(string input)
    {
        switch (level)
        {
            case 1:
                password = "white";                
                break;
            case 2:
                password = "grey";
                break;
            default:
                password = "black";
                break;
        }
        if (input == password)
        {
            Terminal.WriteLine("Win!");
        }
        else
        {
            Terminal.WriteLine("Try again...");
        }
    }

    void StartGame()
    {
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password...");
    }

}
