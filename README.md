# Handle Arduino LED with interruption system

The file .ino contains the code to upload on your Arduino board.
It is important that the button may be connected to other pin dependind on the Arduino model you use.
In my case the "intPin" is connected to the pin number 2.
Finally, the "emuPin" is the pin where the external LED must be connected, this is the LED that will be turned on and turned off.
Just in case you do not have any LED you can change that pin to the internal LED of the board.

The C# code is developed in Visual Studio Enterprise 2022. Before the use of it, you have to change the PortName in order to coincide
with the port that the Arduino board is connected, otherwise an exception will be raised and the application will close.

This is an image of the application when started and the LED is OFF.

![imagen align="center"](https://user-images.githubusercontent.com/57369001/177553799-96ef245b-8a6c-4644-a872-698e86c19a62.png)

When the button is pressed and the LED is turned ON, the button on the interface changes and shows how the LED is ON.

![imagen](https://user-images.githubusercontent.com/57369001/177555044-a6a80492-8310-4de0-a054-7eb937ce81b3.png)

When pressing the exit button, this window appear to confirm.

![imagen](https://user-images.githubusercontent.com/57369001/177556021-92a41702-294e-4dd5-ba7a-5aa5c5bcbb67.png)

