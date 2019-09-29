using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int level;

    // Start is called before the first frame update
    void Start()
    {
        
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        
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
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid Level");
        }
    }

    void StartGame()
    {
        Terminal.WriteLine("Level " + level + " breached");
    }
    
}
