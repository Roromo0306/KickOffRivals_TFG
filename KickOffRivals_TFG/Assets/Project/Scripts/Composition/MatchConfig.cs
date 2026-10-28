using UnityEngine;

namespace KickOffRivals.Composition
{
    [CreateAssetMenu(fileName = "MatchConfig", menuName = "Kick Off Rivals/Match Config")]

    public sealed class MatchConfig : ScriptableObject
    {
        [SerializeField, Min(1)] private int playersPerTeam = 3;
        [SerializeField, Min(1f)] private float durationSeconds = 180f;

        public int PlayersPerTeam => playersPerTeam;
        public float DurationSeconds => durationSeconds;
    }
}