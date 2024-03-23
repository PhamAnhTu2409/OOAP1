using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private string[] itemsArray;
        public Form1()
        {
            InitializeComponent();
            InitializePictureBoxes();

        }
        
        private void InitializePictureBoxes()
        {
            pictureBox1.BackColor = Color.White;
            pictureBox2.BackColor = Color.White;
            pictureBox3.BackColor = Color.White;

        }

        private void button3_Click(object sender, EventArgs e)//Create
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an item from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name = listBox1.SelectedItem.ToString();
            DrawPet(name);
            
        }

        private int nextIndex = 0;
        private void button1_Click(object sender, EventArgs e)//Basic
        {
            string name = listBox1.Items[nextIndex].ToString();
            DrawPet(name);
            label1.Text = "Pet Draw: " + name;
            nextIndex++;
            if (nextIndex >= listBox1.Items.Count)
            {
                nextIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)//Random
        {
            int index = random.Next(itemsArray.Length);
            string name = itemsArray[index];
            DrawPet(name);
            label1.Text = "Pet Draw: " + name;
        }

        private void button4_Click(object sender, EventArgs e)//Add new pet
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
            UpdateItemsArray();
            pictureBox4.BackColor = Color.White;
            
        }

        private void UpdateItemsArray()
        {
            itemsArray = new string[listBox1.Items.Count];
            listBox1.Items.CopyTo(itemsArray, 0);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateItemsArray();
        }

        public interface IPet //Interface
        {
            void Draw(PictureBox pictureBox, Random random);
        }
        public class Cat : IPet
        {
            public virtual void Draw(PictureBox pictureBox, Random random)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                Pen pen = new Pen(randomColor, 2);
                int diameter = random.Next(5, 15);
                pictureBox.CreateGraphics().DrawEllipse(pen, random.Next(0, pictureBox.Width - diameter), random.Next(0, pictureBox.Height - diameter), diameter, diameter);
                pen.Dispose();
            }
        }

        public class Dog : IPet
        {
            public virtual void Draw(PictureBox pictureBox, Random random)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                Pen pen = new Pen(randomColor, 2);
                int diameter = random.Next(5, 15);
                pictureBox.CreateGraphics().DrawEllipse(pen, random.Next(0, pictureBox.Width - diameter), random.Next(0, pictureBox.Height - diameter), diameter, diameter);
                pen.Dispose();
            }
        }

        public class Duck : IPet
        {
            public virtual void Draw(PictureBox pictureBox, Random random)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                Pen pen = new Pen(randomColor, 2);
                int diameter = random.Next(5, 15);
                pictureBox.CreateGraphics().DrawEllipse(pen, random.Next(0, pictureBox.Width - diameter), random.Next(0, pictureBox.Height - diameter), diameter, diameter);
                pen.Dispose();//implement
            }
        }
        public class CustomPet : IPet
        {
            public virtual void Draw(PictureBox pictureBox, Random random)
            {
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                Pen pen = new Pen(randomColor, 2);
                int diameter = random.Next(5, 15);
                pictureBox.CreateGraphics().DrawEllipse(pen, random.Next(0, pictureBox.Width - diameter), random.Next(0, pictureBox.Height - diameter), diameter, diameter);
                pen.Dispose();
            }
        }
        public static class PetFactory /// Factory
        {
            public static IPet CreatePet(string name)
            {
                switch (name)
                {
                    case "cat":
                        return new Cat();
                    case "dog":
                        return new Dog();
                    case "duck":
                        return new Duck();
                    default:
                        return new CustomPet();
                }
            }
        }

        private void DrawPet(string name)
        {
            IPet pet = PetFactory.CreatePet(name);
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
                    return pictureBox4;
            }
        }

    }
}
