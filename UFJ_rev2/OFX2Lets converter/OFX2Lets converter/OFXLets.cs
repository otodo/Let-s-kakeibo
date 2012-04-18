using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CSharp.Japanese.Kanaxs;

namespace OFX2Lets
{
    class OFXLets
    {        
        private string[] alldata = new string[1];
        private string[] headdata = new string[1];
        private string[] footdata = new string[1];

        struct journalBook
        {
            public string paytype;
            public string date;
            public string comment;
            public int payment;
            public string fitid;
            public string shop;
        }

        struct converttable
        {
            public string bef_col;
            public string before;
            public string aft_col;
            public string after;
        }


        private journalBook[] amountdata = new journalBook[1];
        private converttable[] table = new converttable[1];


        public void getdata(string inputfile)
        {
            StreamReader reader = new StreamReader(inputfile, Encoding.UTF8);
            //全てのデータを取り込む
            string line;
            int i = 0;            
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Replace("\r", "").Replace("\n", "");
                line = Regex.Replace(line, @"\s+", "");
                alldata[i] = line;
                i++;
                Array.Resize<string>(ref alldata, i + 1);
            }
            Array.Resize<string>(ref alldata, i);   //最後のwhile文から抜けてきたとき1つ大きな配列になるため、リセット
            reader.Close();
            pickupdata();
        }

        private void pickupdata()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int l = 0;
            while (i < alldata.Length)
            {
                if (Regex.IsMatch(alldata[i],@"^OFXHEADER"))
                {
                    while ((alldata[i] != "<STMTTRN>") && (i < alldata.Length))
                    {
                        headdata[j] = alldata[i];
                        j++;
                        Array.Resize<string>(ref headdata, j + 1);
                        i++;
                    }
                }
                else if (alldata[i] == "<STMTTRN>")
                {
                    while ((alldata[i] != "</STMTTRN>") && (i < alldata.Length))
                    {
                        string temp;
                        if (alldata[i].StartsWith("<TRNTYPE>"))
                            amountdata[k].paytype = Regex.Replace(alldata[i], @"<TRNTYPE>", "");
                        else if (alldata[i].StartsWith("<DTPOSTED>"))
                            amountdata[k].date = Regex.Replace(alldata[i], @"<DTPOSTED>","");
                        else if (alldata[i].StartsWith("<TRNAMT>"))
                        {
                            temp = Regex.Replace(alldata[i], @"<TRNAMT>", "");
                            amountdata[k].payment = int.Parse(temp);
                        }
                        else if (alldata[i].StartsWith("<FITID>"))
                            amountdata[k].fitid = Regex.Replace(alldata[i], @"<FITID>", "");
                        else if (alldata[i].StartsWith("<NAME>"))
                            amountdata[k].shop = Regex.Replace(alldata[i], @"<NAME>", "");
                        else if (alldata[i].StartsWith("<MEMO>"))
                            amountdata[k].comment = Regex.Replace(alldata[i], @"<MEMO>", "");
                        i++;                        
                    }
                    k++;
                    Array.Resize<journalBook>(ref amountdata, k + 1);
                }
                else if (alldata[i] == "</BANKTRANLIST>")
                {
                    while (i < alldata.Length)
                    {
                        footdata[l] = alldata[i];
                        l++;
                        Array.Resize<string>(ref footdata, l + 1);
                        i++;
                    }
                }
                i++;    //無限ループ回避用
            }
            
            //配列のサイズを適正化
            Array.Resize<string>(ref headdata, j);
            Array.Resize<journalBook>(ref amountdata, k);
            Array.Resize<string>(ref footdata, l);
        }


        public void convert(string convertTable)
        {
            //変換テーブルの読み込み
            StreamReader tablefile = new StreamReader(convertTable, Encoding.UTF8);
            
            int i = 0;
            string line;
            while ((line = tablefile.ReadLine()) != null)
            {
                line = line.Replace("\r", "").Replace("\n", "");
                line = Regex.Replace(line, @"\s+", "");
                string[] eachdata = line.Split(',');

                //convert tableは変更後のカラムが変更前のカラムと同一の場合、省略可能
                //その際、eachdataの配列数は3つになる
                if (eachdata.Length == 3)
                {
                    table[i].bef_col = eachdata[0];
                    table[i].before = eachdata[1];
                    table[i].aft_col = eachdata[0];
                    table[i].after = eachdata[2];
                }
                else if (eachdata.Length == 4)  //変更前後のカラムが異なる場合、配列数は4
                {
                    table[i].bef_col = eachdata[0];
                    table[i].before = eachdata[1];
                    table[i].aft_col = eachdata[2];
                    table[i].after = eachdata[3];
                }
                i++;
                Array.Resize<converttable>(ref table, i + 1);
            }
            Array.Resize<converttable>(ref table, i);
            tablefile.Close();

            i = 0;
            //変換開始
            while (i < amountdata.Length)
            {
                foreach (converttable ctable in table)
                {
                    if (ctable.bef_col == "NAME")
                    {
                        if (amountdata[i].shop == ctable.before)
                        {
                            if (ctable.aft_col == "NAME")                            
                                amountdata[i].shop = ctable.after;                            
                            else if (ctable.aft_col == "MEMO")                            
                                amountdata[i].comment = ctable.after;                            
                        }
                    }
                    else if (ctable.bef_col == "MEMO")
                    {
                        if (amountdata[i].comment == ctable.before)
                        {
                            if (ctable.aft_col == "NAME")
                                amountdata[i].shop = ctable.after;
                            else if (ctable.aft_col == "MEMO")
                                amountdata[i].comment = ctable.after;
                        }
                    }
                    else if (ctable.bef_col == "TRNAMT")
                    {
                        if (amountdata[i].payment == int.Parse(ctable.before))
                        {
                            if (ctable.aft_col == "NAME")
                                amountdata[i].shop = ctable.after;
                            else if (ctable.aft_col == "MEMO")
                                amountdata[i].comment = ctable.after;
                        }
                    }
                }

                amountdata[i].shop =    commonconvert(amountdata[i].shop);
                amountdata[i].comment = commonconvert(amountdata[i].comment);
                i++;
            }
        }


        private string commonconvert(string data)
        {
            string conv_data;
            conv_data = data;
            if (conv_data != null)
            {
                conv_data = CSharp.Japanese.Kanaxs.Kana.ToHankaku(conv_data);
                conv_data = CSharp.Japanese.Kanaxs.Kana.ToZenkakuKana(conv_data);
                if (Regex.IsMatch(conv_data,@"[^a-zA-Z]-"))
                {
                    conv_data.Replace('-', 'ー');
                }
            }
            return conv_data;
        }


        public void writefile(string outputfile)
        {
            StreamWriter writefile = new StreamWriter(new FileStream(outputfile, FileMode.Create));
            foreach (string line in headdata)
            {
                writefile.WriteLine(line);
            }
            foreach (journalBook eachdata in amountdata)
            {
                writefile.WriteLine("<STMTTRN>");
                writefile.WriteLine("\t<TRNTYPE>" + eachdata.paytype);
                writefile.WriteLine("\t<DTPOSTED>" + eachdata.date);
                writefile.WriteLine("\t<TRNAMT>" + eachdata.payment);
                writefile.WriteLine("\t<FITID>" + eachdata.fitid);
                writefile.WriteLine("\t<NAME>" + eachdata.shop);
                writefile.WriteLine("\t<MEMO>" + eachdata.comment);
                writefile.WriteLine("</STMTTRN>");
            }
            foreach (string line in footdata)
            {
                writefile.WriteLine(line);
            }
            writefile.Close();
        }


        public void debug_print(string outputfile)
        {
            StreamWriter debugfile = new StreamWriter(new FileStream(outputfile, FileMode.Create));
            debugfile.WriteLine("元データ");
            debugfile.WriteLine("-----------------------");
            foreach (string line in alldata)
            {
                debugfile.WriteLine(line);
            }
            
            debugfile.WriteLine("\n\nヘッダ");
            debugfile.WriteLine("-----------------------");
            foreach (string line in headdata)
            {
                debugfile.WriteLine(line);
            }

            debugfile.WriteLine("\n\n フッター");
            debugfile.WriteLine("-----------------------");
            foreach (string line in footdata)
            {
                debugfile.WriteLine(line);
            }

            debugfile.WriteLine("\n\nお店とコメント");
            foreach (journalBook eachamount in amountdata)
            {
                debugfile.Write(eachamount.shop + "\t, ");
                debugfile.WriteLine(eachamount.comment);
            }
            debugfile.Close();
        }
    }
}
