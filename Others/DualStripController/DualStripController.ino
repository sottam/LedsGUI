/*
 Name:		DualStripController.ino
 Created:	25/02/2018 23:55:48
 Author:	Alonso
*/

#include "Arduino.h"
#include "StripModes.cpp"
#include <FastLED.h>

//======================= DEFINES =============================

//DIGITAL STRIP
#define DATA_PIN    13
#define LED_TYPE    WS2813
#define COLOR_ORDER GRB
#define NUM_LEDS    300
#define BRIGHTNESS  255

//ANALOG STRIP
// #define COMMOM_ANODE
#define RED_PIN   5
#define GREEN_PIN 18
#define BLUE_PIN  19

//----------------------------------------------------------------------
#define ACK									(0x06)
#define NAK									(0x15)

#define HANDSHAKE							(0xF1)
#define HANDSHAKE_ANSWER					(0xF2)

#define MESSAGE_START						(0xF0)

#define STRIP_DATA							(0x0F)

#define	DIGITAL_CHANGEMODE 					(0x01)
#define DIGITAL_CHANGEBRIGHT				(0x02)
#define DIGITAL_CHANGEINTERVAL				(0x03)
#define DIGITAL_CHANGECOLOR					(0x04)
#define DIGITAL_MUSICAL_PATTERN				(0x05)
#define DIGITAL_CUSTOM_PALETTE				(0x06)
#define DIGITAL_CUSTOM_PALETTE_PROPERTIES	(0x07)

#define ANALOG_CHANGEMODE 					(0x08)
#define ANALOG_CHANGEBRIGHT 				(0x09)
#define ANALOG_CHANGEINTERVAL 				(0x0A)
#define ANALOG_CHANGECOLOR					(0x0B)
#define ANALOG_MUSICAL_PATTERN				(0x0C)

#define MESSAGE_END							(0xF7)
//================================================================

//====================== VARIABLES ============================

byte digitalStaticColorRed = 255;
byte digitalStaticColorGreen = 255;
byte digitalStaticColorBlue = 255;

byte analogStaticColorRed = 255;
byte analogStaticColorGreen = 255;
byte analogStaticColorBlue = 255;

CRGBPalette256 musicalPalette;
CRGB BassIntensity;
CRGB MedioIntensity;
CRGB TrebleIntensity;

CRGB MusicalOutput;
byte b0 = 0;
byte b1 = 0;
byte b2 = 0;

CRGBPalette256 breathingPalette = CRGBPalette256(CRGB::Red, CRGB::Black, CRGB::Black, CRGB::Red,
	CRGB::Red, CRGB::Black, CRGB::Black, CRGB::Red,
	CRGB::Red, CRGB::Black, CRGB::Black, CRGB::Red,
	CRGB::Red, CRGB::Black, CRGB::Black, CRGB::Red);

CRGB analogPalette = CRGB(0, 0, 0);;

CRGB CustomColors[16];
byte SelectedCustomPalette;
CRGBPalette16 CustomPalette16;
CRGBPalette32 CustomPalette32;
CRGBPalette256 CustomPalette256;
TBlendType customBlend;
bool animated = false;
byte increment = 3;


// Useful Color Arrays ----------------------------------------------------------------
const byte lights[360] = { 0,   0,   0,   0,   0,   1,   1,   2,   2,   3,   4,   5,   6,   7,   8,   9,
11,  12,  13,  15,  17,  18,  20,  22,  24,  26,  28,  30,  32,  35,  37,  39,
42,  44,  47,  49,  52,  55,  58,  60,  63,  66,  69,  72,  75,  78,  81,  85,
88,  91,  94,  97, 101, 104, 107, 111, 114, 117, 121, 124, 127, 131, 134, 137,
141, 144, 147, 150, 154, 157, 160, 163, 167, 170, 173, 176, 179, 182, 185, 188,
191, 194, 197, 200, 202, 205, 208, 210, 213, 215, 217, 220, 222, 224, 226, 229,
231, 232, 234, 236, 238, 239, 241, 242, 244, 245, 246, 248, 249, 250, 251, 251,
252, 253, 253, 254, 254, 255, 255, 255, 255, 255, 255, 255, 254, 254, 253, 253,
252, 251, 251, 250, 249, 248, 246, 245, 244, 242, 241, 239, 238, 236, 234, 232,
231, 229, 226, 224, 222, 220, 217, 215, 213, 210, 208, 205, 202, 200, 197, 194,
191, 188, 185, 182, 179, 176, 173, 170, 167, 163, 160, 157, 154, 150, 147, 144,
141, 137, 134, 131, 127, 124, 121, 117, 114, 111, 107, 104, 101,  97,  94,  91,
88,  85,  81,  78,  75,  72,  69,  66,  63,  60,  58,  55,  52,  49,  47,  44,
42,  39,  37,  35,  32,  30,  28,  26,  24,  22,  20,  18,  17,  15,  13,  12,
11,   9,   8,   7,   6,   5,   4,   3,   2,   2,   1,   1,   0,   0,   0,   0,
0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,
0,   0,   0,   0,   0,   0,   0,   0 };

const byte HSVlights[61] = { 0,   4,   8,  13,  17,  21,  25,  30,  34,  38,  42,  47,  51,  55,  59,  64,
68,  72,  76,  81,  85,  89,  93,  98, 102, 106, 110, 115, 119, 123, 127, 132,
136, 140, 144, 149, 153, 157, 161, 166, 170, 174, 178, 183, 187, 191, 195, 200,
204, 208, 212, 217, 221, 225, 229, 234, 238, 242, 246, 251, 255 };

const byte HSVpower[121] = { 0,   2,   4,   6,   8,  11,  13,  15,  17,  19,  21,  23,  25,  28,  30,  32,
34,  36,  38,  40,  42,  45,  47,  49,  51,  53,  55,  57,  59,  62,  64,  66,
68,  70,  72,  74,  76,  79,  81,  83,  85,  87,  89,  91,  93,  96,  98, 100,
102, 104, 106, 108, 110, 113, 115, 117, 119, 121, 123, 125, 127, 130, 132, 134,
136, 138, 140, 142, 144, 147, 149, 151, 153, 155, 157, 159, 161, 164, 166, 168,
170, 172, 174, 176, 178, 181, 183, 185, 187, 189, 191, 193, 195, 198, 200, 202,
204, 206, 208, 210, 212, 215, 217, 219, 221, 223, 225, 227, 229, 232, 234, 236,
238, 240, 242, 244, 246, 249, 251, 253, 255 };

//==============================================================

//VariableEffects

//Digital Strip
CRGB leds[NUM_LEDS];
byte digitalRed = 0;
byte digitalGreen = 0;
byte digitalBlue = 0;

int digitalAngle = 0;
byte digitalPercent = 50;

float startIndex = 0;
int colorIndex = 0;

//snakeRainbow
int snake_control = 0;
int aux_control = 1;
int aux_cor = 1;
int cor_controle;
int snakeRed = 255;
int snakeGreen = 0;
int snakeBlue = 0;
CRGB cor_atual;

//Analog Strip
byte analogRed = 0;
byte analogGreen = 0;
byte analogBlue = 0;

int analogAngle = 0;
byte analogPercent = 50;
int analogPercentAux = 1;
byte random_count = 0; //analog random mode

byte analogMusicalRed = 0;
byte analogMusicalGreen = 0;
byte analogMusicalBlue = 0;

//---------------------------------------------------------------------


//digitalLedImplementation
byte digitalStripMode = 14;
byte digitalInterval = 5;//ms
byte digitalBrightness = 255; //max

//analogLedImplementation
byte analogStripMode = 0;
byte analogInterval = 10;//ms
byte analogBrightness = 255;//max

//=============================================================

byte MusMap(byte value, byte max)
{
	return map(value, 0, 255, 0, max);
}

void SetupBreathingPalette()
{
	CRGB CustomColor = CRGB(digitalStaticColorRed, digitalStaticColorGreen, digitalStaticColorBlue);

	breathingPalette = CRGBPalette256(CRGB::Black, CRGB::Black, CRGB::Black, CRGB::Black,
		CustomColor, CustomColor, CustomColor, CustomColor,
		CustomColor, CustomColor, CustomColor, CustomColor,
		CRGB::Black, CRGB::Black, CRGB::Black, CRGB::Black);
}

//======================== PresetedEffects =====================
void RainbowSnake();
void RealHSVRainbow_digital();
void PowerHSVRainbow_digital();
void SineWaveRainbow_digital();
void StaticColor_digital();
void Breath_digital();
void Musical_digital();
void Deactivated_digital();
void FullHSVRainbow_digital();
void FullHSVStripesRainbow_digital();
void Cloud_digital();
void Lava_digital();
void Ocean_digital();
void Forest_digital();
void Party_digital();
void Heat_digital();
void CustomPallete_digital();

void RealHSVRainbow_analog();
void PowerHSVRainbow_analog();
void SineWaveRainbow_analog();
void StaticColor_analog();
void Breath_analog();
void Musical_analog(); //do nothing, only listens to client application
void random_color_analog();
void Deactivated_analog();

//========================= Threads ====================================

TaskHandle_t Task1, Task2;
//SemaphoreHandle_t mutexDig,mutexAng;

 typedef void(*SimplePatternList[])();
//NEVER CHANGE ORDER. ONLY ADD BY THE END. HARDCODED ARRAY.
SimplePatternList digitalPatterns = {	RainbowSnake,					//0
										RealHSVRainbow_digital,			//1
										PowerHSVRainbow_digital,		//2
										SineWaveRainbow_digital,		//3
										StaticColor_digital,			//4
										Breath_digital,					//5
										Musical_digital,				//6
										Deactivated_digital,			//7

										FullHSVRainbow_digital,			//8
										FullHSVStripesRainbow_digital,	//9
										Cloud_digital,					//10
										Lava_digital,					//11
										Ocean_digital,					//12
										Forest_digital,					//13
										Party_digital,					//14
										Heat_digital,					//15
										CustomPallete_digital			//16
										};
int digitalPatternsSize = 17;

SimplePatternList analogPatterns = {	RealHSVRainbow_analog, 
										PowerHSVRainbow_analog, 
										SineWaveRainbow_analog, 
										StaticColor_analog, 
										Breath_analog, 
										Musical_analog, 
										random_color_analog,
										Deactivated_analog
										};
int analogPatternsSize = 8;
//ThreadsFunction
void DigitalLoop(void * parameter)
{
	//Serial.print(xPortGetCoreID());
	for (;;) {
		digitalPatterns[digitalStripMode % digitalPatternsSize]();
		if (digitalStripMode != 6)
			delay(digitalInterval);
		else
			delay(10);
	}
}

void AnalogLoop(void * parameter)
{
	//Serial.print(xPortGetCoreID());
	for (;;) {
		analogPatterns[analogStripMode % analogPatternsSize]();
		if (analogStripMode != 5)
			delay(analogInterval);
		else
			delay(10);
	}
}

int freq = 500;
int resolution = 8;

//========================= ARDUINO FUNCTIONS ========================

void setup() 
{
	Serial.begin(921600);

	ledcSetup(1, freq, resolution);
	ledcSetup(2, freq, resolution);
	ledcSetup(3, freq, resolution);
	ledcAttachPin(RED_PIN, 1);
	ledcAttachPin(GREEN_PIN, 2);
	ledcAttachPin(BLUE_PIN, 3);

	pinMode(2, OUTPUT);

	musicalPalette = RainbowColors_p;

	FastLED.addLeds<LED_TYPE, DATA_PIN, COLOR_ORDER>(leds, NUM_LEDS).setCorrection(TypicalLEDStrip);

	xTaskCreatePinnedToCore(
		DigitalLoop,
		"DigitalStripTask",
		1000,
		NULL,
		1,
		&Task1,
		0);

	delay(500);  // needed to start-up task1

	xTaskCreatePinnedToCore(
		AnalogLoop,
		"AnalogStripTask",
		1000,
		NULL,
		1,
		&Task2,
		0);
}

// here to process incoming serial data after a terminator received
void process_data(const byte * buffer)
{
	byte command = buffer[1];

	if (command == STRIP_DATA)
	{
		byte subCommand = buffer[2];
		byte ColorNum;

		switch (subCommand) {
			case DIGITAL_CHANGEMODE:
				digitalStripMode = buffer[3];
				Serial.write(ACK);
				break;

			case DIGITAL_CHANGEINTERVAL:
				digitalInterval = buffer[3];
				Serial.write(ACK);
				break;

			case DIGITAL_CHANGEBRIGHT:
				digitalBrightness = buffer[3] | (buffer[4] << 7);
				FastLED.setBrightness(digitalBrightness);
				Serial.write(ACK);
				break;

			case DIGITAL_CHANGECOLOR:
				digitalStaticColorRed = buffer[3] | (buffer[4] << 7);
				digitalStaticColorGreen = buffer[5] | (buffer[6] << 7);
				digitalStaticColorBlue = buffer[7] | (buffer[8] << 7);
				SetupBreathingPalette();
				Serial.write(ACK);
				break;

			case DIGITAL_MUSICAL_PATTERN:
				BassIntensity = CRGB(buffer[3] | buffer[4] << 7, 0, 0);
				MedioIntensity = CRGB(0, buffer[5] | buffer[6] << 7, 0);
				TrebleIntensity = CRGB(0, 0, buffer[7] | buffer[8] << 7);
				Serial.write(ACK);
				break;

			case DIGITAL_CUSTOM_PALETTE:
				ColorNum = buffer[3];
				CustomColors[ColorNum] = CRGB(buffer[3] | buffer[4] << 7, buffer[5] | buffer[6] << 7, buffer[7] | buffer[8] << 7);
				Serial.write(ACK);
				break;

			case DIGITAL_CUSTOM_PALETTE_PROPERTIES:
				if (buffer[3] == 0x01)
					customBlend = TBlendType::LINEARBLEND;
				else
					customBlend = TBlendType::NOBLEND;

				if (buffer[4] == 0x01)
					animated = true;
				else
					animated = false;

				increment = buffer[5];

				switch (buffer[6])
				{
					case 0:
						SelectedCustomPalette = 0;
						CustomPalette16 = CRGBPalette16(CustomColors[0], CustomColors[1], CustomColors[2], CustomColors[3],
							CustomColors[4], CustomColors[5], CustomColors[6], CustomColors[7],
							CustomColors[8], CustomColors[9], CustomColors[10], CustomColors[11],
							CustomColors[12], CustomColors[13], CustomColors[14], CustomColors[15]);
						break;
					case 1:
						SelectedCustomPalette = 1;
						CustomPalette32 = CRGBPalette32(CustomColors[0], CustomColors[1], CustomColors[2], CustomColors[3],
							CustomColors[4], CustomColors[5], CustomColors[6], CustomColors[7],
							CustomColors[8], CustomColors[9], CustomColors[10], CustomColors[11],
							CustomColors[12], CustomColors[13], CustomColors[14], CustomColors[15]);
						break;
					case 2:
						SelectedCustomPalette = 2;
						CustomPalette256 = CRGBPalette256(CustomColors[0], CustomColors[1], CustomColors[2], CustomColors[3],
							CustomColors[4], CustomColors[5], CustomColors[6], CustomColors[7],
							CustomColors[8], CustomColors[9], CustomColors[10], CustomColors[11],
							CustomColors[12], CustomColors[13], CustomColors[14], CustomColors[15]);
						break;
				}
				Serial.write(ACK);
				break;

			case ANALOG_CHANGEMODE:
				analogStripMode = buffer[3];
				Serial.write(ACK);
				break;

			case ANALOG_CHANGEINTERVAL:
				analogInterval = buffer[3];
				Serial.write(ACK);
				break;

			case ANALOG_CHANGEBRIGHT:
				analogBrightness = buffer[3] | (buffer[4] << 7);
				Serial.write(ACK);
				break;

			case ANALOG_CHANGECOLOR:
				analogStaticColorRed = buffer[3] | (buffer[4] << 7);
				analogStaticColorGreen = buffer[5] | (buffer[6] << 7);
				analogStaticColorBlue = buffer[7] | (buffer[8] << 7);
				Serial.write(ACK);
				break;

			case ANALOG_MUSICAL_PATTERN:
				analogMusicalRed = buffer[3] | buffer[4] << 7;
				analogMusicalGreen = buffer[5] | buffer[6] << 7;
				analogMusicalBlue = buffer[7] | buffer[8] << 7;
				fillAnalog(analogMusicalRed, analogMusicalGreen, analogMusicalBlue);
				Serial.write(ACK);
				break;
			default:
				Serial.write(NAK);
				return;
				
		}
	}
	else 
	{
		Serial.write(NAK);
	}
}  

void processIncomingByte(const byte inByte)
{
	static byte input_line[128];
	static unsigned int input_pos = 0;

	switch (inByte)
	{
		case MESSAGE_END:   // end of message
			input_line[input_pos] = 0;  
			// terminator reached! process input_line here ...
			process_data(input_line);
			// reset buffer for next time
			input_pos = 0;
			break;

	default:
		// keep adding if not full ... allow for terminating null byte
		if (input_pos < (64 - 1))
			input_line[input_pos++] = inByte;
		break;

	}
}

void loop() {
	//Serial.print(xPortGetCoreID());

	// if serial data available, process it
	while (Serial.available() > 0)
		processIncomingByte(Serial.read());
}

//========================= EFFECT DEFINITIONS =======================

void fillAnalog(int red, int green, int blue)
{
#ifdef COMMOM_ANODE
	ledcWrite(1, 255 - red);
	ledcWrite(2, 255 - green);
	ledcWrite(3, 255 - blue);
#else
	//TRATAR USANDO O OUTPUT ADEQUADO
	ledcWrite(1, red);
	ledcWrite(2, green);
	ledcWrite(3, blue);
#endif	
	//TODO IMPLEMENT BRIGHT CONTROL
}

//Digital Patterns
void RealHSVRainbow_digital() {
	if (digitalAngle < 60)
	{
		digitalRed = 255;
		digitalGreen = HSVlights[digitalAngle];
		digitalBlue = 0;
	}
	else if (digitalAngle < 120)
	{
		digitalRed = HSVlights[120 - digitalAngle];
		digitalGreen = 255;
		digitalBlue = 0;
	}
	else if (digitalAngle < 180)
	{
		digitalRed = 0;
		digitalGreen = 255;
		digitalBlue = HSVlights[digitalAngle - 120];
	}
	else if (digitalAngle < 240)
	{
		digitalRed = 0;
		digitalGreen = HSVlights[240 - digitalAngle];
		digitalBlue = 255;
	}
	else if (digitalAngle < 300)
	{
		digitalRed = HSVlights[digitalAngle - 240];
		digitalGreen = 0;
		digitalBlue = 255;
	}
	else
	{
		digitalRed = 255;
		digitalGreen = 0;
		digitalBlue = HSVlights[360 - digitalAngle];
	}

	fill_solid(leds, NUM_LEDS, CRGB(digitalRed, digitalGreen, digitalBlue));

	FastLED.show();
	digitalAngle = (digitalAngle + 1) % 360;
}

void PowerHSVRainbow_digital()
{
	if (digitalAngle < 120)
	{
		digitalRed = HSVpower[120 - digitalAngle];
		digitalGreen = HSVpower[digitalAngle];
		digitalBlue = 0;
	}
	else if (digitalAngle < 240)
	{
		digitalRed = 0;
		digitalGreen = HSVpower[240 - digitalAngle];
		digitalBlue = HSVpower[digitalAngle - 120];
	}
	else
	{
		digitalRed = HSVpower[digitalAngle - 240];
		digitalGreen = 0;
		digitalBlue = HSVpower[360 - digitalAngle];
	}

	fill_solid(leds, NUM_LEDS, CRGB(digitalRed, digitalGreen, digitalBlue));
	FastLED.show();
	digitalAngle = (digitalAngle + 1) % 360;
}

void SineWaveRainbow_digital()
{
	digitalRed = lights[(digitalAngle + 120) % 360];
	digitalGreen = lights[digitalAngle];
	digitalBlue = lights[(digitalAngle + 240) % 360];

	fill_solid(leds, NUM_LEDS, CRGB(digitalRed, digitalGreen, digitalBlue));

	FastLED.show();
	digitalAngle = (digitalAngle + 1) % 360;
}

void RainbowSnake()
{
	snake_control = aux_control + snake_control;
	if (snake_control == (NUM_LEDS - 1) || snake_control == 0)
	{
		aux_control = -aux_control;
		aux_cor = -aux_cor;
	}

	switch (cor_controle % 3)
	{
	case 0:
		snakeRed = snakeRed - ((int)255 / NUM_LEDS);
		snakeGreen = snakeGreen + ((int)255 / NUM_LEDS);

		if (snakeRed < 0) snakeRed = 0;
		if (snakeGreen > 255) snakeGreen = 255;

		if (snakeRed <= 0 || snakeGreen >= 255) cor_controle++;

		break;
	case 1:
		snakeGreen = snakeGreen - ((int)255 / NUM_LEDS);
		snakeBlue = snakeBlue + ((int)255 / NUM_LEDS);

		if (snakeGreen < 0) snakeGreen = 0;
		if (snakeBlue > 255) snakeBlue = 255;

		if (snakeGreen <= 0 || snakeBlue >= 255) cor_controle++;

		break;
	case 2:
		snakeBlue = snakeBlue - ((int)255 / NUM_LEDS);
		snakeRed = snakeRed + ((int)255 / NUM_LEDS);

		if (snakeBlue < 0) snakeBlue = 0;
		if (snakeRed > 255) snakeRed = 255;

		if (snakeBlue <= 0 || snakeRed >= 255) cor_controle++;

		break;
	}

	cor_atual = CRGB(snakeRed, snakeGreen, snakeBlue);
	leds[snake_control] = CRGB(255, 255, 255);

	if ((snake_control - aux_cor) == -1) leds[0] = cor_atual;
	else if ((snake_control - aux_cor) == NUM_LEDS) leds[59] = cor_atual;
	else leds[snake_control - aux_cor] = cor_atual;

	FastLED.show();
}

void StaticColor_digital()
{
	digitalRed = digitalStaticColorRed;
	digitalGreen = digitalStaticColorGreen;
	digitalBlue = digitalStaticColorBlue;

	fill_solid(leds, NUM_LEDS, CRGB(digitalRed, digitalGreen, digitalBlue));
	FastLED.show();
}

void Breath_digital()
{
	//pattern runnign
	startIndex += 1;
	colorIndex = (int)startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(breathingPalette, colorIndex, 255, LINEARBLEND);
		colorIndex += 3;
	}
	FastLED.show();
}

byte MusicMap(byte value, byte max)
{
	return map(value, 0, 255, 0, max);
}

void Musical_digital()
{

	// contrói uma palheta de cores simétrica rainbow 
	// de padrão de cor (RBGR)
	int block = 0;        	// Tamanho de cada intervalo (em leds)
	int halfBlock = 0;		// Metade de um intervalo
	byte gradient = 0;      	// Diferença em cor de cada bloco
	int central_Point = 0;      	// ponto central da fita (iniciando em zero), que é o ponto final do padrão de cor (RBGR)
	int i = 0;        		// indice
	int counter = 0;              // contador que controla o padrão de cor
	int pattern = 2;      	// par = padrão RGBR, impar = padrão RBGR
	int mid = (NUM_LEDS / 2);	// meio da fita
	int colors = 15;		// intervalos em que a fita vai sobre variação

	byte red = 255;
	byte green = 0;
	byte blue = 0;

	CRGB Bass = BassIntensity;
	CRGB Medio = MedioIntensity;
	CRGB Treble = TrebleIntensity;

	block = NUM_LEDS / colors;

	if (block <= 2)
		block = 3;
	else if (block >= 256)
		block = 255;

	if ((NUM_LEDS % 2) == 0) {
		halfBlock = block / 2;
		central_Point = mid;
	}
	else {
		halfBlock = (block + 1) / 2;
		central_Point = mid;
		leds[mid] = CRGB(Bass.r, 0, 0);
	}

	gradient = 256 / (block + 1);

	// Pinta a fita de led
	for (i = central_Point; i >= 1; i--)
	{
		if (counter < halfBlock)        			// red
		{
			red = 255;
			green = 0;
			blue = 0;

			leds[i - 1] = CRGB(Bass.r, 0, 0);
			leds[NUM_LEDS - i] = CRGB(Bass.r, 0, 0);

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;

		}
		else if (counter < block + halfBlock)     		// orange
		{
			green += gradient;
			if (green >= 255) {
				green = 0;
			}
			leds[i - 1] = CRGB(Bass.r, MusicMap(Medio.g, green), 0);
			leds[NUM_LEDS - i] = CRGB(Bass.r, MusicMap(Medio.g, green), 0);

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;

		}
		else if (counter < (block * 2) + halfBlock)     	// orange
		{
			red -= gradient;
			if (red < 0)
				red = 0;

			leds[i - 1] = CRGB(MusicMap(Bass.r, red), MusicMap(Medio.g, green), 0);
			leds[NUM_LEDS - i] = CRGB(MusicMap(Bass.r, red), MusicMap(Medio.g, green), 0);

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;
		}
		else if (counter < (block * 3))     			// green
		{
			red = 0;
			green = 255;
			blue = 0;

			leds[i - 1] = CRGB(0, Medio.g, 0);
			leds[NUM_LEDS - i] = CRGB(0, Medio.g, 0);

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;
		}
		else if (counter < (block * 4))     			// cian
		{
			blue += gradient;
			if (blue > 255)
				blue = 255;

			leds[i - 1] = CRGB(0, Medio.g, MusicMap(Treble.b, blue));
			leds[NUM_LEDS - i] = CRGB(0, Medio.g, MusicMap(Treble.b, blue));

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;
		}
		else if (counter < (block * 5))     			// cian
		{
			green -= gradient;
			if (green < 0)
				green = 0;

			leds[i - 1] = CRGB(0, MusicMap(Medio.g, green), MusicMap(Treble.b, blue));
			leds[NUM_LEDS - i] = CRGB(0, MusicMap(Medio.g, green), MusicMap(Treble.b, blue));

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;
		}
		else if (counter < (block * 5) + halfBlock)     	// blue
		{
			red = 0;
			green = 0;
			blue = 255;

			leds[i - 1] = CRGB(0, 0, Treble.b);
			leds[NUM_LEDS - i] = CRGB(0, 0, Treble.b);

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;
		}
		else if (counter < (block * 6) + halfBlock)     	// violet
		{
			red += gradient;
			if (red > 255)
				red = 255;

			leds[i - 1] = CRGB(MusicMap(Bass.r, red), 0, Treble.b);
			leds[NUM_LEDS - i] = CRGB(MusicMap(Bass.r, red), 0, Treble.b);

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;
		}
		else if (counter < (block * 7) + halfBlock)     	// violet
		{
			blue -= gradient;
			if (blue < 0)
				blue = 0;

			leds[i - 1] = CRGB(MusicMap(Bass.r, red), 0, MusicMap(Treble.b, blue));
			leds[NUM_LEDS - i] = CRGB(MusicMap(Bass.r, red), 0, MusicMap(Treble.b, blue));

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;
		}
		else if (counter < (block * 8))    			// red
		{
			red = 255;
			green = 0;
			blue = 0;

			leds[i - 1] = CRGB(Bass.r, 0, 0);
			leds[NUM_LEDS - i] = CRGB(Bass.r, 0, 0);

			if ((pattern % 2) == 0)
				counter++;
			else
				counter--;
		}

		if (counter < 0) { 					// espelha o padrão
			pattern++;
			counter = 0;
		}
		else if (counter >= ((block * 8))) {
			pattern++;
			counter = (block * 7) + halfBlock - 1;
		}
	}


	FastLED.show();

}

void Deactivated_digital()
{
	//CRGB black = CRGB::Black;
	fill_solid(leds, NUM_LEDS, CRGB::Black);
	FastLED.show();
}

void FullHSVRainbow_digital()
{
	//pattern runnign
	startIndex += 1;
	colorIndex = (int)startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(RainbowColors_p, colorIndex, 255, LINEARBLEND);
		colorIndex += 3;
	}
	FastLED.show();
}

void FullHSVStripesRainbow_digital()
{
	//pattern runnign
	startIndex += 1;
	colorIndex = (int)startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(RainbowStripeColors_p, colorIndex, 255, LINEARBLEND);
		colorIndex += 3;
	}
	FastLED.show();
}

void Cloud_digital()
{
	//pattern runnign
	startIndex += 1;
	colorIndex = (int)startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(CloudColors_p, colorIndex, 255, LINEARBLEND);
		colorIndex += 3;
	}
	FastLED.show();
}

void Lava_digital()
{
	//pattern runnign
	startIndex += 1;
	colorIndex = (int)startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(LavaColors_p, colorIndex, 255, LINEARBLEND);
		colorIndex += 3;
	}
	FastLED.show();
}

void Ocean_digital()
{
	//pattern runnign
	startIndex += 1;
	colorIndex = (int)startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(OceanColors_p, colorIndex, 255, LINEARBLEND);
		colorIndex += 3;
	}
	FastLED.show();
}

void Forest_digital()
{
	//pattern runnign
	startIndex += 1;
	colorIndex = (int)startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(ForestColors_p, colorIndex, 255, LINEARBLEND);
		colorIndex += 3;
	}
	FastLED.show();
}

void Party_digital()
{
	//pattern runnign
	startIndex += 1;
	colorIndex = (int)startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(PartyColors_p, colorIndex, 255, LINEARBLEND);
		colorIndex += 3;
	}
	FastLED.show();
}

void Heat_digital()
{
	//pattern runnign
	startIndex += 1;
	colorIndex = (int)startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(HeatColors_p, colorIndex, 255, LINEARBLEND);
		colorIndex += 3;
	}
	FastLED.show();
}

void CustomPallete_digital()
{
	//pattern runnign
	if (animated) startIndex += 1;
	colorIndex = (int)startIndex;
	byte increment = increment;
	//pattern being updated
	switch (SelectedCustomPalette)
	{
	case 0:
		for (int i = 0; i < NUM_LEDS; i++) {
			leds[i] = ColorFromPalette(CustomPalette16, colorIndex, 255, customBlend);
			colorIndex += increment;
		}
		break;
	case 1:
		for (int i = 0; i < NUM_LEDS; i++) {
			leds[i] = ColorFromPalette(CustomPalette32, colorIndex, 255, customBlend);
			colorIndex += increment;
		}
		break;
	case 2:
		for (int i = 0; i < NUM_LEDS; i++) {
			leds[i] = ColorFromPalette(CustomPalette256, colorIndex, 255, customBlend);
			colorIndex += increment;
		}
		break;
	default:
		for (int i = 0; i < NUM_LEDS; i++) {
			leds[i] = ColorFromPalette(CustomPalette16, colorIndex, 255, customBlend);
			colorIndex += increment;
		}
		break;
	}

	FastLED.show();
}

//Analog Patterns
void RealHSVRainbow_analog()
{
	if (analogAngle < 60)
	{
		analogRed = 255;
		analogGreen = HSVlights[analogAngle];
		analogBlue = 0;
	}
	else if (analogAngle < 120)
	{
		analogRed = HSVlights[120 - analogAngle];
		analogGreen = 255;
		analogBlue = 0;
	}
	else if (analogAngle < 180)
	{
		analogRed = 0;
		analogGreen = 255;
		analogBlue = HSVlights[analogAngle - 120];
	}
	else if (analogAngle < 240)
	{
		analogRed = 0;
		analogGreen = HSVlights[240 - analogAngle];
		analogBlue = 255;
	}
	else if (analogAngle < 300)
	{
		analogRed = HSVlights[analogAngle - 240];
		analogGreen = 0;
		analogBlue = 255;
	}
	else
	{
		analogRed = 255;
		analogGreen = 0;
		analogBlue = HSVlights[360 - analogAngle];
	}

	fillAnalog(analogRed, analogGreen, analogBlue);

	analogAngle = (analogAngle + 1) % 360;
}

void PowerHSVRainbow_analog()
{
	if (analogAngle < 120)
	{
		analogRed = HSVpower[120 - analogAngle];
		analogGreen = HSVpower[analogAngle];
		analogBlue = 0;
	}
	else if (analogAngle < 240)
	{
		analogRed = 0;
		analogGreen = HSVpower[240 - analogAngle];
		analogBlue = HSVpower[analogAngle - 120];
	}
	else
	{
		analogRed = HSVpower[analogAngle - 240];
		analogGreen = 0;
		analogBlue = HSVpower[360 - analogAngle];
	}

	fillAnalog(analogRed, analogGreen, analogBlue);

	analogAngle = (analogAngle + 1) % 360;
}

void SineWaveRainbow_analog()
{
	analogRed = lights[(analogAngle + 120) % 360];
	analogGreen = lights[analogAngle];
	analogBlue = lights[(analogAngle + 240) % 360];

	fillAnalog(analogRed, analogGreen, analogBlue);

	analogAngle = (analogAngle + 1) % 360;
}

void StaticColor_analog()
{
	analogRed = analogStaticColorRed;
	analogGreen = analogStaticColorGreen;
	analogBlue = analogStaticColorBlue;

	fillAnalog(analogRed, analogGreen, analogBlue);
}

void Breath_analog()
{

	analogRed = (analogStaticColorRed   * analogPercent) / 255;
	analogGreen = (analogStaticColorGreen * analogPercent) / 255;
	analogBlue = (analogStaticColorBlue  * analogPercent) / 255;

	fillAnalog(analogRed, analogGreen, analogBlue);

	if (analogPercent == 100 || analogPercent == 0)
		analogPercentAux = -analogPercentAux;

	analogPercent += analogPercentAux;

}

void Musical_analog()
{
	//fillAnalog(analogMusicalRed, analogMusicalGreen, analogMusicalBlue);
}

void random_color_analog()
{
	byte a0, a1, a2;
	byte color[3];

	a0 = random(240);
	color[random_count] = lights[a0];
	a1 = random(1);
	a2 = ((!a1) + random_count + 1) % 3;
	a1 = (random_count + a1 + 1) % 3;
	color[a1] = lights[(a0 + 100) % 240];
	color[a2] = 0;

	fillAnalog(color[0], color[1], color[2]);

	random_count = (random_count + 1) % 3;
}

void Deactivated_analog()
{
	fillAnalog(0, 0, 0);
}