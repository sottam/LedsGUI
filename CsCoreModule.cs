using CSCore;
using CSCore.DSP;
using CSCore.SoundIn;
using CSCore.SoundOut;
using CSCore.Streams;
using CSCore.Streams.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformsVisualization.Visualization;
using System.Drawing;
using LedsGUI.Cscore;
using CSCore.CoreAudioAPI;
using CSCore.Win32;

namespace LedsGUI
{



    public class CsCoreModule : IDisposable
    {
        private WasapiCapture _soundIn;
        private IWaveSource _source;
        private PitchShifter _pitchShifter;

        public LineSpectrum _lineSpectrum; //analog
        public VoicePrint3DSpectrum _voicePrint3DSpectrum; //analog

        public LineSpectrum _DigitallineSpectrum; //digital

        public VoicePrint3DSpectrum _DigitalBassPrint3DSpectrum;
        //public VoicePrint3DSpectrum _DigitalvoicePrint3DSpectrum; //digital
        public VoicePrint3DSpectrum _DigitalMedioPrint3DSpectrum;
        public VoicePrint3DSpectrum _DigitaltreblePrint3DSpectrum;
        public LineSpectrum _GenericlineSpectrum; //generic
        public VoicePrint3DSpectrum _GenericvoicePrint3DSpectrum; //generic

        BasicSpectrumProvider spectrumProvider;

        MMDeviceEnumerator mMDeviceEnumerator;
        MMNotificationClient mMNotificationClient;

        string DispositivoAtual;

        SoundInSource soundInSource;
        byte[] buffer;

        public CsCoreModule()
        {
            mMNotificationClient = new MMNotificationClient();
            mMDeviceEnumerator = new MMDeviceEnumerator();
            mMDeviceEnumerator.RegisterEndpointNotificationCallback(mMNotificationClient);
            mMNotificationClient.DefaultDeviceChanged += MMNotificationClient_DefaultDeviceChanged;
            
        }

        private void SoundInSource_DataAvailable(object sender, DataAvailableEventArgs e)
        {
            int read;
            while ((read = _source.Read(buffer, 0, buffer.Length)) > 0) ;
        }

        private void MMNotificationClient_DefaultDeviceChanged(object sender, DefaultDeviceChangedEventArgs e)
        {
            if(e.DeviceId.Equals(DispositivoAtual) == false)
            {
                //Console.Write("Default Device changed to: ");
                //Console.WriteLine(e.DeviceId);
                DispositivoAtual = e.DeviceId;
                Listen(false);
                UpdateFromDefaultDevice();
                Listen(true); 
            }
        }

        private void UpdateFromDefaultDevice()
        {
            soundInSource.DataAvailable -= SoundInSource_DataAvailable;

            //open the default device 
            _soundIn = new WasapiLoopbackCapture();
            //Our loopback capture opens the default render device by default so the following is not needed
            _soundIn.Device = MMDeviceEnumerator.DefaultAudioEndpoint(DataFlow.Render, Role.Console);
            _soundIn.Initialize();

            soundInSource = new SoundInSource(_soundIn);
            ISampleSource source = soundInSource.ToSampleSource().AppendSource(x => new PitchShifter(x), out _pitchShifter);

            SetupSampleSource(source);

            // We need to read from our source otherwise SingleBlockRead is never called and our spectrum provider is not populated
            buffer = new byte[_source.WaveFormat.BytesPerSecond / 2];
            soundInSource.DataAvailable += SoundInSource_DataAvailable;
        }

        public void FromDefaultDevice()
        {
            Stop();

            //open the default device 
            _soundIn = new WasapiLoopbackCapture();
            //Our loopback capture opens the default render device by default so the following is not needed
            _soundIn.Device = MMDeviceEnumerator.DefaultAudioEndpoint(DataFlow.Render, Role.Console);
            _soundIn.Initialize();

            soundInSource = new SoundInSource(_soundIn);
            ISampleSource source = soundInSource.ToSampleSource().AppendSource(x => new PitchShifter(x), out _pitchShifter);

            SetupSampleSource(source);

            // We need to read from our source otherwise SingleBlockRead is never called and our spectrum provider is not populated
            buffer = new byte[_source.WaveFormat.BytesPerSecond / 2];
            soundInSource.DataAvailable += SoundInSource_DataAvailable;
        }

        private void SetupSampleSource(ISampleSource aSampleSource)
        {
            const FftSize fftSize = FftSize.Fft4096;
            //create a spectrum provider which provides fft data based on some input
            spectrumProvider = new BasicSpectrumProvider(aSampleSource.WaveFormat.Channels,
                aSampleSource.WaveFormat.SampleRate, fftSize);
            //spectrumProvider.GetFftData()
            //linespectrum and voiceprint3dspectrum used for rendering some fft data
            //in oder to get some fft data, set the previously created spectrumprovider 
            _lineSpectrum = new LineSpectrum(fftSize)
            {
                SpectrumProvider = spectrumProvider,
                UseAverage = true,
                BarCount = 50,
                BarSpacing = 2,
                IsXLogScale = true,
                ScalingStrategy = ScalingStrategy.Sqrt
            };

            _voicePrint3DSpectrum = new VoicePrint3DSpectrum(fftSize)
            {
                SpectrumProvider = spectrumProvider,
                UseAverage = true,
                PointCount = 1,
                IsXLogScale = false,
                ScalingStrategy = ScalingStrategy.Linear,
                MaximumFrequency = 100,
                MinimumFrequency = 20 
            };

            _DigitallineSpectrum = new LineSpectrum(fftSize)
            {
                SpectrumProvider = spectrumProvider,
                UseAverage = true,
                BarCount = 50,
                BarSpacing = 2,
                IsXLogScale = true,
                ScalingStrategy = ScalingStrategy.Sqrt
            };

            _DigitalBassPrint3DSpectrum = new VoicePrint3DSpectrum(fftSize)
            {
                Colors = new Color[2] { Color.Black, Color.Red },
                SpectrumProvider = spectrumProvider,
                UseAverage = true,
                PointCount = 1,
                IsXLogScale = false,
                ScalingStrategy = ScalingStrategy.Linear,
                MaximumFrequency = 250,
                MinimumFrequency = 20
            };

            _DigitalMedioPrint3DSpectrum = new VoicePrint3DSpectrum(fftSize)
            {
                Colors = new Color[2] { Color.Black, Color.Green },
                SpectrumProvider = spectrumProvider,
                UseAverage = true,
                PointCount = 1,
                IsXLogScale = false,
                ScalingStrategy = ScalingStrategy.Linear,
                MaximumFrequency = 5000,
                MinimumFrequency = 250
            };

            _DigitaltreblePrint3DSpectrum = new VoicePrint3DSpectrum(fftSize)
            {
                Colors = new Color[2] { Color.Black, Color.Blue },
                SpectrumProvider = spectrumProvider,
                UseAverage = true,
                PointCount = 1,
                IsXLogScale = false,
                ScalingStrategy = ScalingStrategy.Linear,
                MaximumFrequency = 20000,
                MinimumFrequency = 5000
            };

            _GenericlineSpectrum = new LineSpectrum(fftSize)
            {
                SpectrumProvider = spectrumProvider,
                UseAverage = true,
                BarCount = 50,
                BarSpacing = 2,
                IsXLogScale = true,
                ScalingStrategy = ScalingStrategy.Sqrt
            };

            _GenericvoicePrint3DSpectrum = new VoicePrint3DSpectrum(fftSize)
            {
                SpectrumProvider = spectrumProvider,
                UseAverage = true,
                PointCount = 200,
                IsXLogScale = true,
                ScalingStrategy = ScalingStrategy.Sqrt,
                MaximumFrequency = 20000,
                MinimumFrequency = 20
            };


            //the SingleBlockNotificationStream is used to intercept the played samples
            var notificationSource = new SingleBlockNotificationStream(aSampleSource);
            //pass the intercepted samples as input data to the spectrumprovider (which will calculate a fft based on them)
            notificationSource.SingleBlockRead += (s, a) => spectrumProvider.Add(a.Left, a.Right);

            _source = notificationSource.ToWaveSource(16);
        }

        public void Listen(bool listen)
        {
            if (listen)
                _soundIn.Start();
            else
                _soundIn.Stop();
        }

        public void Stop()
        {
            //SoundSpectrum.Stop();

            if (_soundIn != null)
            {
                _soundIn.Stop();
                _soundIn.Dispose();
                _soundIn = null;
            }
            if (_source != null)
            {
                _source.Dispose();
                _source = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources  
                if (soundInSource != null)
                {
                    soundInSource.Dispose();
                    soundInSource = null;
                }

                if (mMDeviceEnumerator != null)
                {
                    mMDeviceEnumerator.Dispose();
                    mMDeviceEnumerator = null;
                }

                if(mMNotificationClient != null)
                {
                    mMNotificationClient.Dispose();
                    mMNotificationClient = null;
                }

                if(_soundIn != null)
                {
                    _soundIn.Dispose();
                    _soundIn = null;
                }
            }
        }
    }
}
