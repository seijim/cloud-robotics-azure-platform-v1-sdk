1) Python in Pepper については、バイナリコードが導入できない為、Azure IoT Hub SDK が利用できません。
   その為、このフォルダーの Python 用 REST API (HTTP/MQTT) サンプルコードをご利用ください。


2) C, C#, C# in UWP, Java, Node.js, Python(not in Pepper) の各言語については、Azure IoT Hub SDK のサンプルコードをご利用ください。

   - IoT Hub SDK in GitHub
     https://github.com/Azure/azure-iot-sdks

   - IoT Hub Document for .NET (C#) -- UWPの場合は、GitHub のサンプルコードを直接ご覧ください
     https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-csharp-csharp-getstarted

   - IoT Hub Document for Java
     https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-java-java-getstarted

   - IoT Hub Document for Node.js
     https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-node-node-getstarted

   - IoT Hub Device SDK Document for C
     https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-device-sdk-c-intro


3) 通信フォーマットについては、Cloud Robotics Azure Platform Hands-on Document に詳細を記載しています

   ● D2D(Device to Device(s))を指定した場合

       ## Send Format (JSON)
	{
		"RbHeader":{
        		"RoutingType": "D2D",
		        "RoutingKeyword": "Default",
		        "AppId": "<アプリケーションシステム名>",
		        "AppProcessingId": "<無指定か、呼び出したい AppDLL 登録名>",
		        "MessageId": "<アプリケーションに渡したい処理 ID>",
		        "MessageSeqno": "<送信連番>",
		        "SendDateTime": "<送信日時>"
		},
		"RbBody":{
	      		/* アプリケーションが自由に設定 */
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
			"SendDateTime":"2016-11-20T08:10:29.329"
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


   ● CALL (AppDLL の呼び出しのみ) を指定した場合

       ## Send Format (JSON)
	{
		"RbHeader":{
        		"RoutingType": "CALL",
		        "RoutingKeyword": "",
		        "AppId": "<アプリケーションシステム名>",
		        "AppProcessingId": "<呼び出したい AppDLL 登録名>",
		        "MessageId": "<アプリケーションに渡したい処理 ID>",
		        "MessageSeqno": "<送信連番>",
		        "SendDateTime": "<送信日時>"
		},
		"RbBody":{
	      		/* アプリケーションが自由に設定 */
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


   ● LOG (Cloud Robotics FX はスルー) を指定した場合

       ## Send Format (JSON)
	{
		"RbHeader":{
        		"RoutingType": "LOG",
		        "MessageSeqno": "<送信連番>",
		        "SendDateTime": "<送信日時>"
		},
		"RbBody":{
	      		/* アプリケーションが自由に設定 */
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

