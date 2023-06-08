namespace fukuv0608
{
    public partial class Form1 : Form
    {
        int vx = -5;
        int vy = -5;
        string maru = "Åõ";

        public Form1()
        {
            InitializeComponent();
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
        }

        static string ChangeMaru(string a)
        {
            if (a != "Åõ")
                a = "Åõ";
            else if (a != "Åú")
                a = "Åú";

            return a;
        }
    }
}