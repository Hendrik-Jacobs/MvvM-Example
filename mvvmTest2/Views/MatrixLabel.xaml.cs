using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace mvvmTest2.ViewModels
{
    public partial class MatrixLabel : UserControl
    {
        public MatrixLabel()
        {
            InitializeComponent();
            view = new MatrixViewModel();
            this.DataContext = view;
            MakeText();
        }


        private MatrixViewModel view;


        private async Task MakeText()
        {
            while (true)
            {
                int stop = (int)MLabel.ActualWidth / 5;

                string line = await GetLine(stop);
                stop++;
                view.MatrixText = $"{line}\n{view.MatrixText}";
                int length = stop * ((int)MLabel.ActualHeight / 10);
                if (view.MatrixTextLength > length)
                {
                    view.MatrixText = view.MatrixText.Substring(0, length - stop + 1);
                }                
                await Task.Delay(300);
            }
        }


        public async static Task<string> GetLine(int stop)
        {
            string chars = "$%# @! * ab    c  d efg hij kl   mn op qrst uvwx y z12 34 56    789 0?; :ABC DEFG H    KLM NOP QR STU    V WXY   Z^& первы" +
                           "          й эксперимент произ        ошел в мае 20           11 года. Ребята броси          ли пустой баллон из-под монтажной пе" +
                           "              ы в костер и потом решили за           писать это на видео. Вс   коре ви           деоролик пол  учил неско" +
                           "提供研究古漢語訓詁學、音韻學、語義學、文字學的學者一個強有力的在                                                                  " +
                           "線工具。本網站 以《說文解字》為基礎，用戶任意點擊其中任何一字便可閱覽《說文解字》                                                        " +
                           "裏有關該字的內容並查看段玉裁 的注解《段注本》、《廣韻》、《集韻                                                                        " +
                           "》裏的反切與釋文及《爾雅》、《方言》、《釋名》、《玉篇》等書裏的釋義。 網站對每個字                                                          " +
                           "也提供相關的異體字、甲骨文暨金文。用戶尚可直接                              查詢主要在線數據庫的有關內容（字典，                      " +
                           "經典文獻等）          。 多種檢索方式，便利用戶                  簡易查找《說文解字》裏任何一字      。許多注解也提供說文各篆之間 的關係";

            string line = "";
            Random rand = new Random();
            for (int i = 0; i < stop; i++)
            {
                int num = rand.Next(0, chars.Length);
                line += chars[num];
            }
            return line;
        }
    }
}
