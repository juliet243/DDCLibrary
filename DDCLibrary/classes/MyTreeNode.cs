using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDCLibrary
{
    public class MyTreeNode
    {
        public string Code { get; }
        public string Description { get; }
        public List<MyTreeNode> Children { get; } = new List<MyTreeNode>();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        public MyTreeNode(string code, string description)
        {
            Code = code;
            Description = description;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
//----------------------------------------------------------------------------------ooo000EndOfFile000ooo--------------------------------------------------------------------------------------------
