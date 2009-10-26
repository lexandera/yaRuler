
using System;
using System.Windows.Forms;
using System.Drawing;

namespace RulerProject 
{
    class Ruler : System.Windows.Forms.Form
    {
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuShow;
		private System.Windows.Forms.MenuItem layout_h;
		private System.Windows.Forms.PictureBox closeBtn;
		private System.Windows.Forms.MenuItem opacity_60;
		private System.Windows.Forms.MenuItem opacity_100;
		private System.Windows.Forms.ImageList resizeImagesVertical;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.ImageList resizeImages;
		private System.Windows.Forms.MenuItem menuHide;
		private System.Windows.Forms.MenuItem opacity_20;
		private System.Windows.Forms.MenuItem display_label;
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.ContextMenu iconMenu;
		private System.Windows.Forms.PictureBox minimizeBtn;
		private System.Windows.Forms.MenuItem layout_v;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.MenuItem opacity_80;
		private System.Windows.Forms.MenuItem layout_label;
		private System.Windows.Forms.MenuItem display_reset;
		private System.Windows.Forms.MenuItem opacity_40;
		private System.Windows.Forms.MenuItem opacity_label;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.PictureBox resizeBtn;
		private System.Windows.Forms.MenuItem display_0px;
       
        
        
        private const int INITIAL_RULER_WIDTH = 600;
        private const int MIN_RULER_WIDTH = 150;
        
        private bool dragging;
        private bool resizing;
        private int offsetX;
        private int offsetY;
        
        private int maxRulerWidth;
        private int maxRulerHeight;
        private bool isHorizontal = true;
        
        /* number of pixels to subtract from actual dimensions 
         * (for measuring differences) 
         */
        int differencePixels = 0;
        

        
        public Ruler()
        {
            InitializeComponent();
            
            /* turn on double buffering */
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint |
                          ControlStyles.DoubleBuffer, true);
        }
    
        
        // THIS METHOD IS MAINTAINED BY THE FORM DESIGNER
        // DO NOT EDIT IT MANUALLY! YOUR CHANGES ARE LIKELY TO BE LOST
        void InitializeComponent() {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ruler));
        	this.display_0px = new System.Windows.Forms.MenuItem();
        	this.resizeBtn = new System.Windows.Forms.PictureBox();
        	this.imageList = new System.Windows.Forms.ImageList(this.components);
        	this.opacity_label = new System.Windows.Forms.MenuItem();
        	this.opacity_40 = new System.Windows.Forms.MenuItem();
        	this.display_reset = new System.Windows.Forms.MenuItem();
        	this.layout_label = new System.Windows.Forms.MenuItem();
        	this.opacity_80 = new System.Windows.Forms.MenuItem();
        	this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
        	this.iconMenu = new System.Windows.Forms.ContextMenu();
        	this.menuShow = new System.Windows.Forms.MenuItem();
        	this.menuHide = new System.Windows.Forms.MenuItem();
        	this.menuExit = new System.Windows.Forms.MenuItem();
        	this.layout_v = new System.Windows.Forms.MenuItem();
        	this.minimizeBtn = new System.Windows.Forms.PictureBox();
        	this.contextMenu = new System.Windows.Forms.ContextMenu();
        	this.layout_h = new System.Windows.Forms.MenuItem();
        	this.display_label = new System.Windows.Forms.MenuItem();
        	this.opacity_100 = new System.Windows.Forms.MenuItem();
        	this.opacity_60 = new System.Windows.Forms.MenuItem();
        	this.opacity_20 = new System.Windows.Forms.MenuItem();
        	this.resizeImages = new System.Windows.Forms.ImageList(this.components);
        	this.resizeImagesVertical = new System.Windows.Forms.ImageList(this.components);
        	this.closeBtn = new System.Windows.Forms.PictureBox();
        	((System.ComponentModel.ISupportInitialize)(this.resizeBtn)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// display_0px
        	// 
        	this.display_0px.Index = 5;
        	this.display_0px.Text = "    Set to 0px";
        	this.display_0px.Click += new System.EventHandler(this.MenuDisplayClick);
        	// 
        	// resizeBtn
        	// 
        	this.resizeBtn.Cursor = System.Windows.Forms.Cursors.SizeWE;
        	this.resizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("resizeBtn.Image")));
        	this.resizeBtn.Location = new System.Drawing.Point(56, 56);
        	this.resizeBtn.Name = "resizeBtn";
        	this.resizeBtn.Size = new System.Drawing.Size(24, 11);
        	this.resizeBtn.TabIndex = 3;
        	this.resizeBtn.TabStop = false;
        	this.resizeBtn.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
        	this.resizeBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResizeBtnMouseMove);
        	this.resizeBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizeBtnMouseDown);
        	this.resizeBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizeBtnMouseUp);
        	this.resizeBtn.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
        	// 
        	// imageList
        	// 
        	this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
        	this.imageList.TransparentColor = System.Drawing.Color.Transparent;
        	this.imageList.Images.SetKeyName(0, "close.bmp");
        	this.imageList.Images.SetKeyName(1, "close_over.bmp");
        	this.imageList.Images.SetKeyName(2, "minimize.bmp");
        	this.imageList.Images.SetKeyName(3, "minimize_over.bmp");
        	// 
        	// opacity_label
        	// 
        	this.opacity_label.Enabled = false;
        	this.opacity_label.Index = 6;
        	this.opacity_label.Text = "Opacity";
        	// 
        	// opacity_40
        	// 
        	this.opacity_40.Index = 10;
        	this.opacity_40.RadioCheck = true;
        	this.opacity_40.Text = "    40%";
        	this.opacity_40.Click += new System.EventHandler(this.MenuOpacityClick);
        	// 
        	// display_reset
        	// 
        	this.display_reset.Index = 4;
        	this.display_reset.Text = "    Reset";
        	this.display_reset.Click += new System.EventHandler(this.MenuDisplayClick);
        	// 
        	// layout_label
        	// 
        	this.layout_label.Enabled = false;
        	this.layout_label.Index = 0;
        	this.layout_label.Text = "Layout";
        	// 
        	// opacity_80
        	// 
        	this.opacity_80.Index = 8;
        	this.opacity_80.RadioCheck = true;
        	this.opacity_80.Text = "    80%";
        	this.opacity_80.Click += new System.EventHandler(this.MenuOpacityClick);
        	// 
        	// notifyIcon
        	// 
        	this.notifyIcon.ContextMenu = this.iconMenu;
        	this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
        	this.notifyIcon.Text = "yaRuler";
        	this.notifyIcon.Visible = true;
        	this.notifyIcon.Click += new System.EventHandler(this.NotifyIconClick);
        	// 
        	// iconMenu
        	// 
        	this.iconMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
        	        	        	this.menuShow,
        	        	        	this.menuHide,
        	        	        	this.menuExit});
        	// 
        	// menuShow
        	// 
        	this.menuShow.Index = 0;
        	this.menuShow.Text = "Show";
        	this.menuShow.Click += new System.EventHandler(this.ShowHideExitClick);
        	// 
        	// menuHide
        	// 
        	this.menuHide.Index = 1;
        	this.menuHide.Text = "Hide";
        	this.menuHide.Click += new System.EventHandler(this.ShowHideExitClick);
        	// 
        	// menuExit
        	// 
        	this.menuExit.Index = 2;
        	this.menuExit.Text = "Exit";
        	this.menuExit.Click += new System.EventHandler(this.ShowHideExitClick);
        	// 
        	// layout_v
        	// 
        	this.layout_v.Index = 2;
        	this.layout_v.RadioCheck = true;
        	this.layout_v.Text = "    Vertical";
        	this.layout_v.Click += new System.EventHandler(this.MenuLayoutClick);
        	// 
        	// minimizeBtn
        	// 
        	this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
        	this.minimizeBtn.Location = new System.Drawing.Point(88, 56);
        	this.minimizeBtn.Name = "minimizeBtn";
        	this.minimizeBtn.Size = new System.Drawing.Size(12, 11);
        	this.minimizeBtn.TabIndex = 2;
        	this.minimizeBtn.TabStop = false;
        	this.minimizeBtn.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
        	this.minimizeBtn.Click += new System.EventHandler(this.ShowHideExitClick);
        	this.minimizeBtn.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
        	// 
        	// contextMenu
        	// 
        	this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
        	        	        	this.layout_label,
        	        	        	this.layout_h,
        	        	        	this.layout_v,
        	        	        	this.display_label,
        	        	        	this.display_reset,
        	        	        	this.display_0px,
        	        	        	this.opacity_label,
        	        	        	this.opacity_100,
        	        	        	this.opacity_80,
        	        	        	this.opacity_60,
        	        	        	this.opacity_40,
        	        	        	this.opacity_20});
        	// 
        	// layout_h
        	// 
        	this.layout_h.Checked = true;
        	this.layout_h.Index = 1;
        	this.layout_h.RadioCheck = true;
        	this.layout_h.Text = "    Horizontal";
        	this.layout_h.Click += new System.EventHandler(this.MenuLayoutClick);
        	// 
        	// display_label
        	// 
        	this.display_label.Enabled = false;
        	this.display_label.Index = 3;
        	this.display_label.Text = "Display";
        	// 
        	// opacity_100
        	// 
        	this.opacity_100.Checked = true;
        	this.opacity_100.Index = 7;
        	this.opacity_100.RadioCheck = true;
        	this.opacity_100.Text = "    100%";
        	this.opacity_100.Click += new System.EventHandler(this.MenuOpacityClick);
        	// 
        	// opacity_60
        	// 
        	this.opacity_60.Index = 9;
        	this.opacity_60.RadioCheck = true;
        	this.opacity_60.Text = "    60%";
        	this.opacity_60.Click += new System.EventHandler(this.MenuOpacityClick);
        	// 
        	// opacity_20
        	// 
        	this.opacity_20.Index = 11;
        	this.opacity_20.RadioCheck = true;
        	this.opacity_20.Text = "    20%";
        	this.opacity_20.Click += new System.EventHandler(this.MenuOpacityClick);
        	// 
        	// resizeImages
        	// 
        	this.resizeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("resizeImages.ImageStream")));
        	this.resizeImages.TransparentColor = System.Drawing.Color.Transparent;
        	this.resizeImages.Images.SetKeyName(0, "arrows.bmp");
        	this.resizeImages.Images.SetKeyName(1, "arrows_over.bmp");
        	// 
        	// resizeImagesVertical
        	// 
        	this.resizeImagesVertical.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("resizeImagesVertical.ImageStream")));
        	this.resizeImagesVertical.TransparentColor = System.Drawing.Color.Transparent;
        	this.resizeImagesVertical.Images.SetKeyName(0, "arrows_vertical.bmp");
        	this.resizeImagesVertical.Images.SetKeyName(1, "arrows_over_vertical.bmp");
        	// 
        	// closeBtn
        	// 
        	this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
        	this.closeBtn.Location = new System.Drawing.Point(104, 56);
        	this.closeBtn.Name = "closeBtn";
        	this.closeBtn.Size = new System.Drawing.Size(12, 11);
        	this.closeBtn.TabIndex = 1;
        	this.closeBtn.TabStop = false;
        	this.closeBtn.MouseLeave += new System.EventHandler(this.BtnMouseLeave);
        	this.closeBtn.Click += new System.EventHandler(this.ShowHideExitClick);
        	this.closeBtn.MouseEnter += new System.EventHandler(this.BtnMouseEnter);
        	// 
        	// Ruler
        	// 
        	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        	this.BackColor = System.Drawing.Color.White;
        	this.ClientSize = new System.Drawing.Size(152, 128);
        	this.ContextMenu = this.contextMenu;
        	this.Controls.Add(this.resizeBtn);
        	this.Controls.Add(this.minimizeBtn);
        	this.Controls.Add(this.closeBtn);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "yaRuler";
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "yaRuler";
        	this.TopMost = true;
        	this.Load += new System.EventHandler(this.RulerLoad);
        	this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RulerMouseUp);
        	this.Paint += new System.Windows.Forms.PaintEventHandler(this.RulerPaint);
        	this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RulerMouseDown);
        	this.Closing += new System.ComponentModel.CancelEventHandler(this.RulerClosing);
        	this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RulerMouseMove);
        	((System.ComponentModel.ISupportInitialize)(this.resizeBtn)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
        	this.ResumeLayout(false);
		}
            
        [STAThread]
        public static 
        void Main(string[] args)
        {
            Application.Run(new Ruler());
        }

        
        void BtnMouseEnter(object sender, System.EventArgs e)
        {
        	if (sender == closeBtn) {
            	closeBtn.Image = imageList.Images[1];
        	}
        	else if (sender == minimizeBtn) {
        		minimizeBtn.Image = imageList.Images[3];
        	}
        	else if (sender == resizeBtn) {
        		resizeBtn.Image = isHorizontal ? resizeImages.Images[1] : resizeImagesVertical.Images[1];
        	}
        }
        
        void BtnMouseLeave(object sender, System.EventArgs e)
        {
        	if (sender == closeBtn) {
            	closeBtn.Image = imageList.Images[0];
        	}
        	else if (sender == minimizeBtn) {
        		minimizeBtn.Image = imageList.Images[2];
        	}
        	else if (sender == resizeBtn) {
        		resizeBtn.Image = isHorizontal ? resizeImages.Images[0] : resizeImagesVertical.Images[0];
        	}
        }
        
        
        void RulerClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            notifyIcon.Visible = false;
        }
        
        void NotifyIconClick(object sender, System.EventArgs e)
        {
            this.Visible = !this.Visible;
        }
        
        
        void ShowHideExitClick(object sender, System.EventArgs e)
        {
            if (sender == menuShow) {
                this.Visible = true;
            }
            else if (sender == menuHide || sender == minimizeBtn) {
                this.Visible = false;
            }
            else if (sender == menuExit || sender == closeBtn) {
                this.Close();
            }
            
        }
        
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.Visible = false;
                return true;
            }
        
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        
        
        void RulerMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dragging = true;
            offsetX = e.X;
            offsetY = e.Y;
        }
        
        void RulerMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dragging = false;
        }
        
        void RulerMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (dragging) {
                Point pos = new Point();
                
                pos.X = this.Location.X + (e.X - offsetX);
                pos.Y = this.Location.Y + (e.Y - offsetY);
                
                this.Location = pos;
            }
        }


        void ResizeBtnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            resizing = true;
            offsetX = e.X;
            offsetY = e.Y;
        }

        void ResizeBtnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            resizing = false;
        }

        void ResizeBtnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int width = this.Width + (e.X - offsetX);
            int height = this.Height + (e.Y - offsetY);
            
            if (resizing) {
                if (isHorizontal) {
                    if (width < MIN_RULER_WIDTH) { width = MIN_RULER_WIDTH; }
                    if (width > maxRulerWidth) { width = maxRulerWidth; }
                    
                    this.Width = width;
                }
                else {
                    if (height < MIN_RULER_WIDTH) { height = MIN_RULER_WIDTH; }
                    if (height > maxRulerHeight) { height = maxRulerHeight; }
                    
                    this.Height = height;
                }
                PositionControls();
            }
            
        }
        
        
        
        void RulerLoad(object sender, System.EventArgs e)
        {
            /* -------------------------------------------------------------- */
            maxRulerWidth = Screen.PrimaryScreen.WorkingArea.Width;
            maxRulerHeight = Screen.PrimaryScreen.WorkingArea.Height;
            
            this.Width = INITIAL_RULER_WIDTH;
            this.Height = 70;
            
            /* position ruler on screen */
            Point pos = new Point();
            int scrW = Screen.PrimaryScreen.WorkingArea.Width;
            int scrH = Screen.PrimaryScreen.WorkingArea.Height;
            
            pos.X = (scrW - this.Width) / 2;
            pos.Y = (scrH - this.Height) / 2;
            
            this.Location = pos;
            
           
            /* -------------------------------------------------------------- */
            
            PositionControls();
        }
        

        void PositionControls() 
        {
            if (isHorizontal) {
                resizeBtn.Left   = this.Width - 65;
                minimizeBtn.Left = this.Width - 37;
                closeBtn.Left    = this.Width - 21;
                
                resizeBtn.Top   = (this.Height - 11) / 2;
                minimizeBtn.Top = (this.Height - 11) / 2;
                closeBtn.Top    = (this.Height - 11) / 2;
            }
            else {
                resizeBtn.Top   = this.Height - 65;
                minimizeBtn.Top = this.Height - 37;
                closeBtn.Top    = this.Height - 21;
                
                resizeBtn.Left   = (this.Width - 11) / 2;
                minimizeBtn.Left = (this.Width - 11) / 2;
                closeBtn.Left    = (this.Width - 11) / 2;
            }
            
            Refresh();
        }



        void MenuOpacityClick(object sender, System.EventArgs e)
        {
            MenuItem[] items = {
                opacity_100, opacity_80,
                opacity_60, opacity_40, 
                opacity_20
            };
            
            for (int i=0; i<items.Length; i++) {
                MenuItem item = items[i];
                if (item == sender) {
                    item.Checked = true;
                    this.Opacity = (double)(100 - i*20) / 100;
                }
                else {
                    item.Checked = false;
                }
            }
        }
        
        void MenuLayoutClick(object sender, System.EventArgs e)
        {
            int w = this.Width;
            int h = this.Height;
            
            if (sender == layout_h && !isHorizontal) {
                this.Width = h;
                this.Height = w;
                
                isHorizontal = true;
                layout_h.Checked = true;
                layout_v.Checked = false;
                
                this.differencePixels = 0;
            }
            else if (sender == layout_v && isHorizontal) {
                if (w > this.maxRulerHeight) {
                    w = this.maxRulerHeight;
                }
                
                this.Width = h;
                this.Height = w;
                
                isHorizontal = false;
                layout_h.Checked = false;
                layout_v.Checked = true;
                
                this.differencePixels = 0;
            }
            
            PositionControls();
            UpdateResizeBtn();
        }

        
        void UpdateResizeBtn()
        {
            if (isHorizontal) {
                resizeBtn.Width = 24;
                resizeBtn.Height = 11;
                resizeBtn.Cursor = System.Windows.Forms.Cursors.SizeWE;
                resizeBtn.Image = resizeImages.Images[0];
            }
            else {
                resizeBtn.Width = 11;
                resizeBtn.Height = 24;
                resizeBtn.Cursor = System.Windows.Forms.Cursors.SizeNS;
                resizeBtn.Image = resizeImagesVertical.Images[0];
            }
        }
        
        void MenuDisplayClick(object sender, System.EventArgs e)
        {
            if (sender == display_reset) {
                this.differencePixels = 0;
            }
            else if (sender == display_0px) {
                this.differencePixels = isHorizontal ? this.Width : this.Height;
            }
            
            PositionControls();
        }
                
        
        
        void RulerPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Brush white = new SolidBrush(System.Drawing.Color.White);
            Brush red   = new SolidBrush(System.Drawing.Color.Red);
            Brush green = new SolidBrush(System.Drawing.Color.Green);
            Brush blue  = new SolidBrush(System.Drawing.Color.Blue);
            Brush black = new SolidBrush(System.Drawing.Color.Black);
            
            /* I'm too lazy to look up how fonts work... :) */
            Font font = new Label().Font;
            
            /* white bg */
            e.Graphics.FillRectangle(white, 0, 0, Width, Height);
            
            int countLimit = isHorizontal ? Width : Height;
            
            /* --------------------------------------------------------------------------------- */
            /* width labels */
            
            for (int i=1; i<countLimit; i+=100) {
                System.Drawing.SizeF dim = e.Graphics.MeasureString(Convert.ToString(i), font);
                
                if (isHorizontal) {
                    e.Graphics.DrawString(Convert.ToString(i), font, black, i, (Height - dim.Height)/2);
                }
                else {
                    /* calculate the width of string to paint, so we can center it */
                    e.Graphics.DrawString(Convert.ToString(i), font, black, (Width - dim.Width)/2, i);
                }
            }
            
            /* draw current width label */
            if (isHorizontal) {
                string w = Convert.ToString(this.Width - this.differencePixels) + "px";
                System.Drawing.SizeF dim = e.Graphics.MeasureString(w, font);
                e.Graphics.DrawString(w, font, green, 30, (Height - dim.Height)/2);
            }
            else {
                string w = Convert.ToString(this.Height - this.differencePixels) + "px";
                System.Drawing.SizeF dim = e.Graphics.MeasureString(w, font);
                e.Graphics.DrawString(w, font, green, (Width - dim.Width)/2, 25);
            }

            /* --------------------------------------------------------------------------------- */
            /* paint ticks */
            
            Brush brush;
            int length;
            
            for (int i=0; i<countLimit; i+=2) {
                if (i % 100 == 0) {
                    brush = red;
                    length = Height;
                }
                else if (i % 50 == 0) {
                    brush = blue;
                    length = 20;
                }
                else if (i % 10 == 0) {
                    brush = green;
                    length = 10;
                }
                else {
                    brush = black;
                    length = 3;
                }
                
                if (isHorizontal) {
                    e.Graphics.FillRectangle(brush, i,0, 1,length);
                    e.Graphics.FillRectangle(brush, i,Height-length, 1,length);
                }
                else {
                    e.Graphics.FillRectangle(brush, 0,i, length,1);
                    e.Graphics.FillRectangle(brush, Width-length,i, length,1);
                }
            }
            
            /* --------------------------------------------------------------------------------- */

            /* red line at the end */
            if (isHorizontal) {
                e.Graphics.FillRectangle(red, Width-1,0, 1,Height);
            }
            else {
                e.Graphics.FillRectangle(red, 0,Height-1, Width,1);
            }
            
        }
        
    }			
}


