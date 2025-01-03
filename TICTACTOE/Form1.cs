using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using DrawingImage = System.Drawing.Image;
using WinFormsApplication = System.Windows.Forms.Application;


namespace TICTACTOE
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X,
            O
        }

        Player currentPlayer;
        int PlayerXWinCount = 0;
        int PlayerOWinCount = 0;
        List<Button> buttons;

        // Menyimpan gambar 'X' dan 'O' dalam variabel untuk akses yang lebih mudah
        private DrawingImage xImage;
        private DrawingImage oImage;
        private DrawingImage defaultImage;

        public Form1()
        {
            InitializeComponent();
            string xImagePath = Path.Combine(WinFormsApplication.StartupPath, "D:\\Work Stuff\\homework\\TICTACTOE\\TICTACTOE\\Properties\\Image\\X.png");
            string oImagePath = Path.Combine(WinFormsApplication.StartupPath, "D:\\Work Stuff\\homework\\TICTACTOE\\TICTACTOE\\Properties\\Image\\O.png");
            string defaultImagePath = Path.Combine(WinFormsApplication.StartupPath, "D:\\Work Stuff\\homework\\TICTACTOE\\TICTACTOE\\Properties\\Image\\tt.png");
            xImage = DrawingImage.FromFile(xImagePath);
            oImage = DrawingImage.FromFile(oImagePath);
            defaultImage = DrawingImage.FromFile(defaultImagePath);
            buttons = new List<Button>();
            RestartGame();

        }


        private void LoadImages()
        {
            // Memuat gambar dari file
            xImage = DrawingImage.FromFile("D:\\Work Stuff\\homework\\TICTACTOE\\TICTACTOE\\Properties\\Image\\X.png");
            oImage = DrawingImage.FromFile("D:\\Work Stuff\\homework\\TICTACTOE\\TICTACTOE\\Properties\\Image\\O.png");
            defaultImage = DrawingImage.FromFile("D:\\Work Stuff\\homework\\TICTACTOE\\TICTACTOE\\Properties\\Image\\tt.png");
        }
        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;

            button.Enabled = false;
            button.BackgroundImage = currentPlayer == Player.X ? xImage : oImage;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Text = "";  // Menambahkan teks 'X' atau 'O' di atas gambar jika diperlukan.

            buttons.Remove(button);
            CheckGame();
            currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
        }




        private void SaveScore(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
                    saveFileDialog.Title = "Simpan Data Skor";
                    saveFileDialog.DefaultExt = "xml";
                    saveFileDialog.FileName = "score.xml";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Menulis data langsung ke XML
                        var xmlContent = new System.Text.StringBuilder();
                        xmlContent.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                        xmlContent.AppendLine("<Scores>");
                        xmlContent.AppendLine($"  <PlayerXWins>{PlayerXWinCount}</PlayerXWins>");
                        xmlContent.AppendLine($"  <PlayerOWins>{PlayerOWinCount}</PlayerOWins>");
                        xmlContent.AppendLine("</Scores>");

                        File.WriteAllText(saveFileDialog.FileName, xmlContent.ToString());

                        MessageBox.Show("Skor berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menyimpan skor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckGame()
        {
            // Pengecekan horizontal (3 in a row) dengan gambar
            if ((button1.BackgroundImage == xImage && button2.BackgroundImage == xImage && button3.BackgroundImage == xImage) ||
                (button2.BackgroundImage == xImage && button3.BackgroundImage == xImage && button4.BackgroundImage == xImage) ||
                (button3.BackgroundImage == xImage && button4.BackgroundImage == xImage && button5.BackgroundImage == xImage) ||
                (button6.BackgroundImage == xImage && button7.BackgroundImage == xImage && button8.BackgroundImage == xImage) ||
                (button7.BackgroundImage == xImage && button8.BackgroundImage == xImage && button9.BackgroundImage == xImage) ||
                (button8.BackgroundImage == xImage && button9.BackgroundImage == xImage && button10.BackgroundImage == xImage) ||
                (button11.BackgroundImage == xImage && button12.BackgroundImage == xImage && button13.BackgroundImage == xImage) ||
                (button12.BackgroundImage == xImage && button13.BackgroundImage == xImage && button14.BackgroundImage == xImage) ||
                (button13.BackgroundImage == xImage && button14.BackgroundImage == xImage && button15.BackgroundImage == xImage) ||
                (button16.BackgroundImage == xImage && button17.BackgroundImage == xImage && button18.BackgroundImage == xImage) ||
                (button17.BackgroundImage == xImage && button18.BackgroundImage == xImage && button19.BackgroundImage == xImage) ||
                (button18.BackgroundImage == xImage && button19.BackgroundImage == xImage && button20.BackgroundImage == xImage) ||
                (button21.BackgroundImage == xImage && button22.BackgroundImage == xImage && button23.BackgroundImage == xImage) ||
                (button22.BackgroundImage == xImage && button23.BackgroundImage == xImage && button24.BackgroundImage == xImage) ||
                (button23.BackgroundImage == xImage && button24.BackgroundImage == xImage && button25.BackgroundImage == xImage))
            {
                
                EndGame();
                return;
            }

            // Pengecekan vertikal (3 in a row) dengan gambar
            if ((button1.BackgroundImage == xImage && button6.BackgroundImage == xImage && button11.BackgroundImage == xImage) ||
                (button6.BackgroundImage == xImage && button11.BackgroundImage == xImage && button16.BackgroundImage == xImage) ||
                (button11.BackgroundImage == xImage && button16.BackgroundImage == xImage && button21.BackgroundImage == xImage) ||
                (button2.BackgroundImage == xImage && button7.BackgroundImage == xImage && button12.BackgroundImage == xImage) ||
                (button7.BackgroundImage == xImage && button12.BackgroundImage == xImage && button17.BackgroundImage == xImage) ||
                (button12.BackgroundImage == xImage && button17.BackgroundImage == xImage && button22.BackgroundImage == xImage) ||
                (button3.BackgroundImage == xImage && button8.BackgroundImage == xImage && button13.BackgroundImage == xImage) ||
                (button8.BackgroundImage == xImage && button13.BackgroundImage == xImage && button18.BackgroundImage == xImage) ||
                (button13.BackgroundImage == xImage && button18.BackgroundImage == xImage && button23.BackgroundImage == xImage) ||
                (button4.BackgroundImage == xImage && button9.BackgroundImage == xImage && button14.BackgroundImage == xImage) ||
                (button9.BackgroundImage == xImage && button14.BackgroundImage == xImage && button19.BackgroundImage == xImage) ||
                (button14.BackgroundImage == xImage && button19.BackgroundImage == xImage && button24.BackgroundImage == xImage) ||
                (button5.BackgroundImage == xImage && button10.BackgroundImage == xImage && button15.BackgroundImage == xImage) ||
                (button10.BackgroundImage == xImage && button15.BackgroundImage == xImage && button20.BackgroundImage == xImage) ||
                (button15.BackgroundImage == xImage && button20.BackgroundImage == xImage && button25.BackgroundImage == xImage))
            {
                
                EndGame();
                return;
            }

            // Pengecekan diagonal (3 in a row) dengan gambar
            if ((button1.BackgroundImage == xImage && button7.BackgroundImage == xImage && button13.BackgroundImage == xImage) ||
                (button7.BackgroundImage == xImage && button13.BackgroundImage == xImage && button19.BackgroundImage == xImage) ||
                (button13.BackgroundImage == xImage && button19.BackgroundImage == xImage && button25.BackgroundImage == xImage) ||
                (button2.BackgroundImage == xImage && button8.BackgroundImage == xImage && button14.BackgroundImage == xImage) ||
                (button8.BackgroundImage == xImage && button14.BackgroundImage == xImage && button20.BackgroundImage == xImage) ||
                (button3.BackgroundImage == xImage && button9.BackgroundImage == xImage && button15.BackgroundImage == xImage) ||
                (button9.BackgroundImage == xImage && button15.BackgroundImage == xImage && button21.BackgroundImage == xImage) ||
                (button4.BackgroundImage == xImage && button10.BackgroundImage == xImage && button16.BackgroundImage == xImage) ||
                (button10.BackgroundImage == xImage && button16.BackgroundImage == xImage && button22.BackgroundImage == xImage) ||
                (button5.BackgroundImage == xImage && button14.BackgroundImage == xImage && button23.BackgroundImage == xImage) ||
                (button6.BackgroundImage == xImage && button12.BackgroundImage == xImage && button18.BackgroundImage == xImage) ||
                (button11.BackgroundImage == xImage && button17.BackgroundImage == xImage && button23.BackgroundImage == xImage) ||
                (button9.BackgroundImage == xImage && button13.BackgroundImage == xImage && button17.BackgroundImage == xImage) ||
                (button8.BackgroundImage == xImage && button12.BackgroundImage == xImage && button16.BackgroundImage == xImage) ||
                (button12.BackgroundImage == xImage && button18.BackgroundImage == xImage && button24.BackgroundImage == xImage) ||
                (button14.BackgroundImage == xImage && button18.BackgroundImage == xImage && button22.BackgroundImage == xImage) ||
                (button13.BackgroundImage == xImage && button17.BackgroundImage == xImage && button21.BackgroundImage == xImage) ||
                (button4.BackgroundImage == xImage && button8.BackgroundImage == xImage && button12.BackgroundImage == xImage) ||
                (button3.BackgroundImage == xImage && button7.BackgroundImage == xImage && button11.BackgroundImage == xImage) ||
                (button10.BackgroundImage == xImage && button14.BackgroundImage == xImage && button18.BackgroundImage == xImage) ||
                (button15.BackgroundImage == xImage && button19.BackgroundImage == xImage && button23.BackgroundImage == xImage) ||
                (button5.BackgroundImage == xImage && button9.BackgroundImage == xImage && button13.BackgroundImage == xImage))
            {
                
                EndGame();
                return;
            }

            // Pengecekan horizontal (3 in a row) dengan gambar
            if ((button1.BackgroundImage == oImage && button2.BackgroundImage == oImage && button3.BackgroundImage == oImage) ||
                (button2.BackgroundImage == oImage && button3.BackgroundImage == oImage && button4.BackgroundImage == oImage) ||
                (button3.BackgroundImage == oImage && button4.BackgroundImage == oImage && button5.BackgroundImage == oImage) ||
                (button6.BackgroundImage == oImage && button7.BackgroundImage == oImage && button8.BackgroundImage == oImage) ||
                (button7.BackgroundImage == oImage && button8.BackgroundImage == oImage && button9.BackgroundImage == oImage) ||
                (button8.BackgroundImage == oImage && button9.BackgroundImage == oImage && button10.BackgroundImage == oImage) ||
                (button11.BackgroundImage == oImage && button12.BackgroundImage == oImage && button13.BackgroundImage == oImage) ||
                (button12.BackgroundImage == oImage && button13.BackgroundImage == oImage && button14.BackgroundImage == oImage) ||
                (button13.BackgroundImage == oImage && button14.BackgroundImage == oImage && button15.BackgroundImage == oImage) ||
                (button16.BackgroundImage == oImage && button17.BackgroundImage == oImage && button18.BackgroundImage == oImage) ||
                (button17.BackgroundImage == oImage && button18.BackgroundImage == oImage && button19.BackgroundImage == oImage) ||
                (button18.BackgroundImage == oImage && button19.BackgroundImage == oImage && button20.BackgroundImage == oImage) ||
                (button21.BackgroundImage == oImage && button22.BackgroundImage == oImage && button23.BackgroundImage == oImage) ||
                (button22.BackgroundImage == oImage && button23.BackgroundImage == oImage && button24.BackgroundImage == oImage) ||
                (button23.BackgroundImage == oImage && button24.BackgroundImage == oImage && button25.BackgroundImage == oImage))
            {
                
                EndGame();
                return;
            }

            // Pengecekan vertikal (3 in a row) dengan gambar
            if ((button1.BackgroundImage == oImage && button6.BackgroundImage == oImage && button11.BackgroundImage == oImage) ||
                (button6.BackgroundImage == oImage && button11.BackgroundImage == oImage && button16.BackgroundImage == oImage) ||
                (button11.BackgroundImage == oImage && button16.BackgroundImage == oImage && button21.BackgroundImage == oImage) ||
                (button2.BackgroundImage == oImage && button7.BackgroundImage == oImage && button12.BackgroundImage == oImage) ||
                (button7.BackgroundImage == oImage && button12.BackgroundImage == oImage && button17.BackgroundImage == oImage) ||
                (button12.BackgroundImage == oImage && button17.BackgroundImage == oImage && button22.BackgroundImage == oImage) ||
                (button3.BackgroundImage == oImage && button8.BackgroundImage == oImage && button13.BackgroundImage == oImage) ||
                (button8.BackgroundImage == oImage && button13.BackgroundImage == oImage && button18.BackgroundImage == oImage) ||
                (button13.BackgroundImage == oImage && button18.BackgroundImage == oImage && button23.BackgroundImage == oImage) ||
                (button4.BackgroundImage == oImage && button9.BackgroundImage == oImage && button14.BackgroundImage == oImage) ||
                (button9.BackgroundImage == oImage && button14.BackgroundImage == oImage && button19.BackgroundImage == oImage) ||
                (button14.BackgroundImage == oImage && button19.BackgroundImage == oImage && button24.BackgroundImage == oImage) ||
                (button5.BackgroundImage == oImage && button10.BackgroundImage == oImage && button15.BackgroundImage == oImage) ||
                (button10.BackgroundImage == oImage && button15.BackgroundImage == oImage && button20.BackgroundImage == oImage) ||
                (button15.BackgroundImage == oImage && button20.BackgroundImage == oImage && button25.BackgroundImage == oImage))
            {
                
                EndGame();
                return;
            }

            // Pengecekan diagonal (3 in a row) dengan gambar
            if ((button1.BackgroundImage == oImage && button7.BackgroundImage == oImage && button13.BackgroundImage == oImage) ||
                (button7.BackgroundImage == oImage && button13.BackgroundImage == oImage && button19.BackgroundImage == oImage) ||
                (button13.BackgroundImage == oImage && button19.BackgroundImage == oImage && button25.BackgroundImage == oImage) ||
                (button2.BackgroundImage == oImage && button8.BackgroundImage == oImage && button14.BackgroundImage == oImage) ||
                (button8.BackgroundImage == oImage && button14.BackgroundImage == oImage && button20.BackgroundImage == oImage) ||
                (button3.BackgroundImage == oImage && button9.BackgroundImage == oImage && button15.BackgroundImage == oImage) ||
                (button9.BackgroundImage == oImage && button15.BackgroundImage == oImage && button21.BackgroundImage == oImage) ||
                (button4.BackgroundImage == oImage && button10.BackgroundImage == oImage && button16.BackgroundImage == oImage) ||
                (button10.BackgroundImage == oImage && button16.BackgroundImage == oImage && button22.BackgroundImage == oImage) ||
                (button5.BackgroundImage == oImage && button14.BackgroundImage == oImage && button23.BackgroundImage == oImage) ||
                (button6.BackgroundImage == oImage && button12.BackgroundImage == oImage && button18.BackgroundImage == oImage) ||
                (button11.BackgroundImage == oImage && button17.BackgroundImage == oImage && button23.BackgroundImage == oImage) ||
                (button9.BackgroundImage == oImage && button13.BackgroundImage == oImage && button17.BackgroundImage == oImage) ||
                (button8.BackgroundImage == oImage && button12.BackgroundImage == oImage && button16.BackgroundImage == oImage) ||
                (button12.BackgroundImage == oImage && button18.BackgroundImage == oImage && button24.BackgroundImage == oImage) ||
                (button14.BackgroundImage == oImage && button18.BackgroundImage == oImage && button22.BackgroundImage == oImage) ||
                (button13.BackgroundImage == oImage && button17.BackgroundImage == oImage && button21.BackgroundImage == oImage) ||
                (button4.BackgroundImage == oImage && button8.BackgroundImage == oImage && button12.BackgroundImage == oImage) ||
                (button3.BackgroundImage == oImage && button7.BackgroundImage == oImage && button11.BackgroundImage == oImage) ||
                (button10.BackgroundImage == oImage && button14.BackgroundImage == oImage && button18.BackgroundImage == oImage) ||
                (button15.BackgroundImage == oImage && button19.BackgroundImage == oImage && button23.BackgroundImage == oImage) ||
                (button5.BackgroundImage == oImage && button9.BackgroundImage == oImage && button13.BackgroundImage == oImage))
            {
                EndGame();
                return;
            }


        }



        private void EndGame()
        {
            // Menampilkan pesan siapa yang menang berdasarkan enum currentPlayer
            string winner = currentPlayer == Player.X ? "Player X" : "Player O";
            MessageBox.Show($"{winner} Wins!", "Game Over");

            // Menambahkan jumlah kemenangan berdasarkan pemain saat ini
            if (currentPlayer == Player.X)
            {
                PlayerXWinCount++;
                label1.Text = $"PLAYER X Wins: {PlayerXWinCount}";
            }
            else if (currentPlayer == Player.O)
            {
                PlayerOWinCount++;
                label2.Text = $"PLAYER O Wins: {PlayerOWinCount}";
            }

            // Restart permainan
            RestartGame();
        }



        private void RestartGame()
        {
            List<Button> buttons = new List<Button> { button1, button2, button3, button4, button5, button6,
            button7, button8, button9, button10, button11, button12, button13, button14, button15, button16,
            button17, button18, button19, button20, button21, button22, button23, button24, button25 };

            foreach (Button X in buttons)
            {
                X.BackgroundImage = defaultImage;
                X.BackgroundImageLayout = ImageLayout.Stretch;
                X.Enabled = true; // Mengaktifkan tombol yang telah dinonaktifkan sebelumnya
                X.Text = ""; // Menghapus teks pada tombol
            }

            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Reset(object sender, EventArgs e)
        {
            label1.Text = "PLAYER X Wins: 0";
            label2.Text = "PLAYER O Wins: 0";
            PlayerXWinCount = 0;
            PlayerOWinCount = 0;
        }   

        private void RestartGameButton(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void LoadScore(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "XML Files (*.xml)|*.xml";
                    openFileDialog.Title = "Muat Data Skor";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Buat Baca Data XML
                        var xmlDoc = new System.Xml.XmlDocument();
                        xmlDoc.Load(openFileDialog.FileName);

                        // Buat dapetin Value dari XMLNYAH
                        var playerXWinsNode = xmlDoc.SelectSingleNode("//PlayerXWins");
                        var playerOWinsNode = xmlDoc.SelectSingleNode("//PlayerOWins");

                        if (playerXWinsNode != null && playerOWinsNode != null)
                        {
                            PlayerXWinCount = int.Parse(playerXWinsNode.InnerText);
                            PlayerOWinCount = int.Parse(playerOWinsNode.InnerText);

                            // ini buat otmatis update label form
                            label1.Text = $"PLAYER X Wins: {PlayerXWinCount}";
                            label2.Text = $"PLAYER O Wins: {PlayerOWinCount}";

                            MessageBox.Show("Skor berhasil dimuat!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Format file XML tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat skor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
