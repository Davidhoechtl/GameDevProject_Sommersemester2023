
namespace Assets.YourMinigameName.Code.Scripts
{
    using System.Collections;
    using System.Net.Sockets;
    using UnityEngine;

    /// <summary>
    /// Adds movement functionality for a ground element (cube)
    /// </summary>
    public class MovingCube : MonoBehaviour
    {
        /// <summary>
        /// Material that indicates the Cube is not going to move
        /// </summary>
        public Material StationaryMaterial;

        /// <summary>
        /// Material that indicated the cube is going to move
        /// </summary>
        public Material FallingMaterial;

        /// <summary>
        /// Speed of Falling down and up
        /// </summary>
        public float FallingSpped = 10;

        /// <summary>
        /// Y Boundary how far the cube will go down
        /// </summary>
        public float YFallingBound = -10;

        /// <summary>
        /// Y Position that the gameobject has on its initialization
        /// </summary>
        public float YNormalPosition;
        /// <summary>
        /// Provides the propability in percent that a moving cube will not come back up and stay at the bottom
        /// This state is called Locked
        /// </summary>
        public float LockProbabilityInPercent = 4;

        private void Start()
        {
            YNormalPosition = transform.position.y;
        }

        private void Update()
        {
            if (falling == false || locked)
            {
                return;
            }

            float travellingDistance = FallingSpped * Time.deltaTime;

            if (activated)
            {
                if (transform.position.y - travellingDistance < YFallingBound)
                {
                    transform.position = new Vector3(transform.position.x, YFallingBound, transform.position.z);
                    activated = false;
                    LockWithProbability();
                    GetComponent<MeshRenderer>().material = StationaryMaterial;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - travellingDistance, transform.position.z);
                }
            }
            else
            {
                if (transform.position.y + travellingDistance > YNormalPosition)
                {
                    transform.position = new Vector3(transform.position.x, YNormalPosition, transform.position.z);
                    falling = false;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + travellingDistance, transform.position.z);
                }
            }
        }

        /// <summary>
        /// Coroutine that needs to be called for the Falling mechanic
        /// </summary>
        /// <param name="indicationTime"> time between indication and falling </param>
        public IEnumerator StartFalling(float indicationTime)
        {
            activated = true;
            GetComponent<MeshRenderer>().material = FallingMaterial;
            yield return new WaitForSeconds( indicationTime );
            falling = true;
            if (!locked)
            {
                activated = true;
                GetComponent<MeshRenderer>().material = FallingMaterial;
                yield return new WaitForSeconds(indicationTime);
                falling = true;
            }
        }

        /// <summary>
        /// Indicates wethever the cube is stationary (not falling or activated) or not
        /// </summary>
        public bool IsIdle()
        {
            return !falling && !activated;
        }
        private void LockWithProbability()
        {
            if (Random.Range(1, 100) <= 4)
            {
                locked = true;
                falling = false;
                activated = false;
            }
        }

        private bool locked = false;
        private bool falling = false;
        private bool activated = false;
    }
}
