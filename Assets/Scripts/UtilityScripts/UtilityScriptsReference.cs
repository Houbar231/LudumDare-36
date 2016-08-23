using UnityEngine;
using System.Collections;

public class UtilityScriptsReference : MonoBehaviour {
    public static UtilityScriptsReference r; //For easy acces
    public string SBefore;
    public string SAfter;
    public string SNouns;

    public string[] Before;
    public string[] After;
    public string[] Nouns;

    void Awake() {
        r = this;
        Before = SBefore.Split(',');
        After = SAfter.Split(',');
        Nouns = SNouns.Split(',');
    }
}
