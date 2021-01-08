using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OOP_lab5_6
{
    public partial class GuessHeirForm : IGuessForm
    {
        private ITriangle _trParent1;
        private ITriangle _trParent2;
        private ITriangle _trHeir;
        private double[] _1sidePrompts = new double[2];
        private double[] _2sidePrompts = new double[2];
        private double[] _anglePrompts = new double[2];
        private string[] _prompts = new string[3];
        private float[] _pTriangle = new float[3];
        private readonly float[] _pFirst = { 105, 105 };
        private readonly Pen _blackPen = new Pen(Color.Black, 2);
        public GuessHeirForm()
        {
            InitializeComponent();
        }
        public GuessHeirForm(ITriangle parent1, ITriangle parent2)
        {
            _trParent1 = parent1;
            _trParent2 = parent2;
            _1sidePrompts[0] = Math.Min(_trParent1.GetSide(1), _trParent2.GetSide(1));
            _1sidePrompts[1] = Math.Max(_trParent1.GetSide(1), _trParent2.GetSide(1));
            _2sidePrompts[0] = Math.Min(_trParent1.GetSide(2), _trParent2.GetSide(2));
            _2sidePrompts[1] = Math.Max(_trParent1.GetSide(2), _trParent2.GetSide(2));
            _anglePrompts[0] = Math.Min(_trParent1.GetAngle(), _trParent2.GetAngle());
            _anglePrompts[1] = Math.Max(_trParent1.GetAngle(), _trParent2.GetAngle());
            Random ran = new Random();
            int side1 = ran.Next((int)_1sidePrompts[0], (int)_1sidePrompts[1]);
            int side2 = ran.Next((int)_2sidePrompts[0], (int)_2sidePrompts[1]);
            int angle = ran.Next((int)_anglePrompts[0], (int)_anglePrompts[1]);
            _trHeir = FactoryTriangle.CreateObject(side1, side2, angle);
            InitializeComponent();
            _pTriangle[0] = _pFirst[0];
            _pTriangle[1] = _pFirst[0];
            _pTriangle[2] = _pFirst[1];
        }



        private void CheckAttempt(int[] userAttempt)
        {
            if (userAttempt[0] == _trHeir.GetSide(1) && userAttempt[1] == _trHeir.GetSide(2) && userAttempt[2] == _trHeir.GetAngle())
            {
                string info = "Количество использованных подсказок: " + _numberPrompts.ToString() + "\nКоличество попыток: " + _numberAttempt.ToString();
                MessageBox.Show(info, "Вы угадали", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            string[] attempt = new string[3];

            if (userAttempt[0] > _trHeir.GetSide(1))
                attempt[0] = "< " + userAttempt[0].ToString() + '\n';
            else if (userAttempt[0] < _trHeir.GetSide(1))
                attempt[0] = "> " + userAttempt[0].ToString() + '\n';
            else attempt[0] = "верна\n";

            if (userAttempt[1] > _trHeir.GetSide(2))
                attempt[1] = "< " + userAttempt[1].ToString() + '\n';
            else if (userAttempt[1] < _trHeir.GetSide(2))
                attempt[1] = "> " + userAttempt[1].ToString() + '\n';
            else attempt[1] = "верна\n";

            if (userAttempt[2] > _trHeir.GetAngle())
                attempt[2] = "< " + userAttempt[2].ToString() + '\n';
            else if (userAttempt[2] < _trHeir.GetAngle())
                attempt[2] = "> " + userAttempt[2].ToString() + '\n';
            else attempt[2] = "верен\n";
            labelResultsAttempt.Text = "1-я сторона " + attempt[0] + "2-сторона " + attempt[1] + "Угол " + attempt[2];


            return;
        }
        private string GetPrompts(ref double[] prompts, double rightAttempt)
        {
            double med = (prompts[1] + prompts[0]) / 2;
            if (med >= rightAttempt)
            {
                prompts[1] = med;
                return "<= " + med.ToString();
            }
            else
            {
                prompts[0] = med;
                return ">= " + med.ToString();
            }
        }

        private void GuessHeirForm_Load(object sender, EventArgs e)
        {
            _numberAttempt = 0;
            _numberPrompts = 0;

            label1SideParent1v.Text = _trParent1.GetSide(1).ToString();
            label2SideParent1v.Text = _trParent1.GetSide(2).ToString();
            labelAngleParent1v.Text = _trParent1.GetAngle().ToString();

            label1SideParent2v.Text = _trParent2.GetSide(1).ToString();
            label2SideParent2v.Text = _trParent2.GetSide(2).ToString();
            labelAngleParent2v.Text = _trParent2.GetAngle().ToString();

            //label1SideHeir.Text = _trHeir.GetSide(1).ToString();
            //label2SideHeir.Text = _trHeir.GetSide(2).ToString();
            //labelAngleHeir.Text = _trHeir.GetAngle().ToString();

            UpdateStatistics();
        }

        protected override void buttonReply_Click(object sender, EventArgs e)
        {
            int[] att = new int[3];
            try
            {
                att[0] = Convert.ToInt32(textBox1SideHeir.Text);
                att[1] = Convert.ToInt32(textBox2SideHeir.Text);
                att[2] = Convert.ToInt32(textBoxAngleHeir.Text);
                _numberAttempt++;
                CheckAttempt(att);
                float coef = Math.Max((float)att[0] / 100, (float)att[1] / 100);
                _pTriangle[0] = (float)(_pFirst[0] + att[0] / coef);
                _pTriangle[1] = (float)(_pFirst[0] + att[1] / coef * Math.Cos(Math.PI * att[2] / 180));
                _pTriangle[2] = (float)(_pFirst[1] - att[1] / coef * Math.Sin(Math.PI * att[2] / 180));
                pictureTriangleHeir.Refresh();

                UpdateStatistics();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Введите все значения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateStatistics()
        {
            labelStatistics.Text = "Количество попыток: " + _numberAttempt.ToString() + "\nКоличество использованных подсказок: " + _numberPrompts.ToString();
        }

        protected override void buttonGetPrompted_Click(object sender, EventArgs e)
        {
            switch (_numberPrompts % 3)
            {
                case 0:
                    _prompts[0] = "1-я сторона " + GetPrompts(ref _1sidePrompts, _trHeir.GetSide(1));
                    break;
                case 1:
                    _prompts[1] = "\n2-я сторона " + GetPrompts(ref _2sidePrompts, _trHeir.GetSide(2));
                    break;
                case 2:
                    _prompts[2] = "\nУгол " + GetPrompts(ref _anglePrompts, _trHeir.GetAngle());
                    break;
            }
            labelPrompts.Text = _prompts[0] + _prompts[1] + _prompts[2];
            _numberPrompts++;
            UpdateStatistics();
        }

        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void pictureTriangleHeir_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_blackPen, _pFirst[0], _pFirst[1], _pTriangle[0], _pFirst[1]);
            e.Graphics.DrawLine(_blackPen, _pTriangle[0], _pFirst[1], _pTriangle[1], _pTriangle[2]);
            e.Graphics.DrawLine(_blackPen, _pTriangle[1], _pTriangle[2], _pFirst[0], _pFirst[1]);

        }
    }
}