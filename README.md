# ImmuneVR
Watch the [video](https://youtu.be/w4dUdweV7QM)!

![In-game screenshot](https://www.dropbox.com/s/9iwhjh1o9ibeam1/mini.jpg?dl=0&raw=1)

This study evaluates the ability of a gamified educational
Virtual Reality simulation to complement traditional teaching
and convey information in a multimodal way (visual
and auditory). The simulation was designed to distribute
simplified knowledge of the human immune system and vaccination,
with the overarching issue being raising awareness
on vaccine safety and importance. The simulation was evaluated
in-situ at a local school in Denmark with 20 grade
school pupils from two classes and found, on average, a 9%
knowledge improvement after the VR experience.

# Guide

*The following is a guide on how to set up our prototype game "ImmuneVR". If you have any questions regarding anything in this document, please reach out to us as soon as possible!*

## Prerequisites

Please start by making sure you have the latest graphics drivers for your system. How to check and update this depends on the manufacturer of your computer:

- For Nvidia, refer to [this site](https://www.nvidia.com/en-in/drivers/nvidia-update/).
- For AMD, refer to [this site](https://www.amd.com/en/support).

Next, please download our game from our [releases page](https://github.com/turtle-masters/p7-prototype/releases) on the GitHub repo (you specifically need to download and extract the *“p8v1gold.zip”* file).

## Installing Oculus Link

To be able to run the prototype, you will first need to install [Oculus Link](https://www.oculus.com/setup/), enabling the connection between your computer and the virtual reality headset.

Note that you must download and install the version of the software that is intended for your specific headset. You can find software for the Oculus Quest 2 and Oculus Rift S [here](https://www.oculus.com/setup/).

For the software to work, you must sign in through a Facebook account. We cannot provide you with one, but you should be able to use any existing account.

Once you’re signed in, you just need to have the software open and plug in the headset with the Oculus Link Cable.

## Installing SteamVR

Our solution is built on [SteamVR](https://www.steamvr.com/en/), a virtual reality framework built on the OpenVR standard, made to support a very broad set of virtual reality equipment.

To get SteamVR, you must first download and install Steam, [this site](https://www.steamvr.com/en/) will guide you through the process. If you do not already have Steam installed, the site will redirect you to the [steam download page](https://store.steampowered.com/about/).

When you have Steam installed, you must create an account or log in to an existing one. We will not be able to provide you with an account, but it is free to create one.

Once you’re signed in to your Steam account on the client, please download SteamVR through [this link](https://www.steamvr.com/en/).

## Running the prototype for the first time

Once you have SteamVR installed, you...

1. Make sure your PC is plugged in while running the simulation for best performance.
1. start up the Oculus Quest 2 (or the VR headset you are using),
1. plug it into your computer with the Oculus Link Cable,
1. launch SteamVR,
1. unzip the compressed file “p8v1gold.zip”,
1. open the uncompressed folder of the same name,
1. double-click on the “ImmuneVR” executable.

Our prototype should now launch through SteamVR and play through the Quest 2. Please verify that this is the case, then exit SteamVR again. The log files can be found in your `Documents` folder.

# Testing the game in the Unity Editor
Some of the unit tests make use of an [external c# library](https://drive.google.com/file/d/1dNN436832phPiDvM_Iat0k2AhkWbgTdm/view?usp=sharing), which you must download and put into the `Assets` folder for the project to compile.

The game has a DebugPlayer, which you can trigger when running the game in the Unity editor and pressing one of the WASD movement keys. When triggered, you can move around the level with said keys and look around with the mouse. To interact with object, hold fown F and point on the screen where you want to simulate a VR grabbing action (there is a range limit to this). When playing through the game in this mode, Tasks related to moving objects around the scene are skipped.
