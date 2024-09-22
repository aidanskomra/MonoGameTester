using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week3_01
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        GraphicsDeviceManager m_device;
        BasicEffect m_basicEffect;
        VertexBuffer m_vertexBuffer;

        private Matrix m_world = Matrix.Identity;
        private Matrix m_view = Matrix.Identity;
        private Matrix m_projection = Matrix.Identity;

        public Game1()
        {
            m_device = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            m_basicEffect = new BasicEffect(GraphicsDevice);

            m_world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            m_view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), Vector3.Up);
            m_projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), m_device.GraphicsDevice.Viewport.AspectRatio, 0.1f, 100f);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            VertexPositionColor[] vertices = new VertexPositionColor[8];
            vertices[0] = new VertexPositionColor(new Vector3(-0.2f, -0.2f, 0), Color.Red);
            vertices[1] = new VertexPositionColor(new Vector3(0.3f, 1.0f, 0), Color.Green);
            vertices[2] = new VertexPositionColor(new Vector3(0.4f, 0.5f, 0), Color.Blue);
            vertices[3] = new VertexPositionColor(new Vector3(0.7f, 0.8f, 0), Color.Yellow);
            vertices[4] = new VertexPositionColor(new Vector3(0.8f, 0.4f, 0), Color.Cyan);
            vertices[5] = new VertexPositionColor(new Vector3(1.0f, 0.6f, 0), Color.Magenta);
            vertices[6] = new VertexPositionColor(new Vector3(1.0f, 0.2f, 0), Color.Orange);
            vertices[7] = new VertexPositionColor(new Vector3(1.5f, 0.6f, 0), Color.Purple);


            m_vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 8, BufferUsage.WriteOnly);
            m_vertexBuffer.SetData<VertexPositionColor>(vertices);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            #region ConfigureBasicEffect
            m_basicEffect.World = m_world;
            m_basicEffect.View = m_view;
            m_basicEffect.Projection = m_projection;
            m_basicEffect.VertexColorEnabled = true;
            #endregion ConfigureBasicEffect

            #region ConfigureDevice
            GraphicsDevice.Clear(Color.Black);
            GraphicsDevice.SetVertexBuffer(m_vertexBuffer);
            #endregion ConfigureDevice

            #region Render
            foreach (EffectPass pass in m_basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawPrimitives(PrimitiveType.LineStrip, 0, 8);
            }
            base.Draw(gameTime);
            #endregion Render
        }
    }
}
