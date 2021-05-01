using System.Xml.Serialization;
using System.IO;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DialogueSerializerPrototype
{
	[Guid("8C034F6A-1D3F-4DB8-BC99-B73873D8C297")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces(typeof(ISerializator))]
	[ComVisible(true)]
	public class XmlSerializerImp : ISerializator
	{
		XmlSerializer xmlSerializer;

		public void Deserialize(object objToDeserialize, string path)
		{
			try
			{
				using(FileStream fs = new FileStream(path, FileMode.Open))
				{
					objToDeserialize = xmlSerializer.Deserialize(fs);

					Console.WriteLine("Объект десериализован");
				}
			}
			catch(Exception exc)
			{
				Console.WriteLine(exc.Message);
			}
		}

		public void Serialize(object objToSerialize, string path)
		{
			try
			{
				xmlSerializer = new XmlSerializer(objToSerialize.GetType());
				using (FileStream fs = new FileStream(path, FileMode.Create))
				{
					xmlSerializer.Serialize(fs, objToSerialize);

					MessageBox.Show("Serilized");
				}
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
	}
}
