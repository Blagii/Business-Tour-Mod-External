namespace BusinessTourMod
{
    partial class BusinessTourMod
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusinessTourMod));
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.MoneyAdd = new System.Windows.Forms.Button();
            this.MoneyTrackBar = new System.Windows.Forms.TrackBar();
            this.PlayersListBox = new System.Windows.Forms.ListBox();
            this.MoneyRemove = new System.Windows.Forms.Button();
            this.MoneyAmount = new System.Windows.Forms.NumericUpDown();
            this.AboutButton = new System.Windows.Forms.Button();
            this.UpdateAddress = new System.ComponentModel.BackgroundWorker();
            this.FreePair = new System.Windows.Forms.CheckBox();
            this.FreeDouble = new System.Windows.Forms.CheckBox();
            this.FreeCard = new System.Windows.Forms.CheckBox();
            this.FreeReroll = new System.Windows.Forms.CheckBox();
            this.CheckDebugger = new System.ComponentModel.BackgroundWorker();
            this.UpdateValues = new System.ComponentModel.BackgroundWorker();
            this.NotFirstTurn = new System.Windows.Forms.Button();
            this.InfiniteJail = new System.Windows.Forms.Button();
            this.UpdateColor = new System.ComponentModel.BackgroundWorker();
            this.NeverJail = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(13, 5);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(217, 20);
            this.txtStatus.TabIndex = 7;
            this.txtStatus.Text = "Mod status...";
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MoneyAdd
            // 
            this.MoneyAdd.Location = new System.Drawing.Point(127, 162);
            this.MoneyAdd.Name = "MoneyAdd";
            this.MoneyAdd.Size = new System.Drawing.Size(102, 23);
            this.MoneyAdd.TabIndex = 0;
            this.MoneyAdd.Text = "Add Money";
            this.MoneyAdd.UseVisualStyleBackColor = true;
            this.MoneyAdd.Click += new System.EventHandler(this.MoneyAdd_Click);
            // 
            // MoneyTrackBar
            // 
            this.MoneyTrackBar.Location = new System.Drawing.Point(12, 93);
            this.MoneyTrackBar.Minimum = 1;
            this.MoneyTrackBar.Name = "MoneyTrackBar";
            this.MoneyTrackBar.Size = new System.Drawing.Size(217, 45);
            this.MoneyTrackBar.TabIndex = 1;
            this.MoneyTrackBar.Value = 1;
            this.MoneyTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // PlayersListBox
            // 
            this.PlayersListBox.FormattingEnabled = true;
            this.PlayersListBox.Location = new System.Drawing.Point(14, 31);
            this.PlayersListBox.Name = "PlayersListBox";
            this.PlayersListBox.Size = new System.Drawing.Size(216, 56);
            this.PlayersListBox.TabIndex = 2;
            // 
            // MoneyRemove
            // 
            this.MoneyRemove.Location = new System.Drawing.Point(127, 188);
            this.MoneyRemove.Name = "MoneyRemove";
            this.MoneyRemove.Size = new System.Drawing.Size(102, 23);
            this.MoneyRemove.TabIndex = 3;
            this.MoneyRemove.Text = "Remove Money";
            this.MoneyRemove.UseVisualStyleBackColor = true;
            this.MoneyRemove.Click += new System.EventHandler(this.MoneyRemove_Click);
            // 
            // MoneyAmount
            // 
            this.MoneyAmount.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MoneyAmount.Location = new System.Drawing.Point(14, 162);
            this.MoneyAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.MoneyAmount.Name = "MoneyAmount";
            this.MoneyAmount.Size = new System.Drawing.Size(107, 20);
            this.MoneyAmount.TabIndex = 4;
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(14, 188);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(107, 23);
            this.AboutButton.TabIndex = 5;
            this.AboutButton.Text = "About ";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // UpdateAddress
            // 
            this.UpdateAddress.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateAddress_DoWork);
            // 
            // FreePair
            // 
            this.FreePair.AutoSize = true;
            this.FreePair.Location = new System.Drawing.Point(248, 13);
            this.FreePair.Name = "FreePair";
            this.FreePair.Size = new System.Drawing.Size(131, 17);
            this.FreePair.TabIndex = 8;
            this.FreePair.Text = "Free Pair/Even Bonus";
            this.FreePair.UseVisualStyleBackColor = true;
            // 
            // FreeDouble
            // 
            this.FreeDouble.AutoSize = true;
            this.FreeDouble.Location = new System.Drawing.Point(248, 36);
            this.FreeDouble.Name = "FreeDouble";
            this.FreeDouble.Size = new System.Drawing.Size(117, 17);
            this.FreeDouble.TabIndex = 9;
            this.FreeDouble.Text = "Free Double Bonus";
            this.FreeDouble.UseVisualStyleBackColor = true;
            // 
            // FreeCard
            // 
            this.FreeCard.AutoSize = true;
            this.FreeCard.Location = new System.Drawing.Point(248, 59);
            this.FreeCard.Name = "FreeCard";
            this.FreeCard.Size = new System.Drawing.Size(105, 17);
            this.FreeCard.TabIndex = 10;
            this.FreeCard.Text = "Free Card Bonus";
            this.FreeCard.UseVisualStyleBackColor = true;
            // 
            // FreeReroll
            // 
            this.FreeReroll.AutoSize = true;
            this.FreeReroll.Location = new System.Drawing.Point(248, 82);
            this.FreeReroll.Name = "FreeReroll";
            this.FreeReroll.Size = new System.Drawing.Size(110, 17);
            this.FreeReroll.TabIndex = 11;
            this.FreeReroll.Text = "Free Reroll Bonus";
            this.FreeReroll.UseVisualStyleBackColor = true;
            // 
            // CheckDebugger
            // 
#if !CLEAN_BUILD
            this.CheckDebugger.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CheckDebugger_DoWork);
#endif
            // 
            // UpdateValues
            // 
            this.UpdateValues.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateValues_DoWork);
            // 
            // NotFirstTurn
            // 
            this.NotFirstTurn.Location = new System.Drawing.Point(248, 115);
            this.NotFirstTurn.Name = "NotFirstTurn";
            this.NotFirstTurn.Size = new System.Drawing.Size(152, 23);
            this.NotFirstTurn.TabIndex = 12;
            this.NotFirstTurn.Text = "Building Level 3 Houses";
            this.NotFirstTurn.UseVisualStyleBackColor = true;
            this.NotFirstTurn.Click += new System.EventHandler(this.NotFirstTurn_Click);
            // 
            // InfiniteJail
            // 
            this.InfiniteJail.Location = new System.Drawing.Point(248, 145);
            this.InfiniteJail.Name = "InfiniteJail";
            this.InfiniteJail.Size = new System.Drawing.Size(152, 23);
            this.InfiniteJail.TabIndex = 13;
            this.InfiniteJail.Text = "Infinite Jail Selected Player";
            this.InfiniteJail.UseVisualStyleBackColor = true;
            this.InfiniteJail.Click += new System.EventHandler(this.InfiniteJail_Click);
            // 
            // UpdateColor
            // 
            this.UpdateColor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateColor_DoWork);
            // 
            // NeverJail
            // 
            this.NeverJail.AutoSize = true;
            this.NeverJail.Location = new System.Drawing.Point(248, 188);
            this.NeverJail.Name = "NeverJail";
            this.NeverJail.Size = new System.Drawing.Size(58, 17);
            this.NeverJail.TabIndex = 14;
            this.NeverJail.Text = "No Jail";
            this.NeverJail.UseVisualStyleBackColor = true;
            // 
            // BusinessTourMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 223);
            this.Controls.Add(this.NeverJail);
            this.Controls.Add(this.InfiniteJail);
            this.Controls.Add(this.NotFirstTurn);
            this.Controls.Add(this.FreeReroll);
            this.Controls.Add(this.FreeCard);
            this.Controls.Add(this.FreeDouble);
            this.Controls.Add(this.FreePair);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.MoneyAmount);
            this.Controls.Add(this.MoneyRemove);
            this.Controls.Add(this.PlayersListBox);
            this.Controls.Add(this.MoneyTrackBar);
            this.Controls.Add(this.MoneyAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BusinessTourMod";
            this.Text = "Business Tour Mod";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MoneyTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoneyAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Button MoneyAdd;
        private System.Windows.Forms.TrackBar MoneyTrackBar;
        private System.Windows.Forms.ListBox PlayersListBox;
        private System.Windows.Forms.Button MoneyRemove;
        private System.Windows.Forms.NumericUpDown MoneyAmount;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.TextBox txtStatus;
        private System.ComponentModel.BackgroundWorker UpdateAddress;
        private System.Windows.Forms.CheckBox FreePair;
        private System.Windows.Forms.CheckBox FreeDouble;
        private System.Windows.Forms.CheckBox FreeCard;
        private System.Windows.Forms.CheckBox FreeReroll;
        private System.ComponentModel.BackgroundWorker CheckDebugger;
        private System.ComponentModel.BackgroundWorker UpdateValues;
        private System.Windows.Forms.Button NotFirstTurn;
        private System.Windows.Forms.Button InfiniteJail;
        private System.ComponentModel.BackgroundWorker UpdateColor;
        private System.Windows.Forms.CheckBox NeverJail;
    }
}

