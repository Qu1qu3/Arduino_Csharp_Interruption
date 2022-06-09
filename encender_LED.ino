const int ledPIN = 2;

const int EchoPIN = 5;
const int TriggerPIN = 6;

//Añadir los ultrasonidos y cuando se detecte a menos de X
//encender LED

//X = external input from keyboard

void setup() {
  Serial.begin(9600);
  pinMode(ledPIN, OUTPUT);

  pinMode(TriggerPIN, OUTPUT);
  pinMode(EchoPIN, INPUT);
}

void loop() {

  int cm = ping();
  Serial.print("Distancia: ");
  Serial.println(cm);

  if (cm <= 10 ){
    digitalWrite(ledPIN, HIGH);
  }else{
    digitalWrite(ledPIN, LOW);
  }
  delay(750);
  
}

int ping(){
  long duration, distanceCM;

  digitalWrite(TriggerPIN, LOW);
  delayMicroseconds(4);
  digitalWrite(TriggerPIN, HIGH);  //generamos Trigger (disparo) de 10us
  delayMicroseconds(10);
  digitalWrite(TriggerPIN, LOW);
  
  duration = pulseIn(EchoPIN, HIGH);  //medimos el tiempo entre pulsos, en microsegundos
  
  distanceCM = duration * 10 / 292/ 2;   //convertimos a distancia, en cm
  return distanceCM;
}
