﻿using CSCore.DSP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformsVisualization.Visualization;

namespace LedsGUI.Cscore
{
    public class VoicePrint3DSpectrum : SpectrumBase
    {
        public static decimal trebleFactor = 65;
        public static decimal medioFactor = 21;
        public static decimal bassFactor = 8;

        public static decimal trebleFactorSqrt = 2;
        public static decimal MedioFactorSqrt = 2;
        public static decimal BassFactorSqrt = 2;

        private readonly GradientCalculator _colorCalculator;
        private bool _isInitialized;

        public enum DrawPurpose { ForAnalog, ForDigitalBass, ForDigitalMedio, ForDigitalTreble, ForGeneric };

        public VoicePrint3DSpectrum(FftSize fftSize)
        {
            _colorCalculator = new GradientCalculator();
            Colors = new[] { Color.Black, Color.Blue, Color.Cyan, Color.Lime, Color.Yellow, Color.Red };
            

            FftSize = fftSize;
        }

        public Color[] Colors
        {
            get { return _colorCalculator.Colors; }
            set
            {
                if (value == null || value.Length <= 0)
                    throw new ArgumentException("value");

                _colorCalculator.Colors = value;
            }
        }

        public int PointCount
        {
            get { return SpectrumResolution; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value");
                SpectrumResolution = value;

                UpdateFrequencyMapping();
            }
        }

        public bool CreateVoicePrint3D(Graphics graphics, RectangleF clipRectangle, float xPos, Color background, DrawPurpose dp,
            float lineThickness = 1f)
        {
            if (!_isInitialized)
            {
                UpdateFrequencyMapping();
                _isInitialized = true;
            }

            var fftBuffer = new float[(int)FftSize];

            //get the fft result from the spectrumprovider
            if (SpectrumProvider.GetFftData(fftBuffer, this))
            {
                SpectrumPointData[] spectrumPoints;
                //prepare the fft result for rendering
                switch (dp)
                {
                    case DrawPurpose.ForAnalog:
                        spectrumPoints = CalculateSpectrumPoints(0.99, fftBuffer);
                        break;
                    case DrawPurpose.ForDigitalBass:
                        spectrumPoints = CalculateSpectrumPoints(0.99, fftBuffer, bassFactor, BassFactorSqrt);
                        break;
                    case DrawPurpose.ForDigitalMedio:
                        spectrumPoints = CalculateSpectrumPoints(0.99, fftBuffer, medioFactor, MedioFactorSqrt);
                        break;
                    case DrawPurpose.ForDigitalTreble:
                        spectrumPoints = CalculateSpectrumPoints(0.99, fftBuffer, trebleFactor, trebleFactorSqrt);
                        break;
                    case DrawPurpose.ForGeneric:
                        spectrumPoints = CalculateSpectrumPoints(0.99, fftBuffer);
                        break;
                    default:
                        spectrumPoints = CalculateSpectrumPoints(0.99, fftBuffer);
                        break;
                }

                
                using (var pen = new Pen(background, lineThickness))
                {
                    float currentYOffset = clipRectangle.Y + clipRectangle.Height;

                    //render the fft result
                    for (int i = 0; i < spectrumPoints.Length; i++)
                    {
                        SpectrumPointData p = spectrumPoints[i];

                        float xCoord = clipRectangle.X + xPos;
                        float pointHeight = clipRectangle.Height / spectrumPoints.Length;

                        //get the color based on the fft band value
                        pen.Color = _colorCalculator.GetColor((float)p.Value);

                        switch (dp)
                        {
                            case DrawPurpose.ForAnalog:
                                MessageModule.SoundSpectrumColor = pen.Color;
                                break;
                            case DrawPurpose.ForDigitalBass:
                                MessageModule.DigitalSpectrumColor = Color.FromArgb(pen.Color.R, MessageModule.DigitalSpectrumColor.G, MessageModule.DigitalSpectrumColor.B);
                                break;
                            case DrawPurpose.ForDigitalMedio:
                                MessageModule.DigitalSpectrumColor = Color.FromArgb(MessageModule.DigitalSpectrumColor.R, pen.Color.G, MessageModule.DigitalSpectrumColor.B);
                                break;
                            case DrawPurpose.ForDigitalTreble:
                                MessageModule.DigitalSpectrumColor = Color.FromArgb(MessageModule.DigitalSpectrumColor.R, MessageModule.DigitalSpectrumColor.G, pen.Color.B);
                                break;
                            case DrawPurpose.ForGeneric:
                                break;
                            default:
                                break;
                        }


                        var p1 = new PointF(xCoord, currentYOffset);
                        var p2 = new PointF(xCoord, currentYOffset - pointHeight);

                        graphics.DrawLine(pen, p1, p2);

                        currentYOffset -= pointHeight;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
