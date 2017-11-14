
//Part 1////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

1. Once package is downloaded, drag unitypackage into your Unity Editor (2017).

//end of Part 1///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//The bulk of this part of the readme is derived from: https://github.com/kevinta893/Unity360Video
//Part 2/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


A tree planting simulation project that has NetworkIt combined with 360 Video and Google Cardboard. Requires Unity 2017 or higher.

## How to Use
Some setup is required when you import this project. 

To change the 360 video, see notes from: [kevinta893/Unity360Video](https://github.com/kevinta893/Unity360Video)

### Project setup
To run all three pieces together, you will need to setup your *Player Settings* (PC, Android, iOS):
* All platforms:
  * Other Settings > Api Compatibility Level = **.NET 2.0**
  * XR Settings > Virtual Reality Supported = **Checked**, and add Cardboard to the list

* Android:
  * Other Settings > Minimum API Level = **Android 4.4 (API level 19)**

### Prefabs
Use the following Prefabs to add 360+Cardboard functionality to your projects
* **Cardboard360Camera** - A prefab that adds a 360 Video player and GVR reticle. You can change your video here.
* **GvrTriggerObject** - A prefab that has an EventTrigger component for the GVR reticle. Use this to add GVR Clickable objects.

### NetworkItUnity
The library for NetworkItUnity is the same. Refer to the [NetworkItUnity](https://github.com/kevinta893/NetworkIt/tree/master/NetworkItUnity) folder for more information on how to use.

## Libraries Used
* [googlevr/gvr-unity-sdk (v1.100.1)](https://github.com/googlevr/gvr-unity-sdk)
* [Unity-Technologies/SkyboxPanoramicShader](https://github.com/Unity-Technologies/SkyboxPanoramicShader)
* [kevinta893/Unity360Video](https://github.com/kevinta893/Unity360Video)

//End of Part 2////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Part 3///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
1. In the Assets folder, open up the Scenes folder.
2. Double click the fire scene and hit play. This is the first scene of the project.
3. In the Build Settings, check the open scenes and make sure the first scene is the fire scene. (noted by a "0" on the right hand side of panel)
	Make sure all the scenes in the scene folder are in the build settings.
4. To run on your phone, Go to File > Build Settings > Build and Run. 
	Make sure you have a data cable attached from your laptop to your phone, 
	and that USB Debugging is available on your phone. 
	
//End of Part 3//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




//end of Part 3////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


