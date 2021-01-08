
namespace OOP_lab5_6
{
   public partial class IGuessForm
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
            this.labelStatistics = new System.Windows.Forms.Label();
            this.labelPrompts = new System.Windows.Forms.Label();
            this.labelResultsAttempt = new System.Windows.Forms.Label();
            this.buttonReply = new System.Windows.Forms.Button();
            this.buttonGetPrompted = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStatistics
            // 
            this.labelStatistics.Location = new System.Drawing.Point(218, 62);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Size = new System.Drawing.Size(444, 78);
            this.labelStatistics.TabIndex = 10;
            this.labelStatistics.Text = "Статистика";
            this.labelStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPrompts
            // 
            this.labelPrompts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelPrompts.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPrompts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPrompts.Location = new System.Drawing.Point(221, 394);
            this.labelPrompts.Name = "labelPrompts";
            this.labelPrompts.Size = new System.Drawing.Size(444, 106);
            this.labelPrompts.TabIndex = 9;
            this.labelPrompts.Text = "Подсказки";
            this.labelPrompts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResultsAttempt
            // 
            this.labelResultsAttempt.Location = new System.Drawing.Point(218, 234);
            this.labelResultsAttempt.Name = "labelResultsAttempt";
            this.labelResultsAttempt.Size = new System.Drawing.Size(447, 78);
            this.labelResultsAttempt.TabIndex = 8;
            this.labelResultsAttempt.Text = "Результаты попытки";
            this.labelResultsAttempt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonReply
            // 
            this.buttonReply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonReply.Location = new System.Drawing.Point(671, 461);
            this.buttonReply.Name = "buttonReply";
            this.buttonReply.Size = new System.Drawing.Size(203, 39);
            this.buttonReply.TabIndex = 7;
            this.buttonReply.Text = "Дать ответ";
            this.buttonReply.UseVisualStyleBackColor = true;
            this.buttonReply.Click += new System.EventHandler(this.buttonReply_Click);
            // 
            // buttonGetPrompted
            // 
            this.buttonGetPrompted.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonGetPrompted.Location = new System.Drawing.Point(12, 461);
            this.buttonGetPrompted.Name = "buttonGetPrompted";
            this.buttonGetPrompted.Size = new System.Drawing.Size(203, 39);
            this.buttonGetPrompted.TabIndex = 6;
            this.buttonGetPrompted.Text = "Получить подсказку";
            this.buttonGetPrompted.UseVisualStyleBackColor = true;
            this.buttonGetPrompted.Click += new System.EventHandler(this.buttonGetPrompted_Click);
            // 
            // IGuessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 509);
            this.Controls.Add(this.labelStatistics);
            this.Controls.Add(this.labelPrompts);
            this.Controls.Add(this.labelResultsAttempt);
            this.Controls.Add(this.buttonReply);
            this.Controls.Add(this.buttonGetPrompted);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "IGuessForm";
            this.Text = "Дать ответ";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label labelStatistics;
        protected System.Windows.Forms.Label labelPrompts;
        protected System.Windows.Forms.Label labelResultsAttempt;
        protected System.Windows.Forms.Button buttonReply;
        protected System.Windows.Forms.Button buttonGetPrompted;
    }
}