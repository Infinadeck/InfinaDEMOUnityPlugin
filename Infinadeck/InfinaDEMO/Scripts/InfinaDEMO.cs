using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Infinadeck;

public class InfinaDEMO : MonoBehaviour
{
    [InfReadOnlyInEditor] public string pluginVersion = "1.0.0";
    private InfinadeckReferenceObjects refObjects;
    public Text DTRTextN;
    public Text DTRTextE;
    public Text DTRTextS;
    public Text DTRTextW;
    public GameObject holder;
    public int demoTimeRemaining = 120;
    public int demoTime = 120;
    private bool init = false;

    public InfinaDATA preferences;
    public Dictionary<string, InfinaDATA.DataEntry> defaultPreferences;

    public InfinaKEYBIND keybinds;
    private string defaultTimerKeybinds = "1234";
    private string defaultTreadmillKeybinds = "STND";
    public KeyCode[] myKeys;
    public KeyCode[] myTimerKeys;
    public string[] keybindNames = new string[12];
    public string[] keybindTimerNames = new string[12];

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Preferences
        preferences = this.gameObject.AddComponent<InfinaDATA>();
        preferences.fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/Infinadeck/InfinaDEMO/";
        preferences.fileName = "infDemo_preferences.ini";
        defaultPreferences = new Dictionary<string, InfinaDATA.DataEntry>
        {
            // Keybind Preferences:
            { "keyboardInputEnabled", new InfinaDATA.DataEntry { EntryName = "KeybindPreferences", EntryValue = "true" } },
            { "exportBindings", new InfinaDATA.DataEntry { EntryName = "KeybindPreferences", EntryValue = "false" } },

            { "keybindProfile", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = defaultTreadmillKeybinds } },
            { "customBinding", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "Alpha1-Alpha2-Alpha3-Alpha4-Alpha5-Alpha6-Alpha7-Alpha8-Alpha9-Alpha0-Minus-Equals" } },
            { "link01", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link02", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link03", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link04", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link05", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link06", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link07", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link08", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link09", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link10", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link11", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },
            { "link12", new InfinaDATA.DataEntry { EntryName = "Keybinds - Treadmill", EntryValue = "null" } },

            { "timerKeybindProfile", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = defaultTimerKeybinds } },
            { "timerCustomBinding", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "Alpha1-Alpha2-Alpha3-Alpha4-Alpha5-Alpha6-Alpha7-Alpha8-Alpha9-Alpha0-Minus-Equals" } },
            { "tlink01", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink02", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink03", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink04", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink05", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink06", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink07", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink08", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink09", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink10", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink11", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },
            { "tlink12", new InfinaDATA.DataEntry { EntryName = "Keybinds - Timers", EntryValue = "null" } },

            { "FUNC", new InfinaDATA.DataEntry { EntryName = "Reference: Keybind Profiles", EntryValue = "F1-F2-F3-F4-F5-F6-F7-F8-F9-F10-F11-F12" } },
            { "1234", new InfinaDATA.DataEntry { EntryName = "Reference: Keybind Profiles", EntryValue = "Alpha1-Alpha2-Alpha3-Alpha4-Alpha5-Alpha6-Alpha7-Alpha8-Alpha9-Alpha0-Minus-Equals" } },
            { "#PAD", new InfinaDATA.DataEntry { EntryName = "Reference: Keybind Profiles", EntryValue = "Keypad1-Keypad2-Keypad3-Keypad4-Keypad5-Keypad6-Keypad7-Keypad8-Keypad9-KeypadDivide-KeypadMultiply-KeypadMinus" } },
            { "STND", new InfinaDATA.DataEntry { EntryName = "Reference: Keybind Profiles", EntryValue = "LeftShift-LeftControl-LeftAlt-Space-RightShift-RightControl-RightAlt-Return-BackQuote-Tab-Backslash-Backspace" } },
            { "CPAD", new InfinaDATA.DataEntry { EntryName = "Reference: Keybind Profiles", EntryValue = "LeftArrow-DownArrow-RightArrow-UpArrow-Delete-End-PageDown-Insert-Home-PageUp-ScrollLock-Pause" } },
            { "QWER", new InfinaDATA.DataEntry { EntryName = "Reference: Keybind Profiles", EntryValue = "Q-W-E-R-T-Y-U-I-O-P-LeftBracket-RightBracket" } },
            { "ASDF", new InfinaDATA.DataEntry { EntryName = "Reference: Keybind Profiles", EntryValue = "A-S-D-F-G-H-J-K-L-Semicolon-Quote-Slash" } },
            { "Custom", new InfinaDATA.DataEntry { EntryName = "Reference: Keybind Profiles", EntryValue = "parses the 12 keys listed in customBinding" } }
        };
        preferences.all = defaultPreferences;
        preferences.InitMe();

        if (keybinds == null)
        {
            keybinds = FindObjectOfType<InfinaKEYBIND>();
            if (keybinds == null)
            {
                keybinds = this.gameObject.AddComponent<InfinaKEYBIND>();
            }
        }

        StartCoroutine(InitDemo());
    }

    IEnumerator InitDemo()
    {
        yield return new WaitForSeconds(5f);
        if (FindObjectOfType<InfinadeckReferenceObjects>())
        {
            holder = FindObjectOfType<InfinadeckReferenceObjects>().gameObject;
            this.transform.parent = holder.transform;
            this.transform.localPosition = Vector3.zero;
            this.transform.localRotation = Quaternion.identity;
            this.transform.localScale = Vector3.one;
        }

        init = true;
        StartCoroutine(DecrementDemoTime());
    }

    private IEnumerator DecrementDemoTime()
    {
        while(true)
        {
            if (Infinadeck.Infinadeck.GetTreadmillRunState())
            {
                demoTimeRemaining--;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!init) { return; }

        if (demoTimeRemaining <= 0) {
            demoTimeRemaining = demoTime;
            Infinadeck.Infinadeck.StopTreadmill();
        }

        //Demo Time Remaining Text
        float timer = (float)demoTimeRemaining;
        DTRTextN.text = Mathf.Floor(timer / 60).ToString() + ":" + Mathf.RoundToInt(timer % 60).ToString("00");
        DTRTextE.text = DTRTextN.text;
        DTRTextS.text = DTRTextN.text;
        DTRTextW.text = DTRTextN.text;

        if (preferences.ReadBool("keyboardInputEnabled"))
        {
            //GENERAL FUNCTIONS
            //determine which profile is in use
            myKeys = keybinds.GetMyKeys(preferences.ReadString("keybindProfile"), preferences.ReadString("customBinding"));
            myTimerKeys = keybinds.GetMyKeys(preferences.ReadString("timerKeybindProfile"), preferences.ReadString("timerCustomBinding"));
            keybindNames = new string[]
            {
                "Reload Current Level",
                "",
                "",
                "Stop Treadmill",
                "Start Treadmill",
                "",
                "",
                "",
                "",
                "",
                "Import Preferences",
                "Reset Preferences"
            };
            keybindTimerNames = new string[]
            {
                "Set Timer to 1 Minute",
                "Set Timer to 2 Minute",
                "Set Timer to 3 Minute",
                "Set Timer to 4 Minute",
                "Set Timer to 5 Minute",
                "Set Timer to 6 Minute",
                "Set Timer to 7 Minute",
                "Set Timer to 8 Minute",
                "Set Timer to 9 Minute",
                "Set Timer to 10 Minute",
                "Disable Timer",
                ""
            };

            //export bindings once whenever exportBindings set to true
            if (preferences.ReadBool("exportBindings"))
            {
                for (int j = 0; j < 12; j++)
                {
                    if (keybindNames[j] != "") { preferences.Write("link" + String.Format("{0:00}", j + 1), myKeys[j] + " to " + keybindNames[j]); }
                    else { preferences.Write("link" + String.Format("{0:00}", j + 1), "---" ); }
                    if (keybindTimerNames[j] != "") { preferences.Write("tlink" + String.Format("{0:00}", j + 1), myTimerKeys[j] + " to " + keybindTimerNames[j]); }
                    else { preferences.Write("tlink" + String.Format("{0:00}", j + 1), "---"); }
                }
                preferences.Write("exportBindings", "false");
            }

            // determine which function, if any, are being called
            if (!keybinds.isInputEnabled) { keybinds.isInputEnabled = true; }
            else
            {
                switch (keybinds.KeybindRequest(myKeys))
                {
                    case 0: break; // no button was pressed
                    case 1: SceneManager.LoadScene(SceneManager.GetActiveScene().name); break; //LeftShift by default
                    case 2: ; break; //LeftControl by default
                    case 3: ; break; //LeftAlt by default
                    case 4: Infinadeck.Infinadeck.StopTreadmill(); break; //Space by default
                    case 5: Infinadeck.Infinadeck.StartTreadmillUserControl(); break; //RightShift by default
                    case 6: ; break; //RightControl by default
                    case 7: ; break; //RightAlt by default
                    case 8: ; break; //Menu by default
                    case 9: ; break; //BackQuote by default
                    case 10: ; break; //Tab by default
                    case 11: ImportPreferences(); break; //Backslash by default
                    case 12: ResetPreferences(); break; //Backspace by default
                    default: break; // no button was pressed
                }
                switch (keybinds.KeybindRequest(myTimerKeys))
                {
                    case 0: break; // no button was pressed
                    case 1: SetTheTimer(60); break; //Alpha 1 by default
                    case 2: SetTheTimer(120); break; //Alpha 2 by default
                    case 3: SetTheTimer(180); break; //Alpha 3 by default
                    case 4: SetTheTimer(240); break; //Alpha 4 by default
                    case 5: SetTheTimer(300); break; //Alpha 5 by default
                    case 6: SetTheTimer(360); break; //Alpha 6 by default
                    case 7: SetTheTimer(420); break; //Alpha 7 by default
                    case 8: SetTheTimer(480); break; //Alpha 8 by default
                    case 9: SetTheTimer(540); break; //Alpha 9 by default
                    case 10: SetTheTimer(600); break; //Alpha 10 by default
                    case 11: HideTheTimer(); break; //Alpha 11 by default
                    case 12: break; //Alpha 12 by default
                    default: break; // no button was pressed
                }
            }
        }
    }

    /**
     * Imports the preferences from the settings file.
     */
    public void ImportPreferences()
    {
        preferences.LoadSettings();
    }

    /**
     * Resets the settings file to the default preferences.
     */
    public void ResetPreferences()
    {
        preferences.all = defaultPreferences;
        foreach (KeyValuePair<string, InfinaDATA.DataEntry> pref in preferences.all)
        {
            pref.Value.WriteFlag = true;
        }
    }

    public void SetTheTimer(int i)
    {
        DTRTextN.enabled = true;
        DTRTextE.enabled = true;
        DTRTextS.enabled = true;
        DTRTextW.enabled = true;
        demoTime = i;
        demoTimeRemaining = i;
    }

    public void HideTheTimer()
    {
        DTRTextN.enabled = false;
        DTRTextE.enabled = false;
        DTRTextS.enabled = false;
        DTRTextW.enabled = false;
        demoTime = 5000;
        demoTimeRemaining = 5000;
    }
}