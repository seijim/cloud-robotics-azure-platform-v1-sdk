<?xml version="1.0" encoding="UTF-8" ?>
<Package name="cloudroboticsapi_handson" format_version="4">
    <Manifest src="manifest.xml" />
    <BehaviorDescriptions>
        <BehaviorDescription name="behavior" src="sample1" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="handson1" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="sample2" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="handson1_ans" xar="behavior.xar" />
    </BehaviorDescriptions>
    <Dialogs />
    <Resources>
        <File name="__init__" src="lib/cloudrobotics/__init__.py" />
        <File name="ca" src="lib/cloudrobotics/cert/ca.cer" />
        <File name="client" src="lib/cloudrobotics/client.py" />
        <File name="__init__" src="lib/cloudrobotics/facerecognition/__init__.py" />
        <File name="client" src="lib/cloudrobotics/facerecognition/client.py" />
        <File name="message" src="lib/cloudrobotics/facerecognition/message.py" />
        <File name="message" src="lib/cloudrobotics/message.py" />
        <File name="__init__" src="lib/paho/__init__.py" />
        <File name="__init__" src="lib/paho/mqtt/__init__.py" />
        <File name="client" src="lib/paho/mqtt/client.py" />
        <File name="publish" src="lib/paho/mqtt/publish.py" />
        <File name="subscribe" src="lib/paho/mqtt/subscribe.py" />
        <File name="storage" src="lib/cloudrobotics/storage.py" />
        <File name="pikon" src="sound/pikon.ogg" />
        <File name="__init__" src="lib/cloudrobotics/picturerecognition/__init__.py" />
        <File name="client" src="lib/cloudrobotics/picturerecognition/client.py" />
        <File name="message" src="lib/cloudrobotics/picturerecognition/message.py" />
        <File name="icon" src="icon.png" />
        <File name="picture1" src="html/picture1.jpg" />
        <File name="picture2" src="html/picture2.jpg" />
        <File name="picture3" src="html/picture3.jpg" />
        <File name="picture4" src="html/picture4.jpg" />
    </Resources>
    <Topics />
    <IgnoredPaths />
    <Translations auto-fill="en_US">
        <Translation name="translation_en_US" src="translations/translation_en_US.ts" language="en_US" />
        <Translation name="translation_ja_JP" src="translations/translation_ja_JP.ts" language="ja_JP" />
    </Translations>
</Package>
