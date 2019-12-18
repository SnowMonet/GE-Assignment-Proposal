# GE-Assignment
Game Engines Assignment --- C16409712


# Proccess

I first created a new script called AudioData. This script was used to run an AudioSource and spawn and manipulate prefabs based on that AudioSource. I created an empty GameObject and attatched the script to it. 
I used RequireComponent to attach an AudioSource to this empty GameObject. I used GetSpectrumData to recieve the data from this AudioSource, which takes the 3 values of samples, channel and FFTWindow. After testing I decided on 256 samples, and used audio channel 0. I was unsure what FFTWindow was used for, so after reading guides I decided to use the "Blackman" FFTWindow type, as I read that it was the most stable and effective.
I created a new script, InstantiateCubes, and attached it to a new empty GameObject. I created an GameObject array of 256 (same number as samples) and attached a cube prefab to it. In void Start, I instantiated the starting positions and sizes for the cubes. I used a for loop to instantiate the 256 cubes. I wanted the cubes to be instantiated in a circle, so I used divided 360 degrees by the number of cubes I was using (360 / 256 = 1.40625) and processed this number through an eulerAngles statement. But the cubes were still all in the center of the enpty GameObject, so I multiplied their newly-rotated Vector3.forward values by a new value (100 worked best). In void Update, I would manipulate the scale of the cubes based on the AudioSource. I made a new for loop for the cubes, through which I passed a transform.localScale statement for the cubes, changing their Y axis scale based on the audio samples extended from the AudioData script. This didn't quite create the result I was looking for, as the cubes did not increase in size by much, so I multiplied their new Y scale by another value (maxScale) to increase the overall visual impact the audio had on the cubes.
What I had now was a circle of cubes. The cubes were heavily impacted by the music at one point on the circle, which gradually lessened in impact as you moved aroundthe circle. This didn't quite look how I wanted it to, so I created a new empty GameObject and attached the same InstantiateCubes script to it. Both empty GameObjects now did the exact same thing, so I changed the eulerAngles value on one of the GameObjects from 1.40625 to -1.40625. This meant that this second GameObject instantiated cubes going in the opposite direction, creating a mirror-like effect between the two GameObjects.

For the tangental circles beneath the cubes, I created a quad GameObject and attached the material of a circle.png. I then saved this new circle asset as a prefab and deleted it from the scene. I made a new TangentCircles script and passed through a public GameObject, on which I attached this new circle prefab. I then made 2 more private GameObjects called innerCircle anf outerCircle. These wouldbe used to created the two main cricles, between whichmore tangental circles would be instantiated. I created a public Vector4 for both circles, which would give me values of X, Y, and Z (positional coordinates) as well as a W value (for circle scale). I input the scale of the outerCircle to 100, so it fit snugly inside the cubes. I set the innerCircle scale temporarily to 20, but this would change later as I wanted to have it scale with audio instead. 
I created a new script (CircleTangents) which would be used to instantiate a number value of circle prefabs that would remain tangent to both the inner and outer circles at all times.

For the lighting in the scene, I created a new LightAudio script, which would manipulate the insensity value of the directional lights with the AudioSource. I used 3 different colors of directional lights (2 purple, 1 blue and 1 red) and each color was linked to a different frequency band. This meant that the different colors of lights were affected by different bands of the AudioSource, creating a nice strobe lightshow effect.


# What Worked Best
I am very happy with the colors and lighting in the scene. The changing intensity of the lighting works well with the music, and provides good feelings of excitement during intense music, and feelings of calm during more mellow parts of the music. I really enjoy the harmony of the blue and purple colors, and it results in the exact neon feel I wanted.


# Useful Resources
The Unity online documentation manual were a great help during this project.They taught me a lot about how audio data is handled in Unity and C# and as well as useful ways to manipulate it.
Another big help was a series of tutorial videos by Peer Play on YouTube. Many of the effects utilized in my projects were created by combining and mixing different techniques I learned from these videos.


# YouTube Link
<a href="http://www.youtube.com/watch?feature=player_embedded&v=X8__wfXemKE
" target="_blank"><img src="http://img.youtube.com/vi/X8__wfXemKE/0.jpg" 
alt="Audio Visualization" width="1280" height="720" border="10" /></a>
