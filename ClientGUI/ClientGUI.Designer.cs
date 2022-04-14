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
            this.SuspendLayout();
            // 
            // player_name_label
            // 
            this.player_name_label.AutoSize = true;
            this.player_name_label.Enabled = false;
            this.player_name_label.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.player_name_label.Location = new System.Drawing.Point(388, 303);
            this.player_name_label.Name = "player_name_label";
            this.player_name_label.Size = new System.Drawing.Size(253, 50);
            this.player_name_label.TabIndex = 0;
            this.player_name_label.Text = "Player Name";
            this.player_name_label.Visible = false;
            // 
            // server_label
            // 
            this.server_label.AutoSize = true;
            this.server_label.Enabled = false;
            this.server_label.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.server_label.Location = new System.Drawing.Point(398, 401);
            this.server_label.Name = "server_label";
            this.server_label.Size = new System.Drawing.Size(139, 50);
            this.server_label.TabIndex = 0;
            this.server_label.Text = "Server";
            this.server_label.Visible = false;
            // 
            // player_name_box
            // 
            this.player_name_box.Enabled = false;
            this.player_name_box.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.player_name_box.Location = new System.Drawing.Point(723, 307);
            this.player_name_box.Name = "player_name_box";
            this.player_name_box.Size = new System.Drawing.Size(247, 46);
            this.player_name_box.TabIndex = 1;
            this.player_name_box.Visible = false;
            // 
            // server_box
            // 
            this.server_box.Enabled = false;
            this.server_box.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.server_box.Location = new System.Drawing.Point(723, 406);
            this.server_box.Name = "server_box";
            this.server_box.Size = new System.Drawing.Size(255, 46);
            this.server_box.TabIndex = 1;
            this.server_box.Visible = false;
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.BackColor = System.Drawing.Color.IndianRed;
            this.error_label.Enabled = false;
            this.error_label.Font = new System.Drawing.Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.error_label.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.error_label.Location = new System.Drawing.Point(22, 816);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(131, 50);
            this.error_label.TabIndex = 0;
            this.error_label.Text = "Errors";
            this.error_label.Visible = false;
            // 
            // fps_label
            // 
            this.fps_label.AutoSize = true;
            this.fps_label.Enabled = false;
            this.fps_label.Font = new System.Drawing.Font("Segoe UI Black", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fps_label.Location = new System.Drawing.Point(1130, 12);
            this.fps_label.Name = "fps_label";
            this.fps_label.Size = new System.Drawing.Size(65, 37);
            this.fps_label.TabIndex = 0;
            this.fps_label.Text = "FPS";
            this.fps_label.Visible = false;
            // 
            // players_label
            // 
            this.players_label.AutoSize = true;
            this.players_label.Enabled = false;
            this.players_label.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.players_label.Location = new System.Drawing.Point(1074, 49);
            this.players_label.Name = "players_label";
            this.players_label.Size = new System.Drawing.Size(114, 37);
            this.players_label.TabIndex = 0;
            this.players_label.Text = "Players";
            this.players_label.Visible = false;
            // 
            // mass_label
            // 
            this.mass_label.AutoSize = true;
            this.mass_label.Enabled = false;
            this.mass_label.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mass_label.Location = new System.Drawing.Point(1107, 97);
            this.mass_label.Name = "mass_label";
            this.mass_label.Size = new System.Drawing.Size(85, 37);
            this.mass_label.TabIndex = 0;
            this.mass_label.Text = "Mass";
            this.mass_label.Visible = false;
            // 
            // ClientGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1373, 910);
            this.Controls.Add(this.server_box);
            this.Controls.Add(this.player_name_box);
            this.Controls.Add(this.server_label);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.mass_label);
            this.Controls.Add(this.players_label);
            this.Controls.Add(this.fps_label);
            this.Controls.Add(this.player_name_label);
            this.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "ClientGUI";
            this.Tag = "";
            this.Text = "Agario Client - CS3500";
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
    }
}