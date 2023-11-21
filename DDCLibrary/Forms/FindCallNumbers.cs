using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using static System.Windows.Forms.AxHost;
using Button = System.Windows.Forms.Button;
using DDCLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace DDCLibrary
{
    public partial class FindCallNumbers : Form
    {

        private MyTreeNode rootNode; // initialising tree class structure
        private List<Button> optionButtons; //initialising buttons class
        private string randomlyChosenSubcategory; //global string to store subcategories
        int level;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// constructor
        /// </summary>
        public FindCallNumbers()
        {
            InitializeComponent();

            // file path to textfile stored in bin debug folder of the app
            string filePath = "deweydecimalclassifications.txt";

            // Reading data from the text file and populate the tree
            PopulateTree(filePath);

            // populating buttons list with buttons
            optionButtons = new List<Button> { buttonOption1, buttonOption2, buttonOption3, buttonOption4 };

            // Starting the quiz
            StartQuiz();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// The first method to execute the game
        /// </summary>
        private void StartQuiz()
        {
            // Display a randomly chosen subcategory and its main category
            var subcategoryAndMainCategory = GetRandomSubcategoryAndMainCategory(rootNode);
            randomlyChosenSubcategory = subcategoryAndMainCategory.Item1;
            labelQuestion.Text = subcategoryAndMainCategory.Item2;

            // Display main categories as options
            DisplayMainCategoryOptions();

            foreach (var button in optionButtons)
            {
                button.Click += btnOption_Click;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Displaying main categories on buttons
        /// </summary>
        private void DisplayMainCategoryOptions()
        {
            // Get the main categories (top-level nodes)
            List<MyTreeNode> mainCategories = rootNode.Children;

            // Shuffle the main categories to randomize button placement
            Shuffle(mainCategories);

            // Generate a random index to place the correct main category among options
            var correctIndex = new Random().Next(optionButtons.Count);

            // Display the main categories on buttons
            for (int i = 0; i < optionButtons.Count; i++)
            {
                if (i == correctIndex)
                {
                    // Display the correct main category among options
                    optionButtons[i].Text = randomlyChosenSubcategory;
                }
                else
                {
                    // Display other main categories as options
                    optionButtons[i].Text = mainCategories[i].Description;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// getting random subcategory
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Tuple<string, string> GetRandomSubcategoryAndMainCategory(MyTreeNode node)
        {
            // Select a random subcategory from the last level of indentation
            List<MyTreeNode> lastLevelNodes = GetLastLevelNodes(node);
            Shuffle(lastLevelNodes);

            // Get the main category of the randomly chosen subcategory
            MyTreeNode mainCategoryNode = FindParentNode(rootNode, lastLevelNodes.FirstOrDefault());

            return Tuple.Create(lastLevelNodes.FirstOrDefault()?.Description, mainCategoryNode?.Description);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Displaying subcategory options
        /// </summary>
        /// <param name="mainCategoryNode"></param>
        private void DisplaySubcategoryOptions(MyTreeNode mainCategoryNode)
        {
            // Get the subcategories of the chosen main category
            List<MyTreeNode> subcategories = mainCategoryNode.Children;

            // Shuffle the subcategories to randomize button placement
            Shuffle(subcategories);

            // Display the subcategories on buttons
            for (int i = 0; i < optionButtons.Count && i < subcategories.Count; i++)
            {
                optionButtons[i].Text = subcategories[i].Description;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Populating tree with textfile data
        /// </summary>
        /// <param name="filePath"></param>
        private void PopulateTree(string filePath)
        {
            // Create a dummy root node
            MyTreeNode dummyRoot = new MyTreeNode("0", "Dummy Root");

            // Stack to keep track of parent nodes at each level
            Stack<MyTreeNode> parentNodeStack = new Stack<MyTreeNode>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        // Skip empty lines
                        continue;
                    }

                    // Determine the level of the node based on indentation
                    this.level = line.Length - line.TrimStart().Length;

                    // Create a new tree node
                    MyTreeNode newNode = ParseLineToMyTreeNode(line);

                    if (level == 0)
                    {
                        // Clear the stack for top-level nodes
                        parentNodeStack.Clear();

                        // Add the new top-level node to the stack and the dummy root
                        parentNodeStack.Push(newNode);
                        dummyRoot.Children.Add(newNode);
                    }
                    else
                    {
                        // Find the parent node based on the indentation level
                        while (parentNodeStack.Count > level)
                        {
                            parentNodeStack.Pop();
                        }

                        MyTreeNode parentNode = parentNodeStack.Peek();

                        // Add the new node to the parent node
                        parentNode.Children.Add(newNode);

                        // Push the new node to the stack for future levels
                        parentNodeStack.Push(newNode);
                    }
                }
            }

            // The dummy root node now contains all top-level nodes as its children
            rootNode = dummyRoot;

            // Call the method to print the tree structure
            PrintTreeStructure(rootNode);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Getting random subcategory
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetRandomSubcategory(MyTreeNode node)
        {
            // Select a random subcategory from the last level of indentation
            List<MyTreeNode> lastLevelNodes = GetLastLevelNodes(node);
            Shuffle(lastLevelNodes);
            return lastLevelNodes.FirstOrDefault()?.Description;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Shuffling data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        private void Shuffle<T>(List<T> list)
        {
            // Shuffle the list using Fisher-Yates algorithm
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// button click event handlers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption_Click(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;
            string selectedCategory = selectedButton.Text;

            // Check if the selected main category corresponds to the randomly chosen subcategory
            MyTreeNode selectedMainCategoryNode = rootNode.Children.Find(node => node.Description == selectedCategory);

            if (selectedMainCategoryNode != null)
            {
                if (selectedButton != null)
                {
                    // Check if the clicked button contains the correct first-level node
                    if (selectedButton.Text == selectedMainCategoryNode.Description)
                    {
                        MessageBox.Show("Correct!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // selectedButton.BackColor = Color.Blue;//changing back oclor to show if correct color has been chosen                      
                        //   DisplaySubcategoryOptions(selectedMainCategoryNode);
                        StartQuiz();
                        
                    }
                    else if (selectedButton.Text != selectedMainCategoryNode.Description)
                    {
                       // selectedButton.BackColor = Color.Red;
                        MessageBox.Show("Incorrect. Try again!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }               
            }        
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Getting last level nodes
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<MyTreeNode> GetLastLevelNodes(MyTreeNode node)
        {
            List<MyTreeNode> lastLevelNodes = new List<MyTreeNode>();

            if (node.Children.Count == 0)
            {
                // If the node has no children, it is a leaf node
                lastLevelNodes.Add(node);
            }
            else
            {
                // Recursively traverse child nodes
                foreach (var childNode in node.Children)
                {
                    lastLevelNodes.AddRange(GetLastLevelNodes(childNode));
                }
            }

            return lastLevelNodes;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Parse line method
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private MyTreeNode ParseLineToMyTreeNode(string line)
        {
            // Assuming code and description are separated by a space
            string[] parts = line.Split(' ');
            string code = parts[0];
            string description = string.Join(" ", parts.Skip(1));

            return new MyTreeNode(code, description);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Finding parent node
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetNode"></param>
        /// <returns></returns>
        private MyTreeNode FindParentNode(MyTreeNode root, MyTreeNode targetNode)
        {
            if (root == null || targetNode == null)
            {
                return null;
            }

            return FindParentNodeRecursive(root, targetNode);
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="targetNode"></param>
        /// <returns></returns>
        private MyTreeNode FindParentNodeRecursive(MyTreeNode currentNode, MyTreeNode targetNode)
        {
            foreach (var childNode in currentNode.Children)
            {
                if (childNode == targetNode)
                {
                    return currentNode;
                }

                var result = FindParentNodeRecursive(childNode, targetNode);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Printing the textfile in the console
        /// </summary>
        /// <param name="node"></param>
        /// <param name="level"></param>
        private void PrintTreeStructure(MyTreeNode node, int level = 0)
        {
            if (node != null)
            {
                Console.WriteLine($"{new string(' ', level * 2)}{node.Code} - {node.Description}");

                foreach (var childNode in node.Children)
                {
                    PrintTreeStructure(childNode, level + 1);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returning to home screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbReturn_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Home form2 = new Home();
            // Show Form2 and hide Form1
            form2.Show();
            this.Hide();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartQuiz();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbShutDon_Click(object sender, EventArgs e)
        {
            DialogResult promptShutDown = MessageBox.Show("shutting down...", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            if (promptShutDown == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Help feature of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Match the described text to its parent call number category " +
               "\n NB! The provided deweyclassifications text may be used as reference!", "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
//----------------------------------------------------------------------------------ooo000EndOfFile000ooo--------------------------------------------------------------------------------------------

