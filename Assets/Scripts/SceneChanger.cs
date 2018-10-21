using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The order of these scenes should match the order in BuildSettings
/// </summary>
public enum ManagedScenes {
    MainScene,
    LivingRoomScene,
    CorridorScene,
    BarScened,
    KitchenScene,
    StairwayScene,
    BedroomScene,
    Undefined
}

public enum TriggerEvents {
    OnTriggerEnter,
    OnTriggerExit,
    OnTriggerStay
}

public class SceneChanger : MonoBehaviour {

    public string NameOfColliderToTest = "HeadsetCollider";

    public ManagedScenes SceneToLoad = ManagedScenes.Undefined;
    public TriggerEvents EventToLoadSceneOn = TriggerEvents.OnTriggerExit;

    public ManagedScenes SceneToUnload = ManagedScenes.Undefined;
    public TriggerEvents EventToUnloadSceneOn = TriggerEvents.OnTriggerExit;

    public bool SceneLoaded = false;
    public bool SceneUnloaded = false;

    public IEnumerator LoadScene(ManagedScenes scene, LoadSceneMode sceneMode = LoadSceneMode.Additive) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync((int)scene, sceneMode);

        while(!asyncLoad.isDone) {
            Debug.Log("Scene Load Progress: " + (asyncLoad.progress * 100) + "%");
            yield return null;
        }

        Debug.Log("Scene Loaded: " + scene);
        SceneLoaded = true;
    }

    public IEnumerator UnloadScene(ManagedScenes scene) {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync((int)scene);

        while (!asyncUnload.isDone) {
            Debug.Log("Scene Unload Progress: " + (asyncUnload.progress * 100) + "%");
            yield return null;
        }

        Debug.Log("Scene Unloaded: " + scene);
        SceneUnloaded = true;
    }

    private void OnTriggerEnter(Collider other) {

        if(other.name.Contains(NameOfColliderToTest)) {
            if (!SceneLoaded && SceneToLoad != ManagedScenes.Undefined && EventToLoadSceneOn == TriggerEvents.OnTriggerEnter) {
                StartCoroutine(LoadScene(SceneToLoad));
            }

            if(!SceneUnloaded && SceneToUnload != ManagedScenes.Undefined && EventToUnloadSceneOn == TriggerEvents.OnTriggerEnter) {
                StartCoroutine(UnloadScene(SceneToUnload));
            }
        }
    }

    private void OnTriggerExit(Collider other) {

        if (other.name.Contains(NameOfColliderToTest)) {
            if (!SceneLoaded && SceneToLoad != ManagedScenes.Undefined && EventToLoadSceneOn == TriggerEvents.OnTriggerExit) {
                StartCoroutine(LoadScene(SceneToLoad));
            }

            if (!SceneUnloaded && SceneToUnload != ManagedScenes.Undefined && EventToUnloadSceneOn == TriggerEvents.OnTriggerExit) {
                StartCoroutine(UnloadScene(SceneToUnload));
            }
        }
    }

    private void OnTriggerStay(Collider other) {

        if (other.name.Contains(NameOfColliderToTest)) {
            if (!SceneLoaded && SceneToLoad != ManagedScenes.Undefined && EventToLoadSceneOn == TriggerEvents.OnTriggerStay) {
                StartCoroutine(LoadScene(SceneToLoad));
            }

            if (!SceneUnloaded && SceneToUnload != ManagedScenes.Undefined && EventToUnloadSceneOn == TriggerEvents.OnTriggerStay) {
            }
                StartCoroutine(UnloadScene(SceneToUnload));
        }
    }
}
