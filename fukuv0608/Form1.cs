using System.Windows.Forms.VisualStyles;

namespace fukuv0608
{
    public partial class Form1 : Form
    {
        int vx = -5;
        int vy = -5;
        string maru = "��";
        int timerCount = 0;
        
        static Random rand = new Random();
        

        public Form1()
        {
            InitializeComponent();

            label1.Left = rand.Next(ClientSize.Width);
            label1.Top = rand.Next(ClientSize.Height);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label1.Text = "Sekioka Hikaru";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left += vx;
            label1.Top += vy;
            label1.Text = maru;

            if (label1.Left <= 0)
            {
                vx = Math.Abs(vx + (vx / 10));
                maru = Form1.ChangeMaru(maru);

            }
            if (label1.Right >= ClientSize.Width)
            {
                vx = -Math.Abs(vx + (vx / 10));
                maru = Form1.ChangeMaru(maru);
            }
            if (label1.Top <= 0)
            {
                vy = Math.Abs(vy + (vy / 10));
                maru = Form1.ChangeMaru(maru);
            }
            if (label1.Bottom >= ClientSize.Height)
            {
                vy = -Math.Abs(vy + (vy / 10));
                maru = Form1.ChangeMaru(maru);
            }

            //�ϐ�mpos��錾���āA�}�E�X�̃t�H�[�����W�����o��
            //// 1. MousePosition�Ƀ}�E�X���W�����X�N���[�����W�����X�AY�������Ă���
            Text = $"{MousePosition.X} {MousePosition.Y}";

            //// 2. �ϐ�fpos��錾���āAPointToClient()�ŃX�N���[�����W���t�H�[�����W�ɕϊ�
            var fpos = PointToClient(MousePosition);


            // ���x���ɍ��W��\��
            ////�ϊ������t�H�[�����W�́Afpos.X�Afpos.Y�Ŏ��o����
            //label1.Text = $"{fpos.X} {fpos.Y}";

            // label2.Width�Ń��x���̕�
            // label2.Height�Ń��x���̍���
            // �}�E�X�J�[�\���̈ʒu��label2�̒����ɂȂ�悤�ɂ���
            label2.Left = fpos.X - label2.Width / 2;
            label2.Top = fpos.Y - label2.Height / 2;

            // �����蔻��
            if ((fpos.X > label1.Left) && (fpos.X < label1.Right) && (fpos.Y > label1.Top) && (fpos.Y < label1.Bottom))
            {
                timer1.Enabled = false;
            }

            timerCount++;
            label3.Text = timerCount.ToString();
        }

        static string ChangeMaru(string a)
        {
            if (a != "��")
                a = "��";
            else if (a != "��")
                a = "��";

            return a;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}