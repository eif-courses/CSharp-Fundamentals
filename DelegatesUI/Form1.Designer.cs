namespace DelegatesUI
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.messageBoxButton = new System.Windows.Forms.Button();
      this.subtotal = new System.Windows.Forms.TextBox();
      this.textBox2Total = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.FillerButtonTextBox = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // messageBoxButton
      // 
      this.messageBoxButton.Location = new System.Drawing.Point(86, 206);
      this.messageBoxButton.Name = "messageBoxButton";
      this.messageBoxButton.Size = new System.Drawing.Size(166, 62);
      this.messageBoxButton.TabIndex = 0;
      this.messageBoxButton.Text = "MessageBox";
      this.messageBoxButton.UseVisualStyleBackColor = true;
      this.messageBoxButton.Click += new System.EventHandler(this.MessageBox_Click);
      // 
      // subtotal
      // 
      this.subtotal.Location = new System.Drawing.Point(86, 116);
      this.subtotal.Name = "subtotal";
      this.subtotal.Size = new System.Drawing.Size(166, 23);
      this.subtotal.TabIndex = 1;
      // 
      // textBox2Total
      // 
      this.textBox2Total.Location = new System.Drawing.Point(86, 159);
      this.textBox2Total.Name = "textBox2Total";
      this.textBox2Total.Size = new System.Drawing.Size(166, 23);
      this.textBox2Total.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(86, 98);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(51, 15);
      this.label1.TabIndex = 4;
      this.label1.Text = "Subtotal";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(86, 142);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(32, 15);
      this.label2.TabIndex = 5;
      this.label2.Text = "Total";
      // 
      // FillerButtonTextBox
      // 
      this.FillerButtonTextBox.Location = new System.Drawing.Point(86, 309);
      this.FillerButtonTextBox.Name = "FillerButtonTextBox";
      this.FillerButtonTextBox.Size = new System.Drawing.Size(166, 62);
      this.FillerButtonTextBox.TabIndex = 6;
      this.FillerButtonTextBox.Text = "TextBox";
      this.FillerButtonTextBox.UseVisualStyleBackColor = true;
      this.FillerButtonTextBox.Click += new System.EventHandler(this.FillerButtonTextBox_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.FillerButtonTextBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox2Total);
      this.Controls.Add(this.subtotal);
      this.Controls.Add(this.messageBoxButton);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Button messageBoxButton;
    private TextBox subtotal;
    private TextBox textBox2Total;
    private Button texbox1Text;
    private Label label1;
    private Label label2;
    private Button FillerButtonTextBox;
  }
}