using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AR;

namespace Scenes._3MobileAR.Scripts.Managers
{
    /// <summary>
    /// Using  AR Foundation and XR Interaction Toolkit for placing keyboard in real-world environment 
    /// </summary>
    public class ARObjectInteractionManager : MonoBehaviour
    {
        [SerializeField] private ARPlaneManager planeManager;
        //placement reticle for seeing where keyboard will appear before placing 
        [SerializeField] private ARPlacementInteractable placementInteractable;    
        [SerializeField] private ARGestureInteractor gestureInteractor;
        
        private bool _objectPlaced;
        [SerializeField] private GameObject _ARKeyboard;

        //Keeping event in-case needed for future
        // public Action onKeyboardInstantiated;
    

        private void Awake()
        {
            planeManager.planesChanged += OnPlanesChanged;
        }

        private void OnPlanesChanged(ARPlanesChangedEventArgs obj)
        {
            //once object is placed don't add any more visible trackables
            if (_objectPlaced)
            {
                foreach (var trackable in planeManager.trackables)
                {
                    trackable.gameObject.SetActive(false);
                }
            }
        }

        public void PlacedObject(ARObjectPlacementEventArgs eventArgs)
        {
            placementInteractable.enabled = false;
            _objectPlaced = true;
        
            foreach (var trackable in planeManager.trackables)
            {
                trackable.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// After selecting and positioning the object, on exit, instantiate the ARKeyboard
        /// </summary>
        public void ObjectExited(SelectExitEventArgs eventArgs)
        {
            var interactableObj = eventArgs.interactableObject;
            var objTransform = interactableObj.transform;
        
            gestureInteractor.enabled = false;
            objTransform.gameObject.SetActive(false);
            Instantiate(_ARKeyboard, objTransform.position, objTransform.rotation, objTransform.parent);
        }
    
    }
}
