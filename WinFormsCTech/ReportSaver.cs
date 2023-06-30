using System.Text;

namespace WinFormsCTech
{
    static class ReportSaver
    {
        public static void Save(ResponsibleExecutorStorage storage, DateTime currentDate, RichTextBox richTextBox1, string fileName)
        {
            try
            {
                StringBuilder strTable = new StringBuilder();

                strTable.Append(@"{\rtf1 ");

                strTable.Append("{{\\b Справка о неисполненных документах и обращениях граждан}\\par\\par" +
                    "Не исполнено в срок " + (storage.SumRKK() + storage.SumAppeal()) + " документов, из них:\\par\\par" +
                    "- количество неисполненных входящих документов: " + storage.SumRKK() + ";\\par\\par" +
                    "- количество неисполненных письменных обращений граждан: " + storage.SumAppeal() + ".\\par\\par" +
                    "Сортировка: {\\bпо имени ответственного исполнителя.}\\par\\par}");

                strTable.Append(@"{");

                //fill header
                strTable.Append(@"\trowd");

                string addToCell = "\\trftsWidth1\\trpaddl10\\trpaddr10\\trpaddfl3\\trpaddfr3\\tblrsid9120359\\tblind10\\tblindtype3 \\clvertalt\\clbrdrt\\brdrs\\brdrw10 \\clbrdrl\\brdrs\\brdrw10 \\clbrdrb\\brdrs\\brdrw10 \\clbrdrr\\brdrs\\brdrw10 \\cltxlrtb\\clftsWidth3\\clwWidth2000\\clshdrawnil ";
                strTable.Append(addToCell + @"\cellx500");
                strTable.Append(addToCell + @"\cellx3000");
                strTable.Append(addToCell + @"\cellx6000");
                strTable.Append(addToCell + @"\cellx8000");
                strTable.Append(addToCell + @"\cellx10000");

                strTable.Append(@"№ \par п.п.\intbl\cell ");
                strTable.Append(@"Ответственный исполнитель\intbl\cell ");
                strTable.Append(@"Количество неисполненных входящих документов\intbl\cell ");
                strTable.Append(@"Количество неисполненных письменных обращений граждан\intbl\cell ");
                strTable.Append(@"Общее количество документов и обращений\intbl\cell ");

                strTable.Append(@" \row");

                var listRespExecutor = storage.GetAll();

                //fill table
                for (int i = 0; i < listRespExecutor.Count; i++)
                {
                    strTable.Append(@"\trowd");

                    strTable.Append(addToCell + @"\cellx500");
                    strTable.Append(addToCell + @"\cellx3000");
                    strTable.Append(addToCell + @"\cellx6000");
                    strTable.Append(addToCell + @"\cellx8000");
                    strTable.Append(addToCell + @"\cellx10000");

                    strTable.Append(" " + (i + 1) + @"\intbl\cell ");
                    strTable.Append(listRespExecutor[i].Name + @"\intbl\cell ");
                    strTable.Append(listRespExecutor[i].RKKCount + @"\intbl\cell ");
                    strTable.Append(listRespExecutor[i].AppealCount + @"\intbl\cell ");
                    strTable.Append((listRespExecutor[i].RKKCount + listRespExecutor[i].AppealCount) + @"\intbl\cell ");

                    strTable.Append(@" \row");
                }
                strTable.Append(@"\pard}");

                strTable.Append(@"{\par\par{Дата составления справки: {\b " + currentDate.ToString()[..10] + "}}}");
                strTable.Append(@"}");

                richTextBox1.Rtf = strTable.ToString();

                richTextBox1.SaveFile(fileName);

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                throw new IOException(
                    "Возникла ошибка при записи в файл по пути:" +
                    fileName +
                    ". Возможно данный файл используется другим приложением. " +
                    "Для сохранения необходимо освободить файл.");
            }
        }
    }
}
