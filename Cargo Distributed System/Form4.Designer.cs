
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Cargo_Distributed_System
{
    partial class DeliveryAdressScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryAdressScreenForm));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.insertAddressButton = new System.Windows.Forms.Button();
            this.AddressInputBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(503, 536);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // gmap
            // 
            this.gmap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemory = 5;
            this.gmap.Location = new System.Drawing.Point(0, 0);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 100;
            this.gmap.MinZoom = 5;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(503, 536);
            this.gmap.TabIndex = 2;
            this.gmap.Zoom = 10D;
            this.gmap.Load += new System.EventHandler(this.GMapControl1_Load);
            this.gmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Gmap_MouseClick);
            // 
            // insertAddressButton
            // 
            this.insertAddressButton.BackColor = System.Drawing.SystemColors.GrayText;
            this.insertAddressButton.Location = new System.Drawing.Point(661, 162);
            this.insertAddressButton.Name = "insertAddressButton";
            this.insertAddressButton.Size = new System.Drawing.Size(129, 23);
            this.insertAddressButton.TabIndex = 3;
            this.insertAddressButton.Text = "Insert Address";
            this.insertAddressButton.UseVisualStyleBackColor = false;
            this.insertAddressButton.Click += new System.EventHandler(this.InsertAddressButton_Click);
            // 
            // AddressInputBox
            // 
            this.AddressInputBox.Location = new System.Drawing.Point(522, 25);
            this.AddressInputBox.Multiline = true;
            this.AddressInputBox.Name = "AddressInputBox";
            this.AddressInputBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.AddressInputBox.Size = new System.Drawing.Size(268, 131);
            this.AddressInputBox.TabIndex = 4;
            this.AddressInputBox.TextChanged += new System.EventHandler(this.AddressInputBox_TextChanged);
            // 
            // addressLabel
            // 
            this.addressLabel.Location = new System.Drawing.Point(519, 9);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(271, 13);
            this.addressLabel.TabIndex = 5;
            this.addressLabel.Text = "Address";
            this.addressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GrayText;
            this.button1.Location = new System.Drawing.Point(522, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Calculate Shorthest Path";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.CalculateShorthestPathButton);
            // 
            // DeliveryAdressScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(802, 536);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.AddressInputBox);
            this.Controls.Add(this.insertAddressButton);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.splitter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeliveryAdressScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Address Screen";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Button insertAddressButton;
        private System.Windows.Forms.TextBox AddressInputBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Button button1;
    }
}