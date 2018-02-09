using BankInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MEFDemo
{
    class Program
    {
        //[Import("MusicBook")]
        //public IBookService Service { get; set; }

        //[ImportMany("MusicBook")]
        //public IEnumerable<object> Services { get; set; }

        ////导入属性，这里不区分public还是private
        //[ImportMany]
        public List<string> InputString { get; set; }

        ////导入无参数方法
        //[Import]
        //public Func<string> methodWithoutPara { get; set; }

        ////导入有参数方法
        //[Import]
        //public Func<int, string> methodWithPara { get; set; }

        //[ImportMany(typeof(ICard))]
        //public IEnumerable<ICard> cards { get; set; }
        //其中AllowRecomposition=true参数就表示运行在有新的部件被装配成功后进行部件集的重组.
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<ICard, IMetaData>> cards { get; set; }


        static void Main(string[] args)
        {
            Program program=new Program();
            program.Compose();
            if (program.cards != null)
            {
                //foreach (var programService in program.Services)
                //{
                //    var temp = (IBookService) programService;
                //    Console.WriteLine(temp.GetBookName());
                //}
                //foreach (var str in program.InputString)
                //{
                //    Console.WriteLine(str);
                //}
                ////调用无参数方法
                //if (program.methodWithoutPara != null)
                //{
                //    Console.WriteLine(program.methodWithoutPara());
                //}
                ////调用有参数方法
                //if (program.methodWithPara != null)
                //{
                //    Console.WriteLine(program.methodWithPara(3000));
                //}
                foreach (var c in program.cards)
                {
                    //Console.WriteLine(c.GetCountInfo());
                    if (c.Metadata.CardType == "BankOfChina")
                    {
                        Console.WriteLine("Here is a card of Bank Of China ");
                        Console.WriteLine(c.Value.GetCountInfo());
                    }
                    if (c.Metadata.CardType == "NongHang")
                    {
                        Console.WriteLine("Here is a card of Nong Ye Yin Hang ");
                        Console.WriteLine(c.Value.GetCountInfo());
                    }
                }
            }
            Console.Read();
        }

        private void Compose()
        {
            //var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var catalog = new DirectoryCatalog("Cards");
            CompositionContainer compositionContainer=new CompositionContainer(catalog);
            compositionContainer.ComposeParts(this);
        }
    }
}
