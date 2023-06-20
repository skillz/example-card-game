using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpOverlayController : MonoBehaviour
{
  public List<GameObject> helpOverlays;

  private void Awake()
  {
    if (!PlayerPrefs.HasKey("hasPlayedFirstGame"))
    {
      ShowHelpOverlay(0);
      PlayerPrefs.SetInt("hasPlayedFirstGame", 1);
      PlayerPrefs.Save();
    }
  }

  public void ShowHelpOverlay(int index)
  {
    for (int i = 0; i < helpOverlays.Count; i++)
    {
      if (index == i)
      {
        helpOverlays[i].SetActive(true);
      }
      else
      {
        helpOverlays[i].SetActive(false);
      }
    }  
  }

  public void HideHelpOverlay()
  {
    for (int i = 0; i < helpOverlays.Count; i++)
    {
        helpOverlays[i].SetActive(false);
    }
  }
}
