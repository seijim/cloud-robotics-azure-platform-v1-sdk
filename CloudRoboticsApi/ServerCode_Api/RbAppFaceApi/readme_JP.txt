①SQLフォルダー以下にある SQL スクリプト「CreateTable_PersonInfo.sql」を SQLDB 上で実行しておきます。

②Cloud Robotics Definition & Management Tool を起動し、App Master タブに切り替え、対象の AppId の Update を行います。
　App Info (Enc) カラムに対して、以下のような JSON を設定して、Update を行ってください。

{
 "SqlConnString": "Server=tcp:XXXXXXXX.database.windows.net,1433;Database=XXXXX;User ID=XXXXXXXX;Password=XXXXXXXX;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
 "StorageAccount": "XXXXXXXXXXXXX",
 "StorageKey": "XXXXXXXXXXXXXXXX",
 "StorageContainer": "cogapifiles",
 "FaceApiEndpoint": "https://westus.api.cognitive.microsoft.com/face/v1.0",
 "FaceApiKey": "XXXXXXXXXXXXXXXX",
 "FaceConfidence": "0.5",
 "SmileConfidence": "0.5",
 "FacialHairConfidence": "0.65"
}


※StorageAccount	: Pepper が写真をアップロードする先のストレージアカウントです
※StorageKey		: Pepper が写真をアップロードする先のストレージキーです
※StorageContainer	: Pepper が写真をアップロードする先のストレージコンテナです
※FaceApiEndpoint	: Cognitive Services Face API の エンドポイントです
※FaceApiKey		: Cognitive Services Face API の API キーです
※FaceConfidence	: 顔特定の信頼確率の閾値です
※SmileConfidence	: 笑顔かどうかを判定する信頼確率の閾値です
※FacialHairConfidence	: 髭が生えているかどうかを判定する信頼確率の閾値です
