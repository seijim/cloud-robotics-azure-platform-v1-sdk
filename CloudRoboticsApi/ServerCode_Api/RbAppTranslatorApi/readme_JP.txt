①Cloud Robotics Definition & Management Tool を起動し、App Master タブに切り替え、対象の AppId の Update を行います。
　App Info (Enc) カラムに対して、以下のような JSON を設定して、Update を行ってください。

{
 "TranslatorApiKey": "xxxxxxxxxxxxxxxxxxxxxxxxxxx"
}


※TranslatorApiKey	: Cognitive Services Translator Text API の API キーです



②ログデータを可視化・分析する場合
　・SQL_ASA フォルダー以下にある SQL スクリプト「CreateLogTables.sql」を SQLDB 上で実行します
　・SQL_ASA フォルダー以下にある Azure Stream Analytics Query を利用し、 IoT Hub (Device からの入力)
　　と Evnet Hubs (Cloud Robotics FX の C2D ログ)に入ったデータを SQLDB のテーブルに書き出します

