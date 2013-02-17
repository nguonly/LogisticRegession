namespace LogisticRegession
{
  partial class Form1
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
      this.dgvLearningSource = new System.Windows.Forms.DataGridView();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.btnOpen = new System.Windows.Forms.Button();
      this.btnAnalyze = new System.Windows.Forms.Button();
      this.cmdTest = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtX1 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtX2 = new System.Windows.Forms.TextBox();
      this.btnStochastic0 = new System.Windows.Forms.Button();
      this.btnStochastic1 = new System.Windows.Forms.Button();
      this.btnHorseColic = new System.Windows.Forms.Button();
      this.graphInput = new ZedGraph.ZedGraphControl();
      this.dgvTest = new System.Windows.Forms.DataGridView();
      this.btnHorseColicTest = new System.Windows.Forms.Button();
      this.btnHorseColicMultiTest = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgvLearningSource)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
      this.SuspendLayout();
      // 
      // dgvLearningSource
      // 
      this.dgvLearningSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvLearningSource.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvLearningSource.Location = new System.Drawing.Point(3, 54);
      this.dgvLearningSource.Name = "dgvLearningSource";
      this.dgvLearningSource.Size = new System.Drawing.Size(282, 459);
      this.dgvLearningSource.TabIndex = 1;
      // 
      // openFileDialog
      // 
      this.openFileDialog.FileName = "openFileDialog1";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.90366F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.09634F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 499F));
      this.tableLayoutPanel1.Controls.Add(this.dgvTest, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.dgvLearningSource, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.graphInput, 2, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1078, 516);
      this.tableLayoutPanel1.TabIndex = 3;
      // 
      // flowLayoutPanel1
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 3);
      this.flowLayoutPanel1.Controls.Add(this.btnOpen);
      this.flowLayoutPanel1.Controls.Add(this.btnAnalyze);
      this.flowLayoutPanel1.Controls.Add(this.cmdTest);
      this.flowLayoutPanel1.Controls.Add(this.label1);
      this.flowLayoutPanel1.Controls.Add(this.txtX1);
      this.flowLayoutPanel1.Controls.Add(this.label2);
      this.flowLayoutPanel1.Controls.Add(this.txtX2);
      this.flowLayoutPanel1.Controls.Add(this.btnStochastic0);
      this.flowLayoutPanel1.Controls.Add(this.btnStochastic1);
      this.flowLayoutPanel1.Controls.Add(this.btnHorseColic);
      this.flowLayoutPanel1.Controls.Add(this.btnHorseColicTest);
      this.flowLayoutPanel1.Controls.Add(this.btnHorseColicMultiTest);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(1072, 45);
      this.flowLayoutPanel1.TabIndex = 3;
      // 
      // btnOpen
      // 
      this.btnOpen.Location = new System.Drawing.Point(3, 3);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(75, 23);
      this.btnOpen.TabIndex = 0;
      this.btnOpen.Text = "Open";
      this.btnOpen.UseVisualStyleBackColor = true;
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click_1);
      // 
      // btnAnalyze
      // 
      this.btnAnalyze.Location = new System.Drawing.Point(84, 3);
      this.btnAnalyze.Name = "btnAnalyze";
      this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
      this.btnAnalyze.TabIndex = 1;
      this.btnAnalyze.Text = "Analyze";
      this.btnAnalyze.UseVisualStyleBackColor = true;
      this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
      // 
      // cmdTest
      // 
      this.cmdTest.Location = new System.Drawing.Point(165, 3);
      this.cmdTest.Name = "cmdTest";
      this.cmdTest.Size = new System.Drawing.Size(75, 23);
      this.cmdTest.TabIndex = 2;
      this.cmdTest.Text = "Test";
      this.cmdTest.UseVisualStyleBackColor = true;
      this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(246, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(20, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "X1";
      // 
      // txtX1
      // 
      this.txtX1.Location = new System.Drawing.Point(272, 3);
      this.txtX1.Name = "txtX1";
      this.txtX1.Size = new System.Drawing.Size(100, 20);
      this.txtX1.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(378, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(20, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "X2";
      // 
      // txtX2
      // 
      this.txtX2.Location = new System.Drawing.Point(404, 3);
      this.txtX2.Name = "txtX2";
      this.txtX2.Size = new System.Drawing.Size(100, 20);
      this.txtX2.TabIndex = 6;
      // 
      // btnStochastic0
      // 
      this.btnStochastic0.Location = new System.Drawing.Point(510, 3);
      this.btnStochastic0.Name = "btnStochastic0";
      this.btnStochastic0.Size = new System.Drawing.Size(75, 23);
      this.btnStochastic0.TabIndex = 7;
      this.btnStochastic0.Text = "Stochastic0";
      this.btnStochastic0.UseVisualStyleBackColor = true;
      this.btnStochastic0.Click += new System.EventHandler(this.btnStochastic0_Click);
      // 
      // btnStochastic1
      // 
      this.btnStochastic1.Location = new System.Drawing.Point(591, 3);
      this.btnStochastic1.Name = "btnStochastic1";
      this.btnStochastic1.Size = new System.Drawing.Size(75, 23);
      this.btnStochastic1.TabIndex = 8;
      this.btnStochastic1.Text = "Stochastic1";
      this.btnStochastic1.UseVisualStyleBackColor = true;
      this.btnStochastic1.Click += new System.EventHandler(this.btnStochastic1_Click);
      // 
      // btnHorseColic
      // 
      this.btnHorseColic.Location = new System.Drawing.Point(672, 3);
      this.btnHorseColic.Name = "btnHorseColic";
      this.btnHorseColic.Size = new System.Drawing.Size(110, 23);
      this.btnHorseColic.TabIndex = 9;
      this.btnHorseColic.Text = "Horse Colic Open";
      this.btnHorseColic.UseVisualStyleBackColor = true;
      this.btnHorseColic.Click += new System.EventHandler(this.btnHorseColic_Click);
      // 
      // graphInput
      // 
      this.graphInput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.graphInput.Location = new System.Drawing.Point(581, 54);
      this.graphInput.Name = "graphInput";
      this.graphInput.ScrollGrace = 0D;
      this.graphInput.ScrollMaxX = 0D;
      this.graphInput.ScrollMaxY = 0D;
      this.graphInput.ScrollMaxY2 = 0D;
      this.graphInput.ScrollMinX = 0D;
      this.graphInput.ScrollMinY = 0D;
      this.graphInput.ScrollMinY2 = 0D;
      this.graphInput.Size = new System.Drawing.Size(494, 459);
      this.graphInput.TabIndex = 2;
      // 
      // dgvTest
      // 
      this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvTest.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvTest.Location = new System.Drawing.Point(291, 54);
      this.dgvTest.Name = "dgvTest";
      this.dgvTest.Size = new System.Drawing.Size(284, 459);
      this.dgvTest.TabIndex = 4;
      // 
      // btnHorseColicTest
      // 
      this.btnHorseColicTest.Location = new System.Drawing.Point(788, 3);
      this.btnHorseColicTest.Name = "btnHorseColicTest";
      this.btnHorseColicTest.Size = new System.Drawing.Size(94, 23);
      this.btnHorseColicTest.TabIndex = 10;
      this.btnHorseColicTest.Text = "Horse Colic Test";
      this.btnHorseColicTest.UseVisualStyleBackColor = true;
      this.btnHorseColicTest.Click += new System.EventHandler(this.btnHorseColicTest_Click);
      // 
      // btnHorseColicMultiTest
      // 
      this.btnHorseColicMultiTest.Location = new System.Drawing.Point(888, 3);
      this.btnHorseColicMultiTest.Name = "btnHorseColicMultiTest";
      this.btnHorseColicMultiTest.Size = new System.Drawing.Size(125, 23);
      this.btnHorseColicMultiTest.TabIndex = 11;
      this.btnHorseColicMultiTest.Text = "Horse Colic Multi Test";
      this.btnHorseColicMultiTest.UseVisualStyleBackColor = true;
      this.btnHorseColicMultiTest.Click += new System.EventHandler(this.btnHorseColicMultiTest_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1078, 516);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.dgvLearningSource)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dgvLearningSource;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.Button btnAnalyze;
    private System.Windows.Forms.Button cmdTest;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtX1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtX2;
    private System.Windows.Forms.Button btnStochastic0;
    private System.Windows.Forms.Button btnStochastic1;
    private System.Windows.Forms.Button btnHorseColic;
    private ZedGraph.ZedGraphControl graphInput;
    private System.Windows.Forms.DataGridView dgvTest;
    private System.Windows.Forms.Button btnHorseColicTest;
    private System.Windows.Forms.Button btnHorseColicMultiTest;
  }
}

