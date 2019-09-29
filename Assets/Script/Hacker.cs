using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    string[] level1Password = {"books", "aisle", "self", "password", "font", "borrow"};
    string[] level2Password = { "prisoner", "handcuffs", "holster", "uniform", "arrest"};

    // Game State
    int level;

    enum Screen {MainMenu, Password, Win};

    Screen currentScreen;

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
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NASA");

        Terminal.WriteLine(" ");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // Go back to the main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");

        if (isValidLevelNumber)
        {
            level = int.Parse(input); // convert into integer
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid Level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Password[Random.Range(0, level1Password.Length)];
                break;
            case 2:  
                password = level2Password[Random.Range(0, level2Password.Length)];
                break;
            default:
                Debug.LogError("invalid level number");
                break;
        }
        Terminal.WriteLine("Please enter password: ");

    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("***Level " + level + " GRANTED ACCESS***");
        }
        else {
            Terminal.WriteLine("Access Denied!");
        }
    }
}
