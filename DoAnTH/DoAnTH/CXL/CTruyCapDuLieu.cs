﻿using DoAnTH.CQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace DoAnTH
{
    [Serializable]
    internal class CTruyCapDuLieu
    {
        private static CTruyCapDuLieu _instance = null;
        private List<CLoaiThuoc> dsLT;
        private List<CThuoc> dsT;
        private List<CBenhNhan> dsBN;
        private List<CBacSi> dsBS;
        private List<CPhieuKham> dsPK;
        private List<CChiTietPhieuKham> dsCtpk;
        private static string filename = "ds.txt";
        private CTruyCapDuLieu()
        {
            dsLT = new List<CLoaiThuoc>();
            dsT = new List<CThuoc>();
            dsBN = new List<CBenhNhan>();
            dsBS = new List<CBacSi>();
            dsPK = new List<CPhieuKham>();
            dsCtpk = new List<CChiTietPhieuKham>();
        }
        public static CTruyCapDuLieu khoiTao()
        {
            if (_instance == null)
            {
                _instance = new CTruyCapDuLieu();
            }
            return _instance;
        }
        public List<CLoaiThuoc> DSLT => dsLT;
        public List<CThuoc> DST=> dsT;
        
        public List<CBacSi> DSBS => dsBS;

        public List<CBenhNhan> DSBN =>dsBN;

        public List<CPhieuKham> DSPK => dsPK;
        public List<CChiTietPhieuKham> DSCTPK => dsCtpk;
        public void docfile()
        {
            FileStream file = null;
            try
            {
                file = new FileStream(filename, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                _instance = (CTruyCapDuLieu)formatter.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                file?.Close();
                throw ex;
            }
        }
        public void ghifile()
        {
            FileStream file = null;
            try
            {
                file = new FileStream(filename, FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, _instance);
                file.Close();
            }
            catch (Exception ex)
            {
                file?.Close();
                throw ex;
            }
        }
    }
}
