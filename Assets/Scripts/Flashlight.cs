using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Flashlight : VRTK_InteractableObject {

    public Renderer FlashlightRenderer;
    public Light FlashlightLight;
    public AudioSource ToggleSound;

    public bool IsFlashlightOn = false;

    private Material FlashlightMaterial;

	// Use this for initialization
	void Start () {
        if (FlashlightRenderer != null)
            FlashlightMaterial = FlashlightRenderer.material;

        if(FlashlightLight == null)
            FlashlightLight = GetComponentInChildren<Light>();

        if (ToggleSound == null)
            ToggleSound = GetComponentInChildren<AudioSource>();

        if (IsFlashlightOn)
            SwitchOn(false);
        else
            SwitchOff(false);
	}

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null) {
        base.StartUsing(currentUsingObject);
        SwitchOn();
    }

    public override void StopUsing(VRTK_InteractUse previousUsingObject = null, bool resetUsingObjectState = true) {
        base.StopUsing(previousUsingObject, resetUsingObjectState);
        SwitchOff();
    }

    public void SwitchOn(bool PlaySoundEffect = true) {
        if (FlashlightMaterial != null)
            FlashlightMaterial.EnableKeyword("_EMISSION");

        if(FlashlightLight != null)
            FlashlightLight.gameObject.SetActive(true);

        if (PlaySoundEffect && ToggleSound != null)
            ToggleSound.Play();

        IsFlashlightOn = true;
    }

    public void SwitchOff(bool PlaySoundEffect = true) {
        if (FlashlightMaterial != null)
            FlashlightMaterial.DisableKeyword("_EMISSION");

        if (FlashlightLight != null)
            FlashlightLight.gameObject.SetActive(false);

        if (PlaySoundEffect && ToggleSound != null)
            ToggleSound.Play();

        IsFlashlightOn = false;
    }
}
