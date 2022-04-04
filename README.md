# MAG-Intern-Project
 A matching game in the style of Toon Blast.
 
# Known Issues:
 - Popping a tile is still possible even if the game is paused. This will update the score accordingly, although the board will be cleared and refilled only after resuming the game. 
 
 For the sake of my own sanity, below is a fix to the issue described above. I just want to let whoever is going to asses my work know that I am aware of this, but since I am past the deadline, I will not push the fix until my work has been assessed.
 - Fix: Make the variable pauseIsClicked inside PauseMenu public static. Inside tile, OnMouseDown(), add PauseMenu.pauseIsClicked || inside the IF statement.
   This is a quick and dirty fix.

# References:
 - Toon Blast - https://play.google.com/store/apps/details?id=net.peakgames.toonblast&hl=en_GB&gl=US
 - https://www.youtube.com/watch?v=PE1GLtgbMR0
 - https://www.youtube.com/watch?v=9i_sktmLg30
