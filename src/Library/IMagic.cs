using System;
using Characters;
using Inventory;

public interface IMagic 
{
    string Name {get;}
    MagicItems MagicItem {get; set; }
    int Magic {get; set;}
}