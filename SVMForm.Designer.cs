namespace LogisticRegession
{
  partial class SVMForm
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
      this.components = new System.ComponentModel.Container();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.graphInput = new ZedGraph.ZedGraphControl();
      this.dgvLearningSource = new System.Windows.Forms.DataGridView();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnSimpleSMO = new System.Windows.Forms.Button();
      this.btnOpen = new System.Windows.Forms.Button();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.btnKernel = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvLearningSource)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.graphInput, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.dgvLearningSource, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.946F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.054F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 537);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // graphInput
      // 
      this.graphInput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.graphInput.Location = new System.Drawing.Point(407, 94);
      this.graphInput.Name = "graphInput";
      this.graphInput.ScrollGrace = 0D;
      this.graphInput.ScrollMaxX = 0D;
      this.graphInput.ScrollMaxY = 0D;
      this.graphInput.ScrollMaxY2 = 0D;
      this.graphInput.ScrollMinX = 0D;
      this.graphInput.ScrollMinY = 0D;
      this.graphInput.ScrollMinY2 = 0D;
      this.graphInput.Size = new System.Drawing.Size(399, 440);
      this.graphInput.TabIndex = 3;
      // 
      // dgvLearningSource
      // 
      this.dgvLearningSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvLearningSource.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvLearningSource.Location = new System.Drawing.Point(3, 94);
      this.dgvLearningSource.Name = "dgvLearningSource";
      this.dgvLearningSource.Size = new System.Drawing.Size(398, 440);
      this.dgvLearningSource.TabIndex = 2;
      // 
      // groupBox1
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
      this.groupBox1.Controls.Add(this.btnKernel);
      this.groupBox1.Controls.Add(this.btnSimpleSMO);
      this.groupBox1.Controls.Add(this.btnOpen);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(803, 85);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // btnSimpleSMO
      // 
      this.btnSimpleSMO.Location = new System.Drawing.Point(90, 19);
      this.btnSimpleSMO.Name = "btnSimpleSMO";
      this.btnSimpleSMO.Size = new System.Drawing.Size(75, 23);
      this.btnSimpleSMO.TabIndex = 2;
      this.btnSimpleSMO.Text = "Simple SMO";
      this.btnSimpleSMO.UseVisualStyleBackColor = true;
      this.btnSimpleSMO.Click += new System.EventHandler(this.btnSimpleSMO_Click);
      // 
      // btnOpen
      // 
      this.btnOpen.Location = new System.Drawing.Point(9, 19);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(75, 23);
      this.btnOpen.TabIndex = 1;
      this.btnOpen.Text = "Open";
      this.btnOpen.UseVisualStyleBackColor = true;
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.FileName = "openFileDialog1";
      // 
      // btnKernel
      // 
      this.btnKernel.Location = new System.Drawing.Point(171, 19);
      this.btnKernel.Name = "btnKernel";
      this.btnKernel.Size = new System.Drawing.Size(75, 23);
      this.btnKernel.TabIndex = 3;
      this.btnKernel.Text = "Kernel";
      this.btnKernel.UseVisualStyleBackColor = true;
      this.btnKernel.Click += new System.EventHandler(this.btnKernel_Click);
      // 
      // SVMForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(809, 537);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "SVMForm";
      this.Text = "SVMForm";
      this.Load += new System.EventHandler(this.SVMForm_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvLearningSource)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DataGridView dgvLearningSource;
    private ZedGraph.ZedGraphControl graphInput;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.Button btnSimpleSMO;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button btnKernel;
  }
}