
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Modul7_1302200097
{
    class program
    {
        static void Main(string[] args)
        {

        }
    }

    class BankTransferConfig
    {
        public PesanBankConfig PesanBank { get; set; }
        public int JumlahTransfer { get; set; }
        public List <string> jenisFee { get; set; }

        public BankTransferConfig() { }

        public BankTransferConfig(PesanBankConfig pesanBank, int JumlahTransfer, List <string> jenisFee)
        {
            this.PesanBank = pesanBank; 
            this.JumlahTransfer = JumlahTransfer;
            this.jenisFee = jenisFee;
        }
    }

    class HitungFeeConfig
    {
        public BankTransferConfig conf;
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        public string fileConfigName = "bank_transfer_config.json";

        public HitungFeeConfig()
        {
            {
                try
                {
                    ReadConfigFile();
                }
                catch (Exception)
                {
                    SetDefault();
                    WriteNewConfigFile();
                }
            }
        }

        public BankTransferConfig ReadConfigFile()
        {
            string jsonStringFromFile = File.ReadAllText(path + "/" + fileConfigName);
            conf = JsonSerializer.Deserialize<BankTransferConfig>(jsonStringFromFile);
            return conf;
        }

        private void SetDefault()
        {
          
        }

        private void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(conf, options);
            string fullFilePath = path + "/" + fileConfigName;
            File.WriteAllText(fullFilePath, jsonString);
        }
    }

    class PesanBankConfig
    {
        public string en { get; set; }
        public string id { get; set; }

        public PesanBankConfig() { }

        public PesanBankConfig(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
}

