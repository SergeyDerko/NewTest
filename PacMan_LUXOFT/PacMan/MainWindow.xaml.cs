using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PacMan
{
    public partial class MainWindow
    {
        private int[,] _field = new int[20, 20];
        private const int Wall = 1;
        private const int Feed = 2;
        private const int Pac = 3;
        private const int Hunt = 4;
        private const int WinPos = 5;
        //переменные для координат Pacmen
        public int Column;
        public int Rou;
        //переменные для координат Apple
        public int AppleColumn;
        public int AppleRow;
        //переменные для координат Hunter
        public int HuntColumn;
        public int HuntRow;
        //переменные для координат Hunter
        public int Hunt1Column;
        public int Hunt1Row;
        //переменные для координат Hunter
        public int Hunt2Column;
        public int Hunt2Row;
        //переменные для координат Hunter
        public int Hunt3Column;
        public int Hunt3Row;
        //переменные для координат Hunter
        public int Hunt4Column;
        public int Hunt4Row;
        //элемент блокировки
        readonly object _block = new object();
        //флаг старта - стопа
        private bool _start;
        //флаг проверки работы счетчика
        private bool _timer = true;
        //переменная для подсчета яблок
        private int _win = 20;




        public MainWindow()
        {
            InitializeComponent();
            StartPos();
            //Ставим еду
            AppleGo();
            Box.Text = "Spase - Старт,   P - пауза" +
                       " Приятной игры! :)";

            
        }

        private void StartPos()
        {
            _field = new int[20, 20];
            //Начальные позиции Пакмена
            Column = 10;
            Rou = 19;
            _field[Rou, Column] = Pac;
            Grid.SetColumn(Pacman, Column);
            Grid.SetRow(Pacman, Rou);
            //Рисуем стену
            WriteWall();

            //Начальные позиции приведения
            HuntColumn = 8;
            HuntRow = 11;
            _field[HuntRow, HuntColumn] = Hunt;
            Grid.SetColumn(HunteR, HuntColumn);
            Grid.SetRow(HunteR, HuntRow);
            //Начальные позиции приведения 1
            Hunt1Column = 4;
            Hunt1Row = 3;
            _field[Hunt1Row, Hunt1Column] = Hunt;
            Grid.SetColumn(HunteR1, Hunt1Column);
            Grid.SetRow(HunteR1, Hunt1Row);
            //Начальные позиции приведения 2
            Hunt2Column = 1;
            Hunt2Row = 18;
            _field[Hunt2Row, Hunt2Column] = Hunt;
            Grid.SetColumn(HunteR2, Hunt2Column);
            Grid.SetRow(HunteR2, Hunt2Row);
            //Начальные позиции приведения 3
            Hunt3Column = 12;
            Hunt3Row = 3;
            _field[Hunt3Row, Hunt3Column] = Hunt;
            Grid.SetColumn(HunteR3, Hunt3Column);
            Grid.SetRow(HunteR3, Hunt3Row);
            //Начальные позиции приведения 4
            Hunt4Column = 14;
            Hunt4Row = 16;
            _field[Hunt4Row, Hunt4Column] = Hunt;
            Grid.SetColumn(HunteR4, Hunt4Column);
            Grid.SetRow(HunteR4, Hunt4Row);
            //позиция для лукошка
            _field[13, 3] = WinPos;
            Grid.SetColumn(Woll48, 3);
            Grid.SetRow(Woll48, 12);
            _field[12, 3] = Wall;
            
        }

        //Задаем стенке прочность :)
        private void WriteWall()
        {
            //L
            _field[2, 2] = Wall;
            _field[3, 2] = Wall;
            _field[4, 2] = Wall;
            _field[5, 2] = Wall;
            _field[6, 2] = Wall;
            _field[7, 2] = Wall;
            _field[8, 2] = Wall;
            _field[8, 3] = Wall;
            _field[8, 4] = Wall;
            //U
            _field[8, 9] = Wall;
            _field[7, 8] = Wall;
            _field[6, 8] = Wall;
            _field[5, 8] = Wall;
            _field[4, 8] = Wall;
            _field[3, 8] = Wall;
            _field[2, 8] = Wall;
            _field[2, 10] = Wall;
            _field[3, 10] = Wall;
            _field[4, 10] = Wall;
            _field[5, 10] = Wall;
            _field[6, 10] = Wall;
            _field[7, 10] = Wall;
            //X
            _field[5, 15] = Wall;
            _field[4, 15] = Wall;
            _field[3, 16] = Wall;
            _field[2, 17] = Wall;
            _field[7, 16] = Wall;
            _field[8, 17] = Wall;
            _field[3, 14] = Wall;
            _field[6, 15] = Wall;
            _field[7, 14] = Wall;
            _field[8, 13] = Wall;
            _field[2, 13] = Wall;
           
            //O
            
            _field[13, 2] = Wall;
            _field[14, 2] = Wall;
            _field[15, 2] = Wall;
            _field[16, 2] = Wall;
            _field[17, 2] = Wall;
            _field[17, 4] = Wall;
            _field[16, 4] = Wall;
            _field[15, 4] = Wall;
            _field[14, 4] = Wall;
            _field[13, 4] = Wall;
            _field[14, 3] = Wall;
            _field[15, 3] = Wall;
            _field[16, 3] = Wall;
            _field[17, 3] = Wall;
            _field[18, 3] = Wall;
            //F
            _field[12, 8] = Wall;
            _field[13, 8] = Wall;
            _field[14, 8] = Wall;
            _field[15, 8] = Wall;
            _field[16, 8] = Wall;
            _field[17, 8] = Wall;
            _field[18, 8] = Wall;
            _field[15, 9] = Wall;
            _field[12, 9] = Wall;
            _field[12, 10] = Wall;
            //T
            _field[12, 15] = Wall;
            _field[12, 14] = Wall;
            _field[12, 16] = Wall;
            _field[13, 15] = Wall;
            _field[14, 15] = Wall;
            _field[15, 15] = Wall;
            _field[16, 15] = Wall;
            _field[17, 15] = Wall;
            _field[18, 15] = Wall;

            //убираем ловушки для призраков :)
           
            _field[3, 9] = Wall;
            _field[4, 9] = Wall;
            _field[5, 9] = Wall;
            _field[6, 9] = Wall;
            _field[7, 9] = Wall;
        }

        //позиция яблока
        private void AppleGo()
        {
            _field[AppleRow, AppleColumn] = 0;
            for (int i = 0; i < 100000000; i++)
            {
                int a = 0;
                while (a < 50000000)
                {
                    AppleColumn = new Random().Next(1, 19);
                    AppleRow = new Random().Next(1, 19);
                    if (AppleColumn != AppleRow)
                    {
                        break;
                    }
                    a++;
                }

                if (_field[AppleRow, AppleColumn] == 0)
                {

                    Grid.SetColumn(Apple, AppleColumn);
                    Grid.SetRow(Apple, AppleRow);
                    _field[AppleRow, AppleColumn] = Feed;
                    break;
                }
            }
            if (_win <= 0)
            {
                Grid.SetColumn(Woll48, 2);
                Grid.SetRow(Woll48, 13);
                _field[12, 3] = 0;
                Box.Text = "Несите яблоки в корзину!!!";
            }

            else
                Box.Text = "Для победы осталось собрать " + _win + " яблок!";
        }

        //передвижение привидений
        #region stepHunter




        private void HunterGo()
        {
            _field[HuntRow, HuntColumn] = 0;
            // bool flag = true;
            int a = 0;
            while (a < 5000)
            {
                var step = new Random().Next(0, 5);
                if (step / 2 == 2 || step / 2 == 1)
                {
                    try
                    {
                        if (_field[HuntRow, HuntColumn + 1] == 0 || _field[HuntRow, HuntColumn + 1] == Pac)
                        {
                            if (_field[HuntRow, HuntColumn + 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            HuntColumn += 1;
                            Grid.SetColumn(HunteR, HuntColumn);
                            _field[HuntRow, HuntColumn] = Hunt;
                            a = 5001;
                            // flag = false;
                        }
                        else if (_field[HuntRow, HuntColumn - 1] == 0 || _field[HuntRow, HuntColumn - 1] == Pac)
                        {
                            if (_field[HuntRow, HuntColumn - 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            HuntColumn -= 1;
                            Grid.SetColumn(HunteR, HuntColumn);
                            _field[HuntRow, HuntColumn] = Hunt;
                            a = 5001;
                            //  flag = false;
                        }

                    }
                    catch (Exception)
                    {

                        if (HuntColumn == 0)
                        {
                            HuntColumn = 19;
                            if (_field[HuntRow, HuntColumn] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR, HuntColumn);
                            _field[HuntRow, HuntColumn] = Hunt;
                            a = 5001;
                            // flag = false;
                        }
                        else if (HuntColumn == 19)
                        {
                            HuntColumn = 0;
                            if (_field[HuntRow, HuntColumn] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR, HuntColumn);
                            _field[HuntRow, HuntColumn] = Hunt;
                            a = 5001;
                            // flag = false;
                        }
                    }

                }


                else
                {
                    try
                    {
                        if (_field[HuntRow - 1, HuntColumn] == 0 || _field[HuntRow - 1, HuntColumn] == Pac)
                        {
                            if (_field[HuntRow - 1, HuntColumn] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            HuntRow -= 1;
                            Grid.SetRow(HunteR, HuntRow);
                            _field[HuntRow, HuntColumn] = Hunt;
                            a = 5001;
                            // flag = false;
                        }
                        else if (_field[HuntRow + 1, HuntColumn] == 0 || _field[HuntRow + 1, HuntColumn] == Pac)
                        {
                            if (_field[HuntRow + 1, HuntColumn] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            HuntRow += 1;
                            Grid.SetRow(HunteR, HuntRow);
                            _field[HuntRow, HuntColumn] = Hunt;
                            a = 5001;
                            // flag = false;

                        }
                    }
                    catch (Exception)
                    {

                        if (HuntRow == 0)
                        {
                            HuntRow = 19;
                            if (_field[HuntRow, HuntColumn] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR, HuntRow);
                            _field[HuntRow, HuntColumn] = Hunt;
                            a = 5001;
                            // flag = false;
                        }
                        else if (HuntRow == 19)
                        {
                            HuntRow = 0;
                            if (_field[HuntRow, HuntColumn] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR, HuntRow);
                            _field[HuntRow, HuntColumn] = Hunt;
                            a = 5001;
                            // flag = false;
                        }
                    }
                }
                a++;
            }
        }
        private void HunterGo1()
        {
            _field[Hunt1Row, Hunt1Column] = 0;
            // bool flag = true;
            int a = 0;
            while (a < 5000)
            {
                var step = new Random().Next(0, 5);
                if (step / 2 == 2 || step / 2 == 1)
                {
                    try
                    {
                        if (_field[Hunt1Row, Hunt1Column + 1] == 0 || _field[Hunt1Row, Hunt1Column + 1] == Pac)
                        {
                            if (_field[Hunt1Row, Hunt1Column + 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt1Column += 1;
                            Grid.SetColumn(HunteR1, Hunt1Column);
                            _field[Hunt1Row, Hunt1Column] = Hunt;
                            a = 5001;
                            //flag = false;
                        }
                        else if (_field[Hunt1Row, Hunt1Column - 1] == 0 || _field[Hunt1Row, Hunt1Column - 1] == Pac)
                        {
                            if (_field[Hunt1Row, Hunt1Column - 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt1Column -= 1;
                            Grid.SetColumn(HunteR1, Hunt1Column);
                            _field[Hunt1Row, Hunt1Column] = Hunt;
                            a = 5001;
                            //flag = false;

                        }
                    }
                    catch (Exception)
                    {

                        if (Hunt1Column == 0)
                        {
                            Hunt1Column = 19;
                            if (_field[Hunt1Row, Hunt1Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR1, Hunt1Column);
                            _field[Hunt1Row, Hunt1Column] = Hunt;
                            a = 5001;
                            //flag = false;
                        }
                        else if (Hunt1Column == 19)
                        {
                            Hunt1Column = 0;
                            if (_field[Hunt1Row, Hunt1Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR1, Hunt1Column);
                            _field[Hunt1Row, Hunt1Column] = Hunt;
                            a = 5001;
                            // flag = false;
                        }
                    }
                }


                else
                {
                    try
                    {
                        if (_field[Hunt1Row - 1, Hunt1Column] == 0 || _field[Hunt1Row - 1, Hunt1Column] == Pac)
                        {
                            if (_field[Hunt1Row - 1, Hunt1Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt1Row -= 1;
                            Grid.SetRow(HunteR1, Hunt1Row);
                            _field[Hunt1Row, Hunt1Column] = Hunt;
                            a = 5001;
                            //flag = false;
                        }
                        else if (_field[Hunt1Row + 1, Hunt1Column] == 0 || _field[Hunt1Row + 1, Hunt1Column] == Pac)
                        {
                            if (_field[Hunt1Row + 1, Hunt1Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt1Row += 1;
                            Grid.SetRow(HunteR1, Hunt1Row);
                            _field[Hunt1Row, Hunt1Column] = Hunt;
                            a = 5001;
                            //flag = false;

                        }
                    }
                    catch (Exception)
                    {

                        if (Hunt1Row == 0)
                        {
                            Hunt1Row = 19;
                            if (_field[Hunt1Row, Hunt1Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR1, Hunt1Row);
                            _field[Hunt1Row, Hunt1Column] = Hunt;
                            a = 5001;
                            //flag = false;
                        }
                        else if (Hunt1Row == 19)
                        {
                            Hunt1Row = 0;
                            if (_field[Hunt1Row, Hunt1Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR1, Hunt1Row);
                            _field[Hunt1Row, Hunt1Column] = Hunt;
                            a = 5001;
                            // flag = false;
                        }
                    }

                }
                a++;
            }
        }
        private void HunterGo2()
        {
            _field[Hunt2Row, Hunt2Column] = 0;
            //bool flag = true;
            int a = 0;
            while (a < 5000)
            {
                var step = new Random().Next(0, 5);
                if (step / 2 == 2 || step / 2 == 1)
                {
                    try
                    {
                        if (_field[Hunt2Row, Hunt2Column + 1] == 0 || _field[Hunt2Row, Hunt2Column + 1] == Pac)
                        {
                            if (_field[Hunt2Row, Hunt2Column + 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt2Column += 1;
                            Grid.SetColumn(HunteR2, Hunt2Column);
                            _field[Hunt2Row, Hunt2Column] = Hunt;
                            a = 50001;
                            //flag = false;
                        }
                        else if (_field[Hunt2Row, Hunt2Column - 1] == 0 || _field[Hunt2Row, Hunt2Column - 1] == Pac)
                        {
                            if (_field[Hunt2Row, Hunt2Column - 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt2Column -= 1;
                            Grid.SetColumn(HunteR2, Hunt2Column);
                            _field[Hunt2Row, Hunt2Column] = Hunt;
                            a = 50001;
                            // flag = false;
                        }
                    }
                    catch (Exception)
                    {

                        if (Hunt2Column == 0)
                        {
                            Hunt2Column = 19;
                            if (_field[Hunt2Row, Hunt2Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR2, Hunt2Column);
                            _field[Hunt2Row, Hunt2Column] = Hunt;
                            a = 50001;
                            //flag = false;
                        }
                        else if (Hunt2Column == 19)
                        {
                            Hunt2Column = 0;
                            if (_field[Hunt2Row, Hunt2Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR2, Hunt2Column);
                            _field[Hunt2Row, Hunt2Column] = Hunt;
                            a = 50001;
                            // flag = false;
                        }
                    }
                }


                else
                {
                    try
                    {
                        if (_field[Hunt2Row - 1, Hunt2Column] == 0 || _field[Hunt2Row - 1, Hunt2Column] == Pac)
                        {
                            if (_field[Hunt2Row - 1, Hunt2Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt2Row -= 1;
                            Grid.SetRow(HunteR2, Hunt2Row);
                            _field[Hunt2Row, Hunt2Column] = Hunt;
                            a = 50001;
                            //flag = false;
                        }
                        else if (_field[Hunt2Row + 1, Hunt2Column] == 0 || _field[Hunt2Row + 1, Hunt2Column] == Pac)
                        {
                            if (_field[Hunt2Row + 1, Hunt2Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt2Row += 1;
                            Grid.SetRow(HunteR2, Hunt2Row);
                            _field[Hunt2Row, Hunt2Column] = Hunt;
                            a = 50001;
                            // flag = false;

                        }
                    }
                    catch (Exception)
                    {

                        if (Hunt2Row == 0)
                        {
                            Hunt2Row = 19;
                            if (_field[Hunt2Row, Hunt2Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR2, Hunt2Row);
                            _field[Hunt2Row, Hunt2Column] = Hunt;
                            a = 50001;
                            //flag = false;
                        }
                        else if (Hunt2Row == 19)
                        {
                            Hunt2Row = 0;
                            if (_field[Hunt2Row, Hunt2Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR2, Hunt2Row);
                            _field[Hunt2Row, Hunt2Column] = Hunt;
                            a = 50001;
                            //flag = false;
                        }
                    }

                }
                a++;
            }
        }
        private void HunterGo3()
        {
            _field[Hunt3Row, Hunt3Column] = 0;
            // bool flag = true;
            int a = 0;
            while (a < 5000)
            {
                var step = new Random().Next(0, 5);
                if (step / 2 == 2 || step / 2 == 1)
                {
                    try
                    {
                        if (_field[Hunt3Row, Hunt3Column + 1] == 0 || _field[Hunt3Row, Hunt3Column + 1] == Pac)
                        {
                            if (_field[Hunt3Row, Hunt3Column + 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt3Column += 1;
                            Grid.SetColumn(HunteR3, Hunt3Column);
                            _field[Hunt3Row, Hunt3Column] = Hunt;
                            a = 5000;
                            //flag = false;
                        }
                        else if (_field[Hunt3Row, Hunt3Column - 1] == 0 || _field[Hunt3Row, Hunt3Column - 1] == Pac)
                        {
                            if (_field[Hunt3Row, Hunt3Column - 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt3Column -= 1;
                            Grid.SetColumn(HunteR3, Hunt3Column);
                            _field[Hunt3Row, Hunt3Column] = Hunt;
                            a = 5000;
                            //flag = false;

                        }
                    }
                    catch (Exception)
                    {

                        if (Hunt3Column == 0)
                        {
                            Hunt3Column = 19;
                            if (_field[Hunt3Row, Hunt3Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR3, Hunt3Column);
                            _field[Hunt3Row, Hunt3Column] = Hunt;
                            a = 5000;
                            //flag = false;
                        }
                        else if (Hunt3Column == 19)
                        {
                            Hunt3Column = 0;
                            if (_field[Hunt3Row, Hunt3Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR3, Hunt3Column);
                            _field[Hunt3Row, Hunt3Column] = Hunt;
                            a = 5000;
                            //flag = false;
                        }
                    }
                }


                else
                {
                    try
                    {
                        if (_field[Hunt3Row - 1, Hunt3Column] == 0 || _field[Hunt3Row - 1, Hunt3Column] == Pac)
                        {
                            if (_field[Hunt3Row - 1, Hunt3Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt3Row -= 1;
                            Grid.SetRow(HunteR3, Hunt3Row);
                            _field[Hunt3Row, Hunt3Column] = Hunt;
                            a = 5000;
                            //flag = false;
                        }
                        else if (_field[Hunt3Row + 1, Hunt3Column] == 0 || _field[Hunt3Row + 1, Hunt3Column] == Pac)
                        {
                            if (_field[Hunt3Row + 1, Hunt3Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt3Row += 1;
                            Grid.SetRow(HunteR3, Hunt3Row);
                            _field[Hunt3Row, Hunt3Column] = Hunt;
                            a = 5000;
                            // flag = false;

                        }
                    }
                    catch (Exception)
                    {

                        if (Hunt3Row == 0)
                        {
                            Hunt3Row = 19;
                            if (_field[Hunt3Row, Hunt3Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR3, Hunt3Row);
                            _field[Hunt3Row, Hunt3Column] = Hunt;
                            a = 5000;
                            // flag = false;
                        }
                        else if (Hunt3Row == 19)
                        {
                            Hunt3Row = 0;
                            if (_field[Hunt3Row, Hunt3Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR3, Hunt3Row);
                            _field[Hunt3Row, Hunt3Column] = Hunt;
                            a = 5000;
                            //flag = false;
                        }
                    }
                }
                a++;
            }
        }
        private void HunterGo4()
        {
            _field[Hunt4Row, Hunt4Column] = 0;
            //bool flag = true;
            int a = 0;
            while (a < 5000)
            {
                var step = new Random().Next(0, 5);
                if (step / 2 == 2 || step / 2 == 1)
                {
                    try
                    {
                        if (_field[Hunt4Row, Hunt4Column + 1] == 0 || _field[Hunt4Row, Hunt4Column + 1] == Pac)
                        {
                            if (_field[Hunt4Row, Hunt4Column + 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt4Column += 1;
                            Grid.SetColumn(HunteR4, Hunt4Column);
                            _field[Hunt4Row, Hunt4Column] = Hunt;
                            a = 5000;
                            // flag = false;
                        }
                        else if (_field[Hunt4Row, Hunt4Column - 1] == 0 || _field[Hunt4Row, Hunt4Column - 1] == Pac)
                        {
                            if (_field[Hunt4Row, Hunt4Column - 1] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt4Column -= 1;
                            Grid.SetColumn(HunteR4, Hunt4Column);
                            _field[Hunt4Row, Hunt4Column] = Hunt;
                            a = 5000;
                            //flag = false;

                        }
                    }
                    catch (Exception)
                    {

                        if (Hunt4Column == 0)
                        {
                            Hunt4Column = 19;
                            if (_field[Hunt4Row, Hunt4Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR4, Hunt4Column);
                            _field[Hunt4Row, Hunt4Column] = Hunt;
                            a = 5000;
                            // flag = false;
                        }
                        else if (Hunt4Column == 19)
                        {
                            Hunt4Column = 0;
                            if (_field[Hunt4Row, Hunt4Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetColumn(HunteR4, Hunt4Column);
                            _field[Hunt4Row, Hunt4Column] = Hunt;
                            a = 5000;
                            //flag = false;
                        }
                    }
                }


                else
                {
                    try
                    {
                        if (_field[Hunt4Row - 1, Hunt4Column] == 0 || _field[Hunt4Row - 1, Hunt4Column] == Pac)
                        {
                            if (_field[Hunt4Row - 1, Hunt4Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt4Row -= 1;
                            Grid.SetRow(HunteR4, Hunt4Row);
                            _field[Hunt4Row, Hunt4Column] = Hunt;
                            a = 5000;
                            // flag = false;
                        }
                        else if (_field[Hunt4Row + 1, Hunt4Column] == 0 || _field[Hunt4Row + 1, Hunt4Column] == Pac)
                        {
                            if (_field[Hunt4Row + 1, Hunt4Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Hunt4Row += 1;
                            Grid.SetRow(HunteR4, Hunt4Row);
                            _field[Hunt4Row, Hunt4Column] = Hunt;
                            a = 5000;
                            //flag = false;

                        }
                    }
                    catch (Exception)
                    {

                        if (Hunt4Row == 0)
                        {
                            Hunt4Row = 19;
                            if (_field[Hunt4Row, Hunt4Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR4, Hunt4Row);
                            _field[Hunt4Row, Hunt4Column] = Hunt;
                            a = 5000;
                            //flag = false;
                        }
                        else if (Hunt4Row == 19)
                        {
                            Hunt4Row = 0;
                            if (_field[Hunt4Row, Hunt4Column] == Pac)
                            {
                                Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                                _win = 20;
                                Column = 0;
                                Rou = 0;
                                _field[Rou, Column] = Pac;
                                Grid.SetColumn(Pacman, Column);
                                Grid.SetRow(Pacman, Rou);
                                Grid.SetColumn(Woll48, 3);
                                Grid.SetRow(Woll48, 12);
                                _field[12, 3] = Wall;
                            }
                            Grid.SetRow(HunteR4, Hunt4Row);
                            _field[Hunt4Row, Hunt4Column] = Hunt;
                            a = 5000;
                            //flag = false;
                        }
                    }

                }
                a++;
            }
        }
        #endregion

        //передвижения Пакмана
        #region stepPacman 

        private void PacmanUp()
        {
            bool flag = true;
            foreach (var i in _field)
            {
                if (i == 2)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                AppleGo();
            _field[Rou, Column] = 0;
            try
            {
                if (_field[Rou - 1, Column] == Wall)
                {

                }
                else if (_field[Rou - 1, Column] == Hunt)
                {
                    Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                    Column = 0;
                    Rou = 0;
                    _field[Rou, Column] = Pac;
                    Grid.SetColumn(Pacman, Column);
                    Grid.SetRow(Pacman, Rou);
                    _win = 20;
                    Grid.SetColumn(Woll48, 3);
                    Grid.SetRow(Woll48, 12);
                    _field[12, 3] = Wall;
                }
                else if (_field[Rou - 1, Column] == Feed)
                {
                    Box.Text = "Ням - Ням!";
                    _win--;
                    AppleGo();
                    Rou -= 1;
                    Grid.SetRow(Pacman, Rou);
                    _field[Rou, Column] = Pac;



                }
                else if (Rou == 0)
                {
                    Rou = 19;
                    if (_field[Rou, Column] == Hunt)
                    {
                        Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                        _win = 20;
                        Column = 0;
                        Rou = 0;
                        _field[Rou, Column] = Pac;
                        Grid.SetColumn(Pacman, Column);
                        Grid.SetRow(Pacman, Rou);
                        Grid.SetColumn(Woll48, 3);
                        Grid.SetRow(Woll48, 12);
                        _field[12, 3] = Wall;
                    }
                    else
                    {
                        Grid.SetRow(Pacman, Rou);
                        _field[Rou, Column] = Pac;
                    }

                }
                else
                {
                    Rou -= 1;
                    Grid.SetRow(Pacman, Rou);
                    _field[Rou, Column] = Pac;
                }
            }
            catch (Exception)
            {
                if (Rou == 0)
                {
                    Rou = 19;
                    if (_field[Rou, Column] == Hunt)
                    {
                        Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                        _win = 20;
                        Column = 0;
                        Rou = 0;
                        _field[Rou, Column] = Pac;
                        Grid.SetColumn(Pacman, Column);
                        Grid.SetRow(Pacman, Rou);
                        Grid.SetColumn(Woll48, 3);
                        Grid.SetRow(Woll48, 12);
                        _field[12, 3] = Wall;
                    }
                    else
                    {
                        Grid.SetRow(Pacman, Rou);
                        _field[Rou, Column] = Pac;
                    }
                }
                else
                {
                    Rou -= 1;
                    Grid.SetRow(Pacman, Rou);
                    _field[Rou, Column] = Pac;
                }

            }
        }


        private void PacmanDuwn()
        {
            bool flag = true;
            foreach (var i in _field)
            {
                if (i == 2)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                AppleGo();

            _field[Rou, Column] = 0;


            try
            {
                if (_field[Rou + 1, Column] == WinPos)
                {
                    WinerPac();
                }
                else if (_field[Rou + 1, Column] == Wall)
                {

                }
                else if (_field[Rou + 1, Column] == Hunt)
                {
                    Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                    _win = 20;
                    Column = 0;
                    Rou = 0;
                    _field[Rou, Column] = Pac;
                    Grid.SetColumn(Pacman, Column);
                    Grid.SetRow(Pacman, Rou);
                    Grid.SetColumn(Woll48, 3);
                    Grid.SetRow(Woll48, 12);
                    _field[12, 3] = Wall;
                }
                else if (_field[Rou + 1, Column] == Feed)
                {
                    Box.Text = "Ням - Ням!";
                    _win--;
                    AppleGo();
                    Rou += 1;
                    Grid.SetRow(Pacman, Rou);
                    _field[Rou, Column] = Pac;

                }
                else if (Rou == 19)
                {
                    Rou = 0;
                    if (_field[Rou, Column] == Hunt)
                    {
                        Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                        _win = 20;
                        Column = 0;
                        Rou = 0;
                        _field[Rou, Column] = Pac;
                        Grid.SetColumn(Pacman, Column);
                        Grid.SetRow(Pacman, Rou);
                        Grid.SetColumn(Woll48, 3);
                        Grid.SetRow(Woll48, 12);
                        _field[12, 3] = Wall;
                    }
                    else
                    {
                        Grid.SetRow(Pacman, Rou);
                        _field[Rou, Column] = Pac;
                    }
                }
                else
                {
                    Rou += 1;
                    Grid.SetRow(Pacman, Rou);
                    _field[Rou, Column] = Pac;
                }
            }
            catch (Exception)
            {
                if (Rou == 19)
                {
                    Rou = 0;
                    if (_field[Rou, Column] == Hunt)
                    {
                        Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                        _win = 20;
                        Column = 0;
                        Rou = 0;
                        _field[Rou, Column] = Pac;
                        Grid.SetColumn(Pacman, Column);
                        Grid.SetRow(Pacman, Rou);
                        Grid.SetColumn(Woll48, 3);
                        Grid.SetRow(Woll48, 12);
                        _field[12, 3] = Wall;
                    }
                    else
                    {
                        Grid.SetRow(Pacman, Rou);
                        _field[Rou, Column] = Pac;
                    }
                }
                else
                {
                    Rou += 1;
                    Grid.SetRow(Pacman, Rou);
                    _field[Rou, Column] = Pac;
                }
            }


        }

        private void PacmanLeft()
        {
            bool flag = true;
            foreach (var i in _field)
            {
                if (i == 2)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                AppleGo();
            _field[Rou, Column] = 0;
            try
            {
                if (_field[Rou, Column - 1] == Wall)
                {

                }
                else if (_field[Rou, Column - 1] == Hunt)
                {
                    Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                    _win = 20;
                    Column = 0;
                    Rou = 0;
                    _field[Rou, Column] = Pac;
                    Grid.SetColumn(Pacman, Column);
                    Grid.SetRow(Pacman, Rou);
                    Grid.SetColumn(Woll48, 3);
                    Grid.SetRow(Woll48, 12);
                    _field[12, 3] = Wall;
                }
                else if (_field[Rou, Column - 1] == Feed)
                {
                    Box.Text = "Ням - Ням!";
                    _win--;
                    AppleGo();
                    Column -= 1;
                    Grid.SetColumn(Pacman, Column);
                    _field[Rou, Column] = Pac;


                }
                else if (Column == 0)
                {
                    Column = 19;
                    if (_field[Rou, Column] == Hunt)
                    {
                        Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                        _win = 20;
                        Column = 0;
                        Rou = 0;
                        _field[Rou, Column] = Pac;
                        Grid.SetColumn(Pacman, Column);
                        Grid.SetRow(Pacman, Rou);
                        Grid.SetColumn(Woll48, 3);
                        Grid.SetRow(Woll48, 12);
                        _field[12, 3] = Wall;
                    }
                    else
                    {
                        Grid.SetColumn(Pacman, Column);
                        _field[Rou, Column] = Pac;
                    }
                }
                else
                {
                    Column -= 1;
                    Grid.SetColumn(Pacman, Column);
                    _field[Rou, Column] = Pac;
                }
            }
            catch (Exception)
            {
                if (Column == 0)
                {
                    Column = 19;
                    if (_field[Rou, Column] == Hunt)
                    {
                        Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                        _win = 20;
                        Column = 0;
                        Rou = 0;
                        _field[Rou, Column] = Pac;
                        Grid.SetColumn(Pacman, Column);
                        Grid.SetRow(Pacman, Rou);
                        Grid.SetColumn(Woll48, 3);
                        Grid.SetRow(Woll48, 12);
                        _field[12, 3] = Wall;
                    }
                    else
                    {
                        Grid.SetColumn(Pacman, Column);
                        _field[Rou, Column] = Pac;
                    }
                    Grid.SetColumn(Pacman, Column);
                    _field[Rou, Column] = Pac;
                }
                else
                {
                    Column -= 1;
                    Grid.SetColumn(Pacman, Column);
                    _field[Rou, Column] = Pac;
                }
            }

        }

        private void PacmanRight()
        {
            bool flag = true;
            foreach (var i in _field)
            {
                if (i == 2)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                AppleGo();
            _field[Rou, Column] = 0;
            try
            {
                if (_field[Rou, Column + 1] == Wall)
                {

                }
                else if (_field[Rou, Column + 1] == Hunt)
                {
                    Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                    _win = 20;
                    Column = 0;
                    Rou = 0;
                    _field[Rou, Column] = Pac;
                    Grid.SetColumn(Pacman, Column);
                    Grid.SetRow(Pacman, Rou);
                    Grid.SetColumn(Woll48, 3);
                    Grid.SetRow(Woll48, 12);
                    _field[12, 3] = Wall;
                }
                else if (_field[Rou, Column + 1] == Feed)
                {
                    Box.Text = "Ням - Ням!";
                    _win--;
                    AppleGo();
                    Column += 1;
                    Grid.SetColumn(Pacman, Column);
                    _field[Rou, Column] = Pac;


                }
                else
                if (Column == 19)
                {
                    Column = 0;
                    if (_field[Rou, Column] == Hunt)
                    {
                        Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                        _win = 20;
                        Column = 0;
                        Rou = 0;
                        _field[Rou, Column] = Pac;
                        Grid.SetColumn(Pacman, Column);
                        Grid.SetRow(Pacman, Rou);
                        Grid.SetColumn(Woll48, 3);
                        Grid.SetRow(Woll48, 12);
                        _field[12, 3] = Wall;
                    }
                    else
                    {
                        Grid.SetColumn(Pacman, Column);
                        _field[Rou, Column] = Pac;
                    }
                    Grid.SetColumn(Pacman, Column);
                    _field[Rou, Column] = Pac;
                }
                else
                {
                    Column += 1;
                    Grid.SetColumn(Pacman, Column);
                    _field[Rou, Column] = Pac;
                }
            }
            catch (Exception)
            {
                if (Column == 19)
                {
                    Column = 0;
                    if (_field[Rou, Column] == Hunt)
                    {
                        Box.Text = "А-а-а-а-а-а!!! Яблоки утерянны!";
                        _win = 20;
                        Column = 0;
                        Rou = 0;
                        _field[Rou, Column] = Pac;
                        Grid.SetColumn(Pacman, Column);
                        Grid.SetRow(Pacman, Rou);
                        Grid.SetColumn(Woll48, 3);
                        Grid.SetRow(Woll48, 12);
                        _field[12, 3] = Wall;
                    }
                    else
                    {
                        Grid.SetColumn(Pacman, Column);
                        _field[Rou, Column] = Pac;
                    }
                    Grid.SetColumn(Pacman, Column);
                    _field[Rou, Column] = Pac;
                }
                else
                {
                    Column += 1;
                    Grid.SetColumn(Pacman, Column);
                    _field[Rou, Column] = Pac;
                }
            }

        }

        #endregion

        //обработка кнопок
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            if (e.Key == Key.Down)
            {
                if (_start)
                    lock (_block)
                    {
                        PacmanDuwn();
                    }

            }


            else
            if (e.Key == Key.Left)
            {
                if (_start)
                    lock (_block)
                    {
                        PacmanLeft();
                    }

            }

            else
            if (e.Key == Key.Right)
            {
                if (_start)
                    lock (_block)
                    {
                        PacmanRight();
                    }

            }

            else
            if (e.Key == Key.Up)
            {
                if (_start)
                    lock (_block)
                    {
                        PacmanUp();
                    }

            }
            else
            if (e.Key == Key.Space)
            {
                _start = true;
                if (_timer)
                    Timer();


            }
            else
            if (e.Key == Key.P)
            {
                _start = false;

            }

        }
        //запуск таймера для дивижения приведений
        private void Timer()
        {
            _timer = false;
            var timer = new DispatcherTimer();
            timer.Tick += RunHunters;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }
        //вызов методов движения приведений
        private void RunHunters(object sender, EventArgs e)
        {
            if (_start)
            {
                lock (_block)
                {
                    HunterGo();
                    HunterGo1();
                    HunterGo2();
                    HunterGo3();
                    HunterGo4();
                }
            }
        }
        //метод выиграша
        private void WinerPac()
        {
            Box.Text = "ПОБЕДА!!!";
            _start = false;
            _timer = false;
            _win = 20;
            StartPos();
        }
    }

}
