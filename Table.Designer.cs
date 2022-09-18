
namespace LFSR_FORM
{
    partial class Table
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TableGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TableGrid
            // 
            this.TableGrid.AllowUserToAddRows = false;
            this.TableGrid.AllowUserToDeleteRows = false;
            this.TableGrid.AllowUserToResizeColumns = false;
            this.TableGrid.AllowUserToResizeRows = false;
            this.TableGrid.ColumnHeadersHeight = 20;
            this.TableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TableGrid.Location = new System.Drawing.Point(0, 0);
            this.TableGrid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.TableGrid.MaximumSize = new System.Drawing.Size(0, 1080);
            this.TableGrid.MinimumSize = new System.Drawing.Size(100, 50);
            this.TableGrid.Name = "TableGrid";
            this.TableGrid.RowHeadersVisible = false;
            this.TableGrid.Size = new System.Drawing.Size(100, 685);
            this.TableGrid.TabIndex = 0;
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 709);
            this.Controls.Add(this.TableGrid);
            this.Name = "Table";
            this.Text = "Table";
            this.Load += new System.EventHandler(this.Table_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TableGrid;
    }
}