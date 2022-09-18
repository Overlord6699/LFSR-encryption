using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LFSR_FORM
{
    public partial class Table : Form
    {
        public int NumOfRows { get; set; }
        public int NumOfCols { get; set; }

        public int[] MainColumns { get; set; }

        int curRowIndex = 0;



        public Table()
        {
            InitializeComponent();
        }

        void NameRows()
        {
            for (int i = 0; i < NumOfRows; i++)
                TableGrid[0,i].Value = (i).ToString();
        }

        void NameColumns()
        {
            for (int i = 1; i < NumOfCols - 1; i++)
                TableGrid.Columns[i].HeaderText = (NumOfCols - 1 - i).ToString();
            TableGrid.Columns[NumOfCols - 1].HeaderText = "xor";
        }

        private void ColorizeColumns()
        {
            TableGrid.Columns[NumOfCols-1].DefaultCellStyle.BackColor  = Color.LightYellow;

            for(int i = 0; i < MainColumns.Length; i++)
                TableGrid.Columns[1+MainColumns[i]].DefaultCellStyle.BackColor = Color.LightBlue;
        }

        public void CreateTable()
        {
            const int SIZE = 19;

            TableGrid.RowCount = NumOfRows;
            TableGrid.ColumnCount = NumOfCols;

            TableGrid.Columns[0].Width = SIZE+2;

            for (int i = 1; i < NumOfCols; i++)
                TableGrid.Columns[i].Width = SIZE;

            for (int i = 1; i < NumOfRows; i++)
                TableGrid.Rows[i].Height = SIZE;

            TableGrid.Height = SIZE * (TableGrid.RowCount+2);
            TableGrid.Width = SIZE * (TableGrid.ColumnCount+1);

            NameColumns();
            NameRows();
            ColorizeColumns();

            curRowIndex = 0;        
        }

        public void FillRow(in BitArray bitArr,in bool xor)
        {
            for(int i = 0; i < bitArr.Length; i++)
            {
                TableGrid[i+1, curRowIndex].Value = (bitArr[i]==true)?"1":"0";   
            }

            TableGrid[NumOfCols - 1, curRowIndex].Value = (xor == true) ? "1" : "0";

            curRowIndex++;

            if(curRowIndex == NumOfRows-1)
                this.Show();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            //CreateTable();
        }
    }
}
