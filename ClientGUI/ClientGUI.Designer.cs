namespace ClientGUI
{
    partial class ClientGUI
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
            this.player_name_label = new System.Windows.Forms.Label();
            this.server_label = new System.Windows.Forms.Label();
            this.player_name_box = new System.Windows.Forms.TextBox();
            this.server_box = new System.Windows.Forms.TextBox();
            this.error_label = new System.Windows.Forms.Label();
            this.fps_label = new System.Windows.Forms.Label();
            this.players_label = new System.Windows.Forms.Label();
            this.mass_label = new System.Windows.Forms.Label();
            this.fps_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player_name_label
            // 
            this.player_name_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player_name_label.AutoSize = true;
            this.player_name_label.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.player_name_label.Location = new System.Drawing.Point(388, 303);
            this.player_name_label.Name = "player_name_label";
            this.player_name_label.Size = new System.Drawing.Size(131, 25);
            this.player_name_label.TabIndex = 0;
            this.player_name_label.Text = "Player Name";
            // 
            // server_label
            // 
            this.server_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.server_label.AutoSize = true;
            this.server_label.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.server_label.Location = new System.Drawing.Point(398, 401);
            this.server_label.Name = "server_label";
            this.server_label.Size = new System.Drawing.Size(72, 25);
            this.server_label.TabIndex = 0;
            this.server_label.Text = "Server";
            // 
            // player_name_box
            // 
            this.player_name_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player_name_box.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.player_name_box.Location = new System.Drawing.Point(723, 307);
            this.player_name_box.Name = "player_name_box";
            this.player_name_box.Size = new System.Drawing.Size(400, 27);
            this.player_name_box.TabIndex = 1;
            this.player_name_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.player_name_box_KeyDown);
            // 
            // server_box
            // 
            this.server_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.server_box.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.server_box.Location = new System.Drawing.Point(723, 406);
            this.server_box.Name = "server_box";
            this.server_box.Size = new System.Drawing.Size(400, 27);
            this.server_box.TabIndex = 1;
            this.server_box.Text = "localhost";
            // 
            // error_label
            // 
            this.error_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.error_label.AutoSize = true;
            this.error_label.BackColor = System.Drawing.Color.IndianRed;
            this.error_label.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.error_label.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.error_label.Location = new System.Drawing.Point(22, 816);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(67, 25);
            this.error_label.TabIndex = 0;
            this.error_label.Text = "Errors";
            // 
            // fps_label
            // 
            this.fps_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fps_label.AutoSize = true;
            this.fps_label.Font = new System.Drawing.Font("Segoe UI Black", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fps_label.Location = new System.Drawing.Point(1131, 12);
            this.fps_label.Name = "fps_label";
            this.fps_label.Size = new System.Drawing.Size(34, 19);
            this.fps_label.TabIndex = 0;
            this.fps_label.Text = "FPS";
            // 
            // players_label
            // 
            this.players_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.players_label.AutoSize = true;
            this.players_label.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.players_label.Location = new System.Drawing.Point(1075, 49);
            this.players_label.Name = "players_label";
            this.players_label.Size = new System.Drawing.Size(59, 19);
            this.players_label.TabIndex = 0;
            this.players_label.Text = "Players";
            // 
            // mass_label
            // 
            this.mass_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mass_label.AutoSize = true;
            this.mass_label.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mass_label.Location = new System.Drawing.Point(1108, 97);
            this.mass_label.Name = "mass_label";
            this.mass_label.Size = new System.Drawing.Size(45, 19);
            this.mass_label.TabIndex = 0;
            this.mass_label.Text = "Mass";
            // 
            // fps_txt
            // 
            this.fps_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fps_txt.AutoSize = true;
            this.fps_txt.Font = new System.Drawing.Font("Segoe UI Black", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fps_txt.Location = new System.Drawing.Point(1213, 12);
            this.fps_txt.Name = "fps_txt";
            this.fps_txt.Size = new System.Drawing.Size(17, 19);
            this.fps_txt.TabIndex = 0;
            this.fps_txt.Text = "0";
            // 
            // ClientGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1374, 910);
            this.Controls.Add(this.server_box);
            this.Controls.Add(this.player_name_box);
            this.Controls.Add(this.server_label);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.mass_label);
            this.Controls.Add(this.players_label);
            this.Controls.Add(this.fps_txt);
            this.Controls.Add(this.fps_label);
            this.Controls.Add(this.player_name_label);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "ClientGUI";
            this.Tag = "";
            this.Text = "Agario Client - CS3500";
            this.MouseHover += new System.EventHandler(this.ClientGUI_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ClientGUI_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label player_name_label;
        private Label server_label;
        private TextBox player_name_box;
        private TextBox server_box;
        private Label error_label;
        private Label fps_label;
        private Label players_label;
        private Label mass_label;
        private Label fps;
        private Label fps_txt;
    }
}