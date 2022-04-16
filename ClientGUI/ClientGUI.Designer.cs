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
            this.HPS_label = new System.Windows.Forms.Label();
            this.fps_txt = new System.Windows.Forms.Label();
            this.Food_label = new System.Windows.Forms.Label();
            this.Position_label = new System.Windows.Forms.Label();
            this.MouseP_label = new System.Windows.Forms.Label();
            this.Mass_label = new System.Windows.Forms.Label();
            this.HPS_value = new System.Windows.Forms.Label();
            this.Players_value = new System.Windows.Forms.Label();
            this.Food_value = new System.Windows.Forms.Label();
            this.Mass_value = new System.Windows.Forms.Label();
            this.Position_value = new System.Windows.Forms.Label();
            this.MouseP_value = new System.Windows.Forms.Label();
            this.Dead_label = new System.Windows.Forms.Label();
            this.Disconnected_label = new System.Windows.Forms.Label();
            this.Exception_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.server_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.server_box_KeyDown);
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
            this.players_label.Location = new System.Drawing.Point(1122, 93);
            this.players_label.Name = "players_label";
            this.players_label.Size = new System.Drawing.Size(59, 19);
            this.players_label.TabIndex = 0;
            this.players_label.Text = "Players";
            // 
            // HPS_label
            // 
            this.HPS_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HPS_label.AutoSize = true;
            this.HPS_label.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HPS_label.Location = new System.Drawing.Point(1131, 46);
            this.HPS_label.Name = "HPS_label";
            this.HPS_label.Size = new System.Drawing.Size(37, 19);
            this.HPS_label.TabIndex = 0;
            this.HPS_label.Text = "HPS";
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
            // Food_label
            // 
            this.Food_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Food_label.AutoSize = true;
            this.Food_label.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Food_label.Location = new System.Drawing.Point(1131, 129);
            this.Food_label.Name = "Food_label";
            this.Food_label.Size = new System.Drawing.Size(44, 19);
            this.Food_label.TabIndex = 0;
            this.Food_label.Text = "Food";
            // 
            // Position_label
            // 
            this.Position_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Position_label.AutoSize = true;
            this.Position_label.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Position_label.Location = new System.Drawing.Point(1131, 214);
            this.Position_label.Name = "Position_label";
            this.Position_label.Size = new System.Drawing.Size(66, 19);
            this.Position_label.TabIndex = 0;
            this.Position_label.Text = "Position";
            // 
            // MouseP_label
            // 
            this.MouseP_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MouseP_label.AutoSize = true;
            this.MouseP_label.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MouseP_label.Location = new System.Drawing.Point(1131, 247);
            this.MouseP_label.Name = "MouseP_label";
            this.MouseP_label.Size = new System.Drawing.Size(65, 19);
            this.MouseP_label.TabIndex = 0;
            this.MouseP_label.Text = "MouseP";
            // 
            // Mass_label
            // 
            this.Mass_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Mass_label.AutoSize = true;
            this.Mass_label.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Mass_label.Location = new System.Drawing.Point(1131, 171);
            this.Mass_label.Name = "Mass_label";
            this.Mass_label.Size = new System.Drawing.Size(45, 19);
            this.Mass_label.TabIndex = 0;
            this.Mass_label.Text = "Mass";
            // 
            // HPS_value
            // 
            this.HPS_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HPS_value.AutoSize = true;
            this.HPS_value.Font = new System.Drawing.Font("Segoe UI Black", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HPS_value.Location = new System.Drawing.Point(1213, 46);
            this.HPS_value.Name = "HPS_value";
            this.HPS_value.Size = new System.Drawing.Size(17, 19);
            this.HPS_value.TabIndex = 0;
            this.HPS_value.Text = "0";
            // 
            // Players_value
            // 
            this.Players_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Players_value.AutoSize = true;
            this.Players_value.Font = new System.Drawing.Font("Segoe UI Black", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Players_value.Location = new System.Drawing.Point(1213, 93);
            this.Players_value.Name = "Players_value";
            this.Players_value.Size = new System.Drawing.Size(17, 19);
            this.Players_value.TabIndex = 0;
            this.Players_value.Text = "0";
            // 
            // Food_value
            // 
            this.Food_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Food_value.AutoSize = true;
            this.Food_value.Font = new System.Drawing.Font("Segoe UI Black", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Food_value.Location = new System.Drawing.Point(1213, 129);
            this.Food_value.Name = "Food_value";
            this.Food_value.Size = new System.Drawing.Size(17, 19);
            this.Food_value.TabIndex = 0;
            this.Food_value.Text = "0";
            // 
            // Mass_value
            // 
            this.Mass_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Mass_value.AutoSize = true;
            this.Mass_value.Font = new System.Drawing.Font("Segoe UI Black", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Mass_value.Location = new System.Drawing.Point(1213, 171);
            this.Mass_value.Name = "Mass_value";
            this.Mass_value.Size = new System.Drawing.Size(17, 19);
            this.Mass_value.TabIndex = 0;
            this.Mass_value.Text = "0";
            // 
            // Position_value
            // 
            this.Position_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Position_value.AutoSize = true;
            this.Position_value.Font = new System.Drawing.Font("Segoe UI Black", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Position_value.Location = new System.Drawing.Point(1213, 214);
            this.Position_value.Name = "Position_value";
            this.Position_value.Size = new System.Drawing.Size(17, 19);
            this.Position_value.TabIndex = 0;
            this.Position_value.Text = "0";
            // 
            // MouseP_value
            // 
            this.MouseP_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MouseP_value.AutoSize = true;
            this.MouseP_value.Font = new System.Drawing.Font("Segoe UI Black", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MouseP_value.Location = new System.Drawing.Point(1213, 247);
            this.MouseP_value.Name = "MouseP_value";
            this.MouseP_value.Size = new System.Drawing.Size(17, 19);
            this.MouseP_value.TabIndex = 0;
            this.MouseP_value.Text = "0";
            // 
            // Dead_label
            // 
            this.Dead_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dead_label.AutoSize = true;
            this.Dead_label.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Dead_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Dead_label.Location = new System.Drawing.Point(751, 195);
            this.Dead_label.Name = "Dead_label";
            this.Dead_label.Size = new System.Drawing.Size(110, 25);
            this.Dead_label.TabIndex = 0;
            this.Dead_label.Text = "YOU DIED!";
            // 
            // Disconnected_label
            // 
            this.Disconnected_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Disconnected_label.AutoSize = true;
            this.Disconnected_label.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Disconnected_label.ForeColor = System.Drawing.Color.Blue;
            this.Disconnected_label.Location = new System.Drawing.Point(751, 165);
            this.Disconnected_label.Name = "Disconnected_label";
            this.Disconnected_label.Size = new System.Drawing.Size(159, 25);
            this.Disconnected_label.TabIndex = 0;
            this.Disconnected_label.Text = "DISCONNECTED";
            // 
            // Exception_label
            // 
            this.Exception_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Exception_label.AutoSize = true;
            this.Exception_label.BackColor = System.Drawing.Color.IndianRed;
            this.Exception_label.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Exception_label.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.Exception_label.Location = new System.Drawing.Point(106, 816);
            this.Exception_label.Name = "Exception_label";
            this.Exception_label.Size = new System.Drawing.Size(312, 25);
            this.Exception_label.TabIndex = 0;
            this.Exception_label.Text = "FAILED TO CONNECT TO SERVER";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.IndianRed;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.label2.Location = new System.Drawing.Point(-168, 1097);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "FAILED TO CONNECT TO SERVER";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.IndianRed;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.label4.Location = new System.Drawing.Point(-539, 1503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "FAILED TO CONNECT TO SERVER";
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Exception_label);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.MouseP_label);
            this.Controls.Add(this.Mass_label);
            this.Controls.Add(this.Position_label);
            this.Controls.Add(this.Food_label);
            this.Controls.Add(this.HPS_label);
            this.Controls.Add(this.players_label);
            this.Controls.Add(this.MouseP_value);
            this.Controls.Add(this.Position_value);
            this.Controls.Add(this.Mass_value);
            this.Controls.Add(this.Food_value);
            this.Controls.Add(this.Players_value);
            this.Controls.Add(this.HPS_value);
            this.Controls.Add(this.fps_txt);
            this.Controls.Add(this.fps_label);
            this.Controls.Add(this.Disconnected_label);
            this.Controls.Add(this.Dead_label);
            this.Controls.Add(this.player_name_label);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "ClientGUI";
            this.Tag = "";
            this.Text = "Agario Client - CS3500";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClientGUI_KeyDown);
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
        private Label HPS_label;
        private Label fps;
        private Label fps_txt;
        private Label Food_label;
        private Label Position_label;
        private Label MouseP_label;
        private Label Mass_label;
        private Label HPS_value;
        private Label Players_value;
        private Label Food_value;
        private Label Mass_value;
        private Label Position_value;
        private Label MouseP_value;
        private Label Dead_label;
        private Label Disconnected_label;
        private Label Exception_label;
        private Label label2;
        private Label label4;
    }
}