using System;
using System.IO;
using System.Xml.Serialization;


namespace RoomForRentXmlDataAccess
{
    internal class XmlDataAccess
    {
        #region Methods
        public static T Load<T>(string xmlFile)
        {
            using (var reader = new StreamReader(xmlFile))
            {
                var xmlSer = CreateSerializer(typeof(T));
                return (T)xmlSer.Deserialize(reader);
            }
        }

        public static void Save<T>(T data, string xmlFile)
        {
            using (var writer = new StreamWriter(xmlFile))
            {
                var xmlSer = CreateSerializer(typeof(T));
                xmlSer.Serialize(writer, data);
            }
        }
        #endregion


        #region Implementation
        private static XmlSerializer CreateSerializer(Type type)
        {
            return new XmlSerializer(type);
        }
        #endregion
    }
}