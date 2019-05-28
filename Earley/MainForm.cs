using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CFGParser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Test();
        }

        private void Test()
        {
            string[] tokens1 = { "if", "(", "var9", "==", "3", ")", "{", "string", "var5", ";", "}" };
            string[] tokens2 = { "if", "(", "var9", "<=", "3", ")", "{", "bool", "var5", "=", "var2", ";", "}" };
            string[] tokens3 = { "if", "(", "var5", ">=", "var1", ")", "{", "char", "var1", "=", "4", ";", "}" };
            string[] tokens4 = { "if", "(", "var5", "!=", "var8", ")", "{", "int", "var1", "=", "var0", "(", ")", ";", "}" };
            string[] tokens5 = { "if", "(", "var0", "<", "5", ")", "{", "double", "var7", "=", "var0", ".", "var9", "(", ")", ";", "}" };

            string[] error1 = { "var9", "==", "3", "then", "string", "var5", ";", "end" };
            string[] error2 = { "if", "var10", "<=", "3", "then", "bool", "var5", "=", "var2", ";", "end" };
            string[] error3 = { "if", "var5", ">=", "var1", "then", "char", "=", "4", ";", "end" };
            string[] error4 = { "if", "var5", "!=", "var8", "then", "int", "var1", "=", "var0", "(", ")", "end" };
            string[] error5 = { "if", "var0", "<", "5", "then", "double", "var7", "=", "var0", ".", "var9", "(", ")", ";" };

            var grammar = new AleGrammar();
            var parser = new Parser(grammar);

            Parse(tokens1, parser, false);
            Parse(tokens2, parser, false);
            Parse(tokens3, parser, false);
            Parse(tokens4, parser, false);
            Parse(tokens5, parser, false);

            Parse(error1, parser, false);
            Parse(error2, parser, false);
            Parse(error3, parser, false);
            Parse(error4, parser, false);
            Parse(error5, parser, false);
        }

        private void Parse(string[] tokens, Parser parser, bool clear)
        {
            if (clear)
                textBox1.Clear();

            var output = new StringBuilder();

            for (int i = 0; i < tokens.Length - 1; i++)
                output.Append(tokens[i] + " ");

            string sentence = output.ToString();
            textBox1.Text += "Parsing: " + sentence + "\r\n";

            bool success = parser.parseSentence(tokens);

            if (success)
                textBox1.Text += "Parse SUCCESSFUL! :D\r\n";
            else
                textBox1.Text += "Parse FAILED :(\r\n";

            Chart[] charts = parser.getCharts();
            textBox1.Text += "Charts produced by the sentence: " + sentence + "\r\n";

            for (int i = 0; i < charts.Length; i++)
            {
                textBox1.Text += "Chart[" + i.ToString() + "] :\r\n";
                textBox1.Text += charts[i].ToString() + "\r\n";
            }

            textBox1.Text += "========================================================";
            textBox1.Text += "\r\n";
            textBox1.Text += "========================================================";
            textBox1.Text += "\r\n";
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            string input = richTextBox.Text;
            string[] tokens = input.Split(null);

            var grammar = new AleGrammar();
            var parser = new Parser(grammar);

            Parse(tokens, parser, true);
        }
    }
}
