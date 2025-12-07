using DataStructuresToolkit;
using DataStructuresToolkit.StacksQueues;
using DataStructureToolkitCLI.DataStructureDemo;
using DataStructureToolkitCLI.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureToolkitCLI
{
    public class DataStructureMainCLI
    {
        private Stopwatch timer = new Stopwatch();
        private AssociativeHelpers _associativeHelpers = new AssociativeHelpers();


        public void Run()
        {
            while (true)
            {
                ConsoleUtils.ResetColor();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("Data Structure and Algorithms Toolkit Demo");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("                           1. Complexity Tester                              2. Arrays ");
                Console.WriteLine("                           3. Strings                                        4. Lists");
                Console.WriteLine("                           5. Stacks                                         6. Queues");
                Console.WriteLine("                           7. File                                           8. Trees");
                Console.WriteLine("                           9. BST                                            10. Hash Table");
                Console.WriteLine("                           11. AVLTrees                                      12. Associative Containers");
                Console.WriteLine("                           13. Linked Lists                                  14. Graph");
                Console.WriteLine("                           15. Sets                                          0. Exit");
                Console.WriteLine("========================================================================================================================");
                Console.Write("Select an Option: ");
                int input = -1;
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    SelectMenu(input);
                } catch (Exception ex)
                {
                    ConsoleUtils.ErrorMessage(ex.Message);
                }
                if (input == 0 )
                    break;
                
            }
        }

        private void SelectMenu(int input)
        {
            switch (input)
            {
                case 1:
                    ComplexityTesterCLI CLI1 = new ComplexityTesterCLI(timer);
                    CLI1.ComplexityCLI();
                    break;
                case 2:
                    ArrayCLI CLI2 = new ArrayCLI(timer);
                    CLI2.CLI();
                    break;
                case 3:
                    StringCLI CLI3 = new StringCLI(timer);
                    CLI3.CLI();
                    break;
                case 4:
                    ListCLI CLI4 = new ListCLI(timer);
                    CLI4.CLI();
                    break;
                case 5:
                    StacksCLI CLI5 = new StacksCLI(timer);
                    CLI5.CLI();
                    break;
                case 6:
                    QueueCLI CLI6 = new QueueCLI(timer);
                    CLI6.CLI();
                    break;
                case 7:
                    FileCLI CLI7 = new FileCLI(timer);
                    CLI7.CLI();
                    break;
                case 8:
                    TreeCLI CLI8 = new TreeCLI(timer);
                    CLI8.CLI();
                    break;
                case 9:
                    BSTCLI CLI9 = new BSTCLI(timer);
                    CLI9.CLI();
                    break;
                case 10:
                    HashTableCLI CLI10 = new HashTableCLI(timer);
                    CLI10.CLI();
                    break;
                case 11:
                    AVLTreeCLI CLI11 = new AVLTreeCLI(timer);
                    CLI11.CLI();
                    break;
                case 12:
                    AssociativeCLI CLI12 = new AssociativeCLI(timer);
                    CLI12.CLI();
                    break;
                case 13:
                    LinkedListsCLI CLI13 = new LinkedListsCLI(timer);
                    CLI13.CLI();
                    break;
                case 14:
                    GraphCLI CLI14 = new GraphCLI(timer);
                    CLI14.CLI();
                    break;
                case 15:
                    SetCLI CLI15 = new SetCLI(timer);
                    CLI15.CLI();
                    break;
                case 0:
                    return;
                default:
                    ConsoleUtils.ErrorMessage($"The options: {input} is invalid. Please select an acceptable option");
                    break;
            }
        }


    }
}
