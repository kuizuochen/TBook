Imports System.ComponentModel

Public Class clsBook
    Implements INotifyPropertyChanged

#Region "Variables"
    Public _pName As String
    Public _pDesctiptionList As List(Of clsDescription)
    Public _pStyleList As List(Of clsPushPinStyle)
    Public _pLayerList As List(Of clsLayer) 
#End Region

#Region "WPF Properties"
     
#End Region

    Public Sub New()

    End Sub

    Public Sub New(tName As String, tDescription As String, tStyleReaderList As List(Of XmlReader), tLayerReader As List(Of XmlReader), tPlaceReaderList As List(Of XmlReader))
        _pDesctiptionList = New List(Of clsDescription)
        _pStyleList = New List(Of clsPushPinStyle)
        _pLayerList = New List(Of clsLayer)

        Dim _tempPlaceList As New List(Of clsPlace)

        _pName = tName
        _pDesctiptionList.Add(New clsDescription(tDescription))
        'For i As Integer = 0 To tStyleReaderList.Count - 1
        '    _pStyleList.Add(New clsPushPinStyle(tStyleReaderList.Item(i)))
        'Next

        If tLayerReader.Count = 0 Then
            ''舊版
            For i As Integer = 0 To tPlaceReaderList.Count - 1
                _tempPlaceList.Add(New clsPlace(tPlaceReaderList.Item(i)))
            Next

            _pLayerList.Add(New clsLayer("$default", _tempPlaceList))
        Else
            ''新版
            For i As Integer = 0 To tLayerReader.Count - 1
                _tempPlaceList.Add(New clsPlace(tLayerReader.Item(i)))
            Next
        End If
      
    End Sub
 

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
