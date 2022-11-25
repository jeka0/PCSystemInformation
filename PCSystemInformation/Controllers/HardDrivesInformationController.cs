using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSystemInformation.SystemInformation;
using PCSystemInformation.Models;

namespace PCSystemInformation.Controllers
{
    public class HardDrivesInformationController
    {
        private IHardDrivesInformation hardDrivesInformation;

        public HardDrivesInformationController()
        {
            this.hardDrivesInformation = new HardDrivesInformation();
        }

        public InformationBlock DiscNames()
        {
            InformationBlock block = new InformationBlock("Список дисков");
            for (int i = 0; i < hardDrivesInformation.GetDrivesCount(); i++)
            {
                block.elements.Add(new Element("Диск #" + i, hardDrivesInformation.GetName(i) + " (" + hardDrivesInformation.GetTotalSize(i).ToString() + " байт)"));
            }
            return block;
        }

        public List<InformationBlock> GetDrives()
        {
            List<InformationBlock> list = new List<InformationBlock>();
            for (int i=0; i<hardDrivesInformation.GetDrivesCount(); i++)
            {
                long availableFreeSpace = hardDrivesInformation.GetAvailableFreeSpace(i),
                    totalFreeSpace = hardDrivesInformation.GetTotalFreeSpace(i),
                    totalSize = hardDrivesInformation.GetTotalSize(i);
                InformationBlock block = new InformationBlock("Диск: " + hardDrivesInformation.GetName(i));
                block.elements.Add(new Element("Файловая система", hardDrivesInformation.GetDriveFormat(i)));
                block.elements.Add(new Element("Тип диска", hardDrivesInformation.GetDriveType(i)));
                block.elements.Add(new Element("Объем доступного свободного места", GetGB(availableFreeSpace) + " (" + availableFreeSpace.ToString()+" байт)"));
                block.elements.Add(new Element("Готов ли диск", hardDrivesInformation.GetIsReady(i)));
                block.elements.Add(new Element("Корневой каталог диска", hardDrivesInformation.GetRootDirectory(i)));
                block.elements.Add(new Element("Общий объем свободного места, доступного на диске", GetGB(totalFreeSpace) + " (" + totalFreeSpace.ToString() + " байт)"));
                block.elements.Add(new Element("Размер диска", GetGB(totalSize) + " (" + totalSize.ToString() + " байт)"));
                block.elements.Add(new Element("Метка тома диска", hardDrivesInformation.GetVolumeLabel(i)));
                list.Add(block);
            }
            return list;
        }

        private String GetGB(long num)
        {
            return string.Format("{0:#.##}", num / (1024 * 1024 * 1024.0)) + " Гб";
        }
    }
}
