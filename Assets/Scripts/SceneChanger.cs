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
    public TriggerEvents EventToLoadSceneOn = TriggerEvents.OnTriggerEnter;

    public ManagedScenes SceneToUnload = ManagedScenes.Undefined;
    public TriggerEvents EventToUnloadSceneOn = TriggerEvents.OnTriggerEnter;

    public bool locked = false;

    public bool LoadSceneOnStartup = false;
    public RecenterPlayArea recenterScript;

    public bool SceneLoaded = false;
    public bool SceneUnloaded = false;

    private bool unloadNeeded = false;

    private void Start() {
        if(recenterScript != null) {
            Debug.Log("Recenter: " + recenterScript);
            recenterScript.Recenter();
        }

        if(LoadSceneOnStartup && SceneToLoad != ManagedScenes.Undefined) {
            StartCoroutine(LoadScene(SceneToLoad));
        }
    }

    public IEnumerator LoadScene(ManagedScenes scene, LoadSceneMode sceneMode = LoadSceneMode.Additive) {
        while(unloadNeeded && !SceneUnloaded) {
            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync((int)scene, sceneMode);
        asyncLoad.allowSceneActivation = false;

        while(asyncLoad.progress < 0.9f) {
            Debug.Log("Scene Load Progress: " + (asyncLoad.progress * 100) + "%");
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
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
        if(locked) {
            return;
        }

        if(other.name.Contains(NameOfColliderToTest)) {
            if(!SceneUnloaded && SceneToUnload != ManagedScenes.Undefined && EventToUnloadSceneOn == TriggerEvents.OnTriggerEnter) {
                unloadNeeded = true;
                StartCoroutine(UnloadScene(SceneToUnload));
            }
            else {
                unloadNeeded = false;
            }

            if (!SceneLoaded && SceneToLoad != ManagedScenes.Undefined && EventToLoadSceneOn == TriggerEvents.OnTriggerEnter) {
                StartCoroutine(LoadScene(SceneToLoad));
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (locked) {
            return;
        }

        if (other.name.Contains(NameOfColliderToTest)) {
            if (!SceneUnloaded && SceneToUnload != ManagedScenes.Undefined && EventToUnloadSceneOn == TriggerEvents.OnTriggerExit) {
                unloadNeeded = true;
                StartCoroutine(UnloadScene(SceneToUnload));
            }
            else {
                unloadNeeded = false;
            }

            if (!SceneLoaded && SceneToLoad != ManagedScenes.Undefined && EventToLoadSceneOn == TriggerEvents.OnTriggerExit) {
                StartCoroutine(LoadScene(SceneToLoad));
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        if (locked) {
            return;
        }

        if (other.name.Contains(NameOfColliderToTest)) {
            if (!SceneUnloaded && SceneToUnload != ManagedScenes.Undefined && EventToUnloadSceneOn == TriggerEvents.OnTriggerStay) {
                unloadNeeded = true;
                StartCoroutine(UnloadScene(SceneToUnload));
            }
            else {
                unloadNeeded = false;
            }

            if (!SceneLoaded && SceneToLoad != ManagedScenes.Undefined && EventToLoadSceneOn == TriggerEvents.OnTriggerStay) {
                StartCoroutine(LoadScene(SceneToLoad));
            }
        }
    }
}
