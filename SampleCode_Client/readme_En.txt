1) You can't use Python code provided by Azure IoT Hub SDK in Pepper because not installed into it.
   So please see the sample codes in this "Python" folder.
   You can find sample codes using REST API for Python on HTTP or MQTT.


2) You can use sample codes provided by Azure IoT Hub SDK.
   You can find sample codes for C, C#, C# in UWP, Java, Node.js, Python(not in Pepper).

   - IoT Hub SDK in GitHub
     https://github.com/Azure/azure-iot-sdks

   - IoT Hub Document for .NET (C#) -- In the case of UWP, please directly see the GitHub sample codes
     https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-csharp-csharp-getstarted

   - IoT Hub Document for Java
     https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-java-java-getstarted

   - IoT Hub Document for Node.js
     https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-node-node-getstarted

   - IoT Hub Device SDK Document for C
     https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-device-sdk-c-intro


3) Cloud Robotics Communications format is detailed in Cloud Robotics Azure Platform Hands-on Document.

   ● Case of D2D (Device to Device(s))

       ## Send Format (JSON)
	{
		"RbHeader":{
        		"RoutingType": "D2D",
		        "RoutingKeyword": "Default",
		        "AppId": "<application system name>",
		        "AppProcessingId": "<Empty or AppDLL registration name>",
		        "MessageId": "<Empty or anything for AppDLL>",
		        "MessageSeqno": "<send serial number>",
		        "SendDateTime": "<send datetime>"
		},
		"RbBody":{
	      		/* you can use set anything for application */
		}
	}

     #################
     # D2D Example
     #################

       ## Send Format (JSON) -- device A
	{
		"RbHeader":{
	        	"RoutingType":"D2D",
			"RoutingKeyword":"Default",
			"AppId":"PepperShopApp",
			"AppProcessingId":"",
			"MessageId":"detect",
			"MessageSeqno":1,
			"SendDateTime":"2016-11-20 08:10:29.329"
		},
		"RbBody":{
			"visitor":"u001",
			"gender":"f",
			"age":"29"
		}	
	}

       ## Receive Format (JSON) -- device B
	{
		"RbHeader":{
	        	"RoutingType":"D2D",
			"RoutingKeyword":"Default",
			"AppId":"PepperShopApp",
			"AppProcessingId":"",
			"MessageId":"detect",
			"MessageSeqno":1,
			"SendDateTime":"2016-11-20T08:10:29.329",
			"SourceDeviceId":"ms_pepper01",
			"SourceDeviceType":"Pepper",
			"SourceDevRescGroupId":"",
			"TargetType":"Device",
			"TargetDeviceGroupId":"",
			"TargetDeviceId":"ms_hub01",
			"ProcessingStack":""
		},
		"RbBody":{
			"visitor":"u001",
			"gender":"f",
			"age":"29"
		}	
	}


   ● Case of CALL (only call AppDLL)

       ## Send Format (JSON)
	{
		"RbHeader":{
        		"RoutingType": "CALL",
		        "RoutingKeyword": "",
		        "AppId": "<applicatin system name>",
		        "AppProcessingId": "<AppDLL registration name>",
		        "MessageId": "<Empty or anything for AppDLL>",
		        "MessageSeqno": "<send serial number>",
		        "SendDateTime": "<send datetime>"
		},
		"RbBody":{
	      		/* you can use set anything for application */
		}
	}

     #################
     # CALL Example
     #################

       ## Send Format (JSON) -- device A
	{
		"RbHeader":{
	        	"RoutingType":"CALL",
			"RoutingKeyword":"",
			"AppId":"PepperShopApp",
			"AppProcessingId":"RbSampleApp",
			"MessageId": "SayHello",
			"MessageSeqno": "1",
			"SendDateTime": "2016-11-20 08:27:03.961"
	},
		"RbBody": {
			"visitor": "u002"
		}	
	}

       ## Receive Format (JSON) -- device A (same device)
	{
		"RbHeader":{
	        	"RoutingType":"CALL",
			"RoutingKeyword":"Default",
			"AppId":"PepperShopApp",
			"AppProcessingId":"RbSampleApp",
			"MessageId":"SayHello",
			"MessageSeqno":1,
			"SendDateTime":"2016-11-20T08:27:03.961",
			"SourceDeviceId":"ms_pepper01",
			"SourceDeviceType":"",
			"SourceDevRescGroupId":"",
			"TargetType":"Device",
			"TargetDeviceGroupId":"",
			"TargetDeviceId":"ms_pepper01",
			"ProcessingStack":"RbSampleApp.dll"
		},
		"RbBody":{
			"Hello":"Hello World !!!!!!"
		}
	}


   ● Case of LOG (pass through Cloud Robotics FX)

       ## Send Format (JSON)
	{
		"RbHeader":{
        		"RoutingType": "LOG",
		        "MessageSeqno": "<send serial number>",
		        "SendDateTime": "<send datetime>"
		},
		"RbBody":{
	      		/* you can use set anything for application */
		}
	}

     #################
     # CALL Example
     #################

       ## Send Format (JSON) -- device A
	{
		"RbHeader":{
	        	"RoutingType":"LOG",
			"MessageSeqno": "1",
			"SendDateTime": "2016-11-20 08:27:03.961"
	},
		"RbBody": {
			"EventMessage": "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
		}	
	}


