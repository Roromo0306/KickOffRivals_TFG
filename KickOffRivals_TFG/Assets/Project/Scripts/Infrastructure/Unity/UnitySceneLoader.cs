using UnityEngine.SceneManagement;
using KickOffRivals.Application.Ports;

namespace KickOffRivals.Infrastructure.Unity
{
    public sealed class UnitySceneloader : ISceneLoader
    {
        public void Load(string scenenName)
        {
            SceneManager.LoadScene(scenenName);
        }
    }
}