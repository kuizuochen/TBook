﻿#ExternalChecksum("C:\Users\kenny_000\Documents\GitHub\TravelBook\TravelBook\MainPage.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","2A9DDD625757CBF7D678540F6BEC920C")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34014
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Maps.Controls
Imports Microsoft.Phone.Maps.Toolkit
Imports Microsoft.Phone.Shell
Imports System
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Automation.Peers
Imports System.Windows.Automation.Provider
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Interop
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Resources
Imports System.Windows.Shapes
Imports System.Windows.Threading



<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class MainPage
    Inherits Microsoft.Phone.Controls.PhoneApplicationPage
    
    Friend WithEvents abtnDoTest As Microsoft.Phone.Shell.ApplicationBarIconButton
    
    Friend WithEvents abtnDoTest2 As Microsoft.Phone.Shell.ApplicationBarIconButton
    
    Friend WithEvents LayoutRoot As System.Windows.Controls.Grid
    
    Friend WithEvents ContentPanel As System.Windows.Controls.Grid
    
    Friend WithEvents mapMain As Microsoft.Phone.Maps.Controls.Map
    
    Friend WithEvents UserLocationMarker As Microsoft.Phone.Maps.Toolkit.UserLocationMarker
    
    Friend WithEvents MyPushpin As Microsoft.Phone.Maps.Toolkit.Pushpin
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub InitializeComponent()
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        System.Windows.Application.LoadComponent(Me, New System.Uri("/TravelBook;component/MainPage.xaml", System.UriKind.Relative))
        Me.abtnDoTest = CType(Me.FindName("abtnDoTest"),Microsoft.Phone.Shell.ApplicationBarIconButton)
        Me.abtnDoTest2 = CType(Me.FindName("abtnDoTest2"),Microsoft.Phone.Shell.ApplicationBarIconButton)
        Me.LayoutRoot = CType(Me.FindName("LayoutRoot"),System.Windows.Controls.Grid)
        Me.ContentPanel = CType(Me.FindName("ContentPanel"),System.Windows.Controls.Grid)
        Me.mapMain = CType(Me.FindName("mapMain"),Microsoft.Phone.Maps.Controls.Map)
        Me.UserLocationMarker = CType(Me.FindName("UserLocationMarker"),Microsoft.Phone.Maps.Toolkit.UserLocationMarker)
        Me.MyPushpin = CType(Me.FindName("MyPushpin"),Microsoft.Phone.Maps.Toolkit.Pushpin)
    End Sub
End Class

