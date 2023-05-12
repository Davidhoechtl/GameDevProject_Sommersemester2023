using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.YourMinigameName.Code.Scripts
{
    public class MovingCube : MonoBehaviour
    {
        public Material StationaryMaterial;
        public Material FallingMaterial;

        public float FallingSpped = 10;
        public float YFallingBound = -10;
        public float YNormalPosition;

        private void Start()
        {
            YNormalPosition = transform.position.y;
        }

        private void Update()
        {
            if(activated == false)
            {
                return;
            }

            float travellingDistance = FallingSpped * Time.deltaTime;

            if (falling)
            {
                if (transform.position.y - travellingDistance < YFallingBound)
                {
                    transform.position = new Vector3(transform.position.x, YFallingBound, transform.position.z);
                    falling = false;
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

                    activated = false;
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + travellingDistance, transform.position.z);
                }
            }
        }

        public IEnumerator StartFalling( float waitingTime )
        {
            activated = true;
            GetComponent<MeshRenderer>().material = FallingMaterial;
            yield return new WaitForSeconds( waitingTime );
            falling = true;
        }

        public bool IsActivated()
        {
            return activated || falling;
        }

        private bool falling = false;
        private bool activated = false;
    }
}
