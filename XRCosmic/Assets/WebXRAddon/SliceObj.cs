using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceObj : MonoBehaviour
    {
        public GameObject slicedObjs;
        public Transform startPoint;
        public Transform endPoint;
        public VelocityEstimator velocityEstimator;
        public LayerMask layerMask;
        // Start is called before the first frame update
        void Start()
        {
            gameObject.GetComponent<AudioSource>().Pause();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            bool hasHit = Physics.Linecast(startPoint.position, endPoint.position, out RaycastHit hit, layerMask);

            if (hasHit)
            {
                GameObject target = hit.transform.gameObject;
                Slice(target);
            }
        }

        public void Slice(GameObject target)
        {
            gameObject.GetComponent<AudioSource>().Play();

            Vector3 velocity = velocityEstimator.GetVelocityEstimate();
            Vector3 planeNormal = Vector3.Cross(endPoint.position - startPoint.position, velocity);
            planeNormal.Normalize();

            SlicedHull hull = target.Slice(endPoint.position, planeNormal);

            if (hull != null)
            {
                Vector3 vector = target.transform.position;

                GameObject upperHull = hull.CreateUpperHull(target);
                upperHull.transform.parent = gameObject.transform.parent.gameObject.transform;
                SlicedComponent(upperHull, vector);

                GameObject loverHull = hull.CreateLowerHull(target);
                loverHull.transform.parent = gameObject.transform.parent.gameObject.transform;
                SlicedComponent(loverHull, vector);
            }

            Destroy(target);
    }

        public void SlicedComponent(GameObject slicedObj, Vector3 vectorTarget)
        {
            slicedObj.transform.position = vectorTarget;
            slicedObj.transform.parent = slicedObjs.transform;
            slicedObj.tag = "Interactable";
            slicedObj.layer = LayerMask.NameToLayer("Sliceble");
            slicedObj.AddComponent<Rigidbody>();
            MeshCollider collider = slicedObj.AddComponent<MeshCollider>();
            collider.convex = true;
        }
    }
