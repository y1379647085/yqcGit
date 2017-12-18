using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;

namespace ExtendMethods
{
    public class TreeListMethod
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeListNode"></param>
        /// <param name="checkState"></param>
        public static void SetCheckedParentNodes(TreeListNode treeListNode, CheckState checkState)
        {
            if (treeListNode.ParentNode != null)
            {
                var b = false;
                for (var i = 0; i < treeListNode.ParentNode.Nodes.Count; i++)
                {
                    var state = treeListNode.ParentNode.Nodes[i].CheckState;
                    if (checkState.Equals(state)) continue;
                    b = true;
                    break;
                }
                treeListNode.ParentNode.CheckState = b ? CheckState.Indeterminate : checkState;
                SetCheckedParentNodes(treeListNode.ParentNode, checkState);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeListNode"></param>
        /// <param name="checkState"></param>
        public static void SetCheckedChildNodes(TreeListNode treeListNode, CheckState checkState)
        {
            for (var i = 0; i < treeListNode.Nodes.Count; i++)
            {
                treeListNode.Nodes[i].CheckState = checkState;
                SetCheckedChildNodes(treeListNode.Nodes[i], checkState);
            }
        }
    }
}