using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_lab5_6
{
    public partial class FormEnterParents : Form
    {
        private readonly float[] _pFirst = { 105, 105 };
        private float[] _pTriangle1 = new float[3];
        private float[] _pTriangle2 = new float[3];
        private readonly Pen _blackPen = new Pen(Color.Black, 2);
        private int[] _tr1 = new int[3];
        private int[] _tr2 = new int[3];
        public FormEnterParents()
        {
            InitializeComponent();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Tutorial f = new Tutorial();
            f.ShowDialog();
        }
        private void buttonCreateHeir_Click(object sender, EventArgs e)
        {
            try
            {
                GuessHeirForm g = new GuessHeirForm(FactoryTriangle.CreateObject(_tr1[0], _tr1[1], _tr1[2]), FactoryTriangle.CreateObject(_tr2[0], _tr2[1], _tr2[2]));
                //Hide();
                //Application.Run(new GuessHeirForm(FactoryTriangle.CreateObject(_tr1[0], _tr1[1], _tr1[2]), FactoryTriangle.CreateObject(_tr2[0], _tr2[1], _tr2[2])));
                g.ShowDialog();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_blackPen, _pFirst[0], _pFirst[1], _pTriangle2[0], _pFirst[1]);
            e.Graphics.DrawLine(_blackPen, _pTriangle2[0], _pFirst[1], _pTriangle2[1], _pTriangle2[2]);
            e.Graphics.DrawLine(_blackPen, _pTriangle2[1], _pTriangle2[2], _pFirst[0], _pFirst[1]);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_blackPen, _pFirst[0], _pFirst[1], _pTriangle1[0], _pFirst[1]);
            e.Graphics.DrawLine(_blackPen, _pTriangle1[0], _pFirst[1], _pTriangle1[1], _pTriangle1[2]);
            e.Graphics.DrawLine(_blackPen, _pTriangle1[1], _pTriangle1[2], _pFirst[0], _pFirst[1]);
        }
        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void SetTrSide(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text != "")
            {
                ref int side = ref _tr1[0];
                try
                {
                    int val = Convert.ToInt32(text.Text);
                    switch ((string)text.Name)
                    {
                        case "textBox1SideParent1":
                            break;
                        case "textBox2SideParent1":
                            side = ref _tr1[1];
                            break;
                        case "textBoxAngleParent1":
                            side = ref _tr1[2];
                            if (val <= 0 || val >= 180)
                                throw new Exception("Угол должен быть больше 0 и меньше 180");
                            break;
                        case "textBox1SideParent2":
                            side = ref _tr2[0];
                            break;
                        case "textBox2SideParent2":
                            side = ref _tr2[1];
                            break;
                        case "textBoxAngleParent2":
                            side = ref _tr2[2];
                            if (val <= 0 || val >= 180)
                                throw new Exception("Угол должен быть больше 0 и меньше 180");
                            break;
                        default:
                            throw new Exception("Объекта не существует");
                    }
                    side = val;
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Некорректный ввод", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    text.Clear();
                    side = 0;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text.Clear();
                    side = 0;
                }
                finally
                {
                    SetPoints();
                }
            }
        }

        private void SetPoints()
        {
            float coef = Math.Max((float)_tr1[0] / 100, (float)_tr1[1] / 100);
            _pTriangle1[0] = (float)(_pFirst[0] + _tr1[0] / coef);
            _pTriangle1[1] = (float)(_pFirst[0] + _tr1[1] / coef * Math.Cos(Math.PI * _tr1[2] / 180));
            _pTriangle1[2] = (float)(_pFirst[1] - _tr1[1] / coef * Math.Sin(Math.PI * _tr1[2] / 180));

            coef = Math.Max((float)_tr2[0] / 100, (float)_tr2[1] / 100);
            _pTriangle2[0] = (float)(_pFirst[0] + _tr2[0] / coef);
            _pTriangle2[1] = (float)(_pFirst[0] + _tr2[1] / coef * Math.Cos(Math.PI * _tr2[2] / 180));
            _pTriangle2[2] = (float)(_pFirst[1] - _tr2[1] / coef * Math.Sin(Math.PI * _tr2[2] / 180));

            pictureTriangleParent1.Refresh();
            pictureTriangleParent2.Refresh();
        }

        private void FormEnterParents_Load(object sender, EventArgs e)
        {
            SetPoints();
        }
    }
}