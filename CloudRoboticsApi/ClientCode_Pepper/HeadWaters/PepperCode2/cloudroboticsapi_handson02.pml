<?xml version="1.0" encoding="UTF-8" ?>
<Package name="cloudroboticsapi_handson02" format_version="4">
    <Manifest src="manifest.xml" />
    <BehaviorDescriptions>
        <BehaviorDescription name="behavior" src="hanson2_1" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="hanson2_1_ans" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="hanson2_2" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="hanson2_2_ans" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="hanson2_3" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="hanson2_3_ans" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="sample1" xar="behavior.xar" />
        <BehaviorDescription name="behavior" src="sample2" xar="behavior.xar" />
    </BehaviorDescriptions>
    <Dialogs>
        <Dialog name="FreeTalkDialog" src="FreeTalkDialog/FreeTalkDialog.dlg" />
    </Dialogs>
    <Resources>
        <File name="__init__" src="lib/cloudrobotics/__init__.py" />
        <File name="client" src="lib/cloudrobotics/client.py" />
        <File name="message" src="lib/cloudrobotics/message.py" />
        <File name="storage" src="lib/cloudrobotics/storage.py" />
        <File name="ca" src="lib/cloudrobotics/cert/ca.cer" />
        <File name="__init__" src="lib/paho/__init__.py" />
        <File name="__init__" src="lib/paho/mqtt/__init__.py" />
        <File name="client" src="lib/paho/mqtt/client.py" />
        <File name="publish" src="lib/paho/mqtt/publish.py" />
        <File name="subscribe" src="lib/paho/mqtt/subscribe.py" />
        <File name="__init__" src="lib/cloudrobotics/translator/__init__.py" />
        <File name="client" src="lib/cloudrobotics/translator/client.py" />
        <File name="message" src="lib/cloudrobotics/translator/message.py" />
        <File name="__init__" src="lib/cloudrobotics/conversation/__init__.py" />
        <File name="client" src="lib/cloudrobotics/conversation/client.py" />
        <File name="message" src="lib/cloudrobotics/conversation/message.py" />
    </Resources>
    <Topics>
        <Topic name="FreeTalkDialog_enu" src="FreeTalkDialog/FreeTalkDialog_enu.top" topicName="FreeTalkDialog" language="en_US" />
        <Topic name="FreeTalkDialog_jpj" src="FreeTalkDialog/FreeTalkDialog_jpj.top" topicName="FreeTalkDialog" language="ja_JP" />
    </Topics>
    <IgnoredPaths />
    <Translations auto-fill="en_US">
        <Translation name="translation_en_US" src="translations/translation_en_US.ts" language="en_US" />
        <Translation name="translation_ja_JP" src="translations/translation_ja_JP.ts" language="ja_JP" />
    </Translations>
</Package>
