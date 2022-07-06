//Evitar efecto rebote
const int threshTime = 200;
long startTime = 0;
bool turnOn = 0;

const int emuPin = 10;
//Pin that detects the interruption
const int intPin = 2;
volatile int state = LOW;

void handler(){
  if (millis() - startTime > threshTime){
    state = !state;
    turnOn = !turnOn;
    Serial.println(turnOn);
    startTime = millis();
  }
}

void setup() {
   Serial.begin(9600);
   pinMode(emuPin, OUTPUT);
   pinMode(intPin, INPUT);
   attachInterrupt(0, handler, RISING);
}

void loop() {
   //esta parte es para emular la salida
   digitalWrite(emuPin, state);
   delay(50);
   Serial.println(turnOn);
}
