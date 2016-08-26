using System.Collections;
using UnityEngine;

public static class NameGen {
    public static string[] Before = { "Disloyal", "Convinient", "Armoured", "Incinerating", "Alpha", "Bookish", "Great", "Brave" };
    public static string[] After = { "Speaking", "Slapping", "Hunting", "Fleeing", "Tumbling", "Shaking","Burning"};
    public static string[] Nouns = { "Hammer", "Point","Syrups","Horn","Breath","Bolts","Cats","Wheels"};
    public static string Person(string Profession, int Format01) {
        switch(Format01) {
            case 0:
                return "Urist Mc" + Profession + "Dwarf";
            case 1:
                return "Urist Mc" + Profession;
        }
        Debug.LogError("NameGen::Person() - unknown format");
        return null;
    }
    public static string Group() {
        switch(Random.Range(0,2)) {
            case 0:
                return "The " + Rand.Array<string>(UtilityScriptsReference.r.Before) + " " + Rand.Array<string>(UtilityScriptsReference.r.Nouns);
            case 1:
                return "The " + Rand.Array<string>(UtilityScriptsReference.r.Before) + " " + Rand.Array<string>(UtilityScriptsReference.r.Nouns) + " of " + Rand.Array<string>(UtilityScriptsReference.r.After);
            case 2:
                return "The " + Rand.Array<string>(UtilityScriptsReference.r.Nouns) + " of " + Rand.Array<string>(UtilityScriptsReference.r.After);
        }
        return null;
    }
}