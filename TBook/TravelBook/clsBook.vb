Imports System.ComponentModel

Public Class clsBook
    Implements INotifyPropertyChanged

#Region "Variables"
    Private mName As String
    Private mDesctiptionList As List(Of clsDescription)
    Private mStyleList As List(Of clsPushPinStyle)
    Private mLayerList As List(Of clsLayer)
    '   Private mPlaceList As List(Of clsPlace)
#End Region

#Region "WPF Properties"
    Public Property _pName As String
        Get
            Return mName
        End Get
        Set(value As String)
            mName = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("_pName"))
        End Set
    End Property

#End Region

    Public Sub New(tName As String, tDescription As String, tStyleReaderList As List(Of XmlReader), tLayerReader As List(Of XmlReader), tPlaceReaderList As List(Of XmlReader))
        mDesctiptionList = New List(Of clsDescription)
        mStyleList = New List(Of clsPushPinStyle)
        mLayerList = New List(Of clsLayer)

        Dim _tempPlaceList As New List(Of clsPlace)

        mName = tName
        mDesctiptionList.Add(New clsDescription(tDescription))
        For i As Integer = 0 To tStyleReaderList.Count - 1
            mStyleList.Add(New clsPushPinStyle(tStyleReaderList.Item(i)))
        Next

        If tLayerReader.Count = 0 Then
            ''舊版
            For i As Integer = 0 To tPlaceReaderList.Count - 1
                _tempPlaceList.Add(New clsPlace(tPlaceReaderList.Item(i)))
            Next

            mLayerList.Add(New clsLayer("$default", _tempPlaceList))
        Else
            ''新版
            For i As Integer = 0 To tLayerReader.Count - 1
                _tempPlaceList.Add(New clsPlace(tLayerReader.Item(i)))
            Next
        End If
      
    End Sub
 

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
