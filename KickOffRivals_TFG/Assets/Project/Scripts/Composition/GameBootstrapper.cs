using UnityEngine;
using UnityEngine.SceneManagement;
using KickOffRivals.Application.FSM;
using KickOffRivals.Application.Services;
using KickOffRivals.Domain.Models;
using KickOffRivals.Infrastructure.Unity;

namespace KickOffRivals.Composition
{
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private MatchConfig matchConfig;

        private IMatchService _matchService;
        private IBallService _ballService;
        private INavigationService _navigation;


        private void Awake()
        {
            if (matchConfig == null)
            {
                Debug.LogError("Asigna MatchConfig al Bootstrapper");
                enabled = false; 
                return;
            }

            DontDestroyOnLoad(gameObject);

            var rules = new MatchRules(matchConfig.PlayersPerTeam, matchConfig.DurationSeconds);

            _matchService = new MatchService(rules);
            _ballService = new BallService(_matchService);

            var states = new AppStateMachine();

            _navigation = new NavigationService(states, new UnitySceneloader(), _matchService);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Start()
        {
            if(_navigation == null)
            {
                return;
            }

            _navigation.GoHome();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(scene.name == "Bootstrap")
            {
                return;
            }

            foreach(var sceneObject in scene.GetRootGameObjects())
            {
                var compositionRoot = sceneObject.GetComponent<SceneCompositionRoot>();

                if(compositionRoot == null)
                {
                    continue;
                }

                compositionRoot.Initialize(_navigation, _matchService);
                Debug.Log($"Kick Off Rivals: {_navigation.State} -- escena {scene.name}");
                return;
            }

            Debug.LogError($"No hay SsceneCompositionRoot en {scene.name}");
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

    }
}

