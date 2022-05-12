using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Services
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
	[ServiceContract]
	public interface IWeatherService
	{

		[OperationContract]
		string GetWheather(string localtioncode);

		[OperationContract]
		WeatherDetailsResponse GetWheatherDetails(WeatherDetailsRequest composite);

		// TODO: Add your service operations here
	}

	public class WeatherDetailsResponse
	{

		public string DetailDescription { get; set; }

		public bool IsRainning { get; set; }

		public string Temperature { get; set; }
	}

	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class WeatherDetailsRequest
	{
		bool fullDescription = true;
		string stringValue = "pt";

		[DataMember]
		public bool FullDescription
		{
			get { return fullDescription; }
			set { fullDescription = value; }
		}

		[DataMember]
		public string CountryCode
		{
			get { return stringValue; }
			set { stringValue = value; }
		}
	}
}
