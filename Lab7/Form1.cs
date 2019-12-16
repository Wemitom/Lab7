using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Румянцев Владислав, Лабораторная работа №7
//11. Автомобиль, поезд, транспортное средство, экспресс

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Car g_car = new Car(0, "Audi", 60);
        static Train g_train = new Train(0, 250, 100);
        static Express g_express = new Express(0, 3000, 0, 150);

        static int stopIndexTrain, stopIndexExpress;

        // Активируется по нажатию клавиши при наборе в textBox
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if (comboBox1.SelectedItem.ToString() == "Скорость")
                    {
                        if (Convert.ToInt32(textBox4.Text) > 0)
                            g_car.Speed = Convert.ToInt32(textBox2.Text);
                        else
                            MessageBox.Show("Скорость должны быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Выберите пункт в меню!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неверный формат данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Выберите пункт в меню!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if (comboBox1.SelectedItem.ToString() == "Скорость")
                    {
                        if (Convert.ToInt32(textBox4.Text) > 0)
                            g_train.Speed = Convert.ToInt32(textBox3.Text);
                        else
                            MessageBox.Show("Скорость должны быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Остановка")
                    {
                        g_train.AddAStop(textBox3.Text);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неверный формат данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Выберите пункт в меню!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if (comboBox1.SelectedItem.ToString() == "Скорость")
                    {
                        if (Convert.ToInt32(textBox4.Text) > 0)
                            g_express.Speed = Convert.ToInt32(textBox4.Text);
                        else
                            MessageBox.Show("Скорость должны быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Цена билета")
                    {
                        if (Convert.ToInt32(textBox4.Text) > 0)
                            g_express.TicketCost = Convert.ToInt32(textBox4.Text);
                        else
                            MessageBox.Show("Цена должны быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Остановка")
                    {
                        g_express.AddAStop(textBox4.Text);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неверный формат данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Выберите пункт в меню!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Смена изменяемого значения
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Скорость")
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            else if(comboBox1.SelectedItem.ToString() == "Цена билета")
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else if (comboBox1.SelectedItem.ToString() == "Остановка")
            {
                textBox2.Enabled = false;
                textBox3.Enabled = true;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // изменения интерфейса машины
            label2.Text = g_car.GetVehicleType();
            label14.Text = g_car.CarBrand;
            if (g_car.IsEmpty())
                g_car.Speed = 0;
            if (g_car.IsMoving())
            {
                label16.Text = "Движется";
                g_car.FuelDecrease();
            }
            else
                label16.Text = "На месте";
            if (g_car.BlinkersLeft(1))
                label15.Text = "Влево";
            else if (g_car.BlinkersRight(1))
                label15.Text = "Направо";
            else if (g_car.BlinkersOff(1))
                label15.Text = "Выкл.";
            label17.Text = g_car.Speed.ToString() + " км/ч";
            label33.Text = g_car.GetFuel().ToString();

            // изменение интерфейса поезда
            if (g_train.Path.Count != 0)
            {
                label28.Text = g_train.Path[stopIndexTrain];
                button5.Enabled = true;
            }
            else
                button5.Enabled = false;
            if (stopIndexTrain == 0)
                button4.Enabled = false;
            else
                button4.Enabled = true;
            if (stopIndexTrain == g_train.Path.Count - 1 || (stopIndexTrain == g_train.Path.Count && g_train.Path.Count == 0))
                button6.Enabled = false;
            else
                button6.Enabled = true;
            label3.Text = g_train.GetVehicleType();
            label22.Text = g_train.Capacity.ToString();
            if (g_train.IsEmpty())
                g_train.Speed = 0;
            if (g_train.IsMoving())
            {
                label20.Text = "Движется";
                g_train.FuelDecrease();
            }
            else
                label20.Text = "На месте";
            label18.Text = g_train.Speed.ToString() + " км/ч";
            label34.Text = g_train.GetFuel().ToString();

            // Изменение интерфейса эксперсса
            if (g_express.Path.Count != 0)
            {
                label29.Text = g_express.Path[stopIndexExpress];
                button8.Enabled = true;
            }
            else
                button8.Enabled = false;
            if (stopIndexExpress == 0)
                button7.Enabled = false;
            else
                button7.Enabled = true;
            if (stopIndexExpress == g_express.Path.Count - 1 || (stopIndexExpress == g_express.Path.Count && g_express.Path.Count == 0))
                button9.Enabled = false;
            else
                button9.Enabled = true;
            if (g_express.Path.Count != 0)
                label28.Text = g_train.Path[stopIndexExpress];
            label4.Text = g_express.GetVehicleType();
            label23.Text = g_express.Capacity.ToString();
            label25.Text = g_express.TicketCost.ToString();
            if (g_express.IsEmpty())
                g_express.Speed = 0;
            if (g_express.IsMoving())
            {
                label21.Text = "Движется";
                g_express.FuelDecrease();
            }
            else
                label21.Text = "На месте";
            label19.Text = g_express.Speed.ToString() + " км/ч";
            label35.Text = g_express.GetFuel().ToString();
        }

        // Переключение поворотников
        private void Button1_Click(object sender, EventArgs e)
        {
            g_car.BlinkersLeft(0);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            g_car.BlinkersOff(0);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            g_car.BlinkersRight(0);
        }

        // Переключение между остановками
        private void Button4_Click(object sender, EventArgs e)
        {
            stopIndexTrain--;
        }
        
        // Удаление остановки
        private void Button5_Click(object sender, EventArgs e)
        {
            g_train.RemoveAStop(g_train.Path[stopIndexTrain]);
            if (stopIndexTrain != 0) stopIndexTrain--;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            stopIndexTrain++;
        }
         
        // Заправка
        private void Button10_Click(object sender, EventArgs e)
        {
            g_car.Refuel();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            g_train.Refuel();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            g_express.Refuel();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            stopIndexExpress--;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            g_train.RemoveAStop(g_express.Path[stopIndexExpress]);
            if (stopIndexExpress != 0) stopIndexExpress--;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            stopIndexExpress++;
        }
    }
}
