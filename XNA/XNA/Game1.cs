using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Runtime.InteropServices;
using ManagedSteam;
using System.Text;
using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Exceptions;
using System.Net;

namespace XNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        private Steam steam;
        private ServicesGameServer GameServer;
        private KeyboardState oldKeyboard;
        private Color clearColor = Color.CornflowerBlue;
        //public uint myIp = (uint)BitConverter.ToInt32(IPAddress.Parse("129.168.22.23").GetAddressBytes(), 0);
        public uint myIp = 0x00000000;
        public string GameServerVersion = "1.0.0.0";
        public string statusMessage = "";

        //public ChatEntryType myChatEntry = ChatEntryType.ChatMsg;
        public ServerMode myServermode = ServerMode.eServerModeNoAuthentication;

        public Game1()
        {
            try
            {
                steam = Steam.Initialize();
                statusMessage = "Steamworks initialized and ready to use!";
            }
            catch (SteamInitializeFailedException e)
            {
                statusMessage = e.Message;
            }
            catch (SteamInterfaceInitializeFailedException e)
            {
                statusMessage = e.Message;
            }
            catch (DllNotFoundException e)
            {
                statusMessage = e.Message;
            }


            graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            if (steam != null)
            {
                GameServer = ServicesGameServer.Initialize(myIp, 8766, 27015, 27016, myServermode, GameServerVersion);

                MatchmakingServerList responseObject = new MatchmakingServerList();
                MatchMakingKeyValuePair[] filter = new MatchMakingKeyValuePair[2];
                filter[0] = new MatchMakingKeyValuePair("TestKey0", "TestValue0Â‰ˆı");
                filter[1] = new MatchMakingKeyValuePair("TestKey1", "TestValue1≈ƒ÷’");
                steam.MatchmakingServers.RequestInternetServerList(steam.AppID, filter, responseObject);

                steam.Friends.GameOverlayActivated += GameOverlayToggle;
                steam.Utils.SteamShutdown += SteamShutdownFunc;
            }

            base.Initialize();
        }

        //Steam is shutting down, do whatever you need to do, and then shut down.
        private void SteamShutdownFunc(SteamShutdown value)
        {    
            steam.Shutdown();
            GameServer.Shutdown();

            this.Exit();
        }

        private void GameOverlayToggle(GameOverlayActivated value)
        {
            if (value.Active)
            {
                clearColor = Color.OrangeRed;
                Console.WriteLine("Overlay activated");
            }
            else
            {
                clearColor = Color.LawnGreen;
                Console.WriteLine("Overlay closed");
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("MainFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (steam != null)
                steam.Update();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboard.IsKeyDown(Keys.Escape))
            {
                if (steam != null)
                    steam.Shutdown();

                this.Exit();
                return;
            }

            if (keyboard.IsKeyDown(Keys.Space) && oldKeyboard.IsKeyUp(Keys.Space))
            {
                if (steam != null)
                {
                    bool testbool = false;
                    GameServer.GameServerStats.GetUserAchievement(steam.User.GetSteamID(), "Pop", out testbool);
                }

                base.Update(gameTime);
                oldKeyboard = keyboard;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(clearColor);
            spriteBatch.Begin();
            
            spriteBatch.DrawString(spriteFont, statusMessage, new Vector2(10.0f, 10.0f), Color.Black);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }


    class MatchmakingServerList : MatchmakingServerListResponse
    {
        private int respondCount = 0;
        private int failedCount = 0;

        protected override void ServerResponded(ServerListRequestHandle request, int server)
        {
            //Console.WriteLine("ServerResponded: request " + request + " server " + server);
            ++respondCount;
        }

        protected override void ServerFailedToRespond(ServerListRequestHandle request, int server)
        {
            //Console.WriteLine("ServerFailedToRespond: request " + request + " server " + server);
            ++failedCount;
        }

        protected override void RefreshComplete(ServerListRequestHandle request, MatchMakingServerResponse response)
        {
            Console.WriteLine("RefreshComplete: request " + request + " response " + response +
                " respondCount " + respondCount + " failedCount " + failedCount);
        }
    }
}
