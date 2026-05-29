using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace CyberSecurityChatbot
{
    public partial class Form1 : Form
    {
        Chatbot bot = new Chatbot();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bot.SetUserName("User");
            rtbChat.AppendText("========================================\n");
            rtbChat.AppendText("     CYBER SECURITY CHATBOT 🔐\n");
            rtbChat.AppendText("========================================\n\n");

            rtbChat.AppendText("Welcome! I am your Cybersecurity Assistant.\n");
            rtbChat.AppendText("Ask me about passwords, scams, privacy or phishing.\n\n");

            
            try
            {
                string path = Path.Combine(Application.StartupPath, "greeting.wav");

                SoundPlayer player = new SoundPlayer(path);
                player.Play();
            }
            catch
            {
                rtbChat.AppendText("Voice greeting could not be loaded.\n\n");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim();

            if (input == "")
            {
                rtbChat.AppendText("Bot: Please type something.\n\n");
                return;
            }

            rtbChat.AppendText("You: " + input + "\n");

            string response = bot.GetResponse(input);

            rtbChat.AppendText("Bot: " + response + "\n\n");

            txtInput.Clear();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
