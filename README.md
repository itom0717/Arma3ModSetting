Arma3 Mod Setting Tool
====

This program sets the options file for each mod of Arma3.  
このプログラムは Arma3 の各 modのオプションファイルを設定します。  


## 開発環境
 Microsoft Visual Studio Community 2015

## 必要ランタイム
 .NET Framework 4.5  

## 使い方

① Arma3ModSetting.setting をUTF-8対応テキストエディタで編集する。  
　　編集内容はArma3ModSetting.setting内に記載

② @ace3などが存在するmodフォルダと同じところに @mod_settingフォルダ(フォルダ名は任意)を置いてArma3ModSetting.exe を実行  
  

***
MODフォルダ  
　　+-- @ace3  
　　　　+-- addons  
　　　　+-- optionals  
　　+-- @sma  
　　　　+-- addons  
　　　　+-- optional  
　　+-- @mod_setting(フォルダ名は任意)  
　　　　+-- Arma3ModSetting.exe       <---- このファイルを実行  
　　　　+-- Arma3ModSetting.setting   <---- 設定ファイル  
***

##リセット機能
リセット機能は、Optionフォルダに存在する*.pboをaddonsフォルダから削除します。



## Licence
* MIT  
    * see LICENSE.txt

## Author

[itom0717](https://github.com/itom0717)
