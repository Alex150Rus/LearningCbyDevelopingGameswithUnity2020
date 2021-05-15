using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine; 
using CustomExtensions;

public class GameBehaviour : MonoBehaviour, IManager
{
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    private string _state;

    public string State
    {
        get;
        set;
    }
    
    private int _itemsCollected = 0;
    
    public int Items
    {
        get { return _itemsCollected; }
        
        set { 
            _itemsCollected = value; 
            
            if(_itemsCollected >= maxItems) {
                ShowScreen(true, "You've found all the items!");
            }
            else
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
        }
    }
    
    private int _playerHP = 10;
    
    public int HP 
    {
        get { return _playerHP; }
        set { 
            _playerHP = value; 
            if(_playerHP <= 0)
            {
                ShowScreen(false, "You want another life with that?");
            }
            else
            {
                labelText = "Ouch... that's got hurt.";
            }
        }
    }

    public Stack<string> lootStack = new Stack<string>();

    void ShowScreen(bool win, string text)
    {
        if (win)
            showWinScreen = true;
        else
            showLossScreen = true;

        labelText = text;
        Time.timeScale = 0;
    }
    
    public void Initialize() 
    {
        _state = "Manager initialized..";
        _state.FancyDebug();
        
        Debug.Log(_state);
        
        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("Winged Boot");
        lootStack.Push("Mythril Bracers");
    }

    private void Start()
    {
        Initialize();
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
                Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                Utilities.RestartLevel(0);
            }
        }
        
        if(showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 
                Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel();
            }
        }
    }
    
    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();
        
        Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem, nextItem);
        
        Debug.LogFormat("There are {0} random loot items waiting for you!", lootStack.Count);
    }
}
