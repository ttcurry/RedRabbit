/*
Receives the axis of the trigger based on press.
*/
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SteamVR")]
    [Tooltip("Sends an Event when a Trigger Button is pressed.")]
    public class GetTriggerAxis : FsmStateAction
    {
        [Tooltip("Controller set to Trigger.")]
        [CheckForComponent(typeof(SteamVR_TrackedObject))]
        public FsmOwnerDefault controller;

        SteamVR_Controller.Device device;
        SteamVR_TrackedObject trackedObj;

        [Tooltip("Axis values are in the range -1 to 1. Use the multiplier to set a larger range.")]
        public FsmFloat multiplier = 1;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Store the result in a float variable.")]
        public FsmFloat store;

        public override void Reset()
        {
            multiplier = null;
            store = null;
        }
        public override void OnEnter()
        {
            GameObject go = Fsm.GetOwnerDefaultTarget(controller);
            trackedObj = go.GetComponent<SteamVR_TrackedObject>();

        }
        public override void OnUpdate()
        {
            var i = -1;
            if ((int)trackedObj.index > i++)
            {
                device = SteamVR_Controller.Input((int)trackedObj.index);

                //var axisValue = device.GetAxis(SteamVR_Controller.ButtonMask.Trigger);
                var axisValue = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);

                // if variable set to none, assume multiplier of 1
                if (!multiplier.IsNone)
                {
                    axisValue *= multiplier.Value;
                }

                store.Value = axisValue.x;
            }
            
        }
    }
}