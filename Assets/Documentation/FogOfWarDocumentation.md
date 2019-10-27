How to use the Fog of War/Limited Vision System:
By downloading the project, the custom rendering pipeline should already be in use, if not:
1. Download the Lightweight Render Pipeline from the Package Manager
2. In Project Settings > Graphics, put the LightweightRenderPipelineAsset into the Scriptable Render Pipeline Settings box.

Using it in your scene:
- Make sure the camera is rendering a solid black background.
- By default, all objects will be hidden unless revealed by objects on the "Reveal" or "Player<#>Light" layers.
- The objects that you want to hide should be on the "Target" (possibly temporary name) layer.
- It may be helpful to create a large cube on the "reveal" layer and put it below all of your objects.
If you work from a top-down perspective, everything should be visible within that box.
- If objects are being revealed but are still turning up black, they need to be lit by some light source.
- Make use of the Culling Mask property on cameras and lights. e.g. The camera following player 1 should have it so it sees the Walls, Player1, Player1Light, but not anything else.