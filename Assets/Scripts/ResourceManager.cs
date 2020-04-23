using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private List<Image> resourcePoints;
    private int _resourceCount = 0;
    private Color _fillColor;
    private Color _emptyColor;
    
    void Awake()
    {
        ColorUtility.TryParseHtmlString("#FF9800", out _fillColor);
        ColorUtility.TryParseHtmlString("#919191", out _emptyColor);
        if(resourcePoints == null) resourcePoints = new List<Image>();
    }

    public void AddResource()
    {
        foreach (var image in resourcePoints)
        {
            if(image.color == _emptyColor)
            {
                image.color = _fillColor;
                _resourceCount++;
                return;
            }
        }
    }
    
    public void RemoveResource()
    {
        for (var i = resourcePoints.Count - 1; i >= 0; i--)
        {
            if(resourcePoints[i].color == _fillColor)
            {
                resourcePoints[i].color = _emptyColor;
                _resourceCount--;
                return;
            }
        }
    }

    public void EmptyResources()
    {
        foreach (var image in resourcePoints)
        {
            image.color = _emptyColor;
        }

        _resourceCount = 0;
    }

    public int GetResourceCount()
    {
        return _resourceCount;
    }

}
