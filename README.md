# Project Title

Name: Zijing Mu

Student Number: D17129502

Class Group: DT228


# Description of the project

this project is a 3D music visulisation. It is a big sphere consists of a circle formed by 128 3D cube objects and a sphere formed by 360  3D sphere objects. All the cube objects and sphere objects will deform as the music plays. the whole sphere will rotate around the axis and change the speed with the intensity of the music.  

# Instructions for use
run the project in the unity. All music sources are in the Audios folder. if user want to change music, please attach the music to the Audio script. if user want to cahnge the scale of the object, please change the value of the scale in the GenerateCubes class and GenerateSpheres class.  

# How it works
1. first get the spectrum data from the audio source, and divide the range of audible sounds into several parts.Then store them in the repective array. 
2. To generate a circle of 128 cubes, use trigonometric to calcuate the x,z coordinate of eachcube according to the angle.
3. To generate a sphere, also use trigonometric to calculate the x,z coordinate of each sphere accoording to the angle and make it shift along with the y axis.
4. use getSpectrumData function to make the circle and the sphere scale following the music according to how many the audio is divided into.
5. rotate the camera to make the whole object rotate.

# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference

| Class/asset | Source |
|-----------|-----------|
| GenerateSphere.cs | Self written |
| GenerateCubes.cs | Self written |
| Audios.cs | Modified from [reference](https://www.youtube.com/watch?v=0KqwmcQqg0s&list=PL3POsQzaCw53p2tA6AWf7_AWgplskR0Vo&index=3) |
| RotateCamera.cs | Self written |

# References
audio.cs: Self written

# What I am most proud of in the assignment
- The scripts look like clean. 

- The name of the classes and the comments are easy to understand

- Everything works fine and looks good.



# youtube url
https://youtu.be/T2ELRE5pS-Q
