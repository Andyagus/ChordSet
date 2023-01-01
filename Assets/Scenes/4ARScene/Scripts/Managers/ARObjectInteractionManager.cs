using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ARObjectInteractionManager : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARPlacementInteractable placementInteractable;    
    [SerializeField] private ARGestureInteractor gestureInteractor;
    
    private bool _objectPlaced;
    
    // ReSharper disable once InconsistentNaming
    [SerializeField] private GameObject _ARKeyboard;

    private void Awake()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs obj)
    {
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

    public void ObjectExited(SelectExitEventArgs eventArgs)
    {
        var interactableObj = eventArgs.interactableObject;
        var objTransform = interactableObj.transform;
        
        gestureInteractor.enabled = false;
        objTransform.gameObject.SetActive(false);
        
        //instantiate new game obejct at the position of interactable object

        var keyboard = Instantiate(_ARKeyboard, objTransform.position, objTransform.rotation, objTransform.parent);
    }
    
}
