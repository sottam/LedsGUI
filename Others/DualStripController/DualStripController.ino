/*
 Name:		DualStripController.ino
 Created:	25/02/2018 23:55:48
 Author:	Alonso
*/

#if defined(FASTLED_VERSION) && (FASTLED_VERSION < 3001000)
#warning "Requires FastLED 3.1 or later; check github for latest code."
#endif

#include <power_mgt.h>
#include <platforms.h>
#include <pixeltypes.h>
#include <pixelset.h>
#include <noise.h>
#include <lib8tion.h>
#include <led_sysdefs.h>
#include <hsv2rgb.h>
#include <fastspi_types.h>
#include <fastspi_ref.h>
#include <fastspi_nop.h>
#include <fastspi_dma.h>
#include <fastspi_bitbang.h>
#include <fastspi.h>
#include <fastpin.h>
#include <fastled_progmem.h>
#include <fastled_delay.h>
#include <fastled_config.h>
#include <dmx.h>
#include <cpp_compat.h>
#include <controller.h>
#include <colorutils.h>
#include <colorpalettes.h>
#include <color.h>
#include <chipsets.h>
#include <bitswap.h>
#include "Arduino.h"
#include <ConfigurableFirmata.h>
#include <DigitalOutputFirmata.h>
#include <AnalogOutputFirmata.h>
#include <FirmataExt.h>
#include <AnalogWrite.h>
#include <FastLED.h>
#include <Thread.h>
#include <StaticThreadController.h>
#include <FirmataFeature.h>

//---------------------------------------------------------------------

//DIGITAL STRIP
#define DATA_PIN    13
#define LED_TYPE    WS2813
#define COLOR_ORDER GRB
#define NUM_LEDS    300

#define BRIGHTNESS  255

//ANALOG STRIP
// #define COMMOM_ANODE

#define RED_PIN   9
#define GREEN_PIN 10
#define BLUE_PIN  11


//----------------------------------------------------------------------
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

class LedStripUserSysexManager : public FirmataFeature {
public:
	//LedStripUserSysexManager();
	//virtual ~LedStripUserSysexManager();

	// FirmataFeature implementation
	/*boolean handlePinMode(byte pin, int mode);
	void handleCapability(byte pin);
	boolean handleSysex(byte command, byte argc, byte *argv);
	void reset();
	void SetupMusicalPalette();
	void SetupBreathingPalette();*/

	//digitalLedImplementation
	byte digitalStripMode = 0;
	byte digitalInterval = 30;//ms
	byte digitalBrightness = 255; //max

	//analogLedImplementation
	byte analogStripMode = 0;
	byte analogInterval = 10;//ms
	byte analogBrightness = 255;//max

	//controles
	bool digitalIntervalHasChanged = false;
	bool digitalBrightHasChanged = false;

	bool analogIntervalHasChanged = false;
	bool analogBrightHasChanged = false;

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

	CRGBPalette256 breathingPalette = CRGBPalette256(	CRGB::Red, CRGB::Black, CRGB::Black, CRGB::Red,
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

	LedStripUserSysexManager()
	{
		musicalPalette = RainbowColors_p;
	}

	boolean handleSysex(byte command, byte argc, byte* argv) {

		if (command == STRIP_DATA)
		{
			byte subCommand = argv[0];
			byte ColorNum;

			switch (subCommand) {
			case DIGITAL_CHANGEMODE:
				if (argc != 2) return false;
				digitalStripMode = argv[1];
				break;

			case DIGITAL_CHANGEINTERVAL:
				if (argc != 2) return false;
				digitalInterval = argv[1];
				digitalIntervalHasChanged = true;
				break;

			case DIGITAL_CHANGEBRIGHT:
				if (argc != 3) return false;
				digitalBrightness = argv[1] | (argv[2] << 7);
				digitalBrightHasChanged = true;
				break;

			case DIGITAL_CHANGECOLOR:
				if (argc != 7) return false;
				digitalStaticColorRed = argv[1] | (argv[2] << 7);
				digitalStaticColorGreen = argv[3] | (argv[4] << 7);
				digitalStaticColorBlue = argv[5] | (argv[6] << 7);
				SetupBreathingPalette();
				break;

			case DIGITAL_MUSICAL_PATTERN:
				if (argc != 7) return false;
				BassIntensity = CRGB(argv[1] | argv[2] << 7, 0, 0);
				MedioIntensity = CRGB(0, argv[3] | argv[4] << 7, 0);
				TrebleIntensity = CRGB(0, 0, argv[5] | argv[6] << 7);
				b0 = argv[1] | argv[2] << 7;
				b1 = argv[3] | argv[4] << 7;
				b2 = argv[5] | argv[6] << 7;
				SetupMusicalPalette();
				//if (argc != 13) return;
				//BassIntensity = CRGB(argv[1] | argv[2] << 7, argv[3] | argv[4] << 7, argv[5] | argv[6] << 7);
				//MedioIntensity = CRGB(argv[7] | argv[8] << 7, argv[9] | argv[10] << 7, argv[11] | argv[12] << 7);
				//SetupMusicalPalette();
				break;

			case DIGITAL_CUSTOM_PALETTE:
				ColorNum = argv[1];
				CustomColors[ColorNum] = CRGB(argv[2] | argv[3] << 7, argv[4] | argv[5] << 7, argv[6] | argv[7] << 7);
				break;

			case DIGITAL_CUSTOM_PALETTE_PROPERTIES:
				if (argv[1] == 0x01)
					customBlend = TBlendType::LINEARBLEND;
				else
					customBlend = TBlendType::NOBLEND;

				if (argv[2] == 0x01)
					animated = true;
				else
					animated = false;

				increment = argv[3];

				switch (argv[4])
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
				default:
					break;
				}

				break;


			case ANALOG_CHANGEMODE:
				if (argc != 2) return false;
				analogStripMode = argv[1];
				break;

			case ANALOG_CHANGEINTERVAL:
				if (argc != 2) return false;
				analogInterval = argv[1];
				analogIntervalHasChanged = true;
				break;

			case ANALOG_CHANGEBRIGHT:
				if (argc != 3) return false;
				analogBrightness = argv[1] | (argv[2] << 7);
				analogBrightHasChanged = true;
				break;

			case ANALOG_CHANGECOLOR:
				if (argc != 7) return false;
				analogStaticColorRed = argv[1] | (argv[2] << 7);
				analogStaticColorGreen = argv[3] | (argv[4] << 7);
				analogStaticColorBlue = argv[5] | (argv[6] << 7);
				break;

			case ANALOG_MUSICAL_PATTERN:
				if (argc != 7) return false;
				analogPalette = CRGB(argv[1] | argv[2] << 7, argv[3] | argv[4] << 7, argv[5] | argv[6] << 7);
				break;

			default:
				return false;
			}
			return true;
		}
		return false;
	}

	boolean handlePinMode(byte pin, int mode)
	{
		return true;
	}

	void handleCapability(byte pin)
	{
	}

	void reset()
	{
	}

	byte MusMap(byte value, byte max) 
	{
		return map(value, 0, 255, 0, max);
	}

	void SetupMusicalPalette()
	{
		/*
		musicalPalette = CRGBPalette256(
			BassIntensity,
			CRGB(MusMap(BassIntensity.r, 0xD5), MusMap(MedioIntensity.g, 0x2A), 0),
			CRGB(MusMap(BassIntensity.r, 0xAB), MusMap(MedioIntensity.g, 0x55), 0),
			CRGB(MusMap(BassIntensity.r, 0xAB), MusMap(MedioIntensity.g, 0x7F), 0),
			CRGB(MusMap(BassIntensity.r, 0xAB), MusMap(MedioIntensity.g, 0xAB), 0),
			CRGB(MusMap(BassIntensity.r, 0x56), MusMap(MedioIntensity.g, 0xD5), 0),
			MedioIntensity,
			CRGB(0, MusMap(MedioIntensity.g, 0xD5), MusMap(TrebleIntensity.b, 0x2A)),
			CRGB(0, MusMap(MedioIntensity.g, 0xAB), MusMap(TrebleIntensity.b, 0x55)),
			CRGB(0, MusMap(MedioIntensity.g, 0x56), MusMap(TrebleIntensity.b, 0xAA)),
			TrebleIntensity.b,
			CRGB(MusMap(BassIntensity.r, 0x2A), 0, MusMap(TrebleIntensity.b, 0xD5)),
			CRGB(MusMap(BassIntensity.r, 0x55), 0, MusMap(TrebleIntensity.b, 0xAB)),
			CRGB(MusMap(BassIntensity.r, 0x7F), 0, MusMap(TrebleIntensity.b, 0x81)),
			CRGB(MusMap(BassIntensity.r, 0xAB), 0, MusMap(TrebleIntensity.b, 0x55)),
			CRGB(MusMap(BassIntensity.r, 0xD5), 0, MusMap(TrebleIntensity.b, 0x2B))
		);*/
	}

	void SetupBreathingPalette()
	{
		CRGB CustomColor = CRGB(digitalStaticColorRed, digitalStaticColorGreen, digitalStaticColorBlue);

		breathingPalette = CRGBPalette256(	CRGB::Black, CRGB::Black, CRGB::Black, CRGB::Black,
											CustomColor, CustomColor, CustomColor, CustomColor,
											CustomColor, CustomColor, CustomColor, CustomColor,
											CRGB::Black, CRGB::Black, CRGB::Black, CRGB::Black);
	}

	};


DigitalOutputFirmata digitalOutput;
AnalogOutputFirmata analogOutput;
FirmataExt firmataExt;
LedStripUserSysexManager sysexManager;

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

//"Threads"
Thread DigitalStrip = Thread();
Thread AnalogStrip = Thread();
StaticThreadController<2> Manager(&DigitalStrip, &AnalogStrip);

// Useful Color Arrays ----------------------------------------------------------------
const byte lights[360] = {		0,   0,   0,   0,   0,   1,   1,   2,   2,   3,   4,   5,   6,   7,   8,   9,
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

const byte HSVlights[61] = {  0,   4,   8,  13,  17,  21,  25,  30,  34,  38,  42,  47,  51,  55,  59,  64,
							 68,  72,  76,  81,  85,  89,  93,  98, 102, 106, 110, 115, 119, 123, 127, 132,
							136, 140, 144, 149, 153, 157, 161, 166, 170, 174, 178, 183, 187, 191, 195, 200,
							204, 208, 212, 217, 221, 225, 229, 234, 238, 242, 246, 251, 255 };

const byte HSVpower[121] = {  0,   2,   4,   6,   8,  11,  13,  15,  17,  19,  21,  23,  25,  28,  30,  32,
							 34,  36,  38,  40,  42,  45,  47,  49,  51,  53,  55,  57,  59,  62,  64,  66,
							 68,  70,  72,  74,  76,  79,  81,  83,  85,  87,  89,  91,  93,  96,  98, 100,
							102, 104, 106, 108, 110, 113, 115, 117, 119, 121, 123, 125, 127, 130, 132, 134,
							136, 138, 140, 142, 144, 147, 149, 151, 153, 155, 157, 159, 161, 164, 166, 168,
							170, 172, 174, 176, 178, 181, 183, 185, 187, 189, 191, 193, 195, 198, 200, 202,
							204, 206, 208, 210, 212, 215, 217, 219, 221, 223, 225, 227, 229, 232, 234, 236,
							238, 240, 242, 244, 246, 249, 251, 253, 255 };

//PresetedEffects
void RainbowSnake();
//void nextPattern();
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
void DigitalLoop() 
{
	digitalPatterns[sysexManager.digitalStripMode % digitalPatternsSize]();
}

void AnalogLoop() 
{
	analogPatterns[sysexManager.analogStripMode % analogPatternsSize]();
}

void fillAnalog(int red, int green, int blue)
{
#ifdef COMMOM_ANODE
	analogWrite(RED_PIN, 255 - red);
	analogWrite(GREEN_PIN, 255 - green);
	analogWrite(BLUE_PIN, 255 - blue);
#else
	analogWrite(RED_PIN, red);
	analogWrite(GREEN_PIN, green);
	analogWrite(BLUE_PIN, blue);
#endif	
	//TODO IMPLEMENT BRIGHT CONTROL
}

void systemResetCallback() 
{
	for (byte i = 0; i < TOTAL_PINS; i++) {
		if (IS_PIN_ANALOG(i)) {
		}
		else if (IS_PIN_DIGITAL(i)) {
			Firmata.setPinMode(i, OUTPUT);
		}
	}
	firmataExt.reset();
}

void initTransport() 
{
	// Uncomment to save a couple of seconds by disabling the startup blink sequence.
	Firmata.disableBlinkVersion();
	Firmata.begin(2400);
}

void initFirmata() 
{
	Firmata.setFirmwareVersion(FIRMATA_FIRMWARE_MAJOR_VERSION, FIRMATA_FIRMWARE_MINOR_VERSION);

	sysexManager = LedStripUserSysexManager();

	firmataExt.addFeature(sysexManager);
	firmataExt.addFeature(digitalOutput);
	firmataExt.addFeature(analogOutput);

	Firmata.attach(SYSTEM_RESET, systemResetCallback);
}

void setup() 
{
	initFirmata();

	initTransport();

	systemResetCallback();

	Firmata.setPinMode(RED_PIN, OUTPUT);
	Firmata.setPinMode(GREEN_PIN, OUTPUT);
	Firmata.setPinMode(BLUE_PIN, OUTPUT);

	FastLED.addLeds<LED_TYPE, DATA_PIN, COLOR_ORDER>(leds, NUM_LEDS).setCorrection(TypicalLEDStrip);

	AnalogStrip.onRun(AnalogLoop);
	AnalogStrip.setInterval(10);

	DigitalStrip.onRun(DigitalLoop);
	DigitalStrip.setInterval(30);
}

void loop() {
	while (Firmata.available()) 
	{
		Firmata.processInput();
	}

	if (sysexManager.digitalIntervalHasChanged)
	{
		sysexManager.digitalIntervalHasChanged = false;
		DigitalStrip.setInterval(sysexManager.digitalInterval);
	}

	if (sysexManager.analogIntervalHasChanged)
	{
		sysexManager.analogIntervalHasChanged = false;
		AnalogStrip.setInterval(sysexManager.analogInterval);
	}

	if (sysexManager.digitalBrightHasChanged)
	{
		sysexManager.digitalBrightHasChanged = false;
		FastLED.setBrightness(sysexManager.digitalBrightness);
	}

	if (sysexManager.analogBrightHasChanged)
	{
		sysexManager.analogBrightHasChanged = false;
		//FastLED.setBrightness(sysexManager.analogBrightness);
	}

	Manager.run();
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
	digitalRed = sysexManager.digitalStaticColorRed;
	digitalGreen = sysexManager.digitalStaticColorGreen;
	digitalBlue = sysexManager.digitalStaticColorBlue;

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
		leds[i] = ColorFromPalette(sysexManager.breathingPalette, colorIndex, 255, LINEARBLEND);
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

	CRGB Bass = sysexManager.BassIntensity;
	CRGB Medio = sysexManager.MedioIntensity;
	CRGB Treble = sysexManager.TrebleIntensity;

	leds[0]  = CRGB(Bass.r, 0, 0);
	leds[1]  = CRGB(Bass.r, 0, 0);
	leds[2]  = CRGB(Bass.r, 0, 0);
	leds[3]  = CRGB(Bass.r, 0, 0);

	leds[4]  = CRGB(Bass.r, 0, 0);
	leds[5]  = CRGB(Bass.r, 0, 0);
	leds[6]  = CRGB(Bass.r, 0, 0);
	leds[7]  = CRGB(Bass.r, 0, 0);
	leds[8]  = CRGB(Bass.r, 0, 0);
	leds[9]  = CRGB(Bass.r, 0, 0);
	leds[10] = CRGB(Bass.r, 0, 0);
	leds[11] = CRGB(Bass.r, 0, 0);
	leds[12] = CRGB(Bass.r, 0, 0);
	leds[13] = CRGB(Bass.r, 0, 0);
	leds[14] = CRGB(Bass.r, 0, 0);
	leds[15] = CRGB(Bass.r, 0, 0);
	leds[16] = CRGB(Bass.r, 0, 0);
	leds[17] = CRGB(Bass.r, 0, 0);
	leds[18] = CRGB(Bass.r, 0, 0);
	leds[19] = CRGB(Bass.r, 0, 0);
	leds[20] = CRGB(Bass.r, 0, 0);
	leds[21] = CRGB(Bass.r, 0, 0);
	leds[22] = CRGB(Bass.r, 0, 0);
	leds[23] = CRGB(Bass.r, 0, 0);
	leds[24] = CRGB(Bass.r, 0, 0);
	leds[25] = CRGB(Bass.r, 0, 0);

	leds[26] = CRGB(MusicMap(Bass.r, 0xD5), MusicMap(Medio.g, 0x2B), 0);
	leds[27] = CRGB(MusicMap(Bass.r, 0xAB), MusicMap(Medio.g, 0x55), 0);
	leds[28] = CRGB(MusicMap(Bass.r, 0xAB), MusicMap(Medio.g, 0x55), 0);
	leds[29] = CRGB(MusicMap(Bass.r, 0x55), MusicMap(Medio.g, 0xAB), 0);
	leds[30] = CRGB(MusicMap(Bass.r, 0x55), MusicMap(Medio.g, 0xAB), 0);
	leds[31] = CRGB(MusicMap(Bass.r, 0x2B), MusicMap(Medio.g, 0xD5), 0);

	leds[32] = CRGB(0, Medio.g, 0);
	leds[33] = CRGB(0, Medio.g, 0);
	leds[34] = CRGB(0, Medio.g, 0);
	leds[35] = CRGB(0, Medio.g, 0);
	leds[36] = CRGB(0, Medio.g, 0);

	leds[37] = CRGB(0, MusicMap(Medio.g, 0xD5), MusicMap(Treble.b, 0x2B));
	leds[38] = CRGB(0, MusicMap(Medio.g, 0xAB), MusicMap(Treble.b, 0x55));
	leds[39] = CRGB(0, MusicMap(Medio.g, 0xAB), MusicMap(Treble.b, 0x55));
	leds[40] = CRGB(0, MusicMap(Medio.g, 0x55), MusicMap(Treble.b, 0xAB));
	leds[41] = CRGB(0, MusicMap(Medio.g, 0x55), MusicMap(Treble.b, 0xAB));
	leds[42] = CRGB(0, MusicMap(Medio.g, 0x2B), MusicMap(Treble.b, 0xD5));
	
	leds[43] = CRGB(0, 0, Treble.b);
	leds[44] = CRGB(0, 0, Treble.b);
	leds[45] = CRGB(0, 0, Treble.b);
	leds[46] = CRGB(0, 0, Treble.b);
	leds[47] = CRGB(0, 0, Treble.b);
	leds[48] = CRGB(0, 0, Treble.b);

	/*
	//startIndex+= 0.2f;
	startIndex += 1;
	colorIndex = (int) startIndex;
	//pattern being updated
	for (int i = 0; i < NUM_LEDS; i++) {
		leds[i] = ColorFromPalette(sysexManager.musicalPalette, colorIndex, 255, LINEARBLEND);
		//byte Bright = (sysexManager.b0 * 0.5f + sysexManager.b1 * 0.3f + sysexManager.b2 * 0.2);
		//leds[i] = ColorFromPalette(sysexManager.musicalPalette, colorIndex, Bright, LINEARBLEND);
		colorIndex += 10;
	}*/

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
	if(sysexManager.animated) startIndex += 1;
	colorIndex = (int)startIndex;
	byte increment = sysexManager.increment;
	//pattern being updated
	switch (sysexManager.SelectedCustomPalette)
	{
	case 0:
		for (int i = 0; i < NUM_LEDS; i++) {
			leds[i] = ColorFromPalette(sysexManager.CustomPalette16, colorIndex, 255, sysexManager.customBlend);
			colorIndex += increment;
		}
		break;
	case 1:
		for (int i = 0; i < NUM_LEDS; i++) {
			leds[i] = ColorFromPalette(sysexManager.CustomPalette32, colorIndex, 255, sysexManager.customBlend);
			colorIndex += increment;
		}
		break;
	case 2:
		for (int i = 0; i < NUM_LEDS; i++) {
			leds[i] = ColorFromPalette(sysexManager.CustomPalette256, colorIndex, 255, sysexManager.customBlend);
			colorIndex += increment;
		}
		break;
	default:
		for (int i = 0; i < NUM_LEDS; i++) {
			leds[i] = ColorFromPalette(sysexManager.CustomPalette16, colorIndex, 255, sysexManager.customBlend);
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
	analogRed = sysexManager.analogStaticColorRed;
	analogGreen = sysexManager.analogStaticColorGreen;
	analogBlue = sysexManager.analogStaticColorBlue;

	fillAnalog(analogRed, analogGreen, analogBlue);
}

void Breath_analog()
{

	analogRed = (sysexManager.analogStaticColorRed   * analogPercent) / 255;
	analogGreen = (sysexManager.analogStaticColorGreen * analogPercent) / 255;
	analogBlue = (sysexManager.analogStaticColorBlue  * analogPercent) / 255;

	fillAnalog(analogRed, analogGreen, analogBlue);

	if (analogPercent == 100 || analogPercent == 0)
		analogPercentAux = -analogPercentAux;

	analogPercent += analogPercentAux;

}

void Musical_analog() 
{
	fillAnalog(sysexManager.analogPalette.r, sysexManager.analogPalette.g, sysexManager.analogPalette.b);
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


