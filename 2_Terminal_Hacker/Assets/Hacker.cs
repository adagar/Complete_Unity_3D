using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menuHint = "Type 'menu' to return to start";
    int level;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;
    string password;

    string[] whitePasswords = { "help", "aid", "save" };
    string[] greyPasswords = { "find", "seek", "look" };
    string[] blackPasswords = { "hurt", "steal", "destroy" };

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
            LevelSelect(input);
        } else if(currentScreen == Screen.Password)
        {
            RunCheckPassword(input);
        }

    }

    void LevelSelect(string input)
    {
        if (int.TryParse(input, out level) && level <= 3 && level > 0)
        {
            //valid level selected
            Terminal.ClearScreen();
            Terminal.WriteLine("You have chosen level " + level);
            currentScreen = Screen.Password;
            SetRandomPassword();
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
        }
    }

    void RunCheckPassword(string input)
    {
        
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void AskForPassword()
    { 
        Terminal.WriteLine("Enter your password. Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = whitePasswords[Random.Range(0, whitePasswords.Length)];
                break;
            case 2:
                password = greyPasswords[Random.Range(0, greyPasswords.Length)];
                break;
            default:
                password = blackPasswords[Random.Range(0, blackPasswords.Length)];
                break;
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Hack successful...");
                Terminal.WriteLine(@"
 _                _             
| |              | |            
| |__   __ _  ___| | _____ _ __ 
| '_ \ / _` |/ __| |/ / _ \ '__|
| | | | (_| | (__|   <  __/ |   
|_| |_|\__,_|\___|_|\_\___|_|   
                                
                                
");
                break;
            case 2:
                Terminal.WriteLine("Hack successful...");
                Terminal.WriteLine(@"
 _                _             
| |              | |            
| |__   __ _  ___| | _____ _ __ 
| '_ \ / _` |/ __| |/ / _ \ '__|
| | | | (_| | (__|   <  __/ |   
|_| |_|\__,_|\___|_|\_\___|_|   
                                
        
");
                break;
            default:
                Terminal.WriteLine("Hack successful...");
                Terminal.WriteLine(@"

 _                _             
| |              | |            
| |__   __ _  ___| | _____ _ __   
| '_ \ / _` |/ __| |/ / _ \ '__|
| | | | (_| | (__|   <  __/ |   
|_| |_|\__,_|\___|_|\_\___|_|   
                                
        
");
                break;
        }
        
    }

                                                                      
     



}
