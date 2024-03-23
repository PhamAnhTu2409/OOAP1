using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleWinForm
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private List<string> animalNames = new List<string> { "cat", "dog", "duck"};
     
        public Form1()
        {
            InitializeComponent();
            InitializePictureBoxes();
            InitializeListBox();
        }

        private void InitializePictureBoxes()
        {
            pictureBox1.BackColor = Color.White;
            pictureBox2.BackColor = Color.White;
            pictureBox3.BackColor = Color.White;
        }

        private void InitializeListBox()
        {
            foreach (string name in animalNames)
            {
                listBox1.Items.Add(name);
            }
        }
            

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string name = listBox1.SelectedItem.ToString();
                DrawPet(name);
            }
        }

        public abstract class Pet
        {
            public abstract void Draw(PictureBox pictureBox, Random random);
        }
        public class Cat : Pet
        {
            public override void Draw(PictureBox pictureBox, Random random)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                Pen pen = new Pen(randomColor, 2);
                int diameter = random.Next(5, 15);
                pictureBox.CreateGraphics().DrawEllipse(pen, random.Next(0, pictureBox.Width - diameter), random.Next(0, pictureBox.Height - diameter), diameter, diameter);
                pen.Dispose();
            }
        }

        public class Dog : Pet
        {
            public override void Draw(PictureBox pictureBox, Random random)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                Pen pen = new Pen(randomColor, 2);
                int diameter = random.Next(5, 15);
                pictureBox.CreateGraphics().DrawEllipse(pen, random.Next(0, pictureBox.Width - diameter), random.Next(0, pictureBox.Height - diameter), diameter, diameter);
                pen.Dispose();
            }
        }

        public class Duck : Pet
        {
            public override void Draw(PictureBox pictureBox, Random random)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                Pen pen = new Pen(randomColor, 2);
                int diameter = random.Next(5, 15);
                pictureBox.CreateGraphics().DrawEllipse(pen, random.Next(0, pictureBox.Width - diameter), random.Next(0, pictureBox.Height - diameter), diameter, diameter);
                pen.Dispose();
            }
        }


        private void DrawPet(string name)
        {
            Pet pet = null;
            switch (name)
            {
                case "cat":
                    pet = new Cat();
                    break;
                case "dog":
                    pet = new Dog();
                    break;
                case "duck":
                    pet = new Duck();
                    break;
            }

            if (pet != null)
            {
                pet.Draw(GetPictureBoxByName(name), random);
            }
        }

        private PictureBox GetPictureBoxByName(string name)
        {
            switch (name)
            {
                case "cat":
                    return pictureBox1;
                case "dog":
                    return pictureBox2;
                case "duck":
                    return pictureBox3;
                default:
                    return null;
            }
        }
    }
}
