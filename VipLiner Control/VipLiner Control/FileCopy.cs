using System;
using System.IO;
using System.Windows.Forms;

namespace TestFileCopy
{
    public delegate void Complet(bool ifComplete);

    public delegate void Progress(string message, int procent);


    internal class FileCopy
    {
        public FileCopy()
        {
            //задаем размер буфера
            BufferLenght = 1024;
        }

        /// <summary>
        ///     Размер буфера в байтах
        /// </summary>
        public int BufferLenght { get; set; }

        /// <summary>
        ///     Событие на завершение копирования файла
        /// </summary>
        public event Complet OnComplete;

        /// <summary>
        ///     Событие во время копирования
        /// </summary>
        public event Progress OnProgress;

        /// <summary>
        ///     Копирование файла
        /// </summary>
        /// <param name="sourceFile">Путь к исходному файлу</param>
        /// <param name="destinationFile">Путь к целевому файлу</param>
        public void CopyFile(string sourceFile, string destinationFile)
        {
            try
            {
                //Создаем буфер по размеру исходного файла
                //В буфер будем записывать информацию из файла
                var streamBuffer = new Byte[BufferLenght];
                //Общее количество считанных байт
                long totalBytesRead = 0;
                //Количество считываний
                //Используется для задания периода отправки сообщений
                var numReads = 0;

                //Готовим поток для исходного файла
                using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
                {
                    //Получаем длину исходного файла
                    var sLenght = sourceStream.Length;
                    //Готовим поток для целевого файла
                    using (var destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                    {
                        //Читаем из буфера и записываем в целевой файл
                        while (true) //Из цикла выйдем по окончанию копирования файла
                        {
                            //Увеличиваем на единицу количество считываний
                            numReads++;
                            //Записываем в буфер streamBuffer BufferLenght байт
                            //bytesRead содержит количество записанных байт
                            //это количество не может быть больше заданного BufferLenght
                            var bytesRead = sourceStream.Read(streamBuffer, 0, BufferLenght);

                            //Если ничего не было считано
                            if (bytesRead == 0)
                            {
                                //Записываем информацию о процессе
                                getInfo(sLenght, sLenght);
                                //и выходим из цикла
                                break;
                            }

                            //Записываем данные буфера streamBuffer в целевой файл
                            destinationStream.Write(streamBuffer, 0, bytesRead);
                            //Для статистики запоминаем сколько уже байт записали
                            totalBytesRead += bytesRead;

                            //Если количество считываний кратно 10
                            if (numReads%10 == 0)
                            {
                                //Записываем информацию о процессе
                                getInfo(totalBytesRead, sLenght);
                            }

                            //Если количество считанных байт меньше буфера
                            //Значит это конец
                            if (bytesRead < BufferLenght)
                            {
                                //Записываем информацию о процессе
                                getInfo(totalBytesRead, sLenght);
                                break;
                            }
                        }
                    }
                }

                //Отправляем сообщение что процесс копирования закончен удачно
                if (OnComplete != null)
                    OnComplete(true);
            }
            catch (Exception e)
            {
                MessageBox.Show("Возникла следующая ошибка при копировании:\n" + e.Message);
                //Отправляем сообщение что процесс копирования закончен неудачно
                if (OnComplete != null)
                    OnComplete(false);
            }
        }

        /// <summary>
        ///     Задаем информацию о процессе копирования
        /// </summary>
        /// <param name="totalBytesRead">Всего байт прочитано</param>
        /// <param name="sLenght">Размер файла</param>
        private void getInfo(long totalBytesRead, long sLenght)
        {
            //Формируем сообщение
            var message = string.Empty;
            var pctDone = totalBytesRead/(double) sLenght;
            message = string.Format("Считано: {0} из {1}. Всего {2}%",
                totalBytesRead,
                sLenght,
                (int) (pctDone*100));
            //Отправляем сообщение подписавшимя на него
            if (OnProgress != null && !double.IsNaN(pctDone))
                OnProgress(message, (int) (pctDone*100));
        }
    }
}