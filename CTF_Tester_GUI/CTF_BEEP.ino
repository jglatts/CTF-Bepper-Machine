/*
   Test each trace of the CTF unit and display it on LCD
   Please see UPDATES.txt

   @author: John G
*/
#include <SPI.h>
#include <Wire.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

/* Mega2560 Defines */
#define FLEX_SIZE   6  
#define NUM_PINS    54
#define INPUT_PIN   22 
#define TEST_PIN    8
#define TEST_PIN_2  10
#define TEST_SIZE   300
#define ALOG_PIN    A0

/* LCD and CTF Data */
Adafruit_SSD1306 display(128, 32, &Wire, -1);
String errorMsg = "";
int pin = 1, val, FLEX_TRACES;
bool short_check, continunity_check;

void setup() {
  Serial.begin(9600);
  pinMode(INPUT_PIN, INPUT);
  for (int i = 2; i < 12; ++i) pinMode(i, OUTPUT);
}

/* Only test a few pins */
void simpleTest() {
  pinMode(TEST_PIN, OUTPUT);
  pinMode(TEST_PIN_2, OUTPUT);
  while (1) {
    checkPin(TEST_PIN);
    delay(600);
    checkPin(TEST_PIN_2);
    delay(600);
  } 
}

/* Testing the log() and error msgs */
void anotherTest() {
  pinMode(TEST_PIN, OUTPUT);
  pinMode(TEST_PIN_2, OUTPUT);
  for (int i = 0; i < TEST_SIZE; ++i) {
    checkPin(TEST_PIN);
    delay(600);
    checkPin(TEST_PIN_2);
    delay(600);
  }
}

/* 
  Drive the pin(trace) high and check the buzzer went off 
  @param p, the pin to test 
*/
void checkPin(int p) {
  // break this up
  digitalWrite(p, HIGH);
  Serial.print(" Trace #");
  Serial.print((p == TEST_PIN) ? "1" : "2");
  if (digitalRead(INPUT_PIN) == HIGH) {
    Serial.println(" has PASSED.");
  }
  else {
    Serial.println(" has FAILED.");
    logError(p);
  }
  Serial.println("\n\n8bit Value: ");
  Serial.println(convertVal(analogRead(ALOG_PIN)));
  delay(500);
  digitalWrite(p, LOW);
  delay(5); // 5 us delay with pin LOW
}

/* Begin the full test, testing each pin */
void startFullTest() {
  //display.begin(SSD1306_SWITCHCAPVCC, 0x3C);
  //display.setTextSize(2);
  //display.setTextColor(SSD1306_WHITE);
  //display.clearDisplay();
  testTraces();
}

/* Test each trace, tweak this */
void testTraces() {
  int count = 1;
  for (int i = 2; i < 12; ++i) {
    Serial.print("Pin Number: ");  // add trace #info
    Serial.print(count++);
    Serial.println(checkTrace(i) ? " Passed\n" : " Failed\n");
    digitalWrite(i, LOW);
    delay(700);
  }
}

/* Check the individual pin and return status of buzzer */
bool checkTrace(int i) {
  digitalWrite(i, HIGH);
  delay(700);
  //convertVal(analogRead(ALOG_PIN));
  return digitalRead(INPUT_PIN);
}

/* Convert the analong read to a 8bit value */
int convertVal(int v) {
  val = map(v, 0, 1023, 0, 255);
  return val;
}

/* 
  Display info regarding the test on LCD
  @param s, the string to display
  @param i, the pin number
 */
void displayInfo(String s, int i) {  
  //display.clearDisplay();
  Serial.print("Trace = ");
  Serial.println(s);
  //display.print("8Bit Value = ");
  //display.println(val);
  //display.display();
  //delay(1000);
  //display.clearDisplay();
  if (s == "Failed") logError(i);
}

/* Create an error message containing all failed traces */
void logError(int i) {
  errorMsg += "\nPin # ";
  errorMsg += i-1;
  errorMsg += " has failed\n";
  //errorMsg += "8bit Value: ";
  //errorMsg += val;
} 

/* Display the error messgae on LCD and Serial */
void displayErrorLog() {
  //display.clearDisplay();
  //display.setTextSize(2);
  //display.println(errorMsg);
  Serial.println(errorMsg);
}

void loop() {
	if (Serial.available() > 0) {
		int v = Serial.read();
		if (v < 100) FLEX_TRACES = v;
		if (v == 200) continunity_check = true;
		if (v == 250) short_check = true;
		startFullTest();
	}
}
