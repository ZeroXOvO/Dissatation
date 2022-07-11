using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class MenuManager : MonoBehaviour
{
    public Panel currentPanel = null;

    private List<Panel> pandelHistory = new List<Panel>();

    private void Start()
    {
        SetupPanels();
    }

    private void SetupPanels()
    {
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach (Panel panel in panels)
            panel.Setup(this);

        currentPanel.Show();
    }

    private void Update()
    {
        if (SteamVR_Actions._default.GrabPinch.GetLastStateDown(SteamVR_Input_Sources.RightHand))
            GoToPrevious();
    }


    public void PlayGame()
    {
        
        SceneManager.LoadScene("Game");
    }


    public void GoToPrevious()
    {
        if (pandelHistory.Count == 0)
        {
            return;
        }

        int lastIndex = pandelHistory.Count - 1;
        SetCurrent(pandelHistory[lastIndex]);
        pandelHistory.RemoveAt(lastIndex);
    }


    public void SetCurrentWithHistory(Panel newPanel)
    {
        pandelHistory.Add(currentPanel);
        SetCurrent(newPanel);
    }

    public void SetCurrent(Panel newPanel)
    {
        currentPanel.Hide();

        currentPanel = newPanel;
        currentPanel.Show();
    }

    public void LeaveGame()
    {
        Application.Quit();
        //print("Quit Game");
    }
}
