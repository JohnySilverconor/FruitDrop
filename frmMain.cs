using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Media;

namespace com.langesite.fruitdrop
{
    public partial class frmMain : Form
    {
        public static readonly int BOARD_MAX_WIDTH = 8; // Game board width.
        public static readonly int BOARD_MAX_HEIGHT = 7; // Game board height.
        public static readonly int IMAGE_MAX_WIDTH = 28; // Max width of images.
        public static readonly int IMAGE_MAX_HEIGHT = 32; // Max height of images.

        private static Bitmap m_Bitmap = new Bitmap(IMAGE_MAX_WIDTH * BOARD_MAX_WIDTH, IMAGE_MAX_HEIGHT * BOARD_MAX_HEIGHT);
        private static int[,] m_PuzzleGrid = new int[BOARD_MAX_WIDTH, BOARD_MAX_HEIGHT];
        private static int[,] m_TestGrid = new int[BOARD_MAX_WIDTH, BOARD_MAX_HEIGHT];
        private static int m_Score = 0;
        private static bool m_IsGameOver = false;
        private static bool m_IsSoundOn = true;
        private static Random m_Random = new Random();
        private static SoundPlayer m_SoundPlayer = new SoundPlayer();

        #region Form Controls, Methods, and Events
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitializeSound();
            InitializeGame();
        }

        private void InitializeSound()
        {
            // This method simply loads and plays a quiet wav file
            // to 'prime' the sound player.  Otherwise there is a
            // noticeable delay the first time a sound is played.
            // Could be changed to a game intro wav.
            if (m_IsSoundOn)
            {
                try
                {
                    m_SoundPlayer.Stop();
                    m_SoundPlayer.Stream = new MemoryStream(com.langesite.fruitdrop.Properties.Resources.Quiet);
                    m_SoundPlayer.Load();
                    m_SoundPlayer.Play();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void pbGameBox_Click(object sender, EventArgs e)
        {
            ProcessTurn();
        }

        private void menuGameExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuGameNew_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void menuSoundOn_Click(object sender, EventArgs e)
        {
            m_IsSoundOn = true;
            menuSoundOn.Checked = true;
            menuSoundOff.Checked = false;
        }

        private void menuSoundOff_Click(object sender, EventArgs e)
        {
            m_IsSoundOn = false;
            menuSoundOn.Checked = false;
            menuSoundOff.Checked = true;
        }
        #endregion

        #region Game Methods
        private void ProcessTurn()
        {
            if (m_IsGameOver == false)
            {
                // Map the mouse cursor position to the correct image in the picture box.
                Point aPoint = pbGameBox.PointToClient(new Point(MousePosition.X, MousePosition.Y));

                int aPositionX = aPoint.X / IMAGE_MAX_WIDTH;
                int aPositionY = aPoint.Y / IMAGE_MAX_HEIGHT;

                AdjacencySearch(aPositionX, aPositionY);
            }
        }

        private void InitializeGame()
        {
            m_IsGameOver = false;

            m_Score = 0;
            lblScoreValue.Text = m_Score.ToString();

            // Dynamically size and position the picture box.
            pbGameBox.Width = (IMAGE_MAX_WIDTH * BOARD_MAX_WIDTH);
            pbGameBox.Height = (IMAGE_MAX_HEIGHT * BOARD_MAX_HEIGHT);
            pbGameBox.Left = (this.Width - pbGameBox.Width) / 2;

            InitializeGrid();
        }

        public void InitializeGrid()
        {
            // Put a random image into each cell.
            for (int aColumn = 0; aColumn < BOARD_MAX_WIDTH; ++aColumn)
            {
                for (int aRow = 0; aRow < BOARD_MAX_HEIGHT; ++aRow)
                {
                    m_PuzzleGrid[aColumn, aRow] = m_Random.Next(1, 6);
                }
            }
            RenderGrid();
        }

        private void RenderGrid()
        {
            // Clear the picture box.
            pbGameBox.Image = m_Bitmap;

            Image aGameBoxImage = this.pbGameBox.Image;

            // Render the screen using preloaded images.
            using (Graphics g = Graphics.FromImage(aGameBoxImage))
            {

                for (int aRow = 0; aRow < BOARD_MAX_HEIGHT; ++aRow)
                {
                    for (int aColumn = 0; aColumn < BOARD_MAX_WIDTH; ++aColumn)
                    {
                        switch (m_PuzzleGrid[aColumn, aRow])
                        {
                            case 0:
                                g.DrawImage(pbZero.Image, new Rectangle(aColumn * IMAGE_MAX_WIDTH, aRow * IMAGE_MAX_HEIGHT, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), new Rectangle(0, 0, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), GraphicsUnit.Pixel);
                                break;
                            case 1:
                                g.DrawImage(pbOne.Image, new Rectangle(aColumn * IMAGE_MAX_WIDTH, aRow * IMAGE_MAX_HEIGHT, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), new Rectangle(0, 0, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), GraphicsUnit.Pixel);
                                break;
                            case 2:
                                g.DrawImage(pbTwo.Image, new Rectangle(aColumn * IMAGE_MAX_WIDTH, aRow * IMAGE_MAX_HEIGHT, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), new Rectangle(0, 0, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), GraphicsUnit.Pixel);
                                break;
                            case 3:
                                g.DrawImage(pbThree.Image, new Rectangle(aColumn * IMAGE_MAX_WIDTH, aRow * IMAGE_MAX_HEIGHT, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), new Rectangle(0, 0, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), GraphicsUnit.Pixel);
                                break;
                            case 4:
                                g.DrawImage(pbFour.Image, new Rectangle(aColumn * IMAGE_MAX_WIDTH, aRow * IMAGE_MAX_HEIGHT, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), new Rectangle(0, 0, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), GraphicsUnit.Pixel);
                                break;
                            case 5:
                                g.DrawImage(pbFive.Image, new Rectangle(aColumn * IMAGE_MAX_WIDTH, aRow * IMAGE_MAX_HEIGHT, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), new Rectangle(0, 0, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), GraphicsUnit.Pixel);
                                break;
                            case 9:
                                g.DrawImage(pbPop.Image, new Rectangle(aColumn * IMAGE_MAX_WIDTH, aRow * IMAGE_MAX_HEIGHT, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), new Rectangle(0, 0, IMAGE_MAX_WIDTH, IMAGE_MAX_HEIGHT), GraphicsUnit.Pixel);
                                break;
                        }
                    }
                }
            }
        }

        private void DrawGameOver()
        {
            Image aGameBoxImage = this.pbGameBox.Image;

            // Get Graphics Object.
            using (Graphics g = Graphics.FromImage(aGameBoxImage))
            {
                // Draw string on graphic.
                g.DrawString("Game Over", new Font("Verdana", 20, FontStyle.Bold),
                new SolidBrush(Color.Blue), 36, 2);
            }
        }

        private void SetupDrop()
        {
            for (int aColumn = 0; aColumn < BOARD_MAX_WIDTH; ++aColumn)
            {
                for (int aRow = 0; aRow < BOARD_MAX_HEIGHT; ++aRow)
                {
                    if (m_TestGrid[aColumn, aRow] != 0)
                    {
                        m_PuzzleGrid[aColumn, aRow] = 9;
                    }
                }
            }
        }

        private void PerformDrop()
        {
            for (int aRow = BOARD_MAX_HEIGHT - 1; aRow > 0; --aRow)
            {
                for (int aColumn = 0; aColumn < BOARD_MAX_WIDTH; ++aColumn)
                {

                    while (m_PuzzleGrid[aColumn, aRow] == 9)
                    {
                        for (int aMoveRow = aRow; aMoveRow >= 0; --aMoveRow)
                        {
                            if (aMoveRow > 0)
                            {
                                m_PuzzleGrid[aColumn, aMoveRow] = m_PuzzleGrid[aColumn, aMoveRow - 1];
                            }
                            else
                            {
                                m_PuzzleGrid[aColumn, aMoveRow] = 0;
                            }
                        }
                        RenderGrid();
                    }
                }

                for (int aColumn = 0; aColumn < BOARD_MAX_WIDTH; ++aColumn)
                {
                    if (m_PuzzleGrid[aColumn, 0] == 9)
                    {
                        m_PuzzleGrid[aColumn, 0] = 0;
                    }
                }
            }
            ClearCheckGrid();
        }

        private void ClearCheckGrid()
        {
            for (int aColumn = 0; aColumn < BOARD_MAX_WIDTH; ++aColumn)
            {
                for (int aRow = 0; aRow < BOARD_MAX_HEIGHT; ++aRow)
                {
                    m_TestGrid[aColumn, aRow] = 0;
                }
            }
        }

        private void CheckGameOver()
        {
            // If there are no more adjacent matches, then the game is over.
            if (CheckForHorizontalMoves() == true || CheckForVerticalMoves() == true)
            {
                m_IsGameOver = false;
            }
            else
            {
                m_IsGameOver = true;
                DrawGameOver();

                if (m_IsSoundOn)
                {
                    try
                    {
                        m_SoundPlayer.Stop();
                        m_SoundPlayer.Stream = new MemoryStream(com.langesite.fruitdrop.Properties.Resources.Boing);
                        m_SoundPlayer.Load();
                        m_SoundPlayer.Play();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        private bool CheckForHorizontalMoves()
        {
            bool aReturnVal = false;

            for (int aImageType = 1; aImageType <= 6; ++aImageType)
            {
                for (int aRow = 0; aRow < BOARD_MAX_HEIGHT; ++aRow)
                {
                    int aMatchCount = 0;
                    for (int aColumn = 0; aColumn < BOARD_MAX_WIDTH; ++aColumn)
                    {
                        if (m_PuzzleGrid[aColumn, aRow] == aImageType)
                        {
                            ++aMatchCount;
                        }
                        else
                        {
                            aMatchCount = 0;
                        }

                        if (aMatchCount > 1)
                        {
                            aReturnVal = true;
                        }
                    }
                }
            }
            return aReturnVal;
        }

        private bool CheckForVerticalMoves()
        {
            bool aReturnVal = false;

            for (int aImageType = 1; aImageType <= 6; ++aImageType)
            {
                for (int aColumn = 0; aColumn < BOARD_MAX_WIDTH; ++aColumn)
                {
                    int aMatchCount = 0;
                    for (int aRow = 0; aRow < BOARD_MAX_HEIGHT; ++aRow)
                    {
                        if (m_PuzzleGrid[aColumn, aRow] == aImageType)
                        {
                            ++aMatchCount;
                        }
                        else
                        {
                            aMatchCount = 0;
                        }

                        if (aMatchCount > 1)
                        {
                            aReturnVal = true;
                        }
                    }
                }
            }
            return aReturnVal;
        }

        private void RemoveZeroColumns(int[,] tGrid)
        {
            int aCurrentColumn = BOARD_MAX_WIDTH - 1;
            int aNonzeroCounter = 0;
            int aZeroColumnInsertedCounter = 0;

            // Loop until all columns are checked except the zero
            // column or any inserted columns.
            while (aCurrentColumn > aZeroColumnInsertedCounter)
            {
                for (int aCurrentRow = 0; aCurrentRow < BOARD_MAX_HEIGHT; aCurrentRow++)
                {
                    // Does cell contain non-zero?
                    if (tGrid[aCurrentColumn, aCurrentRow] > 0)
                    {
                        // Increment the non-zero counter.
                        aNonzeroCounter++;
                    }
                }

                if (aNonzeroCounter > 0)
                {
                    // If a non-zero was found in the current
                    // column, nothing to do but check the next
                    // column (from max column to first column).
                    aCurrentColumn--;
                    aNonzeroCounter = 0;
                }
                else
                {
                    // No non-zero values were found in the current
                    // column. Move all columns to the right.
                    for (int aMoveColumn = aCurrentColumn; aMoveColumn > 0; aMoveColumn--)
                    {
                        for (int aMoveRow = 0; aMoveRow < BOARD_MAX_HEIGHT; aMoveRow++)
                        {
                            tGrid[aMoveColumn, aMoveRow] = tGrid[aMoveColumn - 1, aMoveRow];
                        }
                    }

                    // Zero out the first column.
                    for (int aZeroRow = 0; aZeroRow < BOARD_MAX_HEIGHT; aZeroRow++)
                    {
                        tGrid[0, aZeroRow] = 0;
                    }

                    // Count the number of columns inserted to
                    // avoid forever loop.
                    aZeroColumnInsertedCounter++;
                }
            }
        }

        private void AdjacencySearch(int tPositionX, int tPositionY)
        {
            // Creat a stack for saving points.
            Stack<Point> aPointStack = new Stack<Point>();
            Point aPoint = new Point();
            int aMatchCount = 0;

            int aCurrX = tPositionX;
            int aCurrY = tPositionY;

            // Get value of selected image.
            int aCellValue = m_PuzzleGrid[tPositionX, tPositionY];
            if (aCellValue > 0)
            {
                // Cell value =   +X: Non-visited cell value.
                // Cell value =   -X: Cell visited.
                // Cell value =  -1X: Cell visited. Checking image to the north.
                // Cell value =  -2X: Cell visited. Checking image to the east.
                // Cell value =  -3X: Cell visited. Checking image to the south.
                // Cell value =  -4X: Cell visited. Checking image to the west.
                // Cell value =  -5X: Cell visited. Done checking.
                // Cell value =    9: Image marked for removal.  

                // Mark current object as 'visited' ... set it equal to -value.
                m_PuzzleGrid[aCurrX, aCurrY] = -m_PuzzleGrid[aCurrX, aCurrY];
                aPoint.X = aCurrX;
                aPoint.Y = aCurrY;
                aPointStack.Push(aPoint);

                while (aPointStack.Count > 0)
                {
                    Point aPeekPoint = aPointStack.Peek();

                    int aCheckValue = m_PuzzleGrid[aPeekPoint.X, aPeekPoint.Y];
                    if (aCheckValue > -10)
                    {
                        Point aPivetPoint = aPointStack.Pop();
                        m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y] -= 10;
                        aPointStack.Push(aPivetPoint);

                        if (aPivetPoint.Y > 0)
                        {
                            if (m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y - 1] == aCellValue)
                            {
                                aMatchCount++;
                                m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y - 1] = -m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y - 1];
                                aPointStack.Push(new Point(aPivetPoint.X, aPivetPoint.Y - 1));
                            }
                        }
                    }
                    else if (aCheckValue > -20)
                    {
                        Point aPivetPoint = aPointStack.Pop();
                        m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y] -= 10;
                        aPointStack.Push(aPivetPoint);

                        if (aPivetPoint.X < BOARD_MAX_WIDTH - 1)
                        {
                            if (m_PuzzleGrid[aPivetPoint.X + 1, aPivetPoint.Y] == aCellValue)
                            {
                                aMatchCount++;
                                m_PuzzleGrid[aPivetPoint.X + 1, aPivetPoint.Y] = -m_PuzzleGrid[aPivetPoint.X + 1, aPivetPoint.Y];
                                aPointStack.Push(new Point(aPivetPoint.X + 1, aPivetPoint.Y));
                            }
                        }
                    }
                    else if (aCheckValue > -30)
                    {
                        Point aPivetPoint = aPointStack.Pop();
                        m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y] -= 10;
                        aPointStack.Push(aPivetPoint);

                        if (aPivetPoint.Y < BOARD_MAX_HEIGHT - 1)
                        {
                            if (m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y + 1] == aCellValue)
                            {
                                aMatchCount++;
                                m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y + 1] = -m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y + 1];
                                aPointStack.Push(new Point(aPivetPoint.X, aPivetPoint.Y + 1));
                            }
                        }
                    }
                    else if (aCheckValue > -40)
                    {
                        Point aPivetPoint = aPointStack.Pop();
                        m_PuzzleGrid[aPivetPoint.X, aPivetPoint.Y] -= 10;
                        aPointStack.Push(aPivetPoint);

                        if (aPivetPoint.X > 0)
                        {
                            if (m_PuzzleGrid[aPivetPoint.X - 1, aPivetPoint.Y] == aCellValue)
                            {
                                aMatchCount++;
                                m_PuzzleGrid[aPivetPoint.X - 1, aPivetPoint.Y] = -m_PuzzleGrid[aPivetPoint.X - 1, aPivetPoint.Y];
                                aPointStack.Push(new Point(aPivetPoint.X - 1, aPivetPoint.Y));
                            }
                        }
                    }
                    else if (aCheckValue > -50)
                    {
                        // All four directions have been checked for the current image,
                        // so pop the stack to get the next image to check.
                        Point aCurrPoint = aPointStack.Pop();

                        if (aPointStack.Count > 0)
                        {
                            // If more than one image is on the stack, then there
                            // must have been at least one match, so clear the current one.
                            m_PuzzleGrid[aCurrPoint.X, aCurrPoint.Y] = 9;
                        }
                        else if (aPointStack.Count == 0 && aMatchCount == 0)
                        {
                            // If there are no images left on the stack and there
                            // are no matches, then it is an illegal click.  Set
                            // image back to original value.
                            m_PuzzleGrid[aCurrPoint.X, aCurrPoint.Y] = aCellValue;
                        }
                        else
                        {
                            // Finally, this is the original image since the stack
                            // is now zero and there was at least one match so clear
                            // the original image as well.
                            aMatchCount++;
                            m_PuzzleGrid[aCurrPoint.X, aCurrPoint.Y] = 9;
                        }
                    }
                }

                if (aMatchCount > 0)
                {
                    // Give the 'image clearing' image a moment to display.
                    RenderGrid();
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(50);

                    if (m_IsSoundOn)
                    {
                        try
                        {
                            m_SoundPlayer.Stop();
                            m_SoundPlayer.Stream = new MemoryStream(com.langesite.fruitdrop.Properties.Resources.Pop);
                            m_SoundPlayer.Load();
                            m_SoundPlayer.Play();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(100);
                    }

                    // Calculate the score for this turn.
                    m_Score += Convert.ToInt32(Math.Pow(aMatchCount, 2));
                    lblScoreValue.Text = m_Score.ToString();

                    // Clear any images marked for removal and let the remaining
                    // images drop as needed.
                    SetupDrop();
                    PerformDrop();
                    RenderGrid();

                    // Handle and empty columns by move all remaining columns
                    // to the right as needed.
                    RemoveZeroColumns(m_PuzzleGrid);
                    RenderGrid();

                    // Check if there are any remaining moves.
                    CheckGameOver();
                }
            }
        }
        #endregion
    }
}