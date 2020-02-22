int LED_BUILTIN = 32;
void setup() {
  pinMode (LED_BUILTIN, OUTPUT);
  Serial.begin(9600);
}
void loop() {
  Serial.print("Hello world.");
  digitalWrite(LED_BUILTIN, HIGH);
  delay(1000);
  digitalWrite(LED_BUILTIN, LOW);
  delay(1000);
  digitalWrite(11,HIGH);
  
}
