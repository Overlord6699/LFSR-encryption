using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LFSR_FORM
{
    public partial class Form1 : Form
    {
        //для удобства
        bool divideBytes = true;
        bool notAllowed;

        private string regText, inputText, key;

        int numOfIterations = 0;
        //32 28 27 1
        int[] polynomIndexes = { 0, 4, 5, 31 };
        int polynomLength = 32;

        BitArray regBitArr, inputBitArr, keyBitArr, outputBitArr;




        #region Calculations

        //метод получения самого левого бита
        private char CalculatePreviousBit()
        {
            //самый правый бит = рез xor
            char result = regText[regText.Length-1];

            for (int i = 0; i < polynomIndexes.Length; i++)
            {
                int curRegIndex = polynomIndexes[i];
                //самый левый бит мы будем игнорировать, так как мы не знаем только его
                if(curRegIndex != 0)
                {
                    //аналогия xor
                    if (!(result == regText[curRegIndex]))
                        result = '1';
                    else
                        result = '0';
                }

            }

           return result;
        }

        private void GenerateKey()
        {
            key = "";

            int registerLength = regBitArr.Length;         
            int index = 0;

            for (int i = 0; i < numOfIterations; i++)
            {
                //добавление бита в ключ
                ChangeKey(true, ref index);


                bool newBit = CalculateNewBit();
                //сдвиг всего влево
                regBitArr = SubArrray(regBitArr, 1, registerLength - 1);
                //новый бит в конец
                regBitArr[regBitArr.Length - 1] = newBit;  
            }

            ShowTable.Enabled = true;
        }

        private void ReGenerateKey(in int numOfIterations)
        {
            int regLength = regText.Length;
            int index = 0;

            keyBitArr = new BitArray(inputBitArr.Length);

            for (int i = 0; i < numOfIterations; i++)
            {
                //добавление бита в ключ слева               
                ChangeKey(false,ref index);

                //сдвиг всего вправо(длина на 1 меньше оригинала)
                string oldRegister = regText.Substring(0, regLength - 1);
                //для удобства нахождения левого бита вставим пока пустоту
                regText = " " + oldRegister;
                char oldBit = CalculatePreviousBit();

                //восстановление прежнего состояния
                regText = oldBit + oldRegister;
            }

            ShowTable.Enabled = true;
        }

        private void CreateOutput()
        {
            outputBitArr = inputBitArr.Xor(keyBitArr);
        }

        private void LFSREncrypt()
        {
            key = "";

            //если полином  задан
            ProcessPolynomInput();
            //заполнение регистра
            regBitArr =  FillBitArray(regText);
            //генерация ключа на длину входа
            GenerateKey();        

            FillKeyInTable();
            //keyBitArr = FillBitArray(key);         
        }

        private void LFSRDecrypt()
        {             
            key = "";

            ProcessPolynomInput();
            regBitArr = FillBitArray(regText);
            //генерируем ключ на длину входной строки
            ReGenerateKey(inputText.Length);

            FillKeyInTable();
            keyBitArr = FillBitArray(key);
        }

        private void FillKeyInTable()
        {
            int size = Convert.ToInt32(SizeTextBox.Text);
            //если недостаточно символов
            if (size > keyBitArr.Length)
                size = keyBitArr.Length;

            string key = "";

            if (divideBytes)
            {
                for (int i = 0; i < size; i++)
                {
                    if (i % 8 == 0)
                        key += " ";
                    key += (keyBitArr[i]==true)?"1":"0";
                    
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    key += (keyBitArr[i] == true) ? "1" : "0";
                }
            }

            KeyTextBox.Text = key;
        }

        private BitArray SubArrray(BitArray source, in int from, in int count)
        {
            bool[] bytes = new bool[count+1];


            int index = from;
            int arrIndex = 0;
            for (int i = 0; i < count; i++)
            {
                bytes[arrIndex] = source[index];
                index++;
                arrIndex++;
            }

            return new BitArray(bytes);
        }

        private void ChangeKey(in bool addToRight, ref int index)
        {
            if (addToRight)
            {
                keyBitArr[index] = regBitArr[0];             
            }
            else//иначе добавление слева
            {
                keyBitArr[keyBitArr.Length-1-index] = regBitArr[0];
            }

            index++;
        }

     

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }



        private bool CalculateNewBit()
        {
            //xor всего
            bool xorRes = regBitArr[polynomIndexes[0]];
            for (int i = 1; i < polynomIndexes.Length; i++)
                xorRes ^= regBitArr[polynomIndexes[i]];

            return xorRes;
        }
/*
        private bool TryGetStartKey()
        {
            if (RegTextBox.Text.Length + regText.Length < polynomLength)
            {
                int size = polynomLength - regText.Length;

                MessageBox.Show("Необходимо минимум " + size.ToString() + " значений в поле стартового ключа!");
                return false;
            }

            key = RegTextBox.Text.Substring(0, RegTextBox.Text.Length) + key;
            return true;
        }*/

        private void ProcessPolynomInput()
        {
            polynomLength = 32;

            if (PolTextBox.Text.Length > 0)
            {
                polynomIndexes = new int[PolTextBox.Text.Length];

                int index = 0;

                for (int i = 0; i < PolTextBox.Text.Length; i++)
                {
                    if (PolTextBox.Text[i] == '1')
                    {
                        polynomIndexes[index] = (PolTextBox.Text.Length - i-1);
                        index++;
                    }
                }


                int[] temp = new int[index];
                for (int i = 0; i < index; i++)
                    temp[i] = polynomIndexes[i];

                polynomIndexes = temp;

                
                polynomLength = polynomIndexes[0] + 1;
                
            }
        }

        private BitArray FillBitArray(in string text)
        {
            bool[] arr = new bool[text.Length];

            for (int i = 0; i < text.Length; i++)
                arr[i] = (text[i] == '1')? true: false;

            return new BitArray(arr);
        }

        #endregion




        public Form1()
        {
            InitializeComponent();
        }

        private void SetRegisterText(in string source)
        {
            regText = source;
        }

        private void FillOutputBox()
        {
            int numOfBits = Convert.ToInt32(SizeTextBox.Text);
            //если недостаточно символов
            if (numOfBits > outputBitArr.Length)
                numOfBits = outputBitArr.Length;

            string output = "";

            if (divideBytes)
            {
                for (int i = 0; i < numOfBits; i++)
                {
                    if (i % 8 == 0)
                        output += " ";
                    output += (outputBitArr[i] == true) ? "1" : "0";
                }
            }
            else {
                for (int i = 0; i < numOfBits; i++)
                    output += (outputBitArr[i] == true) ? "1" : "0";
            }

            outputTextBox.Text = output;
        }

        private void Process_Click(object sender, EventArgs e)
        {
            SetRegisterText(RegTextBox.Text);
            inputText = RegTextBox.Text;

            ClearMainText();

            
            ProcessPolynomInput();

            if (CheckRegisterLength())
            {
                numOfIterations = regText.Length + 20;

                keyBitArr = new BitArray(numOfIterations);
                LFSREncrypt();

                //ClearMemory();
            }
        }

        private void ClearMemory()
        {
            regBitArr = null;
            keyBitArr = null;
            outputBitArr = null;
            inputBitArr = null;
        }

        private void ClearMainText()
        {
            inputTextBox.Text = "";
            outputTextBox.Text = "";
            KeyTextBox.Text = "";        

            ShowTable.Enabled = false;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (ProcessOpenDialog("Open"))
            {
                int numOfBits = Convert.ToInt32(SizeTextBox.Text);
                int numOfBytes = numOfBits / 8;

                ClearMainText();

                string filename = openFileDialog.FileName;
                
                byte[] bytes = File.ReadAllBytes(filename);

                if (bytes.Length < numOfBytes)
                {
                    numOfBytes = bytes.Length;
                    numOfBits = numOfBytes * 8;
                }

                inputBitArr = new BitArray(bytes);
                
                string input = "";
                //заполнение input
                for (int i = 0; i < numOfBits; i++)
                    input += (inputBitArr[i]==true)?"1":"0";
                /*
                for (int i = 0; i < inputBitArr.Length; i++)
                {
                    if (inputBitArr[i] == true)
                        input = input.Insert(i,"1");

                }
                */
                inputTextBox.Text = input;

                MessageBox.Show("Считано " + numOfBytes.ToString() + " байт из файла");
            }else
                MessageBox.Show("Необходимо выбрать файл!");
        }

        private bool CheckRegisterLength()
        {
            int size = polynomLength - regText.Length;


            if (size < 0)
            {
                MessageBox.Show("Уменьшьте длину регистра на " + Math.Abs(size) + " символов");
                return false;
            }else if(size > 0)
            {
                MessageBox.Show("Увеличьте длину регистра на " + size + " символов");
                return false;
            }

            return true;
        }

        private void Cipher_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text.Length > 0)
            {
                SetRegisterText(RegTextBox.Text);
                inputText = inputTextBox.Text;

                KeyTextBox.Text = "";
                outputTextBox.Text = "";

                if (CheckRegisterLength())
                {
                    numOfIterations = inputText.Length;

                    keyBitArr = new BitArray(inputBitArr.Length);
                    LFSREncrypt();

                    CreateOutput();
                    FillOutputBox();

                    //ClearMemory();
                }
            }
            else
                MessageBox.Show("Сначала нужно открыть файл");
        }

        private void Decipher_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text.Length > 0)
            {
                SetRegisterText(RegTextBox.Text);
                inputText = inputTextBox.Text;

                KeyTextBox.Text = "";
                outputTextBox.Text = "";

                if (CheckRegisterLength())
                {
                    numOfIterations = inputText.Length;

                    LFSRDecrypt();

                    CreateOutput();
                    FillOutputBox();

                    //ClearMemory();
                }
            }
            else
                MessageBox.Show("Сначала нужно открыть файл");
        }

        private void SaveToFile_Click(object sender, EventArgs e)
        {
            if (ProcessOpenDialog("Write"))
            {
                string filename = openFileDialog.FileName;

                byte[] bytes = new byte[outputBitArr.Length / 8];
                
                outputBitArr.CopyTo(bytes, 0);
                

                File.WriteAllBytes(filename, bytes);

                MessageBox.Show("Запись в файл выполнена успешно!");
            }else
                MessageBox.Show("Сначала нужно выбрать файл");
        }

        private bool ProcessOpenDialog(in string title)
        {
            openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a file",
                Title = title,
            };

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return false;
            else 
                return true;
        }

        private void RegTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.D0 && e.KeyCode != Keys.D1
                    && e.KeyCode != Keys.NumPad0 && e.KeyCode != Keys.NumPad1
                    && e.KeyCode != Keys.Back)
                notAllowed = true;
            else
                notAllowed = false;
        }

        private void RegTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (notAllowed)
                e.Handled = true;
        }

        private void PolTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.D0 && e.KeyCode != Keys.D1
                    && e.KeyCode != Keys.NumPad0 && e.KeyCode != Keys.NumPad1
                    && e.KeyCode != Keys.Back)
                notAllowed = true;
            else
                notAllowed = false;
        }

        private void PolTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (notAllowed)
                e.Handled = true;
        }

        private void ShowTable_Click(object sender, EventArgs e)
        {
            regText = RegTextBox.Text;
            //если полином  задан
            ProcessPolynomInput();


            if (CheckRegisterLength())
            {
                int numOfCols = RegTextBox.Text.Length + 2;
                int numOfRows = RegTextBox.Text.Length + 20;
                
                //заполнение регистра
                regBitArr = FillBitArray(regText);

                Table table = new Table();

                table.NumOfCols = numOfCols;
                table.NumOfRows = numOfRows;
                table.MainColumns = polynomIndexes;
                table.CreateTable();
              

                //генерация ключа на длину входа
                key = "";
                int registerLength = regBitArr.Length;
                numOfIterations = RegTextBox.Text.Length + 20;
                keyBitArr = new BitArray(numOfIterations);
                int index = 0;
                for (int i = 0; i < numOfIterations; i++)
                {
                    //добавление бита в ключ
                    ChangeKey(true, ref index);


                    bool newBit = CalculateNewBit();
                    //заносим в таблицу
                    table.FillRow(regBitArr, newBit);

                    //сдвиг всего влево
                    regBitArr = SubArrray(regBitArr, 1, registerLength - 1);
                    //новый бит в конец
                    regBitArr[regBitArr.Length - 1] = newBit;               
                }
            }
        }   

        private void FillSpacesInText(ref string text)
        {
            int index = 8;
            int counter = 0;

            while (index < text.Length) {
                text = text.Insert(index, " ");
                counter++;
                index += 8 + 1;
            }
        }


        //более быстрое чтение
        public static ulong[] map = new ulong[257];

        public static Exception CalcMapFast(ref ulong[] map_, string fn)
        {
            for (var i = 0; i < 257; i++) map_[i] = 0;
            try
            {
                byte[] bytes = File.ReadAllBytes(fn);
                var len = bytes.Length;
                for (var i = 0; i < len; i++)
                {
                    map_[bytes[i]]++;
                }
                map_[256] = (ulong)len;
            }
            catch (Exception e)
            {
                return e;
            }
            return null;
        }
    }
}
