# Cloud Robotics SDK V1.5
--Japanese follows English.（日本語は、英語の後に記載しています）

Cloud Robotics Azure Platform V1 SDK includes Cloud Robotics FX (V1) and client tools. Cloud Robotics FX (V1) is a Azure Cloud Services based application server for Azure IoT Hub. It provides features of device routing, application routing and device control. 

The below link describes the details which are architecuture and how to setup Azure services (IoT Hub, SQL Database, Cloud Services, Stream Analytics and Power BI), client tools and deploy Cloud Robotics FX (V1).

https://github.com/seijim/cloud-robotics-azure-platform-v1-sdk/blob/master/Cloud%20Robotics%20v1.0%20Hands-on_v1.5_En.pdf

Cloud Robotics SDK V1.5 is now available. It's fixed bugs, and improved scalability and availability. IoT Hub has throttling mechanism on D2C message and C2D message as described in the below link and C2D capacity is one-tenth of D2C one. So I added the new option of sending C2D message via Azure Storage Queue. 

https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-quotas-throttling

You can activate the feature by setting "true" on Cloud Robotics FX (V1) Cloud Services application parameter "StorageQueue.SendEnabled" and setting the same storage (connection string) as Cloud Services application parameter "IoTHub.StorageAccountName" on "Queue Storage Connection String" in CloudRoboticsDefTool Connection tab.

In addition a new tool for load test called "CRoboLoadTest" is released in the SDK V1.5.

Let's try V1.5. 


--

Cloud Robotics Azure Platform V1 SDK は、Cloud Robotics FX (V1) とクライアントツール群で構成されています。Cloud Robotics FX (V1) は、Azure IoT Hub を対象にしたクラウドサービス ベースの アプリケーション サーバーです。デバイス ルーティング、アプリケーション ルーティング、デバイス制御などの機能を提供しています。

詳細は、以下のリンクをご確認ください。アーキテクチャ、Azure サービス (IoT Hub, SQL Database, Cloud Services, Stream Analytics and Power BI) や クライアントツールのセットアップ方法、Cloud Robotics FX (V1) のディプロイ方法について記載しています。

https://github.com/seijim/cloud-robotics-azure-platform-v1-sdk/blob/master/Cloud%20Robotics%20v1.0%20Hands-on_v1.5_Jp.pdf

Cloud Robotics SDK V1.5 をリリースしました。バグの修正とともに、スケーラビリティと可用性を改善しています。下記リンクに記載されているように、IoT Hub は、D2C メッセージと C2D メッセージに対するスロットリング メカニズムを持っており、C2D メッセージのキャパシティは、D2C に比べて、1/10 のキャパシティです。その為、Azure Storage Queue 経由で、C2D メッセージを送る新しいオプションを追加しました。

https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-devguide-quotas-throttling

この機能を有効にするには、Cloud Roboitcs FX (V1) Cloud Services のアプリケーション パラメータである "StorageQueue.SendEnabled" を "true" に設定し、CloudRoboticsDefTool の Connection タブにある "Queue Storage Connection String" に Cloud Services アプリケーション パラメータである "IoTHub.StorageAccountName" と同じストレージ アカウントの接続文字列を設定します。

加えて、この SDK V1.5 の中に、CRoboLoadTest という名称のロードテスト用の新しいツールをリリースしました。

是非、バージョン 1.5 を試してみてください。
