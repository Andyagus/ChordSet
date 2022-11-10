using System;
using Desktop;
using UnityEngine;
using Interfaces;

namespace Normcore
{
   public class MockNormcore : MonoBehaviour
   {
      public Subject normcoreModelUpdated;

      private void Awake()
      {
         normcoreModelUpdated = new Subject();
      }

      public void UpdateNormcoreModel(InputKey key)
      {
         normcoreModelUpdated.Notify(key);
      } 
   }
}
