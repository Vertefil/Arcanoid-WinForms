namespace WinFormsGame
{
    public partial class Form1 : Form
    {
        MapController map;
        Player player;
        Physics physics;
        //LabelScore
        public Label scoreLabel;
        public Label livesLabel;



        public Form1()
        {
            InitializeComponent();
            //ScoreLabel init
            scoreLabel = new Label();
            scoreLabel.Location = new Point((MapController.mapWidth) * 20 + 6, 50);

            livesLabel = new Label();
            livesLabel.Location = new Point((MapController.mapWidth) * 20 + 6, 100);

            this.Controls.Add(scoreLabel);
            this.Controls.Add(livesLabel);
            timer1.Tick += new EventHandler(update);
            this.KeyUp += new KeyEventHandler(inputCheck);

            Init();
        }
        //Calculating
        private void update(object? sender, EventArgs e)
        {
            if ((player.ballY + player.vecY) > MapController.mapHeight - 1)
            {
                player.lives--;
                if (player.lives == 0)
                {
                    Init();
                }
                else Continue();


            }

            map.map[player.ballY, player.ballX] = 0;
            //ball move
            if (!physics.IsCollide(player, map, scoreLabel))
                player.ballX += player.vecX;
            if (!physics.IsCollide(player, map, scoreLabel))
                player.ballY += player.vecY;
            map.map[player.ballY, player.ballX] = 8;

            map.map[player.platY, player.platX] = 9;
            map.map[player.platY, player.platX + 1] = 99;
            map.map[player.platY, player.platX + 2] = 999;

            Invalidate();
        }

        public void Continue()
        {
            timer1.Interval = 90;
            scoreLabel.Text = "Score: " + player.score;
            livesLabel.Text = "Lives: " + player.lives;
            //Platform init
            map.map[player.platY, player.platX] = 9;
            //No double painting, 99 - part of plat
            map.map[player.platY, player.platX + 1] = 99;
            map.map[player.platY, player.platX + 2] = 999;
            map.map[player.ballY, player.ballX] = 0;

            //Ball init
            player.ballY = player.platY - 1;
            player.ballX = player.platX + 1;

            map.map[player.ballY, player.ballX] = 8;

            player.vecX = 1;
            player.vecY = -1;

            timer1.Start();
        }


        public void GenerateBricks()
        {
            Random r = new Random();
            for (int i = 0; i < (MapController.mapHeight - 1) / 3; i++)
            {
                for (int j = 0; j < MapController.mapWidth; j += 2)
                {
                    int currBrick = r.Next(1, 5);
                    map.map[i, j] = currBrick;
                    map.map[i, j + 1] = currBrick + currBrick * 10;
                }
            }
        }

        //Inititalization all game
        public void Init()
        {
            map = new MapController();
            player = new Player();
            physics = new Physics();
            this.Width = (MapController.mapWidth + 10) * 20;
            this.Height = (MapController.mapHeight + 2) * 20;

            timer1.Interval = 90;
            player.score = 0;
            player.lives = 5;
            scoreLabel.Text = "Score: " + player.score;
            livesLabel.Text = "Lives: " + player.lives;

            //Clear form
            for (int i = 0; i < MapController.mapHeight; i++)
            {
                for (int j = 0; j < MapController.mapWidth; j++)
                {
                    map.map[i, j] = 0;

                }
            }

            player.platX = (MapController.mapWidth - 1) / 2;
            player.platY = MapController.mapHeight - 1;

            //Platform init
            map.map[player.platY, player.platX] = 9;
            //No double painting, 99 - part of plat
            map.map[player.platY, player.platX + 1] = 99;
            map.map[player.platY, player.platX + 2] = 999;

            //Ball init
            player.ballY = player.platY - 1;
            player.ballX = player.platX + 1;
            map.map[player.ballY, player.ballX] = 8;
            player.vecX = 1;
            player.vecY = -1;

            GenerateBricks();

            timer1.Start();
        }

        //KeysUpsEvents move plat
        private void inputCheck(object? sender, KeyEventArgs e)
        {
            //Erasing old plat
            map.map[player.platY, player.platX] = 0;
            map.map[player.platY, player.platX + 1] = 0;
            map.map[player.platY, player.platX + 2] = 0;
            //Moving
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (player.platX + 2 < MapController.mapWidth - 1)
                        player.platX++;
                    break;
                case Keys.Left:
                    if (player.platX > 0)
                        player.platX--;
                    break;
            }
            //Get back id plat
            map.map[player.platY, player.platX] = 9;
            map.map[player.platY, player.platX + 1] = 99;
            map.map[player.platY, player.platX + 2] = 999;
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            map.DrawMap(e.Graphics);
            map.DrawArea(e.Graphics);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush eB = new SolidBrush(Color.Black);
            Pen mP = new Pen(Color.PaleVioletRed, 6);
            e.Graphics.FillEllipse(eB, 0, 10, 40, 40);
            e.Graphics.FillEllipse(eB, 80, 10, 40, 40);
            e.Graphics.DrawLine(mP, 10, 80, 110, 80);

        }
    }
}