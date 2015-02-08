# Unlimited Bullet Festival

A scripting language for bullets in video games.



In UBF, bullets move according to rotation and speed. By writing lines in the UBF script file, you can create intricate and beautiful bullet patterns without clutter.
```
//categorizes the script.
category bullet

//set sprite, loaded as texture2d from assets/sprites/resources
sprite card

//set: sets a value
//values are: angle, size, speed, x, y
set angle 10

//add: adds to a value
add x 10

//delay: delays the thread
delay 2

//make: instantiates a new UBF object w/ speed and rotation
make firebullet 3 270

//effect: play an effect
effect bigcircle

//clear: clears all bullets
clear
```

Looping is a bit more complicated. 
```
loop 4,make firebullet 3 10,modify 0 1,0.5
```
The above code will make 4 `firebullet` bullets with speed 3 and rotation 10. However, each bullet's speed and rotation are incremented by the `modify` values respectively. Each bullet will delay 0.5 seconds before creating itself. In the above example:

 1. firebullet with speed 3 and rotation 10 at time 0
 2. firebullet with speed 3 and rotation 11 at time 0.5
 3. firebullet with speed 3 and rotation 12 at time 1
 4. firebullet with speed 3 and rotation 13 at time 1.5

By default, the script will wait for the loop to complete before continuing. To perform the loop as a seperate thread and go to the next command while the loop is still going, simply add `nodelay` as a fifth parameter

    loop 4,make firebullet 3 10,modify 0 1,0.5,nodelay



Cutscenes are simple compared to the loop stuff. Cutscenes will pause the game and display the given message until the user presses the fire key.
```
cutscene I-am-the-hero
```
The above code would result in "I am the hero" displaying. Make sure to use dashes instead of spaces when delcaring the cutscene string.


**Examples**

Here's a simple bullet that moves downwards for one second, then speeds up.

    category bullet
    set speed 5
    set rotation 270 //this points down
    delay 1
    add speed 5
  
  To make bullet patterns such as circles, often a spawner bullet is used in order to create the pattern.

    //CODE FOR SPAWNER
    category spawner

	//we don't want the spawner to move
    set speed 0 

	//loop to create a circle
    loop 120,make regular 3 0,modify 0 3,0.5

	//destroy itself when done
	destroy

Save this as circlespawner.ubf, for example, and anytime you want to create a circle of bullets, simply call `make circlespawner 0 0`.

   

