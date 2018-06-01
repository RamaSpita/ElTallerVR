using UnityEngine;
using System.Collections;

public class WandController : SteamVR_TrackedController
{ 
    //Velocidad del control
    public Vector3 velocity { get { return controller.velocity; } }
    //Velocidad angular del control
    public Vector3 angularVelocity { get { return controller.angularVelocity; } }

    //0->1 Que tan presionado esta el trigger
    public float GetTriggerAxis()
    {
        if (controller == null)
            return 0;

        return controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis1).x;
    }

    //Donde esta presionado el pad.
    //(0,0) El centro.
    //(1,1) Derecha arriba.
    //(-1,-1) Izquierda abajo.
    public Vector2 GetTouchpadAxis()
    {
        if (controller == null)
            return new Vector2();

        return controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
    }

    //Activa un pulso de una cierta dutacion
    public void Pulse(ushort microseconds)
    {
        SteamVR_Controller.Input((int)controllerIndex).TriggerHapticPulse(microseconds);
    }

    /// <summary>
    /// Vibra el control.
    /// </summary>
    /// <param name="force">Fuerza de vibracion. 0 a 3999.</param>
    /// <param name="time">Tiempo de vibracion.</param>
    /// <param name="times">Cantidad de veces que vibra.</param>
    /// <param name="timeGap">Tiempo entre vibraciones.</param>
    public void Vibrate(ushort force, float time, int times, float timeGap = 0.2f)
    {
        StopAllCoroutines();
        StartCoroutine(VibrateTimes(force, time, times, timeGap));
    }

    #region Private Stuff

    protected SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)controllerIndex); } }

    private IEnumerator VibrateTimes(ushort force, float time, int times, float timeGap)
    {
        int t = 0;
        while (t < times)
        {
            StartCoroutine(StartVibrating(force, time));
            t += 1;
            yield return new WaitForSeconds(time + timeGap);
        }
    }

    private IEnumerator StartVibrating(ushort force, float time)
    {
        float t = 0;
        while (t < time)
        {
            t += Time.deltaTime;
            Pulse(force);
            yield return new WaitForFixedUpdate();
        }
    }
    
    #endregion

}