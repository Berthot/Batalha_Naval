using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naval_batalha
{
    

    public partial class batalhas_navais : Form
    {
        Button[] button_array = new Button[100];
        Button[] enemy_array = new Button[100];

        String[] points = new string[] { "P1H", "P2H", "P3H", "P4H", "P5H", "P1V", "P2V", "P3V", "P4V", "P5V", "C1V", "C2V", "C3V", "C1H", "C2H", "C3H", "S1H", "S2H", "S1V", "S2V" };

        string[] limite_pa_hori = new string[] { "b96", "b86", "b76", "b66", "b56", "b46", "b36", "b26", "b16", "b06", "b97", "b87", "b77", "b67", "b57", "b47", "b37", "b27", "b17", "b07", "b99", "b89", "b79", "b69", "b59", "b49", "b39", "b29", "b19", "b09", "b98", "b88", "b78", "b68", "b58", "b48", "b38", "b28", "b18", "b08" };
        string[] limite_ca_hori = new string[] { "b97", "b87", "b77", "b67", "b57", "b47", "b37", "b27", "b17", "b07", "b99", "b89", "b79", "b69", "b59", "b49", "b39", "b29", "b19", "b09" };
        string[] limite_su_hori = new string[] { "b99", "b89", "b79", "b69", "b59", "b49", "b39", "b29", "b19", "b09" };

        string[] limite_pa_vert = new string[] { "b80", "b90", "b70", "b60", "b81", "b91", "b71", "b61", "b82", "b92", "b72", "b62", "b83", "b93", "b73", "b63", "b84", "b94", "b74", "b64", "b85", "b95", "b75", "b65", "b86", "b96", "b76", "b66", "b87", "b97", "b77", "b67", "b88", "b98", "b78", "b68", "b89", "b99", "b79", "b69" };
        string[] limite_ca_vert = new string[] { "b80", "b90", "b81", "b91", "b82", "b92", "b83", "b93", "b84", "b94", "b85", "b95", "b86", "b96", "b87", "b97", "b88", "b98", "b89", "b99" };
        string[] limite_su_vert = new string[] { "b90", "b91", "b92", "b93", "b94", "b95", "b96", "b97", "b98", "b99" };

        string[] point_pa = new string[] { "P1H", "P2H", "P3H", "P4H", "P5H", "P1V", "P2V", "P3V", "P4V", "P5V" };
        string[] point_ca = new string[] { "C1H", "C2H", "C3H", "C1V", "C2V", "C3V" };
        string[] point_su = new string[] { "S1H", "S2H", "S1V", "S2V" };

        

        int victory = 0; // pontuação player
        int enemy_victory = 0; // pontuação inimigo
        int enemy_vertical = 30;
        int enemy_horizontal = 430;
        int vertical = 30;
        int horizontal = 30;
        bool ver = false; // verificação de localização possivel
        bool ver_1 = false;
        bool ver_2 = false;
        bool ver_3 = false;
        bool ver_4 = false;
        bool flip = false; // horizontal e vertical
        int ztat = 8; // contador para status de peças em jogo
        int enemy_ztat = 8; // contador do inimigo
        bool end = false; // encerra o jogador
        int status = 1; // status geral do jogo
        
        Random rdn = new Random(); // criar valor random u.u
        SoundPlayer soundPlayer;
        SoundPlayer explosao;

        public batalhas_navais()
        {
            InitializeComponent();
            b_flip.BackColor = Color.Transparent;
            
            soundPlayer = new SoundPlayer(musicas.traca);
            explosao = new SoundPlayer(musicas.kabumm);

            botoes();
            soundPlayer.PlayLooping();
        }



        private void Batalhas_navais_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        void botoes()
        {
            b_flip.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/flip_h.png");
            
            for (int i = 0; i < button_array.Length; i++)
            {

                button_array[i] = new Button();


                if (i <= 9)
                {
                    string x = "0" + i;
                    button_array[i].Name = "b" + x[1] + x[0];
                    // criar botão com eixo x e y

                }
                else
                {
                    string x = i.ToString();
                    button_array[i].Name = "b" + x[1] + x[0];
                    

                }

                button_array[i].FlatStyle = FlatStyle.Flat;
                button_array[i].Size = new Size(30, 30);
                button_array[i].Location = new Point(horizontal, vertical);

                if ((i + 1) % 10 == 0)
                {
                    horizontal += 30;
                    vertical -= 270;
                }
                else
                {
                    vertical += 30;
                }

                button_array[i].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/agua.jpg");
                button_array[i].Click += new System.EventHandler(event_click);

                //button_array[i].MouseHover += new System.EventHandler(event_hover);

                this.Controls.Add(button_array[i]);


            }
        }

        void botoes_enemy()
        {
            for (int i = 0; i < enemy_array.Length; i++)
            {

                enemy_array[i] = new Button();
                if (i <= 9)
                {
                    string x = "0" + i;
                    enemy_array[i].Name = "b" + x[1] + x[0];

                }
                else
                {
                    string x = i.ToString();
                    enemy_array[i].Name = "b" + x[1] + x[0];

                }
                enemy_array[i].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/button_vazio.jpg");
                string nn = enemy_array[i].Name;

                char nx = nn[1];
                char ny = nn[2];

                enemy_array[i].FlatStyle = FlatStyle.Flat;
                enemy_array[i].Size = new Size(30, 30);
                enemy_array[i].Location = new Point(enemy_horizontal, enemy_vertical);

                if ((i + 1) % 10 == 0)
                {
                    enemy_horizontal += 30;
                    enemy_vertical -= 270;
                }
                else
                {
                    enemy_vertical += 30;
                }
                enemy_array[i].Click += new System.EventHandler(enemy_event_click);
                enemy_array[i].MouseHover += new System.EventHandler(enemy_event_hover);
                this.Controls.Add(enemy_array[i]);


            }
            for (; enemy_ztat != 1;)
            {
                if (enemy_ztat == 8 || enemy_ztat == 7)
                {
                    int tt = 0;
                    tt = rdn.Next(2);
                    if (tt == 1)
                    {
                        flip = true;
                    }
                    else
                    {
                        flip = false;
                    }
                    enemy_su_switch(enemy_array[rdn.Next(99)]); // ca
                    enemy_ztat = enemy_ztat - 1;
                }
                if (enemy_ztat == 6 || enemy_ztat == 5)
                {
                    int tt = 0;
                    tt = rdn.Next(2);
                    if (tt == 1)
                    {
                        flip = true;
                    }
                    else
                    {
                        flip = false;
                    }
                    enemy_pa_switch(enemy_array[rdn.Next(99)]); // pa
                    enemy_ztat = enemy_ztat - 1;
                }
                if (enemy_ztat == 4 || enemy_ztat == 3 || enemy_ztat == 2)
                {
                    int tt = 0;
                    tt = rdn.Next(2);
                    if (tt == 1)
                    {
                        flip = true;
                    }
                    else
                    {
                        flip = false;
                    }
                    enemy_ca_switch(enemy_array[rdn.Next(99)]); // pa
                    enemy_ztat = enemy_ztat - 1;
                }
            }
        }

        public void event_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String nome = btn.Name;
            verifica(btn); // devolve valor booleano para variavel "ver"
            if (status == 1)
            {
                if (ver != true)
                {

                    if (ztat == 8 || ztat == 7)
                    {
                        su_switch(btn);
                        ztat--;
                    }

                    if (ztat == 6 || ztat == 5)
                    {
                        pa_switch(btn);
                        ztat--;
                    }

                    if (ztat == 4 || ztat == 3 || ztat == 2)
                    {
                        ca_switch(btn);
                        ztat--;
                    }

                    if (ztat == 1)
                    {
                        b_flip.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ready.jpg");
                    }
                }
            }
            if (status == 2)
            {

            }
        }

        public void enemy_event_click(object sender, EventArgs e)
        {
            Button e_btn = (Button)sender;
            String nome = e_btn.Name;
            char but = nome[0];

            if (status == 2)
            {
                if (e_btn.Name != "x") // verifica se ja foi clicado
                {

                    //explosao.Play();

                    if (points.Contains(nome)) // verifica se o botao esta nos que pode ter navio
                    {
                        if (but.ToString() != "b") // verifica se é diferente de b o primerio caractere
                        {
                            if (point_su.Contains(nome)) // se conter nesta lista entao é sumarino
                            {
                                if (nome == "S1H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h1_ex.jpg"); // muda imagem
                                    enemy_victory++; // soma uma vitoria para o jogador
                                }
                                if (nome == "S2H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h2_ex.jpg");
                                    enemy_victory++;
                                }
                                if (nome == "S1V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v1_ex.jpg");
                                    enemy_victory++;
                                }
                                if (nome == "S2V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v2_ex.jpg");
                                    enemy_victory++;
                                }
                            } // img de acerto submarino

                            if (point_ca.Contains(nome))
                            {
                                if (nome == "C1V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v1_ex.jpg");
                                
                                }
                                if (nome == "C2V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v2_ex.jpg");
                              
                                }
                                if (nome == "C3V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v3_ex.jpg");
                               
                                }
                                if (nome == "C1H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h1_ex.jpg");
                                
                                }
                                if (nome == "C2H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h2_ex.jpg");
                                   
                                }
                                if (nome == "C3H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h3_ex.jpg");
                                   
                                }
                            } // img de acerto caravela

                            if (point_pa.Contains(nome))
                            {
                                if (nome == "P1V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v1_ex.jpg");
                                 
                                }
                                if (nome == "P2V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v2_ex.jpg");
                                 
                                }
                                if (nome == "P3V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v3_ex.jpg");
                                   
                                }
                                if (nome == "P4V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v4_ex.jpg");
                                    
                                }
                                if (nome == "P5V")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v5_ex.jpg");
                                    
                                }
                                if (nome == "P1H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h1_ex.jpg");
                                   
                                }
                                if (nome == "P2H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h2_ex.jpg");
                                    
                                }
                                if (nome == "P3H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h3_ex.jpg");
                                    
                                }
                                if (nome == "P4H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h4_ex.jpg");
                                    
                                }
                                if (nome == "P5H")
                                {
                                    e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h5_ex.jpg");
                                    
                                }
                            }// img de acerto porta aviao
                        }
                        //e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/acerto.jpg");
                        victory++;
                        int att = rdn.Next(99); // gera valor aleatoria entre 0 e 99
                        if (points.Contains(button_array[att].Name)) // verifica se vale ponto o botao clicado
                        {
                            string nm = button_array[att].Name;
                            char bu = nm[0];
                            string btt = bu.ToString();
                            if (btt != "b")
                            {
                                if (point_su.Contains(nm))
                                {
                                    if (nm == "S1H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h1_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "S2H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h2_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "S1V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v1_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "S2V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v2_ex.jpg");
                                        enemy_victory++;
                                    }
                                } // img de acerto submarino

                                if (point_ca.Contains(nm))
                                {
                                    if (nm == "C1V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v1_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "C2V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v2_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "C3V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v3_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "C1H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h1_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "C2H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h2_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "C3H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h3_ex.jpg");
                                        enemy_victory++;
                                    }
                                } // img de acerto caravela

                                if (point_pa.Contains(nm))
                                {
                                    if (nm == "P1V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v1_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "P2V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v2_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "P3V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v3_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "P4V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v4_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "P5V")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v5_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "P1H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h1_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "P2H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h2_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "P3H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h3_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "P4H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h4_ex.jpg");
                                        enemy_victory++;
                                    }
                                    if (nm == "P5H")
                                    {
                                        button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h5_ex.jpg");
                                        enemy_victory++;
                                    }
                                }// img de acerto porta aviao
                            }
                        }
                        else
                        {
                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/erro.jpg");

                        }

                    }
                    else
                    {
                        e_btn.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/agua.jpg");
                        int att = rdn.Next(99);
                        if (points.Contains(button_array[att].Name))
                        {
                            if (button_array[att].Name != "x")
                            {
                                string nm = button_array[att].Name;
                                char bu = nm[0];
                                string btt = bu.ToString();
                                if (btt != "b")
                                {
                                    if (point_su.Contains(nm))
                                    {
                                        if (nm == "S1H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h1_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "S2H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h2_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "S1V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v1_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "S2V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v2_ex.jpg");
                                            enemy_victory++;
                                        }
                                    } // img de acerto submarino

                                    if (point_ca.Contains(nm))
                                    {
                                        if (nm == "C1V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v1_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "C2V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v2_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "C3V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v3_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "C1H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h1_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "C2H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h2_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "C3H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h3_ex.jpg");
                                            enemy_victory++;
                                        }
                                    } // img de acerto caravela

                                    if (point_pa.Contains(nm))
                                    {
                                        if (nm == "P1V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v1_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "P2V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v2_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "P3V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v3_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "P4V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v4_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "P5V")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v5_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "P1H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h1_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "P2H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h2_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "P3H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h3_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "P4H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h4_ex.jpg");
                                            enemy_victory++;
                                        }
                                        if (nm == "P5H")
                                        {
                                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h5_ex.jpg");
                                            enemy_victory++;
                                        }
                                    }// img de acerto porta aviao
                                }
                            }
                        }
                        else
                        {
                            button_array[att].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/erro.jpg");

                        }
                    }

                    e_btn.Name = "x";
                }

            }
            if (enemy_victory == 23)
            {
                MessageBox.Show("Bot WIN");
            }
            if (victory == 23)
            {
                MessageBox.Show("You WIN");
            }



        }

        void pa_switch(Button xx)
        {
            if (flip)
            {
                int a = Array.IndexOf(button_array, xx);
                int pa_lad_1 = a + 1;
                int pa_lad_2 = a + 2;
                int pa_lad_3 = a + 3;
                int pa_lad_4 = a + 4;
                bool test = false;
                bool test1 = false;
                bool test2 = false;
                bool test3 = false;
                ver_1 = true;
                ver_2 = true;
                ver_3 = true;
                ver_4 = true;

                if (limite_pa_vert.Contains(xx.Name))
                {
                    test = true;
                    test1 = true;
                    test2 = true;
                    test3 = true;
                }

                if (pa_lad_1 <= 99 && pa_lad_2 <= 99 && pa_lad_3 <= 99 && pa_lad_4 <= 99)
                {
                    verifica_1(button_array[pa_lad_1]);
                    verifica_2(button_array[pa_lad_2]);
                    verifica_3(button_array[pa_lad_3]);
                    verifica_4(button_array[pa_lad_4]);
                }

                if (ver_1 != true && ver_2 != true && ver_3 != true && ver_4 != true && test != true && test1 != true && test2 != true && test3 != true)
                {

                    xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v1.jpg");
                    button_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v2.jpg");
                    button_array[pa_lad_2].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v3.jpg");
                    button_array[pa_lad_3].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v4.jpg");
                    button_array[pa_lad_4].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v5.jpg");

                    xx.Name = "P1V";
                    button_array[pa_lad_1].Name = "P2V";
                    button_array[pa_lad_2].Name = "P3V";
                    button_array[pa_lad_3].Name = "P4V";
                    button_array[pa_lad_4].Name = "P5V";
                }
                else
                {
                    ztat += 1;
                }
            }
            else
            {
                int a = Array.IndexOf(button_array, xx);
                int pa_lad_1 = a + 10;
                int pa_lad_2 = a + 20;
                int pa_lad_3 = a + 30;
                int pa_lad_4 = a + 40;
                bool test = false;
                bool test1 = false;
                bool test2 = false;
                bool test3 = false;
                ver_1 = true;
                ver_2 = true;
                ver_3 = true;
                ver_4 = true;

                if (limite_pa_hori.Contains(xx.Name))
                {
                    test = true;
                    test1 = true;
                    test2 = true;
                    test3 = true;
                }

                if (pa_lad_1 <= 99 && pa_lad_2 <= 99 && pa_lad_3 <= 99 && pa_lad_4 <= 99)
                {
                    verifica_1(button_array[pa_lad_1]);
                    verifica_2(button_array[pa_lad_2]);
                    verifica_3(button_array[pa_lad_3]);
                    verifica_4(button_array[pa_lad_4]);
                }

                if (ver_1 != true && ver_2 != true && ver_3 != true && ver_4 != true && test != true && test1 != true && test2 != true && test3 != true)
                {

                    xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h1.jpg");
                    button_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h2.jpg");
                    button_array[pa_lad_2].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h3.jpg");
                    button_array[pa_lad_3].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h4.jpg");
                    button_array[pa_lad_4].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h5.jpg");

                    xx.Name = "P1H";
                    button_array[pa_lad_1].Name = "P2H";
                    button_array[pa_lad_2].Name = "P3H";
                    button_array[pa_lad_3].Name = "P4H";
                    button_array[pa_lad_4].Name = "P5H";
                }
                else
                {
                    ztat += 1;
                }

            }
        }

        void enemy_pa_switch(Button xx)
        {
            if (flip)
            {
                int a = Array.IndexOf(enemy_array, xx);
                int pa_lad_1 = a + 1;
                int pa_lad_2 = a + 2;
                int pa_lad_3 = a + 3;
                int pa_lad_4 = a + 4;
                bool test = false;
                bool test1 = false;
                bool test2 = false;
                bool test3 = false;
                ver_1 = true;
                ver_2 = true;
                ver_3 = true;
                ver_4 = true;

                if (limite_pa_vert.Contains(xx.Name))
                {
                    test = true;
                    test1 = true;
                    test2 = true;
                    test3 = true;
                }

                if (pa_lad_1 <= 99 && pa_lad_2 <= 99 && pa_lad_3 <= 99 && pa_lad_4 <= 99)
                {
                    verifica_1(enemy_array[pa_lad_1]);
                    verifica_2(enemy_array[pa_lad_2]);
                    verifica_3(enemy_array[pa_lad_3]);
                    verifica_4(enemy_array[pa_lad_4]);
                }

                if (ver_1 != true && ver_2 != true && ver_3 != true && ver_4 != true && test != true && test1 != true && test2 != true && test3 != true)
                {

                    //xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v1.jpg");
                   // enemy_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v2.jpg");
                    //enemy_array[pa_lad_2].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v3.jpg");
                    //enemy_array[pa_lad_3].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v4.jpg");
                    //enemy_array[pa_lad_4].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_v5.jpg");

                    xx.Name = "P1V";
                    enemy_array[pa_lad_1].Name = "P2V";
                    enemy_array[pa_lad_2].Name = "P3V";
                    enemy_array[pa_lad_3].Name = "P4V";
                    enemy_array[pa_lad_4].Name = "P5V";
                }
                else
                {
                    enemy_ztat += 1;
                }
            }
            else
            {
                int a = Array.IndexOf(enemy_array, xx);
                int pa_lad_1 = a + 10;
                int pa_lad_2 = a + 20;
                int pa_lad_3 = a + 30;
                int pa_lad_4 = a + 40;
                bool test = false;
                bool test1 = false;
                bool test2 = false;
                bool test3 = false;
                ver_1 = true;
                ver_2 = true;
                ver_3 = true;
                ver_4 = true;

                if (limite_pa_hori.Contains(xx.Name))
                {
                    test = true;
                    test1 = true;
                    test2 = true;
                    test3 = true;
                }

                if (pa_lad_1 <= 99 && pa_lad_2 <= 99 && pa_lad_3 <= 99 && pa_lad_4 <= 99)
                {
                    verifica_1(enemy_array[pa_lad_1]);
                    verifica_2(enemy_array[pa_lad_2]);
                    verifica_3(enemy_array[pa_lad_3]);
                    verifica_4(enemy_array[pa_lad_4]);
                }

                if (ver_1 != true && ver_2 != true && ver_3 != true && ver_4 != true && test != true && test1 != true && test2 != true && test3 != true)
                {

                    //xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h1.jpg");
                    //enemy_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h2.jpg");
                    //enemy_array[pa_lad_2].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h3.jpg");
                    //enemy_array[pa_lad_3].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h4.jpg");
                    //enemy_array[pa_lad_4].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/pa_h5.jpg");

                    xx.Name = "P1H";
                    enemy_array[pa_lad_1].Name = "P2H";
                    enemy_array[pa_lad_2].Name = "P3H";
                    enemy_array[pa_lad_3].Name = "P4H";
                    enemy_array[pa_lad_4].Name = "P5H";
                }
                else
                {
                    enemy_ztat += 1;
                }

            }
        }

        void ca_switch(Button xx)
        {
            if (flip)
            {
                int a = Array.IndexOf(button_array, xx);
                int pa_lad_1 = a + 1;
                int pa_lad_2 = a + 2;
                bool test = false;
                bool test1 = false;
                ver_1 = true;
                ver_2 = true;

                if (limite_ca_vert.Contains(xx.Name))
                {
                    test1 = true;
                    test = true;
                }

                if (pa_lad_1 <= 99 && pa_lad_2 <= 99)
                {
                    verifica_1(button_array[pa_lad_1]);
                    verifica_2(button_array[pa_lad_2]);
                }


                if (ver_1 != true && ver_2 != true && test != true && test1 != true)
                {
                    xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v1.jpg");
                    button_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v2.jpg");
                    button_array[pa_lad_2].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v3.jpg");

                    xx.Name = "C1V";
                    button_array[pa_lad_1].Name = "C2V";
                    button_array[pa_lad_2].Name = "C3V";

                }
                else
                {
                    ztat += 1;
                }
            }
            else
            {
                int a = Array.IndexOf(button_array, xx);
                int pa_lad_1 = a + 10;
                int pa_lad_2 = a + 20;
                bool test = false;
                bool test1 = false;
                ver_1 = true;
                ver_2 = true;

                if (limite_ca_hori.Contains(xx.Name))
                {
                    test1 = true;
                    test = true;
                }

                if (pa_lad_1 <= 99 && pa_lad_2 <= 99)
                {
                    verifica_1(button_array[pa_lad_1]);
                    verifica_2(button_array[pa_lad_2]);
                }

                if (ver_1 != true && ver_2 != true && test != true && test1 != true)
                {


                    xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h1.jpg");
                    button_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h2.jpg");
                    button_array[pa_lad_2].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h3.jpg");

                    xx.Name = "C1H";
                    button_array[pa_lad_1].Name = "C2H";
                    button_array[pa_lad_2].Name = "C3H";

                }
                else
                {
                    ztat += 1;
                }
            }
        }

        void enemy_ca_switch(Button xx)
        {
            if (flip)
            {
                int a = Array.IndexOf(enemy_array, xx);
                int pa_lad_1 = a + 1;
                int pa_lad_2 = a + 2;
                bool test = false;
                bool test1 = false;
                ver_1 = true;
                ver_2 = true;

                if (limite_ca_vert.Contains(xx.Name))
                {
                    test1 = true;
                    test = true;
                }

                if (pa_lad_1 <= 99 && pa_lad_2 <= 99)
                {
                    verifica_1(enemy_array[pa_lad_1]);
                    verifica_2(enemy_array[pa_lad_2]);
                }


                if (ver_1 != true && ver_2 != true && test != true && test1 != true)
                {
                    //xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v1.jpg");
                    //enemy_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v2.jpg");
                    //enemy_array[pa_lad_2].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_v3.jpg");

                    xx.Name = "C1V";
                    enemy_array[pa_lad_1].Name = "C2V";
                    enemy_array[pa_lad_2].Name = "C3V";

                }
                else
                {
                    enemy_ztat += 1;
                }
            }
            else
            {
                int a = Array.IndexOf(enemy_array, xx);
                int pa_lad_1 = a + 10;
                int pa_lad_2 = a + 20;
                bool test = false;
                bool test1 = false;
                ver_1 = true;
                ver_2 = true;

                if (limite_ca_hori.Contains(xx.Name))
                {
                    test1 = true;
                    test = true;
                }

                if (pa_lad_1 <= 99 && pa_lad_2 <= 99)
                {
                    verifica_1(enemy_array[pa_lad_1]);
                    verifica_2(enemy_array[pa_lad_2]);
                }

                if (ver_1 != true && ver_2 != true && test != true && test1 != true)
                {

                    //xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h1.jpg");
                    //enemy_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h2.jpg");
                    //enemy_array[pa_lad_2].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/ca_h3.jpg");

                    xx.Name = "C1H";
                    enemy_array[pa_lad_1].Name = "C2H";
                    enemy_array[pa_lad_2].Name = "C3H";

                }
                else
                {
                    enemy_ztat += 1;
                }
            }
        }

        void su_switch(Button xx)
        {
            if (flip)
            {
                int a = Array.IndexOf(button_array, xx);
                int pa_lad_1 = a + 1;
                bool test = false;
                ver_1 = true;

                if (limite_su_vert.Contains(xx.Name))
                {

                    test = true;
                }

                if (pa_lad_1 <= 99)
                {

                    verifica_1(button_array[pa_lad_1]);
                }

                if (ver_1 != true && test != true)
                {
                    xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v1.jpg");
                    button_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v2.jpg");

                    xx.Name = "S1V";
                    button_array[pa_lad_1].Name = "S2V";
                }
                else
                {
                    ztat += 1;
                }
            }
            else
            {
                int a = Array.IndexOf(button_array, xx);
                int pa_lad_1 = a + 10;
                bool test = false;
                ver_1 = true;

                if (limite_su_hori.Contains(xx.Name)) // verifica na lista que nao pode cair em 
                {
                    // se estiver la lista entao test verdadeiro ideia é não passar aqui
                    test = true;
                }

                if (pa_lad_1 <= 99)
                {
                    // verifica se esta dentro de 99 a ideia é resultar negativo en
                    verifica_1(button_array[pa_lad_1]);
                }
                // ver == false e test == false (referente a nao estar na lista)
                if (ver_1 != true && test != true)
                {
                    xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h1.jpg");
                    button_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h2.jpg");

                    xx.Name = "S1H";
                    button_array[pa_lad_1].Name = "S2H";
                }
                else
                {
                    ztat += 1;
                }
            }
        }

        void enemy_su_switch(Button xx)
        {
            if (flip)
            {
                int a = Array.IndexOf(enemy_array, xx);
                int pa_lad_1 = a + 1;
                bool test = false;
                ver_1 = true;

                if (limite_su_vert.Contains(xx.Name))
                {
                    test = true;
                }

                if (pa_lad_1 <= 99)
                {

                    verifica_1(enemy_array[pa_lad_1]);
                }

                if (ver_1 != true && test != true)
                {
                    //xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v1.jpg");
                    //enemy_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_v2.jpg");

                    xx.Name = "S1V";
                    enemy_array[pa_lad_1].Name = "S2V";
                }
                else
                {
                    enemy_ztat += 1;
                }
            }
            else
            {
                int a = Array.IndexOf(enemy_array, xx);
                int pa_lad_1 = a + 10;
                bool test = false;
                ver_1 = true;

                if (limite_su_hori.Contains(xx.Name))
                {
                    test = true;
                }

                if (pa_lad_1 <= 99)
                {
                    verifica_1(enemy_array[pa_lad_1]);
                }
                if (ver_1 != true && test != true)
                {
                    //xx.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h1.jpg");
                    //enemy_array[pa_lad_1].BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/su_h2.jpg");

                    xx.Name = "S1H";
                    enemy_array[pa_lad_1].Name = "S2H";
                }
                else
                {
                    enemy_ztat += 1;
                }
            }
        }

        void verifica(Button btn)
        {
            char nam = btn.Name[0];
            string name = nam.ToString();
            if (name != "b")
            {
                // se não é b resulta em true
                ver = true;
            }
            if (name == "b")
            {
                // se é b resulta falso
                ver = false;
            }
            if (ztat < 1)
            {
                // faz com que pare de verificar logo bloqueia os clicks
                ver = false;
            }



        }

        void verifica_1(Button btn)
        {
            char nam = btn.Name[0];
            string name = nam.ToString();
            if (name != "b")
            {
                ver_1 = true;
            }
            else
            {
                ver_1 = false;
            }
        }

        void verifica_2(Button btn)
        {
            char nam = btn.Name[0];
            string name = nam.ToString();
            if (name != "b")
            {
                ver_2 = true;
            }
            else
            {
                ver_2 = false;
            }
        }

        void verifica_3(Button btn)
        {
            char nam = btn.Name[0];
            string name = nam.ToString();
            if (name != "b")
            {
                ver_3 = true;
            }
            else
            {
                ver_3 = false;
            }
        }

        void verifica_4(Button btn)
        {
            char nam = btn.Name[0];
            string name = nam.ToString();
            if (name != "b")
            {
                ver_4 = true;
            }
            else
            {
                ver_4 = false;
            }
        }

        private void B_flip_Click(object sender, EventArgs e)
        {
            ((Button) sender).FlatStyle = FlatStyle.Flat;
            

            b_flip.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/flip_h.png");
            if (flip)
            {
                flip = false;
                b_flip.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/flip_v.png");

            }
            else
            {
                flip = true;
                b_flip.BackgroundImage = Image.FromFile("C:/Users/mathe/OneDrive/Área de Trabalho/Projeto C.Sharp/batalha_naval/fotos_geral/flip_h.png");
            }
            if (end != true && ztat == 1)
            {
                status = status + 1;
                b_flip.Hide();
                ztat--;
                botoes_enemy();
            }
        }

        public void enemy_event_hover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String nome = btn.Name;
            //l_test.Text = nome;

        }

        private void L_test_Click(object sender, EventArgs e)
        {

        }


    }
}
