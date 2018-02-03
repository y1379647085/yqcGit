using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankInterface
{
    //[InheritedExport]
    public interface ICard
    {
        //账户金额
        double Money { get; set; }
        //获取账户信息
        string GetCountInfo();
        //存钱
        void SaveMoney(double money);
        //取钱
        void CheckOutMoney(double money);      
        
    }

    public interface IMetaData
    {
        string CardType { get; }
    }

    /// <summary>
    /// AllowMultiple = false,代表一个类不允许多次使用此属性
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportCardAttribute : ExportAttribute
    {
        public ExportCardAttribute() : base(typeof(ICard))
        {
        }
        public string CardType { get; set; }
    }
}
