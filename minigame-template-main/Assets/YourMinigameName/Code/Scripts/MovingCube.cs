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
            if(falling == false)
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

        public IEnumerator StartFalling( float indicationTime )
        {
            activated = true;
            GetComponent<MeshRenderer>().material = FallingMaterial;
            yield return new WaitForSeconds( indicationTime );
            falling = true;
        }

        public bool IsActivated()
        {
            return falling || activated;
        }

        private bool falling = false;
        private bool activated = false;
    }
}
