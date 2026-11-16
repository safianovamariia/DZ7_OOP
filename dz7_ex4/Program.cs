using System;

namespace ChristmasTreeDecorator
{
    class MainApp
    {
        static void Main()
        {
            ChristmasTree tree = new ChristmasTree();

            Console.WriteLine("1) Simple tree:");
            tree.Show();

            Decorations decorations = new Decorations(10, "red", "gold star");
            decorations.SetComponent(tree);

            Console.WriteLine();
            Console.WriteLine("2) Tree with decorations:");
            decorations.Show();

            Garland garland = new Garland("yellow");
            garland.SetComponent(tree);

            Console.WriteLine();
            Console.WriteLine("3) Tree with garland:");
            garland.Show();

            Garland garland2 = new Garland("blue");
            garland2.SetComponent(decorations);

            Console.WriteLine();
            Console.WriteLine("4) Tree with decorations and garland:");
            garland2.Show();

            Console.Read();
        }
    }

    abstract class Tree
    {
        public abstract void Show();
    }

    class ChristmasTree : Tree
    {
        public override void Show()
        {
            Console.WriteLine("Christmas tree");
        }
    }

    abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        public void SetComponent(Tree tree)
        {
            this.tree = tree;
        }

        public override void Show()
        {
            if (tree != null)
            {
                tree.Show();
            }
        }
    }

    class Decorations : TreeDecorator
    {
        private int ballsCount;
        private string ballsColor;
        private string topper;

        public Decorations(int ballsCount, string ballsColor, string topper)
        {
            this.ballsCount = ballsCount;
            this.ballsColor = ballsColor;
            this.topper = topper;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("  + decorations: {0} {1} balls, {2} on the top", ballsCount, ballsColor, topper);
        }
    }

    class Garland : TreeDecorator
    {
        private string lightsColor;

        public Garland(string lightsColor)
        {
            this.lightsColor = lightsColor;
        }

        public override void Show()
        {
            base.Show();
            Glow();
        }

        public void Glow()
        {
            Console.WriteLine("  + garland: the tree is glowing with {0} lights", lightsColor);
        }
    }
}