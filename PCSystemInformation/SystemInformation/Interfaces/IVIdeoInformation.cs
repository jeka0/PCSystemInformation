using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.SystemInformation
{
    interface IVIdeoInformation
    {
        String GetAdapterCompatibility();
        String GetAdapterDACType();
        String GetAdapterRAM();
        String GetAvailability();
        String GetCaption();
        String GetName();
        String GetConfigManagerErrorCode();
        String GetConfigManagerUserConfig();
        String GetCreationClassName();
        String GetCurrentBitsPerPixel();
        String GetCurrentHorizontalResolution();
        String GetCurrentNumberOfColors();
        String GetCurrentNumberOfColumns();
        String GetCurrentNumberOfRows();
        String GetCurrentRefreshRate();
        String GetCurrentScanMode();
        String GetCurrentVerticalResolution();
        String GetDescription();
        String GetDeviceID();
        String GetDitherType();
        String GetDriverDate();
        String GetDriverVersion();
        String GetInfFilename();
        String GetInfSection();
        String GetInstalledDisplayDrivers();
        String GetMaxRefreshRate();
        String GetMinRefreshRate();
        String GetMonochrome();
        String GetPNPDeviceID();
        String GetStatus();
        String GetSystemCreationClassName();
        String GetSystemName();
        String GetVideoArchitecture();
        String GetVideoMemoryType();
        String GetVideoModeDescription();
        String GetVideoProcessor();
    }
}
