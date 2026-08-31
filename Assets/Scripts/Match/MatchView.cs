using System.Collections;
using UnityEngine;
using TMPro;

public class MatchView : MonoBehaviour
{
    public TextMeshProUGUI eventsText;

    public void PlayMatch(TeamData home, TeamData away)
    {
        if (MatchManager.Instance == null)
        {
            GameObject go = new GameObject("MatchManager");
            go.AddComponent<MatchManager>();
        }

        MatchResult result = MatchManager.Instance.SimulateMatch(home, away);

        // display events
        if (eventsText != null)
        {
            eventsText.text = string.Join("\n", result.events.ToArray());
        }

        // also log
        foreach (var e in result.events)
            Debug.Log(e);
    }
}
