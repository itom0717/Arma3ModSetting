Arma3 Mod Setting Tool
====

This program sets the options file for each mod of Arma3.  
このプログラムは Arma3 の各 modのオプションファイルを設定します。  

※後継ソフトは Arma3ModOptionMover ですので、こちらをご利用ください。  

## 開発環境
 Microsoft Visual Studio Community 2015

## 必要ランタイム
 .NET Framework 4.5  

## 使い方

① 設定ファイル（ファイル名は任意）をUTF-8対応テキストエディタで作成する。  
   編集内容はDefaultSetting.cfgを参考に新規作成する  

② ①で作成した設定ファイルをWebサーバーへアップする。  
   アップしたURLをブラウザのアドレス欄に入力して表示またはダウンロードできることを確認する。

③ ServerList.cfg の編集する。
　これはサーバ側で管理してますので、連絡をいただいたあとに編集をします。  
　または、ServerList.cfgを自分でアップし、ServerListUrl.cfgを編集しても可能です。 

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
　　　　+-- ServerList.cfg            <---- サーバー設定ファイル  
　　　　+-- ServerSetting.cfg         <---- 自動でダウンロードされます  
***

##リセット機能
リセット機能は、ありませんので もとに戻す場合は、Play withSixにて Diagnose してください。

## Licence
* MIT  
    * see LICENSE.txt

## Author

[itom0717](https://github.com/itom0717)
