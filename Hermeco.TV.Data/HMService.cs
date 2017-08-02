using Hermeco.TV.Data.AviableReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Hermeco.TV.Data
{
    public abstract class HMService : IDisposable
    {
        private DataSet dsResultQuery;
        private string resultMessage = String.Empty;

        internal IAviableReports aviableReports;
        public string objectName;
        public Dictionary<string, string> queryParameters = null;


        public HMService()
        {
            queryParameters = new Dictionary<string, string>();
        }


        public DataSet RequestResult()
        {
            ChannelFactory<IAviableReports> channelFactory = HMChannelFactory.Instance;
            aviableReports = channelFactory.CreateChannel();
            if (aviableReports == null)
            {
                throw new Exception("It was not possible to connect to the Application Server, please contact your system administrator");
            }
            return RunService(objectName, queryParameters);
        }

        public DataSet RequestResult(string ObjectName, Dictionary<string, string> QueryParameters)
        {
            objectName = ObjectName;
            queryParameters = QueryParameters;
            return RequestResult();
        }

        private DataSet RunService(string objectName, Dictionary<string, string> QueryParameters)
        {
            try
            {
                var hresult = aviableReports.GetData(objectName, QueryParameters);
                dsResultQuery = DecompressedData(hresult);
                hresult = null;
                GC.Collect();
            }
            catch 
            {
                return null;
            }
            return dsResultQuery;
        }

        public void Dispose()
        {
            if (dsResultQuery != null)
            {
                dsResultQuery.Dispose();
                dsResultQuery = null;
            }

            if (queryParameters != null)
            {
                queryParameters = null;
            }
        }

        public static DataSet DecompressedData(Object objectData)
        {
            try
            {
                DataSet dsData = new DataSet("ResultData");
                byte[] data = (byte[])objectData;
                MemoryStream stream = new MemoryStream(data);
                GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress);
                dsData.ReadXml(zipStream, XmlReadMode.ReadSchema);
                zipStream.Close();
                stream.Close();

                data = null;
                zipStream.Dispose();
                stream.Dispose();

                return dsData;
            }
            catch 
            {
                //TODO: logging on WCF logging service
                return null;
            }
        }
    }
}