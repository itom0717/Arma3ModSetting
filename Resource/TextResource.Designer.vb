﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'このクラスは StronglyTypedResourceBuilder クラスが ResGen
    'または Visual Studio のようなツールを使用して自動生成されました。
    'メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    'ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    '''<summary>
    '''  ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class TextResource
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Arma3ModSetting.TextResource", GetType(TextResource).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        '''  現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  ADD に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property AddText() As String
            Get
                Return ResourceManager.GetString("AddText", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Close に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property CloseButton() As String
            Get
                Return ResourceManager.GetString("CloseButton", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Go ? に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ConfirmationMessageGo() As String
            Get
                Return ResourceManager.GetString("ConfirmationMessageGo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Do you back to the original settings? に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ConfirmationMessageReset() As String
            Get
                Return ResourceManager.GetString("ConfirmationMessageReset", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Create desktop shortcuts. に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property CreateShortCutCheckBox() As String
            Get
                Return ResourceManager.GetString("CreateShortCutCheckBox", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  DEL に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property DelText() As String
            Get
                Return ResourceManager.GetString("DelText", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Addons folder can not be found. ({0}) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ErrMsgNotFoundModAddonsPath() As String
            Get
                Return ResourceManager.GetString("ErrMsgNotFoundModAddonsPath", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  {1} folder can not be found. ({0}) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ErrMsgNotFoundModOptionalsPath() As String
            Get
                Return ResourceManager.GetString("ErrMsgNotFoundModOptionalsPath", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  MOD Path not found. ({0}) に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ErrMsgNotFoundModPath() As String
            Get
                Return ResourceManager.GetString("ErrMsgNotFoundModPath", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Setting files not found. に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ErrMsgSettingFilesNotFound() As String
            Get
                Return ResourceManager.GetString("ErrMsgSettingFilesNotFound", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Update Info に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property GetModInfoButton() As String
            Get
                Return ResourceManager.GetString("GetModInfoButton", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  ADD： に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property LogTextAddFile() As String
            Get
                Return ResourceManager.GetString("LogTextAddFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Create ShortCut に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property LogTextCreateShortCut() As String
            Get
                Return ResourceManager.GetString("LogTextCreateShortCut", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  DISABLE： に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property LogTextDelFile() As String
            Get
                Return ResourceManager.GetString("LogTextDelFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Finish Process に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property LogTextFinish() As String
            Get
                Return ResourceManager.GetString("LogTextFinish", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Reset： に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property LogTextResetFile() As String
            Get
                Return ResourceManager.GetString("LogTextResetFile", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Start Process に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property LogTextStart() As String
            Get
                Return ResourceManager.GetString("LogTextStart", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Go に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property OKButton() As String
            Get
                Return ResourceManager.GetString("OKButton", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Reset に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend Shared ReadOnly Property ResetButton() As String
            Get
                Return ResourceManager.GetString("ResetButton", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
