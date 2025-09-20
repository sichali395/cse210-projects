using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
    }

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            return null;
        }
        
        int index = _random.Next(0, _scriptures.Count);
        _scriptures[index].Reset(); // Ensure the scripture is not hidden when selected
        return _scriptures[index];
    }

    public bool IsEmpty()
    {
        return _scriptures.Count == 0;
    }
}