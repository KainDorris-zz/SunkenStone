using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class TeamManager : MonoBehaviour
{
    [SerializeField] private Sprite defaultImage;
    [SerializeField] private List<Image> teamSlots;
    [SerializeField] private List<Image> profiles;
    [SerializeField] private MonsterDatabaseScriptableObject monsterDatabase;
    [SerializeField] private List<MonsterScriptableObject> minions;
    public static List<MonsterScriptableObject> PlayerTeam;
    private int _profileIndex = 0;
    
    private void Awake()
    {
        minions = monsterDatabase.GetCollected();
        SetSlotDefaults();
        InitializeProfiles();
    }

    // Add this to a static library so it can be used throughout the project.
    private void CheckForNullError(Object obj, string message)
    {
        if(obj == null) Debug.LogError(message);
    }

    private void InitializeProfiles()
    {
        for (int i = 0; i < profiles.Count; i++)
        {
            profiles[i].sprite = minions[i].sprite;
        }
    }

    private void SetSlotDefaults()
    {
        foreach (Image slot in teamSlots)
        {
            slot.sprite = defaultImage;
        }
    }

    private void CreateTeam()
    {
        List<MonsterScriptableObject> newMinions = new List<MonsterScriptableObject>();

        foreach (Image slot in teamSlots)
        {
           newMinions.Add(monsterDatabase.GetMonsterBySprite(slot.sprite)); 
        }

        PlayerTeam = newMinions;
    }

    private void SlideProfiles()
    {
        int minionStart = _profileIndex;
        for (int i = 0; i < profiles.Count; i++)
        {
            profiles[i].sprite = minions[minionStart].sprite;
            minionStart++;
        }
    }

    public void ClickRight()
    {
        int index = _profileIndex == 0 ? 1 : _profileIndex;
        if (index + 4 != minions.Count - 1)
        {
           _profileIndex++;
           SlideProfiles(); 
        }
    }

    public void ClickLeft()
    {
        if (_profileIndex - 1 >= 0)
        {
            _profileIndex--;
            SlideProfiles();
        }
    }

    public void Add(int slotIndex)
    {
        // Loop over each team slot until you find one that is empty and add the that index in the list.
        foreach (Image slot in teamSlots)
        {
            // Check to see current sprite is already contained within selected profiles.
            var currentSprites = teamSlots.Select(s => s.sprite).ToList();
            
            if (slot.sprite == defaultImage && !currentSprites.Contains(profiles[slotIndex].sprite))
            {
                slot.sprite = profiles[slotIndex].sprite;
                return;
            }
        }
    }

    public void Remove(int slotIndex)
    {
        if (teamSlots[slotIndex].sprite != defaultImage)
        {
            teamSlots[slotIndex].sprite = defaultImage;   
        }
    }

    public void Continue()
    {
        CreateTeam();
        SceneManager.LoadScene(3);
    }
    
}
