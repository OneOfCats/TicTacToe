using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public delegate float[] logicFunction1(float a);
    public delegate float[] logicFunction2(float a, float b);

    public partial class Form1 : Form
    {
        TicTacToe Game;
        Button[] buttons;
        Network NeuralNetwork;
        logicFunction2 function2Delegate = new logicFunction2(logicFunctions.logicOr);
        interfaceNetworkGame ifc;

        public Form1()
        {
            InitializeComponent();
            buttons = new Button[9] { this.field0, this.field1, this.field2, this.field3, this.field4, this.field5, this.field6, this.field7, this.field8 };
            Game = new TicTacToe(this);
            this.NeuralNetwork = new Network(30, 2, 18, 9);
            ifc = new interfaceNetworkGame(this.Game, this.NeuralNetwork);
        }

        public float[][] generateInputs()
        {
            float[][] inputs = new float[24][];
            inputs[0] = new float[18] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[1] = new float[18] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[2] = new float[18] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[3] = new float[18] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[4] = new float[18] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[5] = new float[18] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[6] = new float[18] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[7] = new float[18] { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[8] = new float[18] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[9] = new float[18] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[10] = new float[18] { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[11] = new float[18] { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[12] = new float[18] { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[13] = new float[18] { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[14] = new float[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[15] = new float[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
            inputs[16] = new float[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            inputs[17] = new float[18] { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[18] = new float[18] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[19] = new float[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 };
            inputs[20] = new float[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 };
            inputs[21] = new float[18] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            inputs[22] = new float[18] { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            inputs[23] = new float[18] { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return inputs;
        }

        public float[][] generateOutputs()
        {
            float[][] outputs = new float[24][];
            outputs[0] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[1] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[2] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[3] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[4] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[5] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[6] = new float[9] { 0, 0, 1, 0, 0, 0, 0, 0, 0 };
            outputs[7] = new float[9] { 0, 0, 0, 0, 0, 0, 1, 0, 0 };
            outputs[8] = new float[9] { 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            outputs[9] = new float[9] { 0, 0, 0, 0, 0, 0, 1, 0, 0 };
            outputs[10] = new float[9] { 0, 0, 1, 0, 0, 0, 0, 0, 0 };
            outputs[11] = new float[9] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            outputs[12] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[13] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[14] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[15] = new float[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            outputs[16] = new float[9] { 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            outputs[17] = new float[9] { 0, 0, 1, 0, 0, 0, 0, 0, 0 };
            outputs[18] = new float[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            outputs[19] = new float[9] { 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            outputs[20] = new float[9] { 0, 0, 0, 0, 0, 0, 1, 0, 0 };
            outputs[21] = new float[9] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            outputs[22] = new float[9] { 0, 0, 0, 1, 0, 0, 0, 0, 0 };
            outputs[23] = new float[9] { 0, 0, 0, 0, 0, 0, 0, 1, 0 };
            return outputs;
        }

        public void clearField(char check) //Очистка поля, если кто-то победил
        {
            if (check == 'T') return;
            if (Game.winLine[0] != -1)
            {
                buttons[Game.winLine[0]].BackColor = buttons[Game.winLine[1]].BackColor = buttons[Game.winLine[2]].BackColor = System.Drawing.Color.FromArgb(255, 241, 26, 119);
                Game.winLine[0] = Game.winLine[1] = Game.winLine[2] = -1;
            }
            this.field0.Text = this.field1.Text = this.field2.Text = this.field3.Text = this.field4.Text = this.field5.Text = this.field6.Text = this.field7.Text = this.field8.Text = "";
            if (check == 'X')
                this.winsXLabel.Text = Game.wins[0].ToString();
            else if (check == 'O')
                this.winsOLabel.Text = Game.wins[1].ToString();
            else
                this.winsNLabel.Text = Game.wins[2].ToString();
        }

        public void buttonEvent(object sender) //Обработка нажатия на кнопку
        {
            if ((sender as Button).Text.Length != 0) return;
            (sender as Button).Text = Game.currentTurn.ToString();
            clearField(Game.makeTurn(Array.IndexOf(this.buttons, sender))); //Вызов метода выполнения хода и передача результата в метод очистки поля
        }

        private void changeBack(object sender, EventArgs e)
        {
            buttons[Game.winLine[0]].BackColor = buttons[Game.winLine[1]].BackColor = buttons[Game.winLine[2]].BackColor = System.Drawing.Color.FromArgb(255, 176, 92, 107);
        }

        private void field0_Click(object sender, EventArgs e)
        {
            buttonEvent(sender);
        }

        private void field1_Click(object sender, EventArgs e)
        {
            buttonEvent(sender);
        }

        private void field2_Click(object sender, EventArgs e)
        {
            buttonEvent(sender);
        }

        private void field3_Click(object sender, EventArgs e)
        {
            buttonEvent(sender);
        }

        private void field4_Click(object sender, EventArgs e)
        {
            buttonEvent(sender);
        }

        private void field5_Click(object sender, EventArgs e)
        {
            buttonEvent(sender);
        }

        private void field6_Click(object sender, EventArgs e)
        {
            buttonEvent(sender);
        }

        private void field7_Click(object sender, EventArgs e)
        {
            buttonEvent(sender);
        }

        private void field8_Click(object sender, EventArgs e)
        {
            buttonEvent(sender);
        }

        private void networkCountButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
                this.NeuralNetwork.inputData[0] = float.Parse(textBox1.Text);
            else
                this.NeuralNetwork.inputData[0] = 0;
            if (textBox2.Text.Length != 0)
                this.NeuralNetwork.inputData[1] = float.Parse(textBox2.Text);
            else
                this.NeuralNetwork.inputData[1] = 0;
            float[] result = this.NeuralNetwork.launchNetwork();
            this.labelAnswer.Text = result[0].ToString();
        }

        private void teachButton_Click(object sender, EventArgs e)
        {
            int[] output = this.NeuralNetwork.learnFunction(function2Delegate, "BP");
            this.labelTrue.Text = output[0].ToString();
            this.labelFalse.Text = output[1].ToString();
            this.labelTrueChain.Text = output[2].ToString();
        }

        private void saveNetwork_Click(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(Network));
            System.IO.StreamWriter myWriter = new System.IO.StreamWriter("serializedNetwork.xml");
            mySerializer.Serialize(myWriter, this.NeuralNetwork);
            myWriter.Close();
        }

        private void loadNetwork_Click(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(Network));
            System.IO.FileStream myFileStream = new System.IO.FileStream("serializedNetwork.xml", System.IO.FileMode.Open);
            this.NeuralNetwork = (Network)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
        }

        private void networkTurnButton_Click(object sender, EventArgs e)
        {
            int result = ifc.makeTurn();
            if (result != -1)
            {
                this.buttons[result].Text = Game.currentTurn == 'X' ? "O" : "X";
                netErrorLabel.Text = "0";
            }
            else
            {
                netErrorLabel.Text = "1";
            }
        }

        private void teachGameButton_Click(object sender, EventArgs e)
        {
            float[][] inputs = generateInputs();
            float[][] outputs = generateOutputs();
            int[] answers = NeuralNetwork.learnArrays(inputs, outputs, 3000);
        }
        
    }

    class TicTacToe
    {
        public char currentTurn; //Кто ходит сейчас: 'X' - крстики, 'O' - нолики
        public string turnsLine; //Массив ходов: 'X' - крстики, 'O' - нолики, 'N' - пусто
        public int[] wins; //Победы: 0 - крестики, 1 - нолики, 2 - ничьи
        public bool animation; //Включена или выключена анимация
        public int[] winLine;
        public Form myForm;

        public TicTacToe(Form thisForm)
        {
            this.myForm = thisForm;
            this.wins = new int[3] { 0, 0, 0 };
            this.winLine = new int[3] { -1, -1, -1 };
            this.initialize();
            this.animation = true;
        }

        public void initialize()
        {
            this.turnsLine = "NNNNNNNNN";
            this.currentTurn = 'X';
        }

        public char checkWin() //'X' - победа крестиков, 'O' - победа ноликов, 'N' - ничья, 'T' - игра продолжается
        {
            if (this.turnsLine[0] == this.turnsLine[1] && this.turnsLine[0] == this.turnsLine[2] && this.turnsLine[0] != 'N')
            {
                winLine[0] = 0; winLine[1] = 1; winLine[2] = 2;
                return this.turnsLine[0];
            }
            else if(this.turnsLine[3] == this.turnsLine[4] && this.turnsLine[3] == this.turnsLine[5] && this.turnsLine[3] != 'N')
            {
                winLine[0] = 3; winLine[1] = 4; winLine[2] = 5;
                return this.turnsLine[3];
            }
            else if(this.turnsLine[6] == this.turnsLine[7] && this.turnsLine[6] == this.turnsLine[8] && this.turnsLine[6] != 'N')
            {
                winLine[0] = 6; winLine[1] = 7; winLine[2] = 8;
                return this.turnsLine[6];
            }
            else if (this.turnsLine[0] == this.turnsLine[3] && this.turnsLine[0] == this.turnsLine[6] && this.turnsLine[0] != 'N')
            {
                winLine[0] = 0; winLine[1] = 3; winLine[2] = 6;
                return this.turnsLine[0];
            }
            else if (this.turnsLine[1] == this.turnsLine[4] && this.turnsLine[1] == this.turnsLine[7] && this.turnsLine[1] != 'N')
            {
                winLine[0] = 1; winLine[1] = 4; winLine[2] = 7;
                return this.turnsLine[1];
            }
            else if (this.turnsLine[2] == this.turnsLine[5] && this.turnsLine[2] == this.turnsLine[8] && this.turnsLine[2] != 'N')
            {
                winLine[0] = 2; winLine[1] = 5; winLine[2] = 8;
                return this.turnsLine[2];
            }  
            else if (this.turnsLine[0] == this.turnsLine[4] && this.turnsLine[0] == this.turnsLine[8] && this.turnsLine[0] != 'N')
            {
                winLine[0] = 0; winLine[1] = 4; winLine[2] = 8;
                return this.turnsLine[0];
            }
            else if (this.turnsLine[2] == this.turnsLine[4] && this.turnsLine[2] == this.turnsLine[6] && this.turnsLine[2] != 'N')
            {
                winLine[0] = 2; winLine[1] = 4; winLine[2] = 6;
                return this.turnsLine[2];
            }

            if (this.turnsLine.IndexOf('N') != -1)
                return 'T';
            return 'N';
        }

        public void win(char winner)
        {
            switch (winner)
            {
                case 'X':
                    {
                        this.wins[0]++;
                        break;
                    }
                case 'O':
                    {
                        this.wins[1]++;
                        break;
                    }
                case 'N':
                    {
                        this.wins[2]++;
                        break;
                    }
            }
            this.initialize();
        }

        public char makeTurn(int button)
        {
            if (button < 0 || button > 8 || this.turnsLine[button] != 'N') return 'E'; //Вернуть ошибку, если такой кнопки не существует или клетка занята
            this.turnsLine = this.turnsLine.Remove(button, 1).Insert(button, this.currentTurn.ToString());
            if (this.currentTurn == 'X')
                this.currentTurn = 'O';
            else
                this.currentTurn = 'X';
            char isWin = this.checkWin();
            if (isWin != 'T')
                this.win(isWin);
            return isWin;
        }
    }

    [Serializable]
    public class Network
    {
        Random rnd;
        public float[][][] weights;
        public float[][][] neuronInputs; //Входные значения в каждый нейрон (для обучения)
        public float[] inputData;
        public float[] outputData;
        public float[][][] deltas; //Используется в обучении для перепрыгивания локальных минимумов
        public float momentumRate; //Используется в обучении для перепрыгивания локальных минимумов
        public float accuracy;
        int neuronsAmount;
        int layersAmount;
        int inputAmount;
        int outputAmount;

        public void constFunc(int neuronsAmount, int layersAmount, int inputAmount, int outputAmount)
        {
            this.weights = new float[layersAmount + 1][][]; //Инициализация массива слоёв (+1 для выходного слоя, не учитывающемся при вводе)
            this.neuronInputs = new float[layersAmount + 1][][];
            this.deltas = new float[layersAmount + 1][][];
            this.weights[0] = new float[neuronsAmount][]; //Инициализация массива входных нейронов / первого слоя
            this.neuronInputs[0] = new float[neuronsAmount][];
            this.deltas[0] = new float[neuronsAmount][];
            for (int i = 0; i < neuronsAmount; i++) //Инициализация массива весов входных нейронов
            {
                this.weights[0][i] = new float[inputAmount + 1]; //(+1 для bias)
                this.neuronInputs[0][i] = new float[inputAmount + 1];
                this.deltas[0][i] = new float[inputAmount + 1];
            }
            for (int i = 1; i < layersAmount; i++) //Инициализация всех слоёв, кроме выходного
            {
                this.weights[i] = new float[neuronsAmount][];
                this.neuronInputs[i] = new float[neuronsAmount][];
                this.deltas[i] = new float[neuronsAmount][];
                for (int j = 0; j < neuronsAmount; j++)
                {
                    this.weights[i][j] = new float[neuronsAmount + 1]; //(+1 для bias)
                    this.neuronInputs[i][j] = new float[neuronsAmount + 1];
                    this.deltas[i][j] = new float[neuronsAmount + 1];
                }
            }
            this.weights[layersAmount] = new float[outputAmount][]; //Инициализация выходного слоя
            this.neuronInputs[layersAmount] = new float[outputAmount][];
            this.deltas[layersAmount] = new float[outputAmount][];
            for (int i = 0; i < outputAmount; i++)
            {
                this.weights[layersAmount][i] = new float[neuronsAmount + 1]; //(+1 для bias)
                this.neuronInputs[layersAmount][i] = new float[neuronsAmount + 1];
                this.deltas[layersAmount][i] = new float[neuronsAmount + 1];
            }
            this.neuronsAmount = neuronsAmount;
            this.layersAmount = layersAmount;
            this.inputAmount = inputAmount;
            this.outputAmount = outputAmount;
            this.rnd = new Random();
            this.inputData = new float[inputAmount];
            this.outputData = new float[outputAmount];
            this.accuracy = 0.01F;
            this.initialize(-1, 2);
            this.momentumRate = 0.001F;
        }

        public Network() //Беспараметрический конструктор для сериализации
        {
            constFunc(1, 1, 2, 1);
        }

        /// <summary>
        /// Создание сети
        /// </summary>
        /// <param name="neuronsAmount">Кол-во нейронов в слое</param>
        /// <param name="layersAmount">Кол-во слоёв (без выходного)</param>
        /// <param name="inputAmount">Кол-во входных значений</param>
        /// <param name="outputAmount">Кол-во выходных значений</param>
        public Network(int neuronsAmount, int layersAmount, int inputAmount, int outputAmount)
        {
            constFunc(neuronsAmount, layersAmount, inputAmount, outputAmount);
        }

        public void initialize(int min, int max)
        {
            for (int i = 0; i < this.neuronsAmount; i++) //Заполнение весов входных нейронов
            {
                for(int j = 0; j < inputAmount + 1; j++)
                {
                    this.weights[0][i][j] = this.rnd.Next(min, max);
                }
                
            }
            for (int i = 1; i < this.layersAmount; i++) //Заполнение весов остальных нейронов, кроме выходных
            {
                for (int j = 0; j < neuronsAmount; j++)
                {
                    for (int k = 0; k < neuronsAmount + 1; k++)
                    {
                        this.weights[i][j][k] = this.rnd.Next(min, max);
                    }
                }

            }
            this.weights[this.layersAmount] = new float[this.outputAmount][];
            for (int i = 0; i < outputAmount; i++) //Заполнение весов выходных нейронов
            {
                this.weights[this.layersAmount][i] = new float[this.neuronsAmount + 1];
                for (int j = 0; j < neuronsAmount + 1; j++)
                {
                    this.weights[this.layersAmount][i][j] = this.rnd.Next(min, max);
                }
            }
        }

        public float[] launchNetwork() //Запуск сети
        {
            float[] outputLayer = new float[neuronsAmount];
            outputLayer = launchLayer(inputData, 0);
            for (int i = 1; i < this.weights.Length; i++)
            {
                outputLayer = launchLayer(outputLayer, i);
            }
            return this.outputData = outputLayer;
        }

        /// <summary>
        /// Запуск работы слоя
        /// </summary>
        /// <param name="inputData">Массив входных значений</param>
        /// <param name="layer">Номер слоя</param>
        /// <returns>Массив выходных значений</returns>
        public float[] launchLayer(float[] inputData, int layer)
        {
            float sum = 0;
            float[] output = new float[this.weights[layer].Length];
            for (int j = 0; j < this.weights[layer].Length; j++) //j - Обрабатываемый нейрон в слое
            {
                int i = 0;
                for (i = 0; i < inputData.Length; i++) //i - номер входного значения
                {
                    this.neuronInputs[layer][j][i] = inputData[i]; //Записываем входные данные в массив входных значений для дальнейшего обучения
                    sum += inputData[i] * this.weights[layer][j][i]; //Умножаем входное значение на вес и прибавляем к сумме
                }
                this.neuronInputs[layer][j][i] = 1; //У bias входное значение всегда 1
                sum += this.weights[layer][j][i]; //Прибавляем вес bias
                output[j] = this.activate(sum, "sigmoid"); //Записываем выходное значение в массив выходных значений
                sum = 0; //Обнуляем сумму и переходим к следующему нейрону
            }
            return output;
        }

        public float activate(float sum, string method)
        {
            if(method == "sigmoid")
                return (float)(1 / (1 + Math.Pow(Math.E, -sum)));
            else
                return sum < 0.5 ? 0 : 1;
        }

        public float[][][] copyWeights()
        {
            float[][][] newWeights = new float[this.weights.Length][][];
            for (int i = 0; i < this.weights.Length; i++)
            {
                newWeights[i] = new float[this.weights[i].Length][];
                for (int j = 0; j < this.weights[i].Length; j++)
                {
                    newWeights[i][j] = new float[this.weights[i][j].Length];
                    for (int k = 0; k < this.weights[i][j].Length; k++)
                        newWeights[i][j][k] = this.weights[i][j][k];
                }
            }
            return newWeights;
        }

        public bool trainUsual(float[] inputs, float[] answer)
        {
            this.inputData = inputs;
            float[] networkOut = this.launchNetwork();
            if (networkOut.SequenceEqual(answer)) return true;
            float error = 0;
            for (int i = 0; i < answer.Length; i++)
            {
                error += answer[i] - networkOut[i];
            }
            for (int i = 0; i < this.weights.Length; i++)
            {
                for (int j = 0; j < this.weights[i].Length; j++)
                {
                    for (int k = 0; k < this.weights[i][j].Length; k++)
                    {
                        this.weights[i][j][k] += this.accuracy * error * this.neuronInputs[i][j][k];
                    }
                }
            }
            return false;
        }

        public bool trainBP(float[] inputs, float[] answer)
        {
            this.inputData = inputs;
            float[] networkOut = this.launchNetwork();

            float[][][] oldWeights = copyWeights(); //Копируем массив весов для бекпропагайшна (т.к. работаем с копией, а в оригинальный записываем изменения)
            float[][] errors = new float[this.weights.Length][]; //Сигналы ошибок на каждом нейроне
            for (int i = 0; i < errors.Length; i++) //Инициализация массива ошибок
                errors[i] = new float[this.weights[i].Length];

            for (int i = 0; i < this.weights[this.weights.Length - 1].Length; i++) //Выходной слой
            {
                errors[this.weights.Length - 1][i] = (answer[i] - this.outputData[i]) * this.outputData[i] * (1 - this.outputData[i]); //Ошибка этого нейрона (маленькая дельта в формулах)
                for (int j = 0; j < this.weights[this.weights.Length - 1][i].Length; j++)
                {
                    this.weights[this.weights.Length - 1][i][j] += //Исправляем вес: скорость обучения * ошибка нейрона * входное значение из нейрона, связь с которым сейчас корректируем + прошлое изменение веса * на momentumRate
                        this.accuracy * 
                        errors[this.weights.Length - 1][i] * 
                        this.neuronInputs[this.weights.Length - 1][i][j] + 
                        this.deltas[this.weights.Length - 1][i][j] * 
                        this.momentumRate;
                    this.deltas[this.weights.Length - 1][i][j] = //Обновляем momentumRate
                        this.accuracy *
                        errors[this.weights.Length - 1][i] *
                        this.neuronInputs[this.weights.Length - 1][i][j];
                }
            }

            for (int i = this.weights.Length - 2; i >= 0; i--) //Скрытые слои
            {
                for (int j = 0; j < this.weights[i].Length; j++)
                {
                    errors[i][j] = 0; //Обнуляем ошибку данного нейрона
                    for (int k = 0; k < this.weights[i + 1].Length; k++)//идём на следующий слой и вычисляем ошибку для данного нейрона
                    {
                        errors[i][j] += errors[i + 1][k] * oldWeights[i + 1][k][j]; //Ошибку каждого нейрона следующего слоя умножаем на вес входа из обрабатываемого нейрона в этот
                    }
                    errors[i][j] *= this.neuronInputs[i + 1][0][j] * (1 - this.neuronInputs[i + 1][0][j]); //Завершаем вычисление ошибки умножив сумму ошибок следующего слоя на out(1 - out) этого нейрона
                    for (int k = 0; k < this.weights[i][j].Length; k++)
                    {
                        this.weights[i][j][k] +=
                            this.accuracy * 
                            errors[i][j] * 
                            this.neuronInputs[i][j][k] +
                            this.deltas[i][j][k] *
                            this.momentumRate; //Новый вес = новый вес - точность обучения * ошибку нейрона * вход от нейрона обрабатываемого веса
                        this.deltas[i][j][k] = //Обновляем momentumRate
                            this.accuracy *
                            errors[i][j] *
                            this.neuronInputs[i][j][k];
                    }
                }
            }
            return compareAnswers(networkOut, answer);
        }

        public bool compareAnswers(float[] mas, float[] mas1)
        {
            for(int i = 0; i < mas.Length; i++)
                if(Math.Round(mas[i]) != Math.Round(mas1[i]))
                    return false;
            return true;
        }

        public int[] learnArrays(float[][] inputs, float[][] answers, int iterations)
        {
            int[] successes = new int[3] { 0, 0, 0 };
            for (int k = 0; k < iterations; k++)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    if (trainBP(inputs[i], answers[i])) // Выполняем функцию тренировки
                    {
                        successes[0]++; //Если ответ был верным, добавляем счетчик верных ответов
                        successes[2]++; //Счетчик верных ответов подряд
                    }
                    else
                    {
                        successes[1]++; //Счетчик неверных ответов
                        successes[2] = 0; //Сбарос счетчика верных ответов подряд
                    }
                }
            }
            return successes;
        }

        public int[] learnFunction(logicFunction2 func, string method) //2 аргумента
        {
            float[] inputs;
            float[] answer;
            int[] successes = new int[3] { 0, 0, 0 };
            if (method == "BP")
            {
                for (int i = 0; i < 2000; i++)
                {
                    inputs = generateInputs(2, 0, 2);
                    answer = func(inputs[0], inputs[1]);
                    if (trainBP(inputs, answer)) // Выполняем функцию тренировки
                    {
                        successes[0]++; //Если ответ был верным, добавляем счетчик верных ответов
                        successes[2]++; //Счетчик верных ответов подряд
                    }
                    else
                    {
                        successes[1]++; //Счетчик неверных ответов
                        successes[2] = 0; //Сбарос счетчика верных ответов подряд
                    }
                }
            }
            else
            {
                for (int i = 0; i < 2000; i++)
                {
                    inputs = new float[2];
                    inputs[0] = activate(rnd.Next(0, 2), "");
                    inputs[1] = activate(rnd.Next(0, 2), "");
                    answer = func(inputs[0], inputs[1]);
                    if (trainUsual(inputs, answer)) // Выполняем функцию тренировки
                    {
                        successes[0]++; //Если ответ был верным, добавляем счетчик верных ответов
                        successes[2]++; //Счетчик верных ответов подряд
                    }
                    else
                    {
                        successes[1]++; //Счетчик неверных ответов
                        successes[2] = 0; //Сбарос счетчика верных ответов подряд
                    }
                }
            }
            
            return successes;
        }

        public float[] generateInputs(int amount, int from, int to)
        {
            float[] inputs = new float[amount];
            for (int i = 0; i < amount; i++)
            {
                inputs[i] = activate(rnd.Next(from, to + 1), "");
            }
            return inputs;
        }

        public int[] learnFunction(logicFunction1 func) //1 аргумент
        {
            float[] inputs;
            float[] answer;
            int[] successes = new int[3] {0, 0, 0};
            for (int i = 0; i < 2000; i++)
            {
                inputs = generateInputs(1, -50, 50);
                answer = func(inputs[0]);
                if (trainBP(inputs, answer)) // Выполняем функцию тренировки
                {
                    successes[0]++; //Если ответ был верным, добавляем счетчик верных ответов
                    successes[2]++; //Счетчик верных ответов подряд
                }

                else
                {
                    successes[1]++; //Счетчик неверных ответов
                    successes[2] = 0; //Сбарос счетчика верных ответов подряд
                }
                    
            }
            return successes;
        }
    }

    class interfaceNetworkGame
    {
        TicTacToe Game;
        Network Net;
        public float[] field; //Первые 9 - враг сети, последние 9 - сеть
        public float[] output;

        public interfaceNetworkGame(TicTacToe Game, Network Net)
        {
            this.Game = Game;
            this.Net = Net;
            field = new float[18];
            output = new float[9];
        }

        public int makeTurn() //Выполнить ход
        {
            makeInputs();
            Net.inputData = field;
            output = Net.launchNetwork();
            char result = Game.makeTurn(output.ToList().IndexOf(output.Max())); //Ход на клетку, на которой самое высокое значение, выданное сетью

            return result == 'E' ? -1 : output.ToList().IndexOf(output.Max()); //Если сеть походила на занятую клетку, возвращаем ошибку -1. Иначе возвращаем номер клетки
        }

        public void makeInputs()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Game.turnsLine[i] != Game.currentTurn && Game.turnsLine[i] != 'N')
                    field[i] = 1;
                else
                    field[i] = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                if (Game.turnsLine[i] == Game.currentTurn)
                    field[9 + i] = 1;
                else
                    field[9 + i] = 0;
            }
        }
    }

    class logicFunctions
    {
        static public float[] logicNot(float a)
        {
            float[] answer = new float[1];
            if (a == 0)
                answer[0] = 1;
            else
                answer[0] = 0;
            return answer;
        }

        static public float[] logicAnd(float a, float b)
        {
            float[] answer = new float[1];
            if (a == 1 && b == 1)
                answer[0] = 1;
            else
                answer[0] = 0;
            return answer;
        }

        static public float[] logicOr(float a, float b)
        {
            float[] answer = new float[1];
            if (a == 1 || b == 1)
                answer[0] = 1;
            else
                answer[0] = 0;
            return answer;
        }

        static public float[] logicXor(float a, float b)
        {
            float[] answer = new float[1];
            if ((a == 1 && b == 0) || (a == 0 && b == 1))
                answer[0] = 1;
            else
                answer[0] = 0;
            return answer;
        }

        static public float[] pointCheck(float x, float y)
        {
            float[] answer = new float[1];
            float yline = 2 * x + 1;
            answer[0] = y >= yline ? 1 : 0;
            return answer;
        }

        static public float[] circleCheck(float x, float y)
        {
            float[] answer = new float[1];
            if ((x - 3) * (x - 3) + (y - 4) * (y - 4) < 5 * 5)
                answer[0] = 1;
            else
                answer[0] = 0;
            return answer;
        }
    }
}
