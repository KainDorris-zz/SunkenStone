using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    [SerializeField] private Sprite defaultImage;
    // Change this to a List<Minion> once team approves of design.
    [SerializeField] private List<Sprite> minions;
    [SerializeField] private List<Image> teamSlots;
    [SerializeField] private List<Image> profiles;

    private int _profileIndex = 0;
    private void Start()
    {
        SetSlotDefaults();
        InitializeProfiles();
    }

    private void InitializeProfiles()
    {
        for (int i = 0; i < profiles.Count; i++)
        {
            profiles[i].sprite = minions[i];
        }
    }

    private void SetSlotDefaults()
    {
        foreach (Image slot in teamSlots)
        {
            slot.sprite = defaultImage;
        }
    }

    private void SlideProfiles()
    {
        int minionStart = _profileIndex;
        for (int i = 0; i < profiles.Count; i++)
        {
            profiles[i].sprite = minions[minionStart];
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

    public void Add()
    {
        Debug.Log("Add");
    }

    public void Remove()
    {
        Debug.Log("Remove");
    }
    
}
