using Normal.Realtime;
using Normal.Realtime.Serialization;
using Normcore;
using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keyboard;

namespace Scenes._2Normcore.Scripts
{
    /// <summary>
    /// The KeySync Dictionary receives keys and serializes it into a Normcore dictionary
    /// And then passes to the AR Keyboard. 
    /// </summary>
    
    public class KeySyncDictionary : RealtimeComponent<KeySyncDictionaryModel>
    {
        //Intentionally keeping naming of ARKeyboard <- Recognizing breaking naming convention but Emphasizing AR. 
        private ARKeyboard _ARKeyboard;

        private void Start()
        {
            _ARKeyboard = FindObjectOfType<ARKeyboard>();
        }
        
        protected override void OnRealtimeModelReplaced(KeySyncDictionaryModel previousModel, KeySyncDictionaryModel currentModel)
        {
            currentModel.realtimeDictionary.modelReplaced += OnModelReplaced;
           
        }
        
        //When the dictionary changes, passing it to AR Keyboard 
        private void OnModelReplaced(RealtimeDictionary<KeySyncModel> dictionary, uint key, KeySyncModel oldmodel, KeySyncModel newmodel, bool remote)
        {
            //Need to access keyboard again here, because in AR it is instantiated after this Start() is called.
            if (_ARKeyboard == null)
            {
                _ARKeyboard = FindObjectOfType<ARKeyboard>();
            }
            
            //TODO: Refactor - Make this an event instead of a direct call.
            _ARKeyboard.OnKeyDictionaryReceived(model.realtimeDictionary);
        }
        
        public void CreateDictionary(InputKey inputKey)
        {
            var key = new KeySyncModel
            {
                keyName = inputKey.KeyName,
                keyState = inputKey.keyState
            };
            if (!model.realtimeDictionary.ContainsKey((uint)inputKey.KeyCode))
            {
                model.realtimeDictionary.Add((uint)inputKey.KeyCode, key);
            }
        }

        //Updating Dictionary each time key is pressed
        public void SetDictionary(InputKey inputKey)
        {
            var key = new KeySyncModel
            {
                keyName = inputKey.KeyName,
                keyState = inputKey.keyState
            };

            if (model.realtimeDictionary.ContainsKey((uint)inputKey.KeyCode))
            {
                model.realtimeDictionary[(uint)inputKey.KeyCode] = key;
            }

        }
    
    }
}
