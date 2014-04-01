PiBot
=====

Google chat Bot to interact with Raspberry Pi

Description
===========

The idea is to create a Socially Aware IOT device. The Bot runs on the Pi . The Bot has it's own google account and Google plus page. It communicates with the user via Google Hangout Chat. User can issue commands via Chat to control the Pi's GPIO.

The Bot is develop in C# and runs on the Pi over mono runtime.
Bot uses XMPP (agsxmpp-sdk) to commuicate with the google chat server. It also uses WebIOPi to interface with the Pi's GPIO.

Links
=====

1. XMPP lib can downloaded from : http://www.ag-software.net/agsxmpp-sdk/
2. usefull blog to install mono on Pi : http://logicalgenetics.com/raspberry-pi-and-mono-hello-world/
3. WebIOPi : https://code.google.com/p/webiopi/

Commands
========
1. Hi >> Hello there!! How are you !!!
2. is the light on>> yes/on ( depends on if the GPIO is active or not)
3. turn on the light>>(de-activates GPIO 4)
4. turn off the light>>(activates GPIO 4)

How to Use
==========

1. Create or use an existing Google account for the Bot.
2. Change the details in the Config.cs.
3. Build !!! Fire it up!!!!

To Do
=====
1. Make the Bot update status message on its G+ or facebook page.
2. Bot posts pics from the Pi's plugged in Camera.
3. Facebook chat support.

