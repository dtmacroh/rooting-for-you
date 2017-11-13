
//The first part of this readme is derived from: https://github.com/kevinta893/Unity360Video
//Part 1/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Unity Skybox 360 Video Player

A very basic 360 video implementation and demo. Uses a SkyBox rendering technique. Compatiable with Unity 2017 only.

Uses the Skybox Panoramic shader by Unity-Technologies

(Old Sphere Method) 360 Video Player in Unity, By: DominiqueLrx https://forum.unity3d.com/threads/playing-360-videos-with-the-videoplayer.461290/

Sample 360 Videos by: https://www.mettle.com/360vr-master-series-free-360-downloads-page/

How to use

To use, simply use the Main Camera prefab which has the Video Texture for the 360 Skybox made for you.

See MainCamera/360 Video Player gameobject to change the video being played
See Rendering/360VideoRenderTexture.renderTexture file to change the resolution of the video file to be played. This render texture must match the video's resolution.
Troubleshooting:

If you don't see anything in the windows preview, make sure your graphics card supports the correct DirectX API. Otherwise use only DX9 in the Unity editor
//End of Part 1////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



