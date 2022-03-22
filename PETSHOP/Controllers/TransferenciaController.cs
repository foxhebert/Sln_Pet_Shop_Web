using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// using system.io;
//using System.IO.DriveInfo;
using System.IO;
////using System.Diagnostics;
////using Device.Net;
////using Hid.Net.Windows;
////using Microsoft.Extensions.Logging;
////using System.Linq;
////using System.Reactive.Linq;
////using System.Threading.Tasks;
////using Usb.Net.Windows;
//////RegisterDeviceNotification
using System.Management;
using System.Text;
using System.Runtime.InteropServices;


namespace CBX_Web_PetShopWeb.Controllers
{

    public class TransferenciaController : Controller
    {

        public static int intIdMenuGlo { get; set; }


        //13.0  VISTA DEL HTML 
        public ActionResult TransfDatosPCaMovil(string intIdMenu)
        {
            if (Auth.isAuthenticated())
            {
                intIdMenuGlo = Convert.ToInt32(intIdMenu);
                return View();
            }

            return RedirectToAction("CerrarSesion", "LoginSiscop");
        }



        /* 
        //DataReceivedEventHandler p_DataReceived;// = new DataReceivedEventHandler();

        //13.1  VERIFICAR CONECCION DE ANDROID VIA USB
        public void VerificarAndroidConectado()
        {

            //System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();

            ProcessStartInfo psi = new ProcessStartInfo();        

            psi.FileName = @"C:\Windows\System32\cmd.exe";

            

            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;


            
            //System.Diagnostics.Process p = new System.Diagnostics.Process();
            Process p = new Process();
            p.StartInfo = psi;
            p.OutputDataReceived += p_DataReceived;
            p.EnableRaisingEvents = true;
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            p.StandardInput.WriteLine("adb devices");
            p.StandardInput.WriteLine("exit");
            p.WaitForExit();


             void p_DataReceived(object sender, DataReceivedEventArgs e)
             {
                 // Manipulate received data here
                 Console.WriteLine(e.Data);
                 // if no devices, then there will be only "List of devices attached: "
             }

        }
        //https://stackoverflow.com/questions/21222343/how-to-know-when-android-device-is-plugged-into-usb-port
        */

        public void VerificarAndroidConectado()
        {

            //var drives = DriveInfo.GetDrives();

            //var removableFatDrives = drives.Where(
            //        c => c.DriveType == DriveType.Removable &&
            //        c.DriveFormat == "FAT" &&
            //        c.IsReady);

            //var andriods = from c in removableFatDrives
            //               from d in c.RootDirectory.EnumerateDirectories()
            //               where d.Name.Contains("android")
            //               select c;

            IList<String> fullNames = new List<String>();
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                if (driveInfo.DriveType == DriveType.Removable)
                {
                    fullNames.Add(driveInfo.RootDirectory.FullName);
                }
            }

        }
        //FUENTE:https://stackoverflow.com/questions/8072650/programmatically-access-files-on-android-device-from-pc
        /* */




        ////private void button1_Click(object sender, System.EventArgs e)
        ////{
        ////    Usb usb = new Usb();
        ////    usb.OnErrorMessage += new Usb.ErrorMessage(this.ErrorMessageHandler);
        ////    if (!usb.Open("ezusb-0"))
        ////    {
        ////        return;
        ////    }
        ////    UsbDeviceDescriptor descriptor = usb.GetDeviceDescriptor();
        ////    if (descriptor != null)
        ////    {
        ////        DisplayUsbDeviceDescriptor(descriptor);
        ////    }
        ////    usb.Close();
        ////}



        /*
        public ActionResult DetectarUSB()
        {
            var availableDrives = DriveInfo.GetDrives()
            .Where(d => d.IsReady && d.DriveType == DriveType.Removable);

            return Json(1);
        }
        */





        //////Get all drives enumeration using
        ////DriveInfo di[] = DriveInfo.GetDrives();
        ////foreach(DriveInfo divinfo in fi)
        ////{
        ////         If(divinfo.IsReady)
        ////    {
        ////        Console.writeline(divinfo.DriveType);
        ////    }
        ////else
        ////Console.Writeline("Device not Ready");

        ////}

        

        public int VerificarAndroidConectado2()
        {


            //WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent  WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity'");

            //ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            //insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);

            //insertWatcher.Start();

            //insertWatcher.WaitForNextEvent();

            /////////////////////////////////////////////////////////////////////////
            //ManagementEventWatcher watcher = new ManagementEventWatcher();
            //WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            //watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            //watcher.Query = query;
            //watcher.Start();
            //watcher.WaitForNextEvent();
            ////https://stackoverflow.com/questions/620144/detecting-usb-drive-insertion-and-removal-using-windows-service-and-c-sharp
            ///////////////////////////////////////////////////////////////////////////



            return 0;

        }




        /**********************************************************************************************3

        ******************************************************************************************************/


        /**********************************************************************************************3

          public const   int DbtDevicearrival = 0x8000; // system detected a new device        
          public const   int DbtDeviceremovecomplete = 0x8004; // device is gone      
          public const   int WmDevicechange = 0x0219; // device change event      
          private const  int DbtDevtypDeviceinterface = 5;
          private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
          private static IntPtr notificationHandle;

          /// <summary>
          /// Registers a window to receive notifications when USB devices are plugged or unplugged.
          /// </summary>
          /// <param name="windowHandle">Handle to the window receiving notifications.</param>
          public static void RegisterUsbDeviceNotification(IntPtr windowHandle)
          {
              DevBroadcastDeviceinterface dbi = new DevBroadcastDeviceinterface
              {
                  DeviceType = DbtDevtypDeviceinterface,
                  Reserved = 0,
                  ClassGuid = GuidDevinterfaceUSBDevice,
                  Name = 0
              };

              dbi.Size = Marshal.SizeOf(dbi);
              IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
              Marshal.StructureToPtr(dbi, buffer, true);

              notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0);
          }

          /// <summary>
          /// Unregisters the window for USB device notifications
          /// </summary>
          public static void UnregisterUsbDeviceNotification()
          {
              UnregisterDeviceNotification(notificationHandle);
          }

          [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
          private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

          [DllImport("user32.dll")]
          private static extern bool UnregisterDeviceNotification(IntPtr handle);

          [StructLayout(LayoutKind.Sequential)]
          private struct DevBroadcastDeviceinterface
          {
              internal int Size;
              internal int DeviceType;
              internal int Reserved;
              internal Guid ClassGuid;
              internal short Name;
          }
        //FUENTE : https://stackoverflow.com/questions/1976573/using-registerdevicenotification-in-a-net-app


        ******************************************************************************************************/



        //ManagementObjectCollection collection;

        //using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub")) 
        //{
        //    collection = searcher.Get();
        //    foreach (var device in collection)
        //        {
        //            var deviceId = (string)GetPropertyValue("DeviceID");
        //    var pnpDeviceId = (string)GetPropertyValue("PNPDeviceID");
        //    var descr = (string)device.GetPropertyValue("Description");
        //    var classCode = device.GetPropertyValue("ClassCode"); //null here
        //}


        /*************************************************************************************

         //USBS DISPONIBLES CONECTADOS
         public void VerificarAndroidConectado2()
         {
             var drives = DriveInfo.GetDrives()
            .Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable); 
         //FUENTE: https://stackoverflow.com/questions/6003822/how-to-detect-a-usb-drive-has-been-plugged-in
          }
         **************************************************************************************/

        /*************************************************************************************
        //public void VerificarAndroidConectado3()
        //{
        //    var watcher = new ManagementEventWatcher();
        //    var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
        //    watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
        //    watcher.Query = query;
        //    watcher.Start();
        //}
        //https://www.generacodice.com/en/articolo/59278/detecting-usb-drive-insertion-and-removal-using-windows-service-and-c  VARIOS OTROS
        **************************************************************************************/


       /************************************************************************************* 1228PM

        private void BeginAsyncRead()
        {
            byte[] byIn = new
                byte[InputReportLength];
            System.IO.File.BeginRead(byIn, 0, InputReportLength, new AsyncCallback(ReadCompleted), byIn);
        }

        protected void ReadCompleted(IAsyncResult iResult)
        {
            byte[] byIn =
                (byte[])iResult.AsyncState;
            try
            {
                System.IO.File.EndRead(iResult);
                try
                {
                    HandleDataReceived(byIn);
                }
                finally
                {
                    BeginAsyncRead();
                }
            }
            catch (IOException ioexc)
            {
                // Device has been removed!
            }
        }
        //https://www.developerfusion.com/article/84338/making-usb-c-friendly/

    *************************************************************************************/



     public class DeviceInfo
    {

        //  determine if a specific USB device is plugged in
        //FUENTE : https://bytes.com/topic/c-sharp/answers/436368-determine-if-specific-usb-device-plugged
        //https://www.codeproject.com/Articles/6388/NET-Diving-into-System-Programming-Part-2  12:02PM

    }

        //OTRO PARA ESCRITOORIO
        //https://www.generacodice.com/en/articolo/59278/detecting-usb-drive-insertion-and-removal-using-windows-service-and-c


        //FIN
        private void botonBuscarUsbConectado(string nomusb)
        {
            //checkedListBox1.Items.Clear();
            ManagementObjectCollection collection;
            using (var findevice = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = findevice.Get();
            foreach (var device in collection)
            {

                //checkedListBox1.Items.Add(device.GetPropertyValue("DeviceID"));
                //checkedListBox1.Items.Add(device.GetPropertyValue("Description"));
                //how to Get List of connected USB Devices in c#
            }

        }






    }










}
