using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Game2048
{
    public partial class Form1 : Form
    {
        int[,] gameArray = new int[4, 4];

        List<Button> buttons = new List<Button>();

        Random random = new Random();

        bool moved = false;

        public Form1()
        {
            InitializeComponent();

            InitUI();

            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);

            gameArray[0, 2] = 2;
            gameArray[0, 0] = 2;

            RefreshUI();
        }

        private void InitUI()
        {

            foreach (Button btn in buttons)
            {
                btn.Text = "";
            }
        }

        private void RefreshUI()
        {
            button1.Text = gameArray[0, 0].ToString();
            button2.Text = gameArray[0, 1].ToString();
            button3.Text = gameArray[0, 2].ToString();
            button4.Text = gameArray[0, 3].ToString();
            button5.Text = gameArray[1, 3].ToString();
            button6.Text = gameArray[1, 2].ToString();
            button7.Text = gameArray[1, 1].ToString();
            button8.Text = gameArray[1, 0].ToString();
            button9.Text = gameArray[3, 3].ToString();
            button10.Text = gameArray[3, 2].ToString();
            button11.Text = gameArray[3, 1].ToString();
            button12.Text = gameArray[3, 0].ToString();
            button13.Text = gameArray[2, 3].ToString();
            button14.Text = gameArray[2, 2].ToString();
            button15.Text = gameArray[2, 1].ToString();
            button16.Text = gameArray[2, 0].ToString();

            foreach (Button btn in buttons)
            {
                if (btn.Text == "0")
                    btn.Text = "";

                btn.Refresh();
            }

            moved = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D || e.KeyCode == Keys.W)
            {
                MoveBlocks(e);
                MoveBlocks(e);
                MoveBlocks(e);      //这里移动三次就免去了判定逻辑

                MergeBlocks(e);

                MoveBlocks(e);
                MoveBlocks(e);

                if (moved == true)
                    Insert();

                RefreshUI();
            }
        }

        private void Insert()
        {
            int idle = 0;
            bool inserted = false;
            foreach (int num in gameArray)
            {
                if (num == 0)
                    idle++;
            }
            if (idle <= 0)
                return;

            int index = random.Next(1, idle);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (gameArray[i, j] == 0 && inserted == false)
                    {
                        if (index > 1)
                            index--;
                        else if (index == 1)
                        {
                            gameArray[i, j] = 2;
                            inserted = true;
                            break;
                        }
                    }

                }
        }

        private void MoveTo(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;

            moved = true;
        }

        private void MoveBlocks(KeyEventArgs e) //只移动不合并
        {
            if (e.KeyCode == Keys.W)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 3; j > 0; j--)
                    {
                        if (gameArray[j, i] != 0 && gameArray[j - 1, i] == 0)
                            MoveTo(ref gameArray[j, i], ref gameArray[j - 1, i]);
                    }
            }

            if (e.KeyCode == Keys.S)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (gameArray[j, i] != 0 && gameArray[j + 1, i] == 0)
                            MoveTo(ref gameArray[j, i], ref gameArray[j + 1, i]);
                    }
            }

            if (e.KeyCode == Keys.A)
            {
                for (int j = 0; j < 4; j++)
                    for (int i = 3; i > 0; i--)
                    {
                        if (gameArray[j, i] != 0 && gameArray[j, i - 1] == 0)
                            MoveTo(ref gameArray[j, i], ref gameArray[j, i - 1]);
                    }
            }


            if (e.KeyCode == Keys.D)
            {
                for (int j = 0; j < 4; j++)
                    for (int i = 0; i < 3; i++)
                    {
                        if (gameArray[j, i] != 0 && gameArray[j, i + 1] == 0)
                            MoveTo(ref gameArray[j, i], ref gameArray[j, i + 1]);
                    }
            }
        }

        private void MergeBlocks(KeyEventArgs e)//只合并不移动
        {
            if (e.KeyCode == Keys.W)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 3; j > 0; j--)
                    {
                        if (gameArray[j, i] != 0 && gameArray[j - 1, i] == gameArray[j, i])
                        {
                            gameArray[j - 1, i] *= 2;
                            gameArray[j, i] = 0;
                        }
                    }
            }

            if (e.KeyCode == Keys.S)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        if (gameArray[j, i] != 0 && gameArray[j + 1, i] == gameArray[j, i])
                        {
                            gameArray[j + 1, i] *= 2;
                            gameArray[j, i] = 0;
                        }
                    }
            }

            if (e.KeyCode == Keys.D)
            {
                for (int j = 0; j < 4; j++)
                    for (int i = 0; i < 3; i++)
                    {
                        if (gameArray[j, i] != 0 && gameArray[j, i + 1] == gameArray[j, i])
                        {
                            gameArray[j, i + 1] *= 2;
                            gameArray[j, i] = 0;
                        }
                    }
            }


            if (e.KeyCode == Keys.A)
            {
                for (int j = 0; j < 4; j++)
                    for (int i = 3; i > 0; i--)
                    {
                        if (gameArray[j, i] != 0 && gameArray[j, i - 1] == gameArray[j, i])
                        {
                            gameArray[j, i - 1] *= 2;
                            gameArray[j, i] = 0;
                        }
                    }
            }
        }

    }
}
