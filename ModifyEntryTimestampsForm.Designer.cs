namespace KeePassTimestampChanger
{
	partial class ModifyEntryTimestampsForm
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
			this.createdDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.lastModifiedDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.lastAccessedDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.bannerImage = new System.Windows.Forms.PictureBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.createdCheckBox = new System.Windows.Forms.CheckBox();
			this.lastModifiedCheckBox = new System.Windows.Forms.CheckBox();
			this.lastAccessedCheckBox = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.bannerImage)).BeginInit();
			this.SuspendLayout();
			// 
			// createdDateTimePicker
			// 
			this.createdDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.createdDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.createdDateTimePicker.Location = new System.Drawing.Point(124, 66);
			this.createdDateTimePicker.Name = "createdDateTimePicker";
			this.createdDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.createdDateTimePicker.TabIndex = 0;
			// 
			// lastModifiedDateTimePicker
			// 
			this.lastModifiedDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lastModifiedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.lastModifiedDateTimePicker.Location = new System.Drawing.Point(124, 92);
			this.lastModifiedDateTimePicker.Name = "lastModifiedDateTimePicker";
			this.lastModifiedDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.lastModifiedDateTimePicker.TabIndex = 2;
			// 
			// lastAccessedDateTimePicker
			// 
			this.lastAccessedDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lastAccessedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.lastAccessedDateTimePicker.Location = new System.Drawing.Point(124, 118);
			this.lastAccessedDateTimePicker.Name = "lastAccessedDateTimePicker";
			this.lastAccessedDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.lastAccessedDateTimePicker.TabIndex = 4;
			// 
			// bannerImage
			// 
			this.bannerImage.Dock = System.Windows.Forms.DockStyle.Top;
			this.bannerImage.Location = new System.Drawing.Point(0, 0);
			this.bannerImage.Name = "bannerImage";
			this.bannerImage.Size = new System.Drawing.Size(336, 60);
			this.bannerImage.TabIndex = 17;
			this.bannerImage.TabStop = false;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(244, 144);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(80, 23);
			this.cancelButton.TabIndex = 19;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(158, 144);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(80, 23);
			this.okButton.TabIndex = 18;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// createdCheckBox
			// 
			this.createdCheckBox.AutoSize = true;
			this.createdCheckBox.Location = new System.Drawing.Point(11, 69);
			this.createdCheckBox.Name = "createdCheckBox";
			this.createdCheckBox.Size = new System.Drawing.Size(66, 17);
			this.createdCheckBox.TabIndex = 20;
			this.createdCheckBox.Text = "Created:";
			this.createdCheckBox.UseVisualStyleBackColor = true;
			// 
			// lastModifiedCheckBox
			// 
			this.lastModifiedCheckBox.AutoSize = true;
			this.lastModifiedCheckBox.Location = new System.Drawing.Point(11, 95);
			this.lastModifiedCheckBox.Name = "lastModifiedCheckBox";
			this.lastModifiedCheckBox.Size = new System.Drawing.Size(92, 17);
			this.lastModifiedCheckBox.TabIndex = 21;
			this.lastModifiedCheckBox.Text = "Last Modified:";
			this.lastModifiedCheckBox.UseVisualStyleBackColor = true;
			// 
			// lastAccessedCheckBox
			// 
			this.lastAccessedCheckBox.AutoSize = true;
			this.lastAccessedCheckBox.Location = new System.Drawing.Point(11, 121);
			this.lastAccessedCheckBox.Name = "lastAccessedCheckBox";
			this.lastAccessedCheckBox.Size = new System.Drawing.Size(99, 17);
			this.lastAccessedCheckBox.TabIndex = 22;
			this.lastAccessedCheckBox.Text = "Last Accessed:";
			this.lastAccessedCheckBox.UseVisualStyleBackColor = true;
			// 
			// ModifyEntryTimestampsForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(336, 178);
			this.Controls.Add(this.lastAccessedCheckBox);
			this.Controls.Add(this.lastModifiedCheckBox);
			this.Controls.Add(this.createdCheckBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.bannerImage);
			this.Controls.Add(this.lastAccessedDateTimePicker);
			this.Controls.Add(this.lastModifiedDateTimePicker);
			this.Controls.Add(this.createdDateTimePicker);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ModifyEntryTimestampsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Modify Timestamps";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.bannerImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker createdDateTimePicker;
		private System.Windows.Forms.DateTimePicker lastModifiedDateTimePicker;
		private System.Windows.Forms.DateTimePicker lastAccessedDateTimePicker;
		private System.Windows.Forms.PictureBox bannerImage;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.CheckBox createdCheckBox;
		private System.Windows.Forms.CheckBox lastModifiedCheckBox;
		private System.Windows.Forms.CheckBox lastAccessedCheckBox;
	}
}