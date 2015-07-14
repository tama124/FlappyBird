using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyBird
{
    class PipeList
    {
        public List<Pipe> pipeList;
        private string _linkFile;
        private float spawn = 0;

        public PipeList(string linkFile)
        {
            pipeList = new List<Pipe>();
            _linkFile = linkFile;
        }

        private float createRandom()
        {
            Random random = new Random();
            return random.Next(-400, -50);
        }

        private void addHazard(RenderContext renderContext)
        {
            spawn += (float)renderContext.gameTime.ElapsedGameTime.TotalSeconds;
            if (spawn > 1.6)
            {
                spawn = 0;
                if (pipeList.Count < 10)
                {
                    pipeList.Add(new Pipe(_linkFile, new Vector2(createRandom(), -100), 0, 0));
                    pipeList.ElementAt(pipeList.Count - 1).loadContent(renderContext);
                }
            }
            for (int i = 0; i < pipeList.Count - 1; i++)
            {
                if (pipeList[i].isOutofScreen(renderContext))
                {
                    pipeList.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Update(RenderContext renderContext)
        {
            addHazard(renderContext);
            foreach (Pipe pipe in pipeList)
            {
                pipe.Update(renderContext);
            }
        }

        public void Draw(RenderContext renderContext)
        {
            foreach (Pipe pipe in pipeList)
            {
                pipe.Draw(renderContext);
            }
        }
    }
}
