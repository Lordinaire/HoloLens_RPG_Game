using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Helpers
{
    public class SpawnCorrector : NetworkBehaviour
    {
        [SyncVar]
        public Vector3 Scale;

        //[SyncVar]
        //public Quaternion Rotation;

        void Start()
        {
            transform.localScale = Scale;
            //transform.localRotation = Rotation;
        }
    }
}