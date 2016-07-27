using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    class CompresGzip : IStudyTest
    {
        public byte[] Compress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory,
                CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }

        public static byte[] GetMd5HashFromGzFile(string fileName, ref string hash)
        {

            var fileInto = new FileInfo(fileName);

            if (fileInto.Extension != ".gz")
            {
                throw new Exception("To nie jest plik gz");
            }

            using (var gzFileStream = File.Open(fileName, FileMode.Open))
            {
                using (var gzOpenFileStream = new GZipStream(gzFileStream, CompressionMode.Decompress))
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] retVal = md5.ComputeHash(gzOpenFileStream);

                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < retVal.Length; i++)
                    {
                        sBuilder.Append(retVal[i].ToString("x2"));
                    }

                    hash = sBuilder.ToString();

                    return retVal;
                }
            }
        }

        public void Study()
        {
            var fileName = "gzfile";

            var xmlFile = new[]
            {
                "<?xml version=\"1.0\" encoding=\"utf-8\"?><ImportTransactionFile><Transactions><Transaction><Id>1686788390</Id><VPan>479080P000063198</VPan><CrdSeqNo>0</CrdSeqNo><DateLocal>2015-06-06</DateLocal><TimeLocal>181752</TimeLocal><TxnCode>1</TxnCode><FnCode>200</FnCode><MsgCls>2</MsgCls><MsgFn>2</MsgFn><TxnSrc>0</TxnSrc><AmtTxn>50</AmtTxn><CurTxn>978</CurTxn><AmtSet>50</AmtSet><CurSet>978</CurSet><DateSet>2015-06-08</DateSet><AmtBill>214.92</AmtBill><CurBill>985</CurBill><AmtBillCb>0</AmtBillCb><RateBill>4.2984</RateBill><AprvlCode>053526</AprvlCode><Stan>866627</Stan><Rrn>515718830281</Rrn><Arn>75432385157105088200012</Arn><CrdAcptBus>6011</CrdAcptBus><AiId>003238</AiId><AcqCountry>196</AcqCountry><CrdAcptId>0010510139</CrdAcptId><TermCode>00000008</TermCode><CrdAcptLocName>JCCATM KINGS AVENUE MA</CrdAcptLocName><CrdAcptLocStreet>TOMBS OF THE KINGS AVENUE 2</CrdAcptLocStreet><CrdAcptLocCity>Pafos</CrdAcptLocCity><CrdAcptLocCountry>196</CrdAcptLocCountry><CrdAcptLocPostcode>8046</CrdAcptLocPostcode><CrdAcptLocRegion>196</CrdAcptLocRegion><PosDataCodes>511201513344</PosDataCodes><ReasonCode>1401</ReasonCode><TextData/></Transaction><Transaction><Id>1685424852</Id><VPan>479080P000063198</VPan><CrdSeqNo>0</CrdSeqNo><DateLocal>2015-06-07</DateLocal><TimeLocal>150408</TimeLocal><TxnCode>1</TxnCode><FnCode>200</FnCode><MsgCls>2</MsgCls><MsgFn>0</MsgFn><TxnSrc>0</TxnSrc><AmtTxn>100</AmtTxn><CurTxn>985</CurTxn><AmtSet>0</AmtSet><CurSet/><DateSet>2263-08-31</DateSet><AmtBill>100</AmtBill><CurBill>985</CurBill><AmtBillCb>0</AmtBillCb><RateBill>1</RateBill><AprvlCode>085752</AprvlCode><Stan>924777</Stan><Rrn>515813924777</Rrn><Arn>24809395158515813924770</Arn><CrdAcptBus>6011</CrdAcptBus><AiId>480939</AiId><AcqCountry>616</AcqCountry><CrdAcptId>WBK S.A.</CrdAcptId><TermCode>A2213000</TermCode><CrdAcptLocName>WBK S.A.</CrdAcptLocName><CrdAcptLocStreet>RYNEK 11</CrdAcptLocStreet><CrdAcptLocCity>PACZKOW</CrdAcptLocCity><CrdAcptLocCountry>616</CrdAcptLocCountry><CrdAcptLocPostcode>48-370</CrdAcptLocPostcode><CrdAcptLocRegion/><PosDataCodes>51140151334C</PosDataCodes><ReasonCode>0</ReasonCode><TextData/></Transaction><Transaction><Id>1685430328</Id><VPan>479080P000063198</VPan><CrdSeqNo>0</CrdSeqNo><DateLocal>2015-06-07</DateLocal><TimeLocal>150758</TimeLocal><TxnCode>1</TxnCode><FnCode>200</FnCode><MsgCls>2</MsgCls><MsgFn>0</MsgFn><TxnSrc>0</TxnSrc><AmtTxn>20</AmtTxn><CurTxn>985</CurTxn><AmtSet>0</AmtSet><CurSet/><DateSet>2263-08-31</DateSet><AmtBill>20</AmtBill><CurBill>985</CurBill><AmtBillCb>0</AmtBillCb><RateBill>1</RateBill><AprvlCode>018405</AprvlCode><Stan>926209</Stan><Rrn>515813926209</Rrn><Arn>20064645158515813926201</Arn><CrdAcptBus>6011</CrdAcptBus><AiId>006464</AiId><AcqCountry>616</AcqCountry><CrdAcptId>WBK S.A.</CrdAcptId><TermCode>A1128605</TermCode><CrdAcptLocName>WBK S.A.</CrdAcptLocName><CrdAcptLocStreet>RYNEK 7</CrdAcptLocStreet><CrdAcptLocCity>KEPNO</CrdAcptLocCity><CrdAcptLocCountry>616</CrdAcptLocCountry><CrdAcptLocPostcode>63-600</CrdAcptLocPostcode><CrdAcptLocRegion/><PosDataCodes>51140151334C</PosDataCodes><ReasonCode>0</ReasonCode><TextData/></Transaction></Transactions><Check><Number>3</Number><Value>170</Value></Check></ImportTransactionFile>"
            };

            File.WriteAllText("xml.txt",
                "<?xml version=\"1.0\" encoding=\"utf-8\"?><ImportTransactionFile><Transactions><Transaction><Id>1686788390</Id><VPan>479080P000063198</VPan><CrdSeqNo>0</CrdSeqNo><DateLocal>2015-06-06</DateLocal><TimeLocal>181752</TimeLocal><TxnCode>1</TxnCode><FnCode>200</FnCode><MsgCls>2</MsgCls><MsgFn>2</MsgFn><TxnSrc>0</TxnSrc><AmtTxn>50</AmtTxn><CurTxn>978</CurTxn><AmtSet>50</AmtSet><CurSet>978</CurSet><DateSet>2015-06-08</DateSet><AmtBill>214.92</AmtBill><CurBill>985</CurBill><AmtBillCb>0</AmtBillCb><RateBill>4.2984</RateBill><AprvlCode>053526</AprvlCode><Stan>866627</Stan><Rrn>515718830281</Rrn><Arn>75432385157105088200012</Arn><CrdAcptBus>6011</CrdAcptBus><AiId>003238</AiId><AcqCountry>196</AcqCountry><CrdAcptId>0010510139</CrdAcptId><TermCode>00000008</TermCode><CrdAcptLocName>JCCATM KINGS AVENUE MA</CrdAcptLocName><CrdAcptLocStreet>TOMBS OF THE KINGS AVENUE 2</CrdAcptLocStreet><CrdAcptLocCity>Pafos</CrdAcptLocCity><CrdAcptLocCountry>196</CrdAcptLocCountry><CrdAcptLocPostcode>8046</CrdAcptLocPostcode><CrdAcptLocRegion>196</CrdAcptLocRegion><PosDataCodes>511201513344</PosDataCodes><ReasonCode>1401</ReasonCode><TextData/></Transaction><Transaction><Id>1685424852</Id><VPan>479080P000063198</VPan><CrdSeqNo>0</CrdSeqNo><DateLocal>2015-06-07</DateLocal><TimeLocal>150408</TimeLocal><TxnCode>1</TxnCode><FnCode>200</FnCode><MsgCls>2</MsgCls><MsgFn>0</MsgFn><TxnSrc>0</TxnSrc><AmtTxn>100</AmtTxn><CurTxn>985</CurTxn><AmtSet>0</AmtSet><CurSet/><DateSet>2263-08-31</DateSet><AmtBill>100</AmtBill><CurBill>985</CurBill><AmtBillCb>0</AmtBillCb><RateBill>1</RateBill><AprvlCode>085752</AprvlCode><Stan>924777</Stan><Rrn>515813924777</Rrn><Arn>24809395158515813924770</Arn><CrdAcptBus>6011</CrdAcptBus><AiId>480939</AiId><AcqCountry>616</AcqCountry><CrdAcptId>WBK S.A.</CrdAcptId><TermCode>A2213000</TermCode><CrdAcptLocName>WBK S.A.</CrdAcptLocName><CrdAcptLocStreet>RYNEK 11</CrdAcptLocStreet><CrdAcptLocCity>PACZKOW</CrdAcptLocCity><CrdAcptLocCountry>616</CrdAcptLocCountry><CrdAcptLocPostcode>48-370</CrdAcptLocPostcode><CrdAcptLocRegion/><PosDataCodes>51140151334C</PosDataCodes><ReasonCode>0</ReasonCode><TextData/></Transaction><Transaction><Id>1685430328</Id><VPan>479080P000063198</VPan><CrdSeqNo>0</CrdSeqNo><DateLocal>2015-06-07</DateLocal><TimeLocal>150758</TimeLocal><TxnCode>1</TxnCode><FnCode>200</FnCode><MsgCls>2</MsgCls><MsgFn>0</MsgFn><TxnSrc>0</TxnSrc><AmtTxn>20</AmtTxn><CurTxn>985</CurTxn><AmtSet>0</AmtSet><CurSet/><DateSet>2263-08-31</DateSet><AmtBill>20</AmtBill><CurBill>985</CurBill><AmtBillCb>0</AmtBillCb><RateBill>1</RateBill><AprvlCode>018405</AprvlCode><Stan>926209</Stan><Rrn>515813926209</Rrn><Arn>20064645158515813926201</Arn><CrdAcptBus>6011</CrdAcptBus><AiId>006464</AiId><AcqCountry>616</AcqCountry><CrdAcptId>WBK S.A.</CrdAcptId><TermCode>A1128605</TermCode><CrdAcptLocName>WBK S.A.</CrdAcptLocName><CrdAcptLocStreet>RYNEK 7</CrdAcptLocStreet><CrdAcptLocCity>KEPNO</CrdAcptLocCity><CrdAcptLocCountry>616</CrdAcptLocCountry><CrdAcptLocPostcode>63-600</CrdAcptLocPostcode><CrdAcptLocRegion/><PosDataCodes>51140151334C</PosDataCodes><ReasonCode>0</ReasonCode><TextData/></Transaction></Transactions><Check><Number>3</Number><Value>170</Value></Check></ImportTransactionFile>");

            var byteArray = File.ReadAllBytes(fileName);

            var compresByteArry = this.Compress(byteArray);

            File.WriteAllBytes($"{fileName}.gz", compresByteArry);
        }
    }
}
