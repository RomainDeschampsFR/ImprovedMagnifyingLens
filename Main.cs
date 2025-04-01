using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection; 
using System.Collections;

namespace ImprovedMagnifyingLens
{
	public class Main : MelonMod
	{
		public override void OnInitializeMelon()
		{
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
        }

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{

        }
    }
}