using NAudio.Wave;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGUIApp.BusinessLayer
{
    internal class Utils
    {
        /// <summary>
        /// Used to play a sound file in a loop
        /// </summary>
        public static ConcurrentBag<IWavePlayer> players = new ConcurrentBag<IWavePlayer>();
        /// <summary>
        /// Used to play a sound file in a loop
        /// </summary>
        public static string SoundMode { get; set; } = "all"; // all, nobg, none
        Image tile = Image.FromFile("Assets/Tile.png");



        /// <summary>
        /// Creates a tile for the board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="boardSize"></param>
        /// <param name="windowHeight"></param>
        /// <returns></returns>
        public PictureBox MakeTile(int x, int y, int boardSize, int windowHeight) => MakeTile(x, y, DetermineTileSize(boardSize, windowHeight));
        /// <summary>
        /// Creates a tile for the board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PictureBox MakeTile(int x, int y, int size)
        {
            PictureBox button = new PictureBox();

            button.Location = new Point(y * size, x * size);

            button.SizeMode = PictureBoxSizeMode.StretchImage;
            button.Size = new Size(size, size);
            button.Tag = new Point(x, y);
            button.Cursor = Cursors.Hand;
            button.Image = tile;

            return button;
        }
        /// <summary>
        /// Determines the size of the tile based on the board size and window height
        /// </summary>
        /// <param name="boardSize"></param>
        /// <param name="windowHeight"></param>
        /// <returns></returns>
        public int DetermineTileSize(int boardSize, int windowHeight)
        {
            if (boardSize <= 0 || windowHeight <= 0)
            {
                return 20;
            }

            if (windowHeight - 100 > 200)
            {
                windowHeight -= 100;
            }
            int size = (windowHeight / boardSize) - 4;
            return size;
        }



        public Label CreateLabel(string text) => CreateLabel(text, Color.FromArgb(48, 33, 33), 22F);
        public Label CreateLabel(string text, float fontSize) => CreateLabel(text, Color.FromArgb(48, 33, 33), fontSize);

        /// <summary>
        /// Creates a label with the specified text, color, and font size
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        public Label CreateLabel(string text, Color color, float fontSize)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Azonix", fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.ForeColor = color;
            label.BackColor = Color.Transparent;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;

            return label;

        }

        /// <summary>
        ///  Creates a button with the specified text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public PictureBox CreateButton(string text)
        {
            PictureBox btn = new PictureBox();
            btn.SizeMode = PictureBoxSizeMode.StretchImage;
            btn.Size = new Size(175, 72);
            btn.Cursor = Cursors.Hand;
            btn.Image = Image.FromFile("Assets/BtnYellow.png");

            Label label = CreateLabel(text, Color.White, 12F);
            btn.Controls.Add(label);
            label.BringToFront();

            return btn;
        }

        /// <summary>
        /// Finds
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public PictureBox FindPictureBoxWithTag(Control parent, object tag)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is PictureBox pictureBox && Equals(pictureBox.Tag, tag))
                {
                    return pictureBox;
                }
            }
            return null;
        }



        /// <summary>
        /// Plays a singular sound
        /// </summary>
        /// <param name="filePath"></param>
        public static void PlaySound(string filePath)
        {

            if (SoundMode == "none")
            {
                return;
            }

            Task.Run(() =>
            {
                try
                {
                    var waveOut = new WaveOutEvent();
                    var audioFile = new AudioFileReader(filePath);
                    waveOut.Init(audioFile);

                    players.Add(waveOut);

                    waveOut.Play();
                    waveOut.PlaybackStopped += (s, e) =>
                    {
                        try
                        {
                            waveOut.Dispose();
                            audioFile.Dispose();
                            if (players.TryTake(out IWavePlayer player))
                            {
                                var specificPlayer = player as WaveOutEvent;
                                specificPlayer?.Dispose();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error during playback stop: {ex.Message}");
                        }


                    };

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing sound: {ex.Message}");
                }
            });

        }


        /// <summary>
        /// Used to play a sound file in a loop
        /// </summary>
        public static IWavePlayer waveOut;
        /// <summary>
        /// Used to play a sound file in a loop
        /// </summary>
        public static AudioFileReader audioFile;

        /// <summary>
        /// Used to play a sound file in a loop
        /// </summary>
        /// <param name="filePath"></param>
        public static void PlayLoopingSound(string filePath)
        {
            try
            {
                // Initialize WaveOutEvent and AudioFileReader
                waveOut = new WaveOutEvent();
                audioFile = new AudioFileReader(filePath);

                // Initialize WaveOutEvent with AudioFileReader
                waveOut.Init(audioFile);

                // Start playing the sound
                waveOut.Play();

                // Loop the sound manually by resetting its position when it ends
                waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }

        /// <summary>
        /// Method to stop sounds
        /// </summary>
        public static void StopSounds()
        {
            try
            {
                // Safely stop and dispose of waveOut
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.PlaybackStopped -= WaveOut_PlaybackStopped; // Unsubscribe from event
                    waveOut.Dispose();
                    waveOut = null;
                }

                // Dispose of audioFile
                audioFile?.Dispose();
                audioFile = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error stopping sounds: {ex.Message}");
            }
        }

        /// <summary>
        /// Stops sounds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            try
            {
                if (audioFile != null && waveOut != null)
                {
                    audioFile.Position = 0;
                    waveOut.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in playback loop: {ex.Message}");
            }
        }

        /// <summary>
        /// Checks if a sound is playing
        /// </summary>
        /// <returns></returns>
        public static bool IsSoundPlaying()
        {
            // Check if waveOut is initialized and currently playing
            return waveOut != null && waveOut.PlaybackState == PlaybackState.Playing;
        }



    }
}
