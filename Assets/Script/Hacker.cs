using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
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
        if (input == "1")
        {
            level = 1;
            password = "librarian";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "capture";
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
        Terminal.WriteLine("Level " + level + " reached");
        Terminal.WriteLine("Please enter password: ");

    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("***Level " + level + " BREACHED***");
        }
        else {
            Terminal.WriteLine("Access Denied!");
        }
    }
}
