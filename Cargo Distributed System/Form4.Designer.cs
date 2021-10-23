
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
            this.DeliveryAddressScreenForm = new GMap.NET.WindowsForms.GMapControl();
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
            // DeliveryAddressScreenForm
            // 
            this.DeliveryAddressScreenForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeliveryAddressScreenForm.Bearing = 0F;
            this.DeliveryAddressScreenForm.CanDragMap = true;
            this.DeliveryAddressScreenForm.EmptyTileColor = System.Drawing.Color.Navy;
            this.DeliveryAddressScreenForm.GrayScaleMode = false;
            this.DeliveryAddressScreenForm.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.DeliveryAddressScreenForm.LevelsKeepInMemory = 5;
            this.DeliveryAddressScreenForm.Location = new System.Drawing.Point(0, 0);
            this.DeliveryAddressScreenForm.MarkersEnabled = true;
            this.DeliveryAddressScreenForm.MaxZoom = 2;
            this.DeliveryAddressScreenForm.MinZoom = 2;
            this.DeliveryAddressScreenForm.MouseWheelZoomEnabled = true;
            this.DeliveryAddressScreenForm.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.DeliveryAddressScreenForm.Name = "DeliveryAddressScreenForm";
            this.DeliveryAddressScreenForm.NegativeMode = false;
            this.DeliveryAddressScreenForm.PolygonsEnabled = true;
            this.DeliveryAddressScreenForm.RetryLoadTile = 0;
            this.DeliveryAddressScreenForm.RoutesEnabled = true;
            this.DeliveryAddressScreenForm.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.DeliveryAddressScreenForm.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.DeliveryAddressScreenForm.ShowTileGridLines = false;
            this.DeliveryAddressScreenForm.Size = new System.Drawing.Size(503, 536);
            this.DeliveryAddressScreenForm.TabIndex = 2;
            this.DeliveryAddressScreenForm.Zoom = 0D;
            this.DeliveryAddressScreenForm.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // DeliveryAdressScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(802, 536);
            this.Controls.Add(this.DeliveryAddressScreenForm);
            this.Controls.Add(this.splitter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeliveryAdressScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Address Screen";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private GMap.NET.WindowsForms.GMapControl DeliveryAddressScreenForm;
    }
}