using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ingest_Assistant
{
   public  class FS_Operations
    {

        public static Queue<string> Get_Directories_Encluding_ID_Viplanner(string Directory_Path, string ID_ViPanner)
        {
            string[] directories = Directory.GetDirectories(Directory_Path);
            Queue<string> directories_with_files_to_collect = new Queue<string>();
            foreach (var cur in directories)
            {
                if (Path.GetDirectoryName(cur).Contains(ID_ViPanner)) directories_with_files_to_collect.Enqueue(cur);
            }
            return directories_with_files_to_collect;

        }

    }
}
